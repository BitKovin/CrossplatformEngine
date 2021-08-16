using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Engine.Network
{
    public class GameClient
    {
        public UDP udp;

        public TcpClient tcpClient;
        public static GameClient instance;
        private NetworkStream stream;
        private Packet receivedData;
        private byte[] receiveBuffer;

        private delegate void PacketHandler(Packet _packet);
        private static Dictionary<int, PacketHandler> packetHandlers;

        public static int dataBufferSize = 4096;

        string ip;
        int port;

        public int id;
        public GameClient()
        {
            tcpClient = new TcpClient();

        }

        public bool Connect(String ip, int port = 7777)
        {
            this.ip = ip;
            this.port = port;

            InitializeClientData();
            receiveBuffer = new byte[dataBufferSize];



            tcpClient.BeginConnect(ip, port,ConnectCallback,tcpClient);

            instance = this;
            udp = new UDP();
            return true;
        }

        private void ConnectCallback(IAsyncResult _result)
        {
            tcpClient.EndConnect(_result);

            if (!tcpClient.Connected)
            {
                return;
            }

            stream = tcpClient.GetStream();

            receivedData = new Packet();

            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    // TODO: disconnect
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(receiveBuffer, _data, _byteLength);

                receivedData.Reset(HandleData(_data));
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }
            catch
            {
                // TODO: disconnect
            }
        }

        private bool HandleData(byte[] _data)
        {
            int _packetLength = 0;

            receivedData.SetBytes(_data);

            if (receivedData.UnreadLength() >= 4)
            {
                _packetLength = receivedData.ReadInt();
                if (_packetLength <= 0)
                {
                    return true;
                }
            }

            while (_packetLength > 0 && _packetLength <= receivedData.UnreadLength())
            {
                byte[] _packetBytes = receivedData.ReadBytes(_packetLength);
                Console.WriteLine(_packetLength);
                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        try
                        {
                            int _packetId = _packet.ReadInt();
                            packetHandlers[_packetId](_packet);
                        }catch(SystemException ex) { Console.WriteLine(ex); }
                    }
                });

                _packetLength = 0;
                if (receivedData.UnreadLength() >= 4)
                {
                    _packetLength = receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        return true;
                    }
                }
            }

            if (_packetLength <= 1)
            {
                return true;
            }

            return false;
        }


        public class UDP
        {
            public UdpClient socket;
            public IPEndPoint endPoint;

            public UDP()
            {
                endPoint = new IPEndPoint(IPAddress.Parse(instance.ip), instance.port);
            }

            /// <summary>Attempts to connect to the server via UDP.</summary>
            /// <param name="_localPort">The port number to bind the UDP socket to.</param>
            public void Connect(int _localPort)
            {
                socket = new UdpClient(_localPort);

                socket.Connect(endPoint);
                socket.BeginReceive(ReceiveCallback, null);

                using (Packet _packet = new Packet())
                {
                    SendData(_packet);
                }
            }

            /// <summary>Sends data to the client via UDP.</summary>
            /// <param name="_packet">The packet to send.</param>
            public void SendData(Packet _packet)
            {
                try
                {
                    _packet.InsertInt(instance.id); // Insert the client's ID at the start of the packet
                    if (socket != null)
                    {
                        socket.BeginSend(_packet.ToArray(), _packet.Length(), null, null);
                    }
                }
                catch (Exception _ex)
                {
                    Console.WriteLine($"Error sending data to server via UDP: {_ex}");
                }
            }

            /// <summary>Receives incoming UDP data.</summary>
            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    byte[] _data = socket.EndReceive(_result, ref endPoint);
                    socket.BeginReceive(ReceiveCallback, null);

                    if (_data.Length < 4)
                    {
                        //instance.Disconnect();
                        return;
                    }

                    HandleData(_data);
                }
                catch
                {
                    Disconnect();
                }
            }

            /// <summary>Prepares received data to be used by the appropriate packet handler methods.</summary>
            /// <param name="_data">The recieved data.</param>
            private void HandleData(byte[] _data)
            {
                using (Packet _packet = new Packet(_data))
                {
                    int _packetLength = _packet.ReadInt();
                    _data = _packet.ReadBytes(_packetLength);
                }

                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_data))
                    {
                        int _packetId = _packet.ReadInt();
                        packetHandlers[_packetId](_packet); // Call appropriate method to handle the packet
                    }
                });
            }

            /// <summary>Disconnects from the server and cleans up the UDP connection.</summary>
            private void Disconnect()
            {
                //instance.Disconnect();

                endPoint = null;
                socket = null;
            }
        }

        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>()
        {
            { (int)ServerPackets.welcome, ClientHandle.Welcome },
            { (int)ServerPackets.SetPlayerPos, ClientHandle.SetPlayerPos }
        };
            Console.WriteLine("Initialized packets.");
        }

        public void SendTCPData(Packet packet)
        {
            packet.WriteLength();
            tcpClient.GetStream().BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
        }

    }

}


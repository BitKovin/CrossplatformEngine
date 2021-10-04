using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Engine.Network
{
    public class Client
    {
        public TcpClient tcpClient;

        public UDP udp;

        private NetworkStream TcpStream;
        private Packet TcpReceivedData;
        private byte[] TcpReceiveBuffer;
        private int id;

        public static int dataBufferSize = 4096;

        public Client(TcpClient Client, int _id)
        {
            id = _id;

            tcpClient = Client;
            TcpStream = tcpClient.GetStream();

            tcpClient.ReceiveBufferSize = dataBufferSize;
            tcpClient.SendBufferSize = dataBufferSize;

            TcpReceivedData = new Packet();
            TcpReceiveBuffer = new byte[dataBufferSize];

            TcpStream.BeginRead(TcpReceiveBuffer, 0, dataBufferSize, ReceiveCallback, null);

            udp = new UDP(_id);

            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write("Hi");
                _packet.Write(id);
                SendTCP(_packet);
            }
        }

        public void Update()
        {

        }

        private void ReceiveCallback(IAsyncResult _result)
        {
            try
            {
                int _byteLength = TcpStream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    Disconnect();
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(TcpReceiveBuffer, _data, _byteLength);

                TcpReceivedData.Reset(HandleData(_data));
                TcpStream.BeginRead(TcpReceiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }
            catch (Exception _ex)
            {
                Console.WriteLine($"Error receiving TCP data: {_ex}");
                Disconnect();
                Server.instance.StartUDP();
            }
        }

        private bool HandleData(byte[] _data)
        {
            int _packetLength = 0;

            TcpReceivedData.SetBytes(_data);

            if (TcpReceivedData.UnreadLength() >= 4)
            {
                _packetLength = TcpReceivedData.ReadInt();
                if (_packetLength <= 0)
                {
                    return true;
                }
            }

            while (_packetLength > 0 && _packetLength <= TcpReceivedData.UnreadLength())
            {
                byte[] _packetBytes = TcpReceivedData.ReadBytes(_packetLength);
                ThreadManagerServer.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        Server.packetHandlers[_packetId](id, _packet);

                        _packet.Length();

                    }
                });

                _packetLength = 0;
                if (TcpReceivedData.UnreadLength() >= 4)
                {
                    _packetLength = TcpReceivedData.ReadInt();
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

        public void SendTCP(Packet packet, bool wr = true)
        {
            if(wr)
                packet.WriteLength();
            tcpClient.GetStream().BeginWrite(packet.ToArray(),0,packet.Length(),null,null);
        }

        public class UDP
        {
            public IPEndPoint endPoint;

            private int id;

            public UDP(int _id)
            {
                id = _id;
            }

            /// <summary>Initializes the newly connected client's UDP-related info.</summary>
            /// <param name="_endPoint">The IPEndPoint instance of the newly connected client.</param>
            public void Connect(IPEndPoint _endPoint)
            {
                endPoint = _endPoint;
            }

            /// <summary>Sends data to the client via UDP.</summary>
            /// <param name="_packet">The packet to send.</param>
            public void SendData(Packet _packet)
            {
                Server.instance.SendUDPData(endPoint, _packet);
            }

            /// <summary>Prepares received data to be used by the appropriate packet handler methods.</summary>
            /// <param name="_packetData">The packet containing the recieved data.</param>
            public void HandleData(Packet _packetData)
            {
                int _packetLength = _packetData.ReadInt();
                byte[] _packetBytes = _packetData.ReadBytes(_packetLength);

                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        Server.packetHandlers[_packetId](id, _packet); // Call appropriate method to handle the packet
                    }
                });
            }
        }

            void Disconnect()
        {
            Server.instance.clients[id]=null;
            //tcpClient.Close();
            //TcpStream = null;
            //TcpReceivedData = null;
            //TcpReceiveBuffer = null;
            //tcpClient = null;
            //udp.endPoint = null;
            Console.WriteLine($"Client {id.ToString()} disconnected");
        }

    }
}

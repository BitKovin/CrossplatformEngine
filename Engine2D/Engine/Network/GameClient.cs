using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Engine.Network
{
    public class GameClient
    {
        public TcpClient tcpClient;
        public static GameClient instance;
        private NetworkStream stream;
        private Packet receivedData;
        private byte[] receiveBuffer;

        private delegate void PacketHandler(Packet _packet);
        private static Dictionary<int, PacketHandler> packetHandlers;

        public static int dataBufferSize = 4096;

        public GameClient()
        {
            tcpClient = new TcpClient();
        }

        public bool Connect(String ip, int port = 7777)
        {
            InitializeClientData();
            receiveBuffer = new byte[dataBufferSize];

            tcpClient.BeginConnect(ip, port,ConnectCallback,tcpClient);

            instance = this;

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

        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>()
        {
            { (int)ServerPackets.welcome, ClientHandle.Welcome }
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


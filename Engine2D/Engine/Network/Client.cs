using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Engine.Network
{
    public class Client
    {
        public TcpClient tcpClient;

        private NetworkStream stream;
        private Packet receivedData;
        private byte[] receiveBuffer;
        private int id;

        public static int dataBufferSize = 4096;

        public Client(TcpClient Client, int _id)
        {
            id = _id;

            tcpClient = Client;
            stream = tcpClient.GetStream();

            tcpClient.ReceiveBufferSize = dataBufferSize;
            tcpClient.SendBufferSize = dataBufferSize;

            receivedData = new Packet();
            receiveBuffer = new byte[dataBufferSize];

            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);

            Thread.Sleep(100);
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
            catch (Exception _ex)
            {
                Console.WriteLine($"Error receiving TCP data: {_ex}");
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
                ThreadManagerServer.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        Server.packetHandlers[_packetId](id, _packet);
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

        public void SendTCP(Packet packet, bool wr = true)
        {
            if(wr)
                packet.WriteLength();
            tcpClient.GetStream().BeginWrite(packet.ToArray(),0,packet.Length(),null,null);
        }

    }
}

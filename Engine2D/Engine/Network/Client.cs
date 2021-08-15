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

        public Client(TcpClient Client)
        {
            tcpClient = Client;

            Thread.Sleep(100);
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write("Hi");
                SendTCP(_packet);
            }
        }

        public void Update()
        {

        }

        public void SendTCP(Packet packet)
        {
            packet.WriteLength();
            tcpClient.GetStream().BeginWrite(packet.ToArray(),0,packet.Length(),null,null);
        }

    }
}

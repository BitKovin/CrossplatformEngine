using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    class ClientHandle
    {
        public static void Welcome(Packet packet)
        {
            Console.WriteLine(packet.ReadString());

            Packet packetResp = new Packet((int)ClientPackets.welcomeReceived);
            packetResp.Write("Hi from client");
            GameClient.instance.SendTCPData(packetResp);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    class ServerHandle
    {
        public static void WelcomeReceived(int playerId, Packet packet)
        {
            Console.WriteLine(packet.ReadString());
        }
    }
}

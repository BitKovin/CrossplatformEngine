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
        }
    }
}

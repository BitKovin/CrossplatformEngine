using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    class ServerSend
    {
        public static void SetPlayerPos(Vector2 pos, int id)
        {
            Packet packet = new Packet((int)ServerPackets.SetPlayerPos);
            packet.Write(id);
            packet.Write(pos.X);
            packet.Write(pos.Y);
            SendUDPDataToAll(packet);
        }

        static void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();
            foreach (Client client in Server.instance.clients)
            {
                client.SendTCP(packet,false);
                
            }
        }

        static void SendUDPDataToAll(Packet packet)
        {
            packet.WriteLength();
            foreach (Client client in Server.instance.clients)
            {
                client.udp.SendData(packet);

            }
        }

    }
}

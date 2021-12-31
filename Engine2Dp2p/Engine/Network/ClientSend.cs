using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Engine.Network
{
    public class ClientSend
    {
        public static void SetPlayerPos(Vector2 pos)
        {
            Packet packet = new Packet((int)ClientPackets.SetPlayerPos);
            packet.Write(pos.X);
            packet.Write(pos.Y);
            packet.WriteLength();
            GameClient.instance.udp.SendData(packet);
        }

        public static void SendP2PPacket(string name, Packet _packet)
        {
            Console.WriteLine("sended");
            Packet packet = new Packet((int)ServerPackets.SendP2PPacket);
            packet.Write(name);
            packet.Write(packet.buffer.ToArray());
            packet.WriteLength();
            //GameClient.instance.SendTCPData(packet);
            SendUDPDataToAll(packet);
            
        }

        public static void RequestClientsUDP()
        {
            Packet packet = new Packet((int)ClientPackets.RequestClientsUDP);
            packet.WriteLength();
            GameClient.instance.SendTCPData(packet);
        }


        public static void SendUDPDataToAll(Packet packet)
        {
            GameClient client = GameClient.instance;

            foreach ( IPEndPoint endPoint in client.sessionConnections)
            {
                GameClient.instance.udp.SendUDPData(endPoint, packet);
                Console.WriteLine(endPoint.ToString());
            }

        }

    }
}

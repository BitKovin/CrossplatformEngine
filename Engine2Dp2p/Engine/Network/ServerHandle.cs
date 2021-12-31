using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    class ServerHandle
    {
        public static void WelcomeReceived(int playerId, Packet packet, Session session)
        {
            //Console.WriteLine(playerId);
            ServerSend.SetPlayerPosTCP(new Microsoft.Xna.Framework.Vector2(0, 0), playerId);
            packet.ReadString();
            Server.instance.clients[playerId].port = packet.ReadInt();
        }
        public static void SetPlayerPos(int playerId, Packet packet, Session session)
        {
            float X = packet.ReadFloat();
            float Y = packet.ReadFloat();
            ServerSend.SetPlayerPos(new Microsoft.Xna.Framework.Vector2(X, Y), playerId);
        }

        public static void ReceiveP2PPacket(int playerId, Packet packet, Session session)
        {
            ServerSend.SendP2PPacket(packet,session);
        }

        public static void RequestClientsUDP(int playerId, Packet packet, Session session)
        {
            ServerSend.ReturnClientsUDP(playerId);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    class ServerHandle
    {
        public static void WelcomeReceived(int playerId, Packet packet)
        {
            Console.WriteLine(playerId);
            ServerSend.SetPlayerPos(new Microsoft.Xna.Framework.Vector2(0, 0), playerId);
        }
        public static void SetPlayerPos(int playerId, Packet packet)
        {
            float X = packet.ReadFloat();
            float Y = packet.ReadFloat();
            ServerSend.SetPlayerPos(new Microsoft.Xna.Framework.Vector2(X, Y), playerId);
        }
    }
}

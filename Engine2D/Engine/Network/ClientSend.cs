using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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


    }
}

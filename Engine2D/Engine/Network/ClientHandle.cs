using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Engine.Entities;

namespace Engine.Network
{
    class ClientHandle
    {
        public static void Welcome(Packet packet)
        {
            Console.WriteLine(packet.ReadString());
            GameClient.instance.id = packet.ReadInt();

            Packet packetResp = new Packet((int)ClientPackets.welcomeReceived);
            packetResp.Write("Hi from client");
            GameClient.instance.SendTCPData(packetResp);
            GameClient.instance.udp.Connect(((IPEndPoint)GameClient.instance.tcpClient.Client.LocalEndPoint).Port);

        }
        public static void SetPlayerPos(Packet packet)
        {
            int id = packet.ReadInt();
            float X = packet.ReadFloat();
            float Y = packet.ReadFloat();
            if(GameMain.inst.curentLevel.players[id]==null)
            {
                Player player = GameMain.inst.curentLevel.players[id] = new Player(id);
                GameMain.inst.curentLevel.players[id].id = id;
                GameMain.inst.curentLevel.entities.Add(player);
            }

            GameMain.inst.curentLevel.players[id].Position = new Microsoft.Xna.Framework.Vector2(X, Y);

        }
    }
}

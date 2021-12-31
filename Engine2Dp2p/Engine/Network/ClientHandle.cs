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
            packetResp.Write(((IPEndPoint)GameClient.instance.tcpClient.Client.LocalEndPoint).Port);
            GameClient.instance.SendTCPData(packetResp);
            GameClient.instance.udp.Connect(((IPEndPoint)GameClient.instance.tcpClient.Client.LocalEndPoint).Port);

        }

        public static void ReturnClientsUDP(Packet packet) 
        {
            List<IPEndPoint> list = new List<IPEndPoint>();

            int length = packet.ReadInt();

            long ip;
            int port = 0;

            for (int i = 0; i < length; i++)
            {
                ip = packet.ReadLong();
                port = packet.ReadInt();
                //Console.WriteLine(port);
                list.Add(new IPEndPoint(ip, port));
            }
            

            GameClient.instance.UpdateUDPConnections(list);

        }

        public static void ReceiveP2PPPacket(Packet packet)
        {
            string name = packet.ReadString();
            switch (name) {
                case "PlayerPos":
                    SetPlayerPos(packet);
                    break;

            }

        }

        public static void SetPlayerPos(Packet packet)
        {
            packet.ReadInt();
            int id = packet.ReadInt();
            float X = packet.ReadFloat();
            float Y = packet.ReadFloat();

            Console.WriteLine(id);

            if (GameMain.inst.curentLevel.players[id]==null)
            {
                Player player = GameMain.inst.curentLevel.players[id] = new Player(id);
                GameMain.inst.curentLevel.players[id].id = id;
                GameMain.inst.curentLevel.entities.Add(player);
            }

            GameMain.inst.curentLevel.players[id].Position = new Microsoft.Xna.Framework.Vector2(X, Y);

        }
    }
}

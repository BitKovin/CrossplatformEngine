using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    class ServerSend
    {

        public static void ReturnClientsUDP(int client)
        {

            Packet packet = new Packet((int)ServerPackets.ReturnClientsUDP);

            Client requestedClient = Server.instance.clients[client];

            List<Client> clients = requestedClient.session.clients;

            int length = clients.Count;

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].udp.endPoint == null)
                    length--;
            }

            packet.Write(length);

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].udp.endPoint == null) continue;
                packet.Write(clients[i].udp.endPoint.Address.Address);
                packet.Write(clients[i].port);
            }
            requestedClient.SendTCP(packet);

        }

        public static void SetPlayerPos(Vector2 pos, int id)
        {
            Packet packet = new Packet((int)ServerPackets.SetPlayerPos);
            packet.Write(id);
            packet.Write(id);
            packet.Write(pos.X);
            packet.Write(pos.Y);
            SendUDPDataToAll(packet);
        }

        public static void SendP2PPacket(Packet _packet, Session session)
        {
            Packet packet = new Packet((int)ServerPackets.SendP2PPacket);
            packet.buffer = _packet.buffer;
            SendTCPDataToAll(_packet,session);
            
        }

        public static void SetPlayerPosTCP(Vector2 pos, int id)
        {
            Packet packet = new Packet((int)ServerPackets.SetPlayerPos);
            packet.Write(id);
            packet.Write(id);
            packet.Write(pos.X);
            packet.Write(pos.Y);
            SendTCPDataToAll(packet);
        }

        static void SendTCPDataToAll(Packet packet, Session session = null, Client exept = null)
        {
            packet.WriteLength();

            if (session == null)
            {
                foreach (Client client in Server.instance.clients)
                {
                    if (client != null)
                        if (client != exept)
                            client.SendTCP(packet, false);

                }
            }
            else
            {
                foreach (Client client in session.clients)
                {
                    if (client != null)
                        if (client != exept)
                            client.SendTCP(packet, false);

                }
            }
        }

        static void SendUDPDataToAll(Packet packet, Client exept = null)
        {
            packet.WriteLength();
            foreach (Client client in Server.instance.clients)
            {
                if(client!=null)
                    if (client != exept)
                        client.udp.SendData(packet);
            }
        }

    }
}

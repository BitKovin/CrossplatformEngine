using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Engine.Network
{
    public class Server
    {
        Session session = new Session();

        Stopwatch sw = new Stopwatch();
        const int TPS = 60;
        int port;
        public static Server instance;

        int maxPlayers;

        TcpListener Listener; // Объект, принимающий TCP-клиентов
        private UdpClient udpListener;

        public Client[] clients;

        public delegate void PacketHandler(int _fromClient, Packet _packet, Session session);
        public static Dictionary<int, PacketHandler> packetHandlers;

        // Запуск сервера
        public Server(int Port = 7777, int MaxPlayers = 5)
        {
            port = Port;
            maxPlayers = MaxPlayers;
            if (instance == null)
                instance = this;

            clients = new Client[maxPlayers];

            // Создаем "слушателя" для указанного порта
            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); // Запускаем его

            udpListener = new UdpClient(Port);
            udpListener.BeginReceive(UDPReceiveCallback, null);

            new Thread(new ThreadStart(AcceptConnections)).Start();
            new Thread(new ThreadStart(BeginUpdateClients)).Start();
            InitializeServerData();

        }

        public void StartUDP()
        {
            udpListener.Close();
            udpListener = new UdpClient(port);
            udpListener.BeginReceive(UDPReceiveCallback, null);
        }

        int FindSlot()
        {
            for(int i = 0; i<clients.Length;i++)
            {
                if(clients[i]==null)
                {
                    return i;
                }else if(clients[i].tcpClient==null)
                {
                    clients[i] = null;
                    return i;
                }
            }
            return -1;
        }

        void AcceptConnections()
        {
            // В бесконечном цикле
            while (true)
            {
                int slot = FindSlot();
                // Принимаем новых клиентов
                clients[slot] = new Client(Listener.AcceptTcpClient(),slot);
                clients[slot].session = session;
                Console.WriteLine("connection accepted");
            }
        }

        private void UDPReceiveCallback(IAsyncResult _result)
        {
            try
            {
                IPEndPoint _clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] _data = udpListener.EndReceive(_result, ref _clientEndPoint);
                udpListener.BeginReceive(UDPReceiveCallback, null);

                if (_data.Length < 4)
                {
                    
                    return;
                    
                }


                using (Packet _packet = new Packet(_data))
                {
                    int _clientId = _packet.ReadInt();

                    if (_clientId == 0)
                    {
                        //return;
                    }

                    if (clients[_clientId].udp.endPoint == null)
                    {
                        // If this is a new connection
                        clients[_clientId].udp.Connect(_clientEndPoint);
                        return;
                    }

                    if (clients[_clientId].udp.endPoint.ToString() == _clientEndPoint.ToString())
                    {
                        // Ensures that the client is not being impersonated by another by sending a false clientID
                        clients[_clientId].udp.HandleData(_packet);
                    }
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine($"Error receiving UDP data: {_ex}");
            }
        }

        void BeginUpdateClients()
        {
            while (true)
            {
                sw.Restart();
                ThreadManagerServer.UpdateMain();
                Parallel.ForEach(clients,
                    client =>
                    {
                        if(client!=null)
                        client.Update();
                    });
                sw.Stop();
                float FrameTime = 1000 / TPS;
                Thread.Sleep(Math.Clamp((int)(FrameTime - (float)sw.ElapsedMilliseconds), 0, 10000));
            }
        }

        public void SendUDPData(IPEndPoint _clientEndPoint, Packet _packet)
        {
            try
            {
                if (_clientEndPoint != null)
                {
                    udpListener.BeginSend(_packet.ToArray(), _packet.Length(), _clientEndPoint, null, null);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine($"Error sending data to {_clientEndPoint} via UDP: {_ex}");
            }
        }

        void SendTCPPacketForAll(Packet packet)
        {
            foreach(Client client in clients)
            {
                if(client!=null)
                {
                    client.SendTCP(packet);
                }
            }
        }

        private static void InitializeServerData()
        {

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
                { (int)ClientPackets.SetPlayerPos, ServerHandle.SetPlayerPos },
                { (int)ClientPackets.SendP2PPacket, ServerHandle.ReceiveP2PPacket },
                { (int)ClientPackets.RequestClientsUDP, ServerHandle.ReceiveP2PPacket }
            };
            Console.WriteLine("Initialized packets.");
        }

        // Остановка сервера
        ~Server()
        {
            // Если "слушатель" был создан
            if (Listener != null)
            {
                // Остановим его
                Listener.Stop();
            }

        }
    }
}

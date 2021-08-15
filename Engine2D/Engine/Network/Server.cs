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
        Stopwatch sw = new Stopwatch();
        const int TPS = 10;

        TcpListener Listener; // Объект, принимающий TCP-клиентов

        List<Client> clients = new List<Client>();

        // Запуск сервера
        public Server(int Port = 7777)
        {
            // Создаем "слушателя" для указанного порта
            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); // Запускаем его

            new Thread(new ThreadStart(AcceptConnections)).Start();
            new Thread(new ThreadStart(BeginUpdateClients)).Start();
        }

        void AcceptConnections()
        {
            // В бесконечном цикле
            while (true)
            {
                // Принимаем новых клиентов
                clients.Add(new Client(Listener.AcceptTcpClient()));
                Console.WriteLine("connection accepted");
            }
        }

        void BeginUpdateClients()
        {
            while (true)
            {
                sw.Restart();
                Parallel.ForEach(clients,
                    client =>
                    {
                        if (!client.tcpClient.Connected)
                        {
                            clients.Remove(client);
                            Console.WriteLine("disconnected");
                        }
                        else
                        {
                            client.Update();
                        }

                    });
                sw.Stop();
                float FrameTime = 1000 / TPS;
                Thread.Sleep(Math.Clamp((int)(FrameTime - (float)sw.ElapsedMilliseconds), 0, 10000));
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Network
{
    public class Session
    {

        public List<Client> clients = new List<Client>();

        public bool TryAddClient(Client newClient)
        {
            
            for (int i = 0; i < clients.Count; i++) 
            {
                if (clients[i] == null)
                {
                    clients[i] = newClient;
                    return true;
                }
            }
            
            clients.Add(newClient);

            return true;
        }

    }
}

using RocloWebApp.Models.clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    interface IClient
    public interface IClient
    {

        public Task CreerClient(Client client);
        public Task SupprimerClient(string idClient);
        public Task ModifierClient(string idClient);
        public Task ModifierClient(Client client);
        public Task<List<Client>> AfficherClient();
    }
}

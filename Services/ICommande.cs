using RocloWebApp.Models.commande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface ICommande
    {
        public Task CreerCommande(Commande nouvelleCommande);
        public Task SupprimerCommande(String idCommande);
        public Task ModifierCommande(Commande commande);
        public Task ModifierCommande(String idCommande);
        public Task<List<Commande>> AfficherCommande();
    }
}

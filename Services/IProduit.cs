using RocloWebApp.Models.produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface IProduit
    {
        public Task CreerProduit(Produit nouveauProduit);
        public Task SupprimerProduit(string idProduit);
        public Task<List<Produit>> AfficherProduit();
    }
}

using RocloWebApp.Models.Collecteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface ICollecteur
    {
        public Task CreerCollecteur(Collecteur nouveauCollecteur);
        public Task SupprimerCollecteur(string idCollecteur);
        public Task ModifierCollecteur(Collecteur collecteur);
        public Task ModifierCollecteur(string idCollecteur);
        public Task<List<Collecteur>> AfficherCollecteur();
    }
}

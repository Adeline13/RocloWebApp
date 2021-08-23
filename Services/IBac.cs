using RocloWebApp.Models.bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface IBac
    {
        public Task CreerBac(Bac nouveauBac);
        public Task SupprimerBac(string idBac);
        public Task<List<Bac>> AfficherBac();
        public Task ModifierBac(Bac bac);
        public Task ModifierBac(string idBac);
    }
}

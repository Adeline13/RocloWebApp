using RocloWebApp.Models.typeRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    interface ITypeRelation
    {
        public Task CreerTypeRelation(TypeRelation nouveauTypeRelation);
        public Task SupprimerTypeRelation(string idTypeRelation);
        public Task<List<TypeRelation>> AfficherTypeRelation();
    }
}

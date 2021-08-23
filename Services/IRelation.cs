using RocloWebApp.Models.relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface IRelation
    {
        public Task CreerRelation(Relation nouvelleRelation);
        public Task<List<Relation>> AfficherRelation();
    }
}

using RocloWebApp.Models.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface IAdmin
    {

        public Task CreerAdmin(Admin nouvelAdmin);
        public Task SupprimerAdmin(string idAdmin);
        public Task ModifierAdmin(Admin admin);
        public Task ModifierAdmin(string idAdmin);
        public Task<List<Admin>> AfficherAdmin();
       // public Task RechercherAdmin();
    }
}

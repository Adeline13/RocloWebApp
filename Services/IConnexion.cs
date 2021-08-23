using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface IConnexion
    {
       public Task<Object[]> Connexion(string username, string password);
    }
}

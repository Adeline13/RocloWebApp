using RocloWebApp.Models.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public interface INotification
    {
        public Task CreerNotification(Notification nouvelleNotification);
        public Task SupprimerNotification(string idNotification);
        public Task ModifierNotification(string idNotification);
        public Task ModifierNotification(Notification notification);
        public Task<List<Notification>> AfficherNotification();
    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.notifications
{
    [FirestoreData]
    public class Notification
    {
        public string idNotification { get; set; }
        [FirestoreProperty]
        public string typeNotification { get; set; }
    }
}

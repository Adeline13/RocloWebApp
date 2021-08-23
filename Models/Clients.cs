using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.clients
{
    [FirestoreData]
    public class Clients
    {
        public int idClient { get; set; }
        [FirestoreProperty]
        public string nomClient { get; set; }
        [FirestoreProperty]
        public string emailClient { get; set; }
        [FirestoreProperty]
        public int telephoneClient { get; set; }
        [FirestoreProperty]
        public string quartierClient { get; set; }
        [FirestoreProperty]
        public string regionClient { get; set; }
        [FirestoreProperty]
        public string motDePasseClient { get; set; }
    }

    //*****************************************************************

}

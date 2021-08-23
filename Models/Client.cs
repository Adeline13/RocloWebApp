using Google.Cloud.Firestore;
using RocloWebApp.Models.bac;
using RocloWebApp.Models.Collecteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.clients
{
    [FirestoreData]
    public class Client
    {
        public string idClient { get; set; }
        [FirestoreProperty]
        public string nom { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public int telephone { get; set; }
        [FirestoreProperty]
        public string quartier { get; set; }
        [FirestoreProperty]
        public string region { get; set; }
        [FirestoreProperty]
        public string motDePasse { get; set; }
        public Collecteur collecteur { get; set; }
        public Bac bac { get; set; }
    }

    //*****************************************************************

}

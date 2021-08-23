using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.Collecteurs
{
    [FirestoreData]
    public class Collecteur
    {
        public string idCollecteur { get; set; }
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
    }
}

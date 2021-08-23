using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.collecteurs
{
    [FirestoreData]
    public class Collecteur
    {
        public int idCollecteur { get; set; }
        [FirestoreProperty]
        public string nomCollecteur { get; set; }
        [FirestoreProperty]
        public string emailCollecteur { get; set; }
        [FirestoreProperty]
        public int telephoneCollecteur { get; set; }
        [FirestoreProperty]
        public string quartierCollecteur { get; set; }
        [FirestoreProperty]
        public string regionCollecteur { get; set; }
        [FirestoreProperty]
        public string motDePasseCollecteur { get; set; }
    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.bac
{
    [FirestoreData]
    public class Bac
    {
        public string idBac { get; set; }
        [FirestoreProperty]
        public int longitude { get; set; }
        [FirestoreProperty]
        public int latitude { get; set; }
        [FirestoreProperty]
        public string quartier { get; set; }
        [FirestoreProperty]
        public string region { get; set; }
        [FirestoreProperty]
        public string Remplissage { get; set; }
    }
}

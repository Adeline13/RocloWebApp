using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.bacs
{
    [FirestoreData]
    public class Bac
    {
        public int idBac { get; set; }
        [FirestoreProperty]
        public int longitude { get; set; }
        [FirestoreProperty]
        public int latitude { get; set; }
        [FirestoreProperty]
        public string quartierBac { get; set; }
        [FirestoreProperty]
        public string regionBac { get; set; }
    }
}

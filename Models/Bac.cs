using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.bac
namespace RocloWebApp.Models.bacs
{
    [FirestoreData]
    public class Bac
    {
        public string idBac { get; set; }
        public int idBac { get; set; }
        [FirestoreProperty]
        public int longitude { get; set; }
        [FirestoreProperty]
        public int latitude { get; set; }
        [FirestoreProperty]
        public string quartierBac { get; set; }
        public string quartier { get; set; }
        [FirestoreProperty]
        public string region { get; set; }
        [FirestoreProperty]
        public string Remplissage { get; set; }
        public string regionBac { get; set; }
    }
}

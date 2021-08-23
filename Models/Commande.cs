using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.commande
{
    [FirestoreData]
    public class Commande
    {
        public DateTime dateCommande { get; set; }
        [FirestoreProperty]
        public int quantiteCommande { get; set; }
        [FirestoreProperty]
        public int montantTotal { get; set; }
    }
}

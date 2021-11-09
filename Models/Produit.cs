using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.produits
{
    [FirestoreData]
    public class Produit
    {
        public string typeProduit { get; set; }
        public string idProduit { get; set; }
        [FirestoreProperty]
        public string type { get; set; }
        [FirestoreProperty]
        public int prixUnitaire { get; set; }
    }
}

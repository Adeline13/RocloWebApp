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
        [FirestoreProperty]
        public int prixUnitaire { get; set; }
    }
}

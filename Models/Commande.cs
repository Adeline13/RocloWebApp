using Google.Cloud.Firestore;
using RocloWebApp.Models.clients;
using RocloWebApp.Models.produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.commande
{
    [FirestoreData]
    public class Commande
    {
        public string idCommande { get; set; }
        [FirestoreProperty]
        public DateTime date { get; set; }
        [FirestoreProperty]
        public int quantite { get; set; }
        [FirestoreProperty]
        public int montantTotal { get; set; }
        public Client client { get; set; }
        public Produit produit { get; set; }
    }
}

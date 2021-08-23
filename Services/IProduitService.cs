using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class IProduitService : IProduit
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public IProduitService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Produit>> AfficherProduit()
        {
            Query resourceQuery = _firestoreDb.Collection("Produit");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Produit> listProduit = new List<Produit>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> produit = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(produit);
                    Produit nouveauProduit = JsonConvert.DeserializeObject<Produit>(json);
                    nouveauProduit.idProduit = documentSnapshot.Id;
                    listProduit.Add(nouveauProduit);
                }

            }
            return listProduit;
        }

        public async Task CreerProduit(Produit nouveauProduit)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Produit");
            await collectionReference.AddAsync(nouveauProduit);
        }

        public async Task SupprimerProduit(string idProduit)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Produit").Document(idProduit);
            await documentReference.DeleteAsync();
        }
    }
}

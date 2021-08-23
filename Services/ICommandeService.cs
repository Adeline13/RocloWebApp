using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.commande;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class ICommandeService : ICommande
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public ICommandeService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Commande>> AfficherCommande()
        {
            Query resourceQuery = _firestoreDb.Collection("Commande");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Commande> listCommande = new List<Commande>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> commande = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(commande);
                    Commande nouvelleCommande = JsonConvert.DeserializeObject<Commande>(json);
                    nouvelleCommande.idCommande = documentSnapshot.Id;
                    listCommande.Add(nouvelleCommande);
                }

            }
            return listCommande;
        }

        public async Task CreerCommande(Commande nouvelleCommande)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Commande");
            await collectionReference.AddAsync(nouvelleCommande);
        }

        public async Task ModifierCommande(Commande commande)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Commande").Document(commande.idCommande);
            await documentReference.SetAsync(commande, SetOptions.Overwrite);
        }

        public async Task ModifierCommande(string idCommande)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Commande").Document(idCommande);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                Commande commande = documentSnapshot.ConvertTo<Commande>();
            }
        }

        public async Task SupprimerCommande(string idCommande)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Commande").Document(idCommande);
            await documentReference.DeleteAsync();
        }
    }
}

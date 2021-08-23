using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.Collecteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class ICollecteurService : ICollecteur
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public ICollecteurService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Collecteur>> AfficherCollecteur()
        {
            Query resourceQuery = _firestoreDb.Collection("Collecteur");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Collecteur> listCollecteur = new List<Collecteur>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> collecteur = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(collecteur);
                    Collecteur nouveauCollecteur = JsonConvert.DeserializeObject<Collecteur>(json);
                    nouveauCollecteur.idCollecteur = documentSnapshot.Id;
                    listCollecteur.Add(nouveauCollecteur);
                }

            }
            return listCollecteur;
        }

        public async Task CreerCollecteur(Collecteur nouveauCollecteur)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Collecteur");
            await collectionReference.AddAsync(nouveauCollecteur);
        }
        public async Task ModifierCollecteur(Collecteur collecteur)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Collecteur").Document(collecteur.idCollecteur);
            await documentReference.SetAsync(collecteur, SetOptions.Overwrite);
        }

        public async Task ModifierCollecteur(string idCollecteur)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Collecteur").Document(idCollecteur);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                Collecteur collecteur = documentSnapshot.ConvertTo<Collecteur>();
            }
        }

        public async Task SupprimerCollecteur(string idCollecteur)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Collecteur").Document(idCollecteur);
            await documentReference.DeleteAsync();
        }
    }
}

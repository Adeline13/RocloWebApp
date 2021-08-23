using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class IBacsService : IBac
    {
        /*----------------------connexion avec la base de données---------------------------------*/

        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public IBacsService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        /*----------------------- implementations methodes---------------------------------------*/
        public async Task<List<Bac>> AfficherBac()
        {
            Query resourceQuery = _firestoreDb.Collection("Bac");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Bac> listBac = new List<Bac>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> bac = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(bac);
                    Bac nouveauBac = JsonConvert.DeserializeObject<Bac>(json);
                    nouveauBac.idBac = documentSnapshot.Id;
                    listBac.Add(nouveauBac);
                }

            }
            return listBac;
        }

        public async Task CreerBac(Bac nouveauBac)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Bac");
            await collectionReference.AddAsync(nouveauBac);
        }

        public async Task ModifierBac(string idBac)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Bac").Document(idBac);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                Bac bac = documentSnapshot.ConvertTo<Bac>();

            }
        }
        public async Task ModifierBac(Bac bac)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Bac").Document(bac.idBac);
            await documentReference.SetAsync(bac, SetOptions.Overwrite);
        }


        public async Task SupprimerBac(string idBac)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Bac").Document(idBac);
            await documentReference.DeleteAsync();
        }
    }
}

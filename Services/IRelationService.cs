using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class IRelationService : IRelation
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public IRelationService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Relation>> AfficherRelation()
        {
            Query resourceQuery = _firestoreDb.Collection("Relation");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Relation> listRelation = new List<Relation>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> relation = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(relation);
                    Relation nouvelleRelation = JsonConvert.DeserializeObject<Relation>(json);
                    nouvelleRelation.idRelation = documentSnapshot.Id;
                    listRelation.Add(nouvelleRelation);
                }

            }
            return listRelation;
        }

        public async Task CreerRelation(Relation nouvelleRelation)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Relation");
            await collectionReference.AddAsync(nouvelleRelation);
        }
    }
}

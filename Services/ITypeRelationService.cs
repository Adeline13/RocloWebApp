using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.typeRelation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class ITypeRelationService : ITypeRelation
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public ITypeRelationService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<TypeRelation>> AfficherTypeRelation()
        {
            Query resourceQuery = _firestoreDb.Collection("TypeRelation");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<TypeRelation> listTypeRelation = new List<TypeRelation>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> typeRelation = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(typeRelation);
                    TypeRelation nouveauTypeRelation = JsonConvert.DeserializeObject<TypeRelation>(json);
                    nouveauTypeRelation.idType = documentSnapshot.Id;
                    listTypeRelation.Add(nouveauTypeRelation);
                }

            }
            return listTypeRelation;
        }

        public async Task CreerTypeRelation(TypeRelation nouveauTypeRelation)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("TypeRelation");
            await collectionReference.AddAsync(nouveauTypeRelation);
        }

        public async Task SupprimerTypeRelation(string idTypeRelation)
        {
            DocumentReference documentReference = _firestoreDb.Collection("TypeRelation").Document(idTypeRelation);
            await documentReference.DeleteAsync();
        }
    }
}

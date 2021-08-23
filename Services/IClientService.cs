using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class IClientService : IClient
    {
        /*----------------------connexion avec la base de données---------------------------------*/

        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public IClientService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        /*----------------------- implementations methodes---------------------------------------*/
        public async Task<List<Client>> AfficherClient()
        {
            Query resourceQuery = _firestoreDb.Collection("Client");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Client> listClient = new List<Client>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> client = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(client);
                    Client nouveauClient = JsonConvert.DeserializeObject<Client>(json);
                    nouveauClient.idClient = documentSnapshot.Id;
                    listClient.Add(nouveauClient);
                }

            }
            return listClient;
        }

        public async Task CreerClient(Client client)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Client");
            await collectionReference.AddAsync(client);
        }

        public async Task ModifierClient(Client client)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Client").Document(client.idClient);
            await documentReference.SetAsync(client, SetOptions.Overwrite);
        }

        public async Task ModifierClient(string idClient)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Client").Document(idClient);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                Client client = documentSnapshot.ConvertTo<Client>();

            }
        }

        public async Task SupprimerClient(string idClient)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Client").Document(idClient);
            await documentReference.DeleteAsync();
        }

    }
}

using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class INotificationService : INotification
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public INotificationService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Notification>> AfficherNotification()
        {
            Query resourceQuery = _firestoreDb.Collection("Notification");
            QuerySnapshot roleQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Notification> listNotification = new List<Notification>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> notification = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(notification);
                    Notification nouvelleNotification = JsonConvert.DeserializeObject<Notification>(json);
                    nouvelleNotification.idNotification = documentSnapshot.Id;
                    listNotification.Add(nouvelleNotification);
                }

            }
            return listNotification;
        }

        public async Task CreerNotification(Notification nouvelleNotification)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Notification");
            await collectionReference.AddAsync(nouvelleNotification);
        }

        public async Task ModifierNotification(Notification notification)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Notification").Document(notification.idNotification);
            await documentReference.SetAsync(notification, SetOptions.Overwrite);
        }

        public async Task ModifierNotification(string idNotification)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Notification").Document(idNotification);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                Notification notification = documentSnapshot.ConvertTo<Notification>();
            }
        }

        public async Task SupprimerNotification(string idNotification)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Notification").Document(idNotification);
            await documentReference.DeleteAsync();
        }
    }
}

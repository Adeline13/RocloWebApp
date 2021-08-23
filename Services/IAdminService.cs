using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RocloWebApp.Models.admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class IAdminService : IAdmin
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public IAdminService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task<List<Admin>> AfficherAdmin()
        {
            Query adminQuery = _firestoreDb.Collection("Admin");
            QuerySnapshot adminQuerySnapshot = await adminQuery.GetSnapshotAsync();
            List<Admin> listAdmin = new List<Admin>();

            foreach (DocumentSnapshot documentSnapshot in adminQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> admin = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(admin);
                    Admin nouvelAdmin = JsonConvert.DeserializeObject<Admin>(json);
                    nouvelAdmin.idAdmin = documentSnapshot.Id;
                    listAdmin.Add(nouvelAdmin);
                }

            }
            return listAdmin;
        }

        public async Task CreerAdmin(Admin nouvelAdmin)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Admin");
            await collectionReference.AddAsync(nouvelAdmin);
        }

        public async Task ModifierAdmin(string idAdmin)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Admin").Document(idAdmin);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
               Admin admin = documentSnapshot.ConvertTo<Admin>();
            }
        }

        public async Task ModifierAdmin(Admin admin)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Admin").Document(admin.idAdmin);
           await documentReference.SetAsync(admin, SetOptions.Overwrite);
        }

        public async Task SupprimerAdmin(string idAdmin)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Admin").Document(idAdmin);
            await documentReference.DeleteAsync();
        }
    }
}

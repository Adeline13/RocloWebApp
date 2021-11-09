using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers.DataAccess
{
    public class ConnexionBD
    {
        string projectId;
        FirestoreDb fireStoreDb;
        public ConnexionBD()
        {
            string filepath = "C:\\Users\\FabLab ODC\\source\repos\\RocloWebApp\\Controllers\\DataAccess\\rocloapplication-df6ffaa55554.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "FgJQPeY9g3IVxM7DUuZlg2QEAnexspHea6tOIuYQ";
            fireStoreDb = FirestoreDb.Create(projectId);
        }
    }
}

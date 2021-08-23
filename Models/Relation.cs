using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.relation
{
    [FirestoreData]
    public class Relation
    {
        public DateTime date { get; set; }
    }
}

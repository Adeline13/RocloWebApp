using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Models.typeRelation
{
    [FirestoreData]
    public class TypeRelation
    {
        public int idType { get; set; }
        [FirestoreProperty]
        public string type { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace RocloWebApp.Models.admin
{
    [FirestoreData]
    public class Admin
    {
        public int idAdmin { get; set; }
        [FirestoreProperty]
        public string motDePasseAdmin { get; set; }
    }
}

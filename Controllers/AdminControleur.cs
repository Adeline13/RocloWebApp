using FireSharp.Config;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.admin;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class AdminControleur : Controller
    {
        /*FirebaseConfig _firestoreDb = new FirebaseConfig
        {
            AuthSecret = "FgJQPeY9g3IVxM7DUuZlg2QEAnexspHea6tOIuYQ",
            BasePath = "https://rocloapplication-default-rtdb.firebaseio.com/"
        };*/
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly IAdmin _iadmin;

        public AdminControleur(IAdmin iadmin)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _iadmin = iadmin;
        }

        [HttpGet]
        public ActionResult Ajouter()
        {
            return View();
        }
       /* public ActionResult Ajouter()
        {
            return View();
        }
        
        public ActionResult Modifier()
        {
            return View();
        }
         ActionResult SupprimerAdmin()
        {
            return View();
        }*/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Admin> listAdmin = await _iadmin.AfficherAdmin();
            return View(listAdmin);
        }
        [HttpPost]
        public async Task<IActionResult> Ajouter(Admin admin)
        {
            await _iadmin.CreerAdmin(admin);
            return RedirectToAction(nameof(Index));
        }

        /**
                [HttpPost]
                public async Task<IActionResult> AfficherAdmin(Admin admin)
                {
                    DocumentReference documentReference = _firestoreDb.Collection("Admin").Document(admin.idAdmin);
                    await documentReference.SetAsync(admin, SetOptions.Overwrite);
                    return RedirectToAction(nameof(Index));
                }
        **/

        [HttpGet]
        public async Task<IActionResult> ModifierAdmin(string idAdmin)
        {
             await _iadmin.ModifierAdmin(idAdmin);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModifierAdmin(Admin admin)
        {
            await _iadmin.ModifierAdmin(admin);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerAdmin(string idAdmin)
        {
            await _iadmin.SupprimerAdmin(idAdmin);
            return RedirectToAction(nameof(Index));
        }
    }
}

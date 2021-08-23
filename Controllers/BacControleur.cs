using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.bac;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class BacControleur : Controller
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly IBac _ibac;

        public BacControleur(IBac ibac)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _ibac = ibac;
        }
        [HttpGet]
        public ActionResult CreerBac()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Bac> listBac = await _ibac.AfficherBac();
            return View(listBac);
        }
        [HttpPost]
        public async Task<IActionResult> CreerBac(Bac bac)
        {
            await _ibac.CreerBac(bac);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ModifierBac(string idBac)
        {
            await _ibac.ModifierBac(idBac);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ModifierBac(Bac bac)
        {
            await _ibac.ModifierBac(bac);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerBac(string idBac)
        {
            await _ibac.SupprimerBac(idBac);
            return RedirectToAction(nameof(Index));
        }
    }
}

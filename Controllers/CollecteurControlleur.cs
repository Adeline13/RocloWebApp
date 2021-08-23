using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.Collecteurs;
using RocloWebApp.Controllers;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class CollecteurControlleur : Controller
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly ICollecteur _icollecteur;

        public CollecteurControlleur(ICollecteur icollecteur)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _icollecteur = icollecteur;
        }

        [HttpGet]
        public ActionResult CreerCollecteur()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            List<Collecteur> listCollecteur = await _icollecteur.AfficherCollecteur();
            return View(listCollecteur);
        }

        [HttpPost]
        public async Task<IActionResult> CreerCollecteur(Collecteur collecteur)
        {
            await _icollecteur.CreerCollecteur(collecteur);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Inscription(Collecteur collecteur)
        {
            await _icollecteur.CreerCollecteur(collecteur);
            //return RedirectToAction(nameof(RocloFrontControleur.Connexion));
            return RedirectToAction("Connexion", "RocloFrontControleur");
        }

        [HttpGet]
        public async Task<IActionResult> ModifierCollecteur(string idCollecteur)
        {
            await _icollecteur.ModifierCollecteur(idCollecteur);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModifierCollecteur(Collecteur collecteur)
        {
            await _icollecteur.ModifierCollecteur(collecteur);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerCollecteur(string idCollecteur)
        {
            await _icollecteur.SupprimerCollecteur(idCollecteur);
            return RedirectToAction(nameof(Index));
        }
    }
}

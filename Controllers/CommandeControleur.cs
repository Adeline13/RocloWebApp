using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.commande;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class CommandeControleur : Controller
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly ICommande _icommande;

        public CommandeControleur(ICommande icommande)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _icommande = icommande;
        }

        [HttpGet]
        public ActionResult CreerCommande()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Commande> listCommande = await _icommande.AfficherCommande();
            return View(listCommande);
        }
        [HttpPost]
        public async Task<IActionResult> CreerCommande(Commande commande)
        {
            await _icommande.CreerCommande(commande);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ModifierCommande(string idCommande)
        {
            await _icommande.ModifierCommande(idCommande);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModifierCommande(Commande commande)
        {
            await _icommande.ModifierCommande(commande);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerCommande(string idCommande)
        {
            await _icommande.SupprimerCommande(idCommande);
            return RedirectToAction(nameof(Index));
        }
    }
}

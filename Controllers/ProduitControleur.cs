using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.produits;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class ProduitControleur : Controller
    {

        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly IProduit _iproduit;

        public ProduitControleur(IProduit iproduit)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _iproduit = iproduit;
        }

        [HttpGet]
        public ActionResult CreerProduit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Produit> listProduit = await _iproduit.AfficherProduit();
            return View(listProduit);
        }
        [HttpPost]
        public async Task<IActionResult> CreerProduit(Produit produit)
        {
            await _iproduit.CreerProduit(produit);
            return RedirectToAction(nameof(Index));
        }


        /*[HttpGet]
        public async Task<IActionResult> ModifierProduit(string idProduit)
        {
            await _iproduit.ModifierProduit(idProduit);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModifierProduit(Produit produit)
        {
            await _iproduit.ModifierProduit(produit);
            return RedirectToAction(nameof(Index));
        }*/

        [HttpPost]
        public async Task<IActionResult> SupprimerProduit(string idProduit)
        {
            await _iproduit.SupprimerProduit(idProduit);
            return RedirectToAction(nameof(Index));
        }
    }
}

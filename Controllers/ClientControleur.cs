using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.clients;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class ClientControleur : Controller
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly IClient _iclient;

        public ClientControleur(IClient iclient)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _iclient = iclient;
        }

        [HttpGet]
        public ActionResult CreerClient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Inscription()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Client> listClient = await _iclient.AfficherClient();
            return View(listClient);
        }
        [HttpPost]
        public async Task<IActionResult> CreerClient(Client client)
        {
            await _iclient.CreerClient(client);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Inscription(Client client)
        {
            await _iclient.CreerClient(client);
           // return RedirectToAction(nameof(RocloFrontControleur.Connexion));
            return RedirectToAction("Connexion", "RocloFrontControleur");
        }

        [HttpGet]
        public async Task<IActionResult> ModifierClient(string idClient)
        {
            await _iclient.ModifierClient(idClient);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModifierClient(Client client)
        {
            await _iclient.ModifierClient(client);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerClient(string idClient)
        {
            await _iclient.SupprimerClient(idClient);
            return RedirectToAction(nameof(Index));
        }
    }
}

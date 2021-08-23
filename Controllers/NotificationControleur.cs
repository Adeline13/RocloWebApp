using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using RocloWebApp.Models.notifications;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class NotificationControleur : Controller
    {

        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly INotification _inotification;

        public NotificationControleur(INotification inotification)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
            _inotification = inotification;
        }

        [HttpGet]
        public ActionResult CreerNotification()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Notification> listNotification = await _inotification.AfficherNotification();
            return View(listNotification);
        }
        [HttpPost]
        public async Task<IActionResult> CreerNotification(Notification notification)
        {
            await _inotification.CreerNotification(notification);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> ModifierNotification(string idNotification)
        {
            await _inotification.ModifierNotification(idNotification);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModifierNotification(Notification notification)
        {
            await _inotification.ModifierNotification(notification);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerNotification(string idNotification)
        {
            await _inotification.SupprimerNotification(idNotification);
            return RedirectToAction(nameof(Index));
        }
    }
}

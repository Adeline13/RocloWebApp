using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocloWebApp.Controllers
{
    public class RocloFrontControleur : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public RocloFrontControleur(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public IActionResult Accueil()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Plus()
        {
            return View();
        }
        public IActionResult Materiel()
        {
            return View();
        }
        /*public IActionResult Inscription()
        {
            return View();
        }*/
        public IActionResult Contact()
        {
            return View();
        }
       /* [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }*/
        /*-------------------Map et graphes-------------------------------*/
        public IActionResult PageGraphique()
        {
            return View();
        }
        public IActionResult detailBac()
        {
            return View();
        }
        public IActionResult detailConvoyeur()
        {
            return View();
        }
        public IActionResult detailRideau()
        {
            return View();
        }
    }
}

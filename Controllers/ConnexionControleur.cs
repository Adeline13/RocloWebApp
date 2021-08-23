using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
//using RocloWebApp.Services;
using RocloWebApp.Models.admin;
using Microsoft.VisualBasic;

namespace RocloWebApp.Controllers
{
   // [Authorize(AuthenticationSchemes = Constants.NoOpSchema)]
    //[Authorize]
    public class ConnexionControleur : Controller
    {
        [HttpGet]
        public ActionResult Connexion()
        {
            return View();
        }
        //private readonly IConnexion _iConnexion;
       /* public ConnexionControleur(IConnexion iConnexion)
        {
            this._iConnexion = iConnexion;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Connexion([FromBody] Admin admin)
        {
           /* var token = await _iConnexion.Connexion
                (admin.nom, admin.motDePasse);
            if (token == null)
                return Unauthorized();*
           // return Ok(token);
            return RedirectToAction("Index", "AdminControleur");
        }*/
    }
}

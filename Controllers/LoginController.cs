using SistemaGestionDeConfiguracionSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SistemaGestionDeConfiguracionSoftware.Filtros.AdminFilters;


namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class LoginController : Controller
    {
        private USUARIO usuario = new USUARIO();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Validar(string Codigo, string Contraseña)
        {
            var rm = usuario.ValidarLogin(Codigo, Contraseña);

            if (rm.response)
            {
                rm.href = Url.Content("~/Usuario/Index");
            }
            else if (rm.response)
            {
                rm.href = Url.Content("~/Login/Index");
            }
            return Json(rm);
        }


        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }

    }
}
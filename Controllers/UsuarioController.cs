using SistemaGestionDeConfiguracionSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class UsuarioController : Controller
    {
        USUARIO usuario = new USUARIO();
        TIPO_USUARIO tipo_usuario = new TIPO_USUARIO();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuario()
        {
            ViewBag.Tipo = tipo_usuario.Listar();
            return View(usuario.ListarTodo());
        }

        public ActionResult Guardar(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Guardar();
                return Redirect("~/Usuario/Usuario");
            }
            else
            {
                return View("~/Usuario/Usuario");
            }
        }

        public ActionResult Edituser(int id = 0)
        {
            return View(id == 0 ? new USUARIO() : usuario.ObtenerUsuario(id));
        }

        public ActionResult Eliminar(int id)
        {
            usuario.ID_USUARIO = id;
            usuario.Eliminar();
            return Redirect("~/Usuario/Usuario");
        }

        public ActionResult Habilitar(int id)
        {
            usuario.ID_USUARIO = id;
            usuario.Habilitar();
            return Redirect("~/Usuario/Usuario");
        }
    }
}

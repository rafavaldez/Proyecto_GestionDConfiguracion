using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SistemaGestionDeConfiguracionSoftware.Models;
namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    
    public class ProyectoController : Controller
    {

        USUARIO usuario = new USUARIO();
        PROYECTO proyecto = new PROYECTO();
        METODOLOGIA metodologia = new METODOLOGIA();

        // GET: Proyecto
        public ActionResult Index()
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Metodologia = metodologia.ListarTodo();
            return View(proyecto.ListarTodo());



           
        }

        public ActionResult Guardar(PROYECTO proyecto, string daterange)
        {
            if (!proyecto.DESCRIPCION.Equals("") && !daterange.Equals(""))
            {
                //split de la fecha
                string[] fechas = daterange.Split('-');
                proyecto.FECHA_INICIO = Convert.ToDateTime(fechas[0]);
                proyecto.FECHA_FIN = Convert.ToDateTime(fechas[1]);

                proyecto.Guardar();
                return Redirect("~/Proyecto/Index");
            }
            else
            {
                return View("~/Proyecto/Index");
            }
        }

        public ActionResult EditPro(int id = 0)
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Metodologia = metodologia.ListarTodo();
            return View(id == 0 ? new PROYECTO() : proyecto.ObtenerProyecto(id));
        }

        public ActionResult Eliminar(int id)
        {
            proyecto.ID_PROYECYO = id;
            proyecto.Eliminar();
            return Redirect("~/Proyecto/Index");
        }

        public ActionResult Habilitar(int id)
        {
            proyecto.ID_PROYECYO = id;
            proyecto.Habilitar();
            return Redirect("~/Proyecto/Index");
        }

        public ActionResult Revision(int id)
        {
            proyecto.ID_PROYECYO = id;
            proyecto.Revision();
            return Redirect("~/Proyecto/Index");
        }

    }
}
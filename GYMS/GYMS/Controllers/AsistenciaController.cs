using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYMS.Controllers
{
    public class AsistenciaController : Controller
    {
        // GET: Asistencia
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListaAsistencia(int idUsuario)
        {
            var a = Models.Asistencia.ListaAsistencia(idUsuario);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
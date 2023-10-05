using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYMS.Controllers
{
    public class SuscripcionController : Controller
    {
        // GET: Suscripcion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tipo()
        {
            return View();
        }
        public JsonResult ListaTipoSuscripcion(string idNombre)
        {
            var a = Models.TipoSuscripcion.ListaTipoSuscripcion(idNombre);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CargarSuscripcion(int idSuscripcion)
        {
            var a = Models.TipoSuscripcion.CargarSuscripcion(idSuscripcion);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Cargar(int id)
        {
            var a = Models.TipoSuscripcion.Cargar(id);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Siguiente()
        {
            var a = Models.TipoSuscripcion.Siguiente();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Guardar(Models.TipoSuscripcion ts)
        {
            var a = ts.Guardar();
            return a;
        }
        public string Borrar(Models.TipoSuscripcion ts)
        {
            var a = ts.Borrar();
            return a;
        }
    }
}
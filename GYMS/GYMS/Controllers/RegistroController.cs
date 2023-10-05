using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYMS.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cliente()
        {
            return View();
        }
        public JsonResult ListaTablaClientes(string idNombre)
        {
            var a = Models.Cliente.ListaClientes(idNombre);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CargarCliente(int id)
        {
            var a = Models.Cliente.Cargar(id);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Siguiente()
        {
            var a = Models.Cliente.Siguiente();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidarUsuario(string correo, string contraseña)
        {
            var a= Models.Cliente.ValidarCorreo(correo, contraseña);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        /**/public JsonResult Verificador()
        {
            var a = Models.Cliente.ConsultarVerificador();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        /**/public string VerificarUsuario(Models.Cliente c)
        {
            var a = c.VerificarUsuario();
            return a;
        }
        [HttpPost]

        public string Guardar(Models.Cliente c)
        {
            var a = c.Guardar();
            return a;
        }
        public string EditarCliente(Models.Cliente c)
        {
            var a = c.Editar();
            return a;
        }


        public string BorrarCliente(Models.Cliente c)
        {
            var a = c.Borrar();
            return a;
        }

        //

        /**/public string RegistrarUsuario(Models.Cliente c)
        {
            var a = c.RegistrarUsuario();
            return a;
        }
    }
}
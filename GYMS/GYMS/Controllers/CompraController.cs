using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYMS.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }
        
        
        public ActionResult Compra()
        {
            return View();
        }
        [HttpPost]
        public string RealizarCompra(Models.Compra compra)
        {
            string r = compra.RealizarCompra();
            return r;
        }
    }
}
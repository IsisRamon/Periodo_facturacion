using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodo_facturacion.Models;
using Periodo_facturacion.Services;

namespace Periodo_facturacion.Controllers
{
    public class PeriodoController : Controller
    {
     
        // GET: Periodo
        public ActionResult Index()
        {
            return View(new Periodo());
        }
        [HttpPost]
        public ActionResult Index(Periodo p,string generarPeriodo, string Periodicidad)
        {
            var fechasService = new FechasService();
            var model = fechasService.ObtenerFecha(p);
            if (generarPeriodo == "generar")
            {
             
            }
            return View("Detalle",model);

        }
    }
}
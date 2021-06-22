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
        public ActionResult Index(Periodo p,string generarPeriodo)
        {

            //   List<FechasModelClass> _items = new List<FechasModelClass>();
         //   inp.DiaCorte;
            var fechasService = new FechasService();
            var model = fechasService.ObtenerFecha(p);
            if (generarPeriodo == "generar")
            {
             
                /*
                _items.Add(new FechasModelClass()
                {
                    FechaImpresion = "fecha impresion 1",
                    FechasInicioAll = "fecha inicial1",
                    FechasFinalAll = "fecha final 1"

                });
                */
            }
            // p.FechasLIst = lista;
            return View("Detalle",model);

            //    var fechas = new List<FechasModelClass>();
            // DateTime fechaInicial = new DateTime();
            //fechaInicial.AddMonths(2);

            /*
                           
                fechas.Add(new FechasModelClass()
                {
                    FechasInicioAll = "fecha inicio 1= " + p.FechaInicial,
                    FechasFinalAll = "Fecha final 1= " + p.FechaFinal,
                    FechaImpresion = "impresion 1"
                }); ;
                fechas.Add(new FechasModelClass()
                {
                    FechasInicioAll = "fecha inicio 2",
                    FechasFinalAll = "fecha finnal 2",
                    FechaImpresion = "impresion 2"
                }); ;
            */



            //return View("Detalle",fechas);
        }
    }
}
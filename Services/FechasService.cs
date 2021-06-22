using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Periodo_facturacion.Models;

namespace Periodo_facturacion.Services
{
    public class FechasService
    {
        public Periodo ObtenerFechas(Periodo p)
        {

            

            return new Periodo()
            {
                FechasInicioAll = "inicio="+p.FechaInicial,
                FechasFinalAll = "fin="+p.FechaFinal,
                FechaImpresion="impresion="+p.DiaImpresion

            };
        }
        public List<Periodo>ObtenerFecha(Periodo p)
        {

            
            
            Periodo fecha = new Periodo()
            {


                FechasInicioAll = "inicio=" + p.FechaInicial,
                FechasFinalAll = "fin=" + p.FechaFinal,
                FechaImpresion = "impresion=" + p.DiaImpresion
            };


            return new List<Periodo>
            {
                fecha
            };
        }
    }
}
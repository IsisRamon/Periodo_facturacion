using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//"/Index", "Periodo", FormMethod.Post

namespace Periodo_facturacion.Models
{
    public class Periodo
    {
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public int Periodicidad { get; set; }

        public int DiaCorte { get; set; }
        public int DiaImpresion { get; set; }


        public string FechasFinalAll { get; set; }
        public string FechasInicioAll { get; set; }

        public string FechaImpresion { get; set; }
    }
}
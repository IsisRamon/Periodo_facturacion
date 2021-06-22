using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Periodo_facturacion.Models;

namespace Periodo_facturacion.Services
{
    public class FechasService
    { 
        //  public List<Periodo> ObtenerFecha(Periodo p)

        public int nombre()
        {
            int num = 0;
            return num;
        }
        public List<Periodo> ObtenerFecha(Periodo p)
        {

            

            List<Periodo> parts = new List<Periodo>();
            DateTime _auxfin = DateTime.Parse("01 / 01 / 0001");
            DateTime _fechainicial = DateTime.Parse(p.FechaInicial);
            DateTime _fechafinal = DateTime.Parse(p.FechaFinal);
            // _fechainicial.ToString("dd/MM/yyyy")
            do
            {

                if (p.Periodicidad == 1)//mensual
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(1).AddDays(-2);
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial, FechasFinalAll = "" + _auxfin, FechaImpresion = "" });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(1).AddDays(-1);

                }
                else if (p.Periodicidad == 2)//bimestral    
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(2).AddDays(-2);
                    //validar si _aunfin es mayor a fecha fin ENTONCES 
                    //
                    if (_auxfin > _fechafinal&& p.DiaCorte<=_fechafinal.Day)
                    {
                        _auxfin=new  DateTime (_fechafinal.Year, _fechafinal.Month,p.DiaCorte);   
                        
                    }
                   
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin, FechaImpresion = "" });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(2).AddDays(-1);
                }
                else if (p.Periodicidad == 3)//semestral
                { 
                    _auxfin = _fechainicial.AddDays(1).AddMonths(6).AddDays(-2);
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin, FechaImpresion = "" });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(6).AddDays(-1);
                }
                else if (p.Periodicidad == 4)//anual
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(12).AddDays(-2);
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin, FechaImpresion = "" });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(12).AddDays(-1);

                    //07-2020
                    //05-2025

                    //01-2020
                    //03-2021


                    //si el mes inicial es menor o igual Y 
                   // (_fechainicial.Month < _fechafinal.Month && _fechainicial.Year <= _fechafinal.Year) ||  (_fechainicial.Month >= _fechafinal.Month && _fechainicial.Year <= _fechafinal.Year))

                }
            } while ((_fechainicial) <= ( _fechafinal));


            return parts;
           
        }
    }

}
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
            DateTime _fechaimp = DateTime.Parse("01 / 01 / 0001");
            DateTime _fechainicial = DateTime.Parse(p.FechaInicial);
            DateTime _fechafinal = DateTime.Parse(p.FechaFinal);
            // _fechainicial.ToString("dd/MM/yyyy")
            do
            {

                if (p.Periodicidad == 1)//mensual
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(1).AddDays(-2);
                    _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, p.DiaImpresion);
                    if (p.DiaCorte > _fechafinal.Day && _auxfin.Month == _fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if(p.DiaImpresion>=_fechafinal.Day && _fechaimp.Month == _fechafinal.Month)
                    {
                        _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, _fechafinal.Day);

                    }

                    if (_auxfin > _fechafinal && p.DiaCorte <= _fechafinal.Day)
                    {
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);

                    }

               
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(1).AddDays(-1);

                }
                else if (p.Periodicidad == 2)//bimestral    
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(2).AddDays(-2);
                    _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, p.DiaImpresion);

                    if (p.DiaCorte > _fechafinal.Day && _auxfin.Month == _fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if (p.DiaCorte > _fechafinal.Day && _auxfin.Month == _fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if (_auxfin > _fechafinal&& p.DiaCorte<=_fechafinal.Day)
                    { 
                        _auxfin =new  DateTime (_fechafinal.Year, _fechafinal.Month,p.DiaCorte);                      
                    }

              
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = ""+ _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(2).AddDays(-1);
                   

                    if (p.DiaCorte == _auxfin.Day && _auxfin < _fechafinal)
                    {
                        _auxfin = _auxfin.AddDays(1);
                        _fechaimp = _fechafinal;
                        parts.Add(new Periodo() { FechasInicioAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _fechafinal.ToString("dd/MM/yyyy"), FechaImpresion = ""+ _fechaimp.ToString("dd/MM/yyyy") });
                    }
                }
                else if (p.Periodicidad == 3)//semestral
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(6).AddDays(-2);
                    _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, p.DiaImpresion);

                    if (p.DiaCorte>_fechafinal.Day && _auxfin.Month==_fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if (p.DiaCorte > _fechafinal.Day && _auxfin.Month == _fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if (_auxfin > _fechafinal && p.DiaCorte <= _fechafinal.Day)
                    {
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }

                   
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(6).AddDays(-1);


                    if (p.DiaCorte == _auxfin.Day && _auxfin < _fechafinal)
                    {
                        _auxfin = _auxfin.AddDays(1);
                        _fechaimp = _fechafinal;
                        parts.Add(new Periodo() { FechasInicioAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _fechafinal.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    }
                }
                else if (p.Periodicidad == 4)//anual
                {
                    _auxfin = _fechainicial.AddDays(1).AddMonths(12).AddDays(-2);
                    _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, p.DiaImpresion);
                    if (p.DiaCorte > _fechafinal.Day && _auxfin.Month == _fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if (p.DiaCorte > _fechafinal.Day && _auxfin.Month == _fechafinal.Month)
                    {
                        p.DiaCorte = _fechafinal.Day;
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }
                    if (_auxfin > _fechafinal && p.DiaCorte <= _fechafinal.Day)
                    {
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }

                    
                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _fechainicial.AddDays(1).AddMonths(12).AddDays(-1);

                    if (p.DiaCorte == _auxfin.Day && _auxfin < _fechafinal)
                    {
                        _auxfin = _auxfin.AddDays(1);
                        _fechaimp = _fechafinal;
                        parts.Add(new Periodo() { FechasInicioAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _fechafinal.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    }
                }
            } while ((_fechainicial) <= ( _fechafinal));


            return parts;
           
        }
    }

}
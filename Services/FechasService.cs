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
            DateTime _primerdiames = new DateTime(_fechainicial.Year,_fechainicial.Month,1);
            DateTime _ultimodiames = DateTime.Parse("01 / 01 / 0001");
            do
            {

                if (p.Periodicidad == 1)//mensual
                {

                    if (_fechainicial.Day<p.DiaCorte)
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);
                        if (p.DiaCorte > _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, p.DiaCorte);
                        }
                    }
                    else
                    {

                    }

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);
                    //---------------------------------------------------------------------------------------------------------

                    //si el dia de fecha inicio es == dia corte
                    /*

                    if (_fechainicial.Day < p.DiaCorte ) //si el dia de la fecha inicial es MAYOR al dia de Corte
                    {
                         _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);

                        if (p.DiaCorte > _ultimodiames.Day)
                        {
                            _auxfin= new DateTime(_fechainicial.Year, _fechainicial.Month,_ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, p.DiaCorte);
                        }


                       // original _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, p.DiaCorte);
                        //_auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, p.DiaCorte);
                    }
                    else
                    {
                         _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);
                        if (p.DiaCorte >= _ultimodiames.Day )
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, _ultimodiames.Day);
                        }
                        else
                        {
                            ////////
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, p.DiaCorte);
                        }
                      //  _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, p.DiaCorte);
                    }


                    //si dia de corte es = o mayor DIasdelmes ENTONCES Fecha final =Ultimo dia de mes

                    if (_auxfin >= _fechafinal)
                    {
                        _auxfin = _fechafinal;
                    }

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);
                    */
                }
                else if (p.Periodicidad == 2)//bimestral    
                {

                    if (_fechainicial.Day < p.DiaCorte) //si el dia de la fecha inicial es MAYOR al dia de Corte
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(2).AddDays(-1);

                        if (p.DiaCorte > _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, p.DiaCorte);
                        }
                    }
                    else
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(2).AddDays(-1);
                        if (p.DiaCorte >= _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 2, _ultimodiames.Day);
                        }
                        else
                        {
                            ////////
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 2, p.DiaCorte);
                        }
                    }
                    

                    if (_auxfin >= _fechafinal)
                    {
                        _auxfin = _fechafinal;
                    }
                    if(_auxfin.Day==p.DiaCorte)
                    {
                        _auxfin = new DateTime(_fechafinal.Year, _fechafinal.Month, p.DiaCorte);
                    }

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);

                }
                else if (p.Periodicidad == 3)//semestral
                {
                    if (_fechainicial.Day < p.DiaCorte) //si el dia de la fecha inicial es MAYOR al dia de Corte
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);

                        if (p.DiaCorte > _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, p.DiaCorte);
                        }
                    }
                    else
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);
                        if (p.DiaCorte >= _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, _ultimodiames.Day);
                        }
                        else
                        {
                            ////////
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, p.DiaCorte);
                        }
                    }

                    if (_auxfin >= _fechafinal)
                    {
                        _auxfin = _fechafinal;
                    }

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);
                }
                else if (p.Periodicidad == 4)//anual
                {
                    if (_fechainicial.Day < p.DiaCorte) //si el dia de la fecha inicial es MAYOR al dia de Corte
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);

                        if (p.DiaCorte > _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, p.DiaCorte);
                        }
                    }
                    else
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                        _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1);
                        if (p.DiaCorte >= _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, _ultimodiames.Day);
                        }
                        else
                        {
                            ////////
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, p.DiaCorte);
                        }
                    }

                    if (_auxfin >= _fechafinal)
                    {
                        _auxfin = _fechafinal;
                    }

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);

                }
            } while ((_fechainicial) <= ( _fechafinal));


            return parts;
           
        }
    }

}
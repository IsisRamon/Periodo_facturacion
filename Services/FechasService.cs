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
                    _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
           
                    _ultimodiames = _primerdiames.AddMonths(1).AddDays(-1); //aumentarle dias en caso de sea otro periodo 1/2/6/12

                    if (_fechainicial.Day < p.DiaCorte)
                    {                 
                        if (p.DiaCorte >= _ultimodiames.Day) //ver si es >= o solo >
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month, p.DiaCorte);
                        }
                    }
                    else if (_fechainicial.Day > p.DiaCorte)
                    {

                        if (p.DiaCorte >= _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, _ultimodiames.Day);
                        }
                        else
                        {
                            _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month+1, 1);
                            _ultimodiames = _primerdiames.AddMonths(2).AddDays(-1); //aumentarle dias en caso de sea otro periodo 1/2/6/12

                            if(p.DiaCorte >= _ultimodiames.Day)
                            {
                                _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, _ultimodiames.Day);
                            }
                            else
                            {
                                _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, p.DiaCorte);
                            }
                           
                        }
                    }
                    else if(_fechainicial.Day==p.DiaCorte)
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, 1);
                        _ultimodiames = _primerdiames.AddMonths(2).AddDays(-1);
                        if (p.DiaCorte >= _ultimodiames.Day) //ver si es >= o solo >
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, p.DiaCorte);
                        }
                    }

                    _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, p.DiaImpresion);

                    if (_auxfin >= _fechafinal)
                    {
                        if(p.DiaCorte==_fechafinal.Day)
                        {
                            _auxfin = _fechafinal;
                        }
                        else if (_auxfin.Month>=_fechafinal.Month && _auxfin.Day>=p.DiaCorte )
                        {

                            _fechainicial = _fechainicial.AddMonths(-1);
                            if(_fechainicial.Month==2)
                            {
                                _fechainicial = _fechainicial.AddDays(1);
                            }
                           
                            _auxfin = _fechafinal;
                            _fechaimp = _fechafinal;

                        }
                        else
                        {
                            _auxfin = _fechafinal;
                            _fechaimp = _fechafinal;
                        }
                    } 

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);

                }
                else if (p.Periodicidad == 2)//bimestral    
                {
                    _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month, 1);
                    
                    _ultimodiames = _primerdiames.AddMonths(2).AddDays(-1); //aumentarle dias en caso de sea otro periodo 1/2/6/12   //

                    if (_fechainicial.Day < p.DiaCorte)
                    {                 
                        if (p.DiaCorte >= _ultimodiames.Day) //ver si es >= o solo >
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+1, p.DiaCorte);
                        }
                    }
                    else if (_fechainicial.Day > p.DiaCorte)
                    {

                        if (p.DiaCorte >= _ultimodiames.Day)
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 2, _ultimodiames.Day);
                        }
                        else
                        {
                            _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month+2, 1);
                            _ultimodiames = _primerdiames.AddMonths(2).AddDays(-1); //aumentarle dias en caso de sea otro periodo 1/2/6/12

                            if(p.DiaCorte >= _ultimodiames.Day)
                            {
                                _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 2, _ultimodiames.Day);
                            }
                            else
                            {
                                _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month + 2, p.DiaCorte);
                            }
                           
                        }
                    }
                    else if(_fechainicial.Day==p.DiaCorte)
                    {
                        _primerdiames = new DateTime(_fechainicial.Year, _fechainicial.Month + 1, 1);
                        _ultimodiames = _primerdiames.AddMonths(3).AddDays(-1);
                        if (p.DiaCorte >= _ultimodiames.Day) //ver si es >= o solo >
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+2, _ultimodiames.Day);
                        }
                        else
                        {
                            _auxfin = new DateTime(_fechainicial.Year, _fechainicial.Month+2, p.DiaCorte);
                        }
                    }

                    _fechaimp = new DateTime(_auxfin.Year, _auxfin.Month, p.DiaImpresion);

                    if (_auxfin >= _fechafinal)
                    {
                        if(p.DiaCorte==_fechafinal.Day)
                        {
                            _auxfin = _fechafinal;
                        }
                        else if (_auxfin.Month>=_fechafinal.Month && _auxfin.Day>=p.DiaCorte )
                        {

                            _fechainicial = _fechainicial.AddMonths(-1);
                            if(_fechainicial.Month==2)
                            {
                                _fechainicial = _fechainicial.AddDays(1);
                            }
                           
                            _auxfin = _fechafinal;
                            _fechaimp = _fechafinal;

                        }
                        else
                        {
                            _auxfin = _fechafinal;
                            _fechaimp = _fechafinal;
                        }
                    } 

                    parts.Add(new Periodo() { FechasInicioAll = "" + _fechainicial.ToString("dd/MM/yyyy"), FechasFinalAll = "" + _auxfin.ToString("dd/MM/yyyy"), FechaImpresion = "" + _fechaimp.ToString("dd/MM/yyyy") });
                    _fechainicial = _auxfin.AddDays(1);

                }
                else if (p.Periodicidad == 3)//semestral
                {
                    
                }
                else if (p.Periodicidad == 4)//anual
                {
                  
                }
            } while ((_fechainicial) <= ( _fechafinal));


            return parts;
           
        }
    }

}

/*
 

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
*/


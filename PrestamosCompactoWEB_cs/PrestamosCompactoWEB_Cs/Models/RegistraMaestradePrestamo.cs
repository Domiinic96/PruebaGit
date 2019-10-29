using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class RegistraMaestradePrestamo
    {
        public string NoPrestamo { get; set; }
        public string Cedula { get; set; }
        public string NombreApellido { get; set; }       
        public string MontoPrestamo { get; set; }      
        public string ValorOtros { get; set; }
        public string NoCuotas { get; set; }
        public string CuotasOtros { get; set; }
        public string FechaPrestamo { get; set; }
        public string FechaPrimeraCuota { get; set; }
        public byte FrecuenciaPago { get; set; }       
        public string TasaInteres { get; set; }    
        public string TasaMora { get; set; }
        public string FormaPagos { get; set; }
        public string codigoCobradorAsignado { get; set; }
        public string NombreCobradorAsignado { get; set; }     
        public string NotaPtm { get; set; }        
        public string Cuota { get; set; }
        public string Fecha { get; set; }
        public string Saldo { get; set; }
        public string ValorCuota { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }   
        public string CedulaCliente { get; set; }  
        public string Balance { get; set; }    
        public string CuotasARecalcular { get; set; }      
        public string FrecuenciaPagos { get; set; }        
        public string CodigoCobradorAsignado { get; set; }
     
        

    }
    public class TablaMaestradePrestamo
        {
            public string Cia { get; set; }
            public string Usuario { get; set; }
            public string Contrato { get; set; }
            public string CuotasOriginales { get; set; }
            public string BALANCE { get; set; }
            public string Cuota { get; set; }

            public string FechaVencCuota { get; set; }
            public string Saldo { get; set; }
            public string ValorCuota { get; set; }
            public string Capital { get; set; }
            public string Interes { get; set; }
            public string Otros { get; set; }


    }
    public class tblMaestradePrestamo
        {
            public List<RegistraMaestradePrestamo> tblMaestradePrestamos { get; set; }
        }

    }


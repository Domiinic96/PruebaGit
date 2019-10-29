using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class PTC_MaestroPrestamos
    {
        public string NoPrestamo { get; set; }
        public string Cedula { get; set; }
        public string NombreApellido { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal ValorOtros { get; set; }
        public int NoCuotas { get; set; }
        public decimal CuotasOtros { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaPrimeraCuota { get; set; }
        public int FrecuenciaPago { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal TasaMora { get; set; }
        public bool FormaPagos { get; set; }
        public string codigoCobradorAsignado { get; set; }
        public string NombreCobradorAsignado { get; set; }
        public string DetallesNegociacion { get; set; }
        public string Cuota { get; set; }
        public string Fecha { get; set; }
        public string Saldo { get; set; }
        public string ValorCuota { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }
    }
}
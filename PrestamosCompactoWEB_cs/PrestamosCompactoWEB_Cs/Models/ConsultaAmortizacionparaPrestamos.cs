using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ConsultaAmortizacionparaPrestamos
    {
        public string NombreApellidoCliente { get; set; }
        public string MontoPrestamo { get; set; }
        public string ValorOtros { get; set; }
        public string NoCuotas { get; set; }
        public string CuotasOtros { get; set; }
        public string FechaPrestamo { get; set; }
        public string FechaPrimeraCuota { get; set; }
        public string FrecuenciaPagos { get; set; }
        public string TasaInteres { get; set; }
        public string FormaPagos { get; set; }
        public string Cuota { get; set; }
        public string Fecha { get; set; }
        public string Saldo { get; set; }
        public string ValorCuota { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }

    }
}
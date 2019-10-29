using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ReporteUltimaCuotaDeContrato
    {
        public string Cia { get; set; }
        public string NombreCia { get; set; }
        public string Fecha { get; set; }
        public string CodigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public string Contrato { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public Int16 CuotasPtm { get; set; }
        public DateTime FechaPtm { get; set; }
        public decimal MontoPtm { get; set; }
    }
}
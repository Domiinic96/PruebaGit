using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ContratoDelMes
    {

        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int FormaReporte { get; set; }
        public string CodigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public int OrdenadoPor { get; set; }
        public string Contrato { get; set; }
        public decimal MontoPtm { get; set; }
        public decimal InteresPtm { get; set; }
        public decimal TasaInteres { get; set; }
        public Int16 CuotasPtm { get; set; }
        public int Venc { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPtm { get; set; }
        public DateTime Vencimiento { get; set; }





    }
}
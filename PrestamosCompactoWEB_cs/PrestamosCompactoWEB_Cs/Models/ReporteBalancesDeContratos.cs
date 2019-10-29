using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ReporteBalancesDeContratos
    {
        public string Contrato { get; set; }
        public string FechaHasta { get; set; }
        public Boolean PrestamoBalance { get; set; }
        public int FormaReporte { get; set; }
        public string CodigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public string Cobrador { get; set; }
        public int OrdenadoPor { get; set; }
        public float capital { get; set; }
        public decimal interes { get; set; }
        public decimal comision { get; set; }
        public decimal mora { get; set; }
        public decimal otros { get; set; }
        public byte formaDeReporte { get; set; }
    }
}
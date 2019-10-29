using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ContratosConBalance
    {
        public string Cia { get; set; }
        public string NombreClte { get; set;}
        public string Contrato { get; set; }
        public string FechaHasta { get; set; }
        public byte PrestamoBalance { get; set; }
        public int FormaReporte { get; set; }
        public string Cobrador { get; set; }
        public string NombreCobrador { get; set; }
        public int OrdenadoPor { get; set; }
        public int CuotasVenc { get; set; }
        public decimal DiasVenc { get; set; }
        public decimal capital { get; set; }
        public decimal interes { get; set; }
        public decimal comision { get; set; }
        public decimal mora { get; set; }
        public decimal otros { get; set; }
 
    }
}
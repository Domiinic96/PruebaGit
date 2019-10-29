using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ReporteContratoDelMes
    {

        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int FormaReporte { get; set; }
        public string CodigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public int OrdenadoPor { get; set; }
        public string Contrato { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class ListadoDeCobrosRealizados
    {
        public string Cia { get; set; }
        public string NombreCia { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public DateTime FechaDocCont { get; set; }
        public int TipoMovimiento { get; set; }
        public string FormaReporte { get; set; }
        public string CodigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public int OrdenadoPor { get; set; }
        public string NombreCliente { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Mora { get; set; }
        public decimal Otros { get; set; }
        public string Contrato { get; set; }
        public string NoDocumento { get; set;}
        public string TipoDocumento { get; set; }



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class CobrosRealizados
    {


            public string Cia { get; set; }
            public string NombreCia { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public DateTime FechaDocCont { get; set; }
            public byte TipoMovimiento { get; set; }
            public byte FormaReporte { get; set; }
            public string CodigoCobrador { get; set; }
            public string NombreCobrador { get; set; }
            public int OrdenadoPor { get; set; }
            public string NombreCliente { get; set; }
            public decimal Capital { get; set; }
            public decimal Interes { get; set; }
            public decimal Mora { get; set; }
            public decimal Otros { get; set; }
            public string Contrato { get; set; }
            public string NoDocumento { get; set; }
            public string TipoDocumento { get; set; }
            public decimal Total { get; set; }

    }
}
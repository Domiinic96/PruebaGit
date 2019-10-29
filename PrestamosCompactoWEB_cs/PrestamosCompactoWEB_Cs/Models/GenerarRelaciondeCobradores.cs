using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class GenerarRelaciondeCobradores
    {
        public DateTime Fecha { get; set; }
        public string CodigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
    }
    public class GenerarTablaDeRelacion
    { 
        public string Contrato {get; set;}
        public string Nombre { get; set; }
        public string Cuota { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }
        public string Total { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class MovimientosDeContabilidad
    {
        public string NoDocumento { get; set; }

        [DisplayName("Codigo")]
        public string NoCuenta { get; set; }

        public string DescripcionCuenta { get; set; }
        public string ConceptoGeneral { get; set; }

        [DisplayName("Codigo")]
        public string NoAuxiliar { get; set; }

        public string NomAuxiliar { get; set; }
        public string Tipo { get; set; }
        public string DocAplicacion { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public string Movimiento { get; set; }

        [DisplayName("Descripcion")]
        public string Concpcuenta { get; set; }

        [DisplayName("Descripcion")]
        public string Concpauxiliar { get; set; }

        public string Contipo { get; set; }
        public string Valora { get; set; }
        public string Modulo { get; set; }
        public string Usuario { get; set; }
        public string Prestamos { get; set; }
    }
}
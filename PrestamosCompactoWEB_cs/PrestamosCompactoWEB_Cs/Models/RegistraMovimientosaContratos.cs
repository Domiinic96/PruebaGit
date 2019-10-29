using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class RegistraMovimientosaContratos
    {
        public string NoPrestamo { get; set; }
        public string CedulaCliente { get; set; }
        public string NombreApellidoCliente { get; set; }
        public byte Movimiento { get; set; }
        public string NoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Fecha { get; set; }
        public string codigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public string Comentario { get; set; }
        public decimal Pendientes { get; set; }
        public decimal Pagadas { get; set; }
        public decimal BalanceAlCobro { get; set; }
        public bool FormaPagos { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Otros { get; set; }
        public decimal Mora { get; set; }
        public decimal Total { get; set; }


    }


}
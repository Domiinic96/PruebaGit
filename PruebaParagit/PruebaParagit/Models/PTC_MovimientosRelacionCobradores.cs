//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaParagit.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PTC_MovimientosRelacionCobradores
    {
        public string Cia { get; set; }
        public Nullable<System.DateTime> FechaHoraReg { get; set; }
        public string Usuario { get; set; }
        public string CodigoCobrador { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Contrato { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreApls { get; set; }
        public string CedulaRnc { get; set; }
        public Nullable<System.DateTime> FechaUltimoPago { get; set; }
        public Nullable<decimal> ValorUltimoPago { get; set; }
        public string Pagadas { get; set; }
        public string Pendientes { get; set; }
        public Nullable<decimal> ValorCuotaCap { get; set; }
        public Nullable<decimal> ValorCuotaInt { get; set; }
        public Nullable<decimal> ValorCuotaCom { get; set; }
        public Nullable<decimal> ValorCuotaOtros { get; set; }
        public Nullable<decimal> ValorPagoCap { get; set; }
        public Nullable<decimal> ValorPagoInt { get; set; }
        public Nullable<decimal> ValorPagoCom { get; set; }
        public Nullable<decimal> ValorPagoOtros { get; set; }
        public Nullable<decimal> BceIntAdicional { get; set; }
        public Nullable<decimal> BceMora { get; set; }
        public Nullable<decimal> BceAuxiliar { get; set; }
        public Nullable<int> PagosEspeciales { get; set; }
        public string DetalleCuotasEspeciales { get; set; }
        public string FechaCuotas { get; set; }
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public string NombreCompañia { get; set; }
        public string DireccionCliente { get; set; }
        public Nullable<decimal> MontoPtm { get; set; }
    }
}
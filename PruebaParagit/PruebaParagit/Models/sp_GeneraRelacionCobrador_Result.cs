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
    
    public partial class sp_GeneraRelacionCobrador_Result
    {
        public string Cobrador { get; set; }
        public string NombreCliente { get; set; }
        public string Contrato { get; set; }
        public string Cuota { get; set; }
        public Nullable<System.DateTime> FechaVencCuota { get; set; }
        public Nullable<decimal> ValorCuotaCap { get; set; }
        public Nullable<decimal> ValorCuotaInt { get; set; }
        public Nullable<decimal> ValorCuotaCom { get; set; }
        public Nullable<decimal> ValorCuotaLeg { get; set; }
        public Nullable<decimal> ValorCuotaOtr { get; set; }
        public Nullable<decimal> TasaMora { get; set; }
        public Nullable<decimal> DiasVencido { get; set; }
    }
}

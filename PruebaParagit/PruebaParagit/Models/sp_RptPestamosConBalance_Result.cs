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
    
    public partial class sp_RptPestamosConBalance_Result
    {
        public string Nombre_Cliente { get; set; }
        public string Contrato { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<decimal> Interes { get; set; }
        public Nullable<decimal> Mora { get; set; }
        public Nullable<decimal> Comision { get; set; }
        public Nullable<decimal> Capital { get; set; }
        public Nullable<decimal> OtrosPtm { get; set; }
    }
}

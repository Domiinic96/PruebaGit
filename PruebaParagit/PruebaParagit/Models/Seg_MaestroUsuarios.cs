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
    
    public partial class Seg_MaestroUsuarios
    {
        public string CodigoCia { get; set; }
        public Nullable<System.DateTime> FechaHoraReg { get; set; }
        public string Usuario { get; set; }
        public string IdentificacionUsr { get; set; }
        public string ClaveDeAccesoUsr { get; set; }
        public string NombreUsr { get; set; }
        public Nullable<byte> TodoTipoAccesoCia { get; set; }
        public Nullable<byte> EscribirUsr { get; set; }
        public Nullable<byte> LeerUsr { get; set; }
        public Nullable<byte> ActualizarUsr { get; set; }
        public Nullable<byte> EliminarUsr { get; set; }
        public Nullable<int> Consolidado { get; set; }
    }
}

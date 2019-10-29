using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class RegistraModificaEliminaClientes
    {

        public string Cia { get; set; }
        public string CedulaoRNC { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreNegocio { get; set; }
        public string DireccionCobro { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        ////public IEnumerable<Select_ListadoClientes> Select_ListadoClientes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class Select_ListadoClientes
    {


        
        public string Cia { get; set; } 

        [DisplayName("Cod. Cliente")]
        public string CodCliente { get; set; }

        [DisplayName("Nombre Cliente")]
        public string NombreCliente { get; set; }

        [DisplayName("Apellido Cliente")]
        public string ApellidoCliente { get; set; }

        [DisplayName("Cédula")]
        public string Cedula { get; set; }

    }
}
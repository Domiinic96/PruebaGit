using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class Select_ListadoCobradores
    {
        [DisplayName("Cod. Oficial")]
        public string CodCobrador { get; set; }

        [DisplayName("Nombre Cobrador")]
        public string NombreCobrador { get; set; }

    }
}
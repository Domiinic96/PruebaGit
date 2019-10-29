using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace PrestamosCompactoWEB_Cs.Models
{
    public class VariablesGlobales
    {
        public WebServices.Service WS = new WebServices.Service();
        public decimal Activos;
        public decimal Pasivos;
        public decimal Capital;
        public decimal Ingresos;
        public decimal Costos;

        public decimal Gastos;
        public decimal Diferencia;

        public byte[] logo;
        public Image image;
    }

}
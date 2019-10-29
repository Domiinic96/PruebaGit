using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PrestamosCompactoWEB_Cs.Models
{
    public class ConsultaContrato
    {
        public string NoPrestamo { get; set; }
        public string CedulaCliente { get; set; }
        public string NombreApellido { get; set; }
        public string FechaPrestamo { get; set; }
        public decimal MontoPrestamo { get; set; }
  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal TasaInteres { get; set; }
        public string FechaConsulta { get; set; }
        public int NoCuotas { get; set; }
        public string CodigoCobradorAsignado { get; set; }
        public string NombreCobradorAsignado { get; set; }

        public string CedulaoRNC { get; set; }
        public string Codigo { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string NombreNegocio { get; set; }
        public string DireccionCobro { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

    }
    public class ConsultaVerTabla
    {
        public string Cuota { get; set; }
        public string FechaVencCuota { get; set; }
        public string Saldo { get; set; }
        public string ValorCuota { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }
    }
    public class ConsultaVerTablaDetalle
    {
        public List<ConsultaVerTabla> ConsultaVerTablaDetalles { get; set; }
    }

    public class MenuDinamico
    {
        public string DescripcionFrm { get; set; }
        public string DescripcionTipoPgm { get; set; }
        public string Url { get; set; }
        public string CodigoTipoPgm {get;set;}
        public string NombreFrm { get; set; }
    }
     public class ObtenerMenuDinamico
    {
        public List<MenuDinamico> menu { get; set; }
    }

 
    public class MenuCabecera
    {
       public string CodigoApls { get; set; }

       public string CodigoTipoPgm { get; set; }

       public string DescripcionTipoPgm { get; set; }

    }

    public class obtenerMenuCabecera
    {
        public List<MenuCabecera> menuCabecera { get; set; }


    }
 

    public class ConsultaMovimientos
    {
        public string Fecha { get; set; }
        public string Documento { get; set; }
        public string Movimiento { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }
        public string Mora { get; set; }
        public string Total { get; set; }
    }
    public class ConsultaMovimientosDetalle
    {
        public List<ConsultaMovimientos> ConsultaMovimientosDetalles { get; set; }
    }

    public class ConsultaCuotasVencidas
    {
        public string Cuota { get; set; }
        public string Capital { get; set; }
        public string Interes { get; set; }
        public string Otros { get; set; }
        public string Total { get; set; }
        public string Fecha { get; set; }
    }
    public class ConsultaCuotasVencidasDetalle
    {
        public List<ConsultaCuotasVencidas> ConsultaCuotasVencidasDetalles { get; set; }
    }

    public class ConsultaCalculoMora
    {
        public string Cuota { get; set; }
        public string Fecha { get; set; }
        public string Valor { get; set; }
        public string Dias { get; set; }
        public string Calculo { get; set; }
        public string TasaAnual { get; set; }

    }
    public class ConsultaCalculoMoraDetalle
    {
        public List<ConsultaCalculoMora> ConsultaCalculoMoraDetalles { get; set; }
    }
}
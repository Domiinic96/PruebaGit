using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using iTextSharp.text;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class modeldescrip
    {
        public string descripcion { get; set; }
        public decimal Costo { get; set; }
    }
    public class RegistraNuevaCuenta
    {
        
        //public List<modeldescrip> DescripcionApls = new List<modeldescrip>();

        public string Codigo { get; set; }

       
        public DateTime FechaHoraReg { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(20,ErrorMessage ="Este nombre de usuario es muy largo"), MinLength(5, ErrorMessage ="Ingrese un nombre de usuario valido")]
        [DisplayName("Nombre de Usuario")]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(60, ErrorMessage = "Este nombre es muy largo")]
        [DisplayName("Nombre Cliente")]
        public string NombreClte { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(60, ErrorMessage = "Este Apellido es muy largo")]
        [DisplayName("Apellido Cliente")]
        public string ApellidoClte { get; set; }

        public string servidor { get; set; }
        public string Instancia { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(80, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("Nombre Empresa")]
        public string NombreCia { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(80, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(40, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("Ciudad")]
        public string CiudadCia { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(40, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("Sector")]
        public string SectorCia { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(40, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("País")]
        public string PaisCia { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(13, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("Cédula/Rnc")]
        public string RncCia { get; set; }

        [Phone(ErrorMessage = "Este campo solo permite numeros")]
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(13, ErrorMessage = "Este campo es muy largo, el numero telefónico excede los limites.")]
        [DisplayName("Teléfono")]
        public string TelefonosCia { get; set; }

        [DisplayName("Fax")]
        [MaxLength(13, ErrorMessage = "Este campo es muy largo")]
        public string FaxCia { get; set; }

        [Required(ErrorMessage = "Campo requerido"),EmailAddress(ErrorMessage ="Direccion de correo electrónico invalida")]
        [MaxLength(60, ErrorMessage = "Este campo es muy largo")]
        [DisplayName("Email")]
        public string EmailCia { get; set; }

        [DisplayName("Web")]
        public string WebCia { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Local")]
        public string LocalNo { get; set; }

        [DisplayName("Consolidación")]
        public Byte Consolidacion { get; set; }

       // [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Estatus")]
        public Byte Estatus { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Pago con Tarjeta")]
        public int PagoConTarjeta { get; set; }

        
        public int DiaDelPago { get; set; }
        public DateTime FechaUltimoPago { get; set; }

        [DisplayName("Nombre del Titular de la Tarjeta")]
        public string NombreTitularTarjeta { get; set; }

        [DisplayName("Numero de la Tarjeta")]
        public string NumeroTarjeta { get; set; }

        [DisplayName("Expira")]
        public string Expira { get; set; }

        [DisplayName("CVV")]
        public int CVV { get; set; }

        [DisplayName("Direccion 1")]
        public string Direccion1 { get; set; }

        [DisplayName("Direccion 2")]
        public string Direccion2 { get; set; }

        [DisplayName("Ciudad")]
        public string Ciudad { get; set; }

        [DisplayName("Codigo Postal")]
        public string CodigoPostal { get; set; }

        [DisplayName("Pais")]
        public string Pais { get; set; }


        


    }
    
   public class NuevoRegistro
    {
        public List<RegistraNuevaCuenta> NuevaCuenta { get; set; }
    }
   




}
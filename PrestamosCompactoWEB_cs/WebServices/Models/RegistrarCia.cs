using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class RegistrarCia
    {
        public string Codigo { get; set; }


        public DateTime FechaHoraReg { get; set; }
      
        public string Usuario { get; set; }
       
        public string NombreClte { get; set; }
       
        public string ApellidoClte { get; set; }
        public string servidor { get; set; }
        public string Instancia { get; set; }

        //public string DescripcionApls { get; set; }

        //public IEnumerable<string> DescripcionApls { get; set; }
      
        public string NombreCia { get; set; }
     
        
        public string Direccion { get; set; }
     
     
        public string CiudadCia { get; set; }
 
  
        public string SectorCia { get; set; }
       
       
        public string PaisCia { get; set; }

        public string RncCia { get; set; }
     

        
        public int TelefonosCia { get; set; }

        
        public string FaxCia { get; set; }
        
        
        public string EmailCia { get; set; }

   
        public string WebCia { get; set; }
     
        public string LocalNo { get; set; }

    
        public Byte Consolidacion { get; set; }

 
        public Byte Estatus { get; set; }

       
        public bool PagoConTarjeta { get; set; }


        public int DiaDelPago { get; set; }
        public DateTime FechaUltimoPago { get; set; }

      
        public string NombreTitularTarjeta { get; set; }

  
        public string NumeroTarjeta { get; set; }

       
        public string Expira { get; set; }

   
        public int CVV { get; set; }


        public string Direccion1 { get; set; }

      
        public string Direccion2 { get; set; }

       
        public string Ciudad { get; set; }

    
        public string CodigoPostal { get; set; }

       
        public string Pais { get; set; }


    }
}
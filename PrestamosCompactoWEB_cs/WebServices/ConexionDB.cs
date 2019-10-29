using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebServices
{
    public class ConexionDB
    {

        public string ObtenerConexion_PrestamosCompactoWEB()
        {
            return ConfigurationManager.ConnectionStrings["Conexion_PrestamosCompactoWEB"].ConnectionString;
        }

        //public string ObtenerConexion_Transacciones()
        //{
        //    return ConfigurationManager.ConnectionStrings["Conexion_Transacciones"].ConnectionString;
        //}

        //public string ObtenerConexion_Seguridad(){
        //return ConfigurationManager.ConnectionStrings["Conexion_Seguridad"].ConnectionString;
        //}

    }
}
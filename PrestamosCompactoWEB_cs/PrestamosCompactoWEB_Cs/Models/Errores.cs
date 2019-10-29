using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebServices.Models;
using PrestamosCompactoWEB_Cs.Models;

namespace PrestamosCompactoWEB_Cs.Models
{
    public class Errores
    {
        public  bool  error()

         {
            bool respuesta = false;
            string hola = "";
            WebServices.ConexionDB conn = new WebServices.ConexionDB();
            conn.ObtenerConexion_PrestamosCompactoWEB();
            SqlConnection sqlConnection = new SqlConnection(conn.ObtenerConexion_PrestamosCompactoWEB());
            sqlConnection.Open();
            if (sqlConnection.State== System.Data.ConnectionState.Open)
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }
           
            
            return respuesta;
        }
    }
}
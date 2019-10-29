using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class WSRegistraMaestradePrestamo
    {
        public string NoPrestamo { get; set; }
        public string Cedula { get; set; }
        public string NombreApellido { get; set; }
        public double MontoPrestamo { get; set; }
        public double ValorOtros { get; set; }
        public int NoCuotas { get; set; }
        public double CuotasOtros { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaPrimeraCuota { get; set; }
        public int FrecuenciaPago { get; set; }
        public double TasaInteres { get; set; }
        public double TasaMora { get; set; }
        public bool FormaPagos { get; set; }
        public string codigoCobradorAsignado { get; set; }
        public string NombreCobradorAsignado { get; set; }
        public string DetallesNegociacion { get; set; }

        public bool RegistraCliente(GRL_MaestroClientes model)
        {
            DataICDigitalDataContext db = new DataICDigitalDataContext();
            db.GRL_MaestroClientes.InsertOnSubmit(model);
            db.SubmitChanges();
            return true;
        }

        public DataSet Select_ListadoCobradores()
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spConsultaMaestraOficialesCobrosPr";

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            daListaCobradores.Fill(ObjDsListaCobradores, "Select_ListadoCobradores");
            ObjConexion.Close();

            return ObjDsListaCobradores;

        }

        public DataSet Select_ListadoContratos()
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaContratos = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaContratos = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spConsultaMaestraPrestamos";

            daListaContratos = new SqlDataAdapter(SqlCmd);

            daListaContratos.Fill(ObjDsListaContratos, "Select_ListadoContratos");
            ObjConexion.Close();

            return ObjDsListaContratos;

        }


    }
}
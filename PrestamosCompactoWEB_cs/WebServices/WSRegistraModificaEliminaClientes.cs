using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class WSRegistraModificaEliminaClientes
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

        public bool RegistraCliente(GRL_MaestroClientes model)
        {
            DataICDigitalDataContext db = new DataICDigitalDataContext();
            db.GRL_MaestroClientes.InsertOnSubmit(model);
            db.SubmitChanges();
            return true;
        }

        public DataSet Select_ListadoClientes(string Cia)
        {
        ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaClient = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
            SqlDataAdapter daListaClient = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectMaestroClientes";

            daListaClient = new SqlDataAdapter(SqlCmd);

            daListaClient.Fill(ObjDsListaClient, "Select_ListadoClientes");
            ObjConexion.Close();

            return ObjDsListaClient;

        }


    }
}
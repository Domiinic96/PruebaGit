using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class WSRegistraMovimientosaContratos
    {
        public string NoPrestamo { get; set; }
        public string CedulaCliente { get; set; }
        public string NombreApellidoCliente { get; set; }
        public int Movimiento { get; set; }
        public string NoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public string codigoCobrador { get; set; }
        public string NombreCobrador { get; set; }
        public string Comentario { get; set; }
        public int Pendientes { get; set; }
        public int Pagadas { get; set; }
        public double BalanceAlCobro { get; set; }
        public bool FormaPagos { get; set; }
        public double Capital { get; set; }
        public double Interes { get; set; }
        public double Otros { get; set; }
        public double Mora { get; set; }
        public double Total { get; set; }

        //public bool RegistraCliente(MaestroClientes model)
        //{
        //    DataICDigitalDataContext db = new DataICDigitalDataContext();
        //    db.MaestroClientes.InsertOnSubmit(model);
        //    db.SubmitChanges();
        //    return true;
        //}

        public DataSet Select_ListadoDocumentos()
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaClient = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaClient = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

           
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spConsultaTipoDocumento";

            daListaClient = new SqlDataAdapter(SqlCmd);

            daListaClient.Fill(ObjDsListaClient, "Select_ListadoDocumentos");
            ObjConexion.Close();

            return ObjDsListaClient;

        }


    }
}
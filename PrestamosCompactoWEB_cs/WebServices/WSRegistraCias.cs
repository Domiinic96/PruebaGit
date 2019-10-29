

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class WSRegistraCias
    {
        public string Codigo { get; set; }
        public DateTime FechaHoraReg { get; set; }
        public string Usuario { get; set; }        
        public string NombreCia { get; set; }        
        public string DireccionCia { get; set; }
        public string CiudadCia { get; set; }
        public string SectorCia { get; set; }
        public string PaisCia { get; set; }
        public string RncCia { get; set; }
        public string TelefonosCia { get; set; }
        public string FaxCia { get; set; }
        public string EmailCia { get; set; }
        public string WebCia { get; set; }
        public string LocalNo { get; set; }
        public Byte Consolidacion { get; set; }
        public Byte Estatus { get; set; }
        public Byte PagoConTarjeta { get; set; }
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

        public bool RegistraNuevaCuenta   (SEG_MaestroCias model)
        {
            DataICDigitalDataContext db = new DataICDigitalDataContext();
            db.SEG_MaestroCias.InsertOnSubmit(model);
            db.SubmitChanges();
            return true;
        }
        
        public DataSet RegistraCias(string Columns)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.Parameters.Add("@Columns", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Columns"].Value = Columns;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spConsultaMaestroCias";

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            ObjConexion.Close();

            return ObjDsListaCobradores;

        }


        
//public DataSet Select_ListadoContratos()
//{

//    ConexionDB Conn = new ConexionDB();
//    DataSet ObjDsListaContratos = new DataSet();
//    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
//    SqlDataAdapter daListaContratos = default(SqlDataAdapter);
//    ObjConexion.Open();

//    SqlCommand SqlCmd = new SqlCommand();
//    SqlCmd.Connection = ObjConexion;
//    SqlCmd.CommandType = CommandType.StoredProcedure;
//    SqlCmd.CommandText = "spConsultaMaestraPrestamos";

//    daListaContratos = new SqlDataAdapter(SqlCmd);

//    daListaContratos.Fill(ObjDsListaContratos, "Select_ListadoContratos");
//    ObjConexion.Close();

//    return ObjDsListaContratos;

//}



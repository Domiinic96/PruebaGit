using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebServices
{
    public class AccesoDB
    {
        
        //public DataSet ConsultaParametros()
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_CNT_Parametros";

        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "Parametros");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        //public DataSet MayorGeneral(string Cia, System.DateTime FechaMayor, int CuadrePrestamo)
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_RptMayorGeneral";

        //    SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cia"].Value = Cia;

        //    SqlCmd.Parameters.Add("@FechaMayor", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaMayor"].Value = FechaMayor;

        //    SqlCmd.Parameters.Add("@CuadrePrestamo", SqlDbType.Int);
        //    SqlCmd.Parameters["@CuadrePrestamo"].Value = CuadrePrestamo;

        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "Mayor");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        //public DataSet Balanza(string Cia, string MesCadena, string TableName, string Usuario, string Pc){
        //ConexionDB Conn = new ConexionDB();
        //DataSet ObjDsListaFacturas = new DataSet();
        //SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //SqlDataAdapter daListaFacturas = new SqlDataAdapter();

        //ObjConexion.Open();

        //SqlCommand SqlCmd = new SqlCommand();
        //SqlCmd.Connection = ObjConexion;
        //SqlCmd.CommandType = CommandType.StoredProcedure;
        //SqlCmd.CommandText = "sp_RptBalanza";

        //SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //SqlCmd.Parameters["@Cia"].Value = Cia;

        //SqlCmd.Parameters.Add("@MesCadena", SqlDbType.NVarChar);
        //SqlCmd.Parameters["@MesCadena"].Value = MesCadena;

        //SqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
        //SqlCmd.Parameters["@TableName"].Value = TableName;

        //SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
        //SqlCmd.Parameters["@Usuario"].Value = Usuario;

        //SqlCmd.Parameters.Add("@Pc", SqlDbType.NVarChar);
        //SqlCmd.Parameters["@Pc"].Value = Pc;

        //daListaFacturas = new SqlDataAdapter(SqlCmd);
        //daListaFacturas.Fill(ObjDsListaFacturas, "Balanza");
        //ObjConexion.Close();

        //return ObjDsListaFacturas;
        //}

        //public DataSet Cuentas(string Cia, DateTime FechaCuentas, int cuadre)
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_RptCuentas";

        //    SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cia"].Value = Cia;

        //    SqlCmd.Parameters.Add("@FechaCuentas", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaCuentas"].Value = FechaCuentas;


        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "Cuentas");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        //public DataSet DiarioGeneral(string Cia, System.DateTime FechaDesde, System.DateTime FechaHasta, string TipoDoc)
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_RptDiarioGeneral";

        //    SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cia"].Value = Cia;

        //    SqlCmd.Parameters.Add("@FechaDesde", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaDesde"].Value = FechaDesde;

        //    SqlCmd.Parameters.Add("@FechaHasta", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaHasta"].Value = FechaHasta;

        //    SqlCmd.Parameters.Add("@TipoDoc", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@TipoDoc"].Value = TipoDoc;

        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "Diario");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        //public DataSet Auxiliares(string Cia, string FechaHasta, string Cuenta, string Auxiliar)
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_RptAuxiliares";

        //    SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cia"].Value = Cia;

        //    SqlCmd.Parameters.Add("@FechaHasta", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@FechaHasta"].Value = FechaHasta;

        //    SqlCmd.Parameters.Add("@Cuenta", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cuenta"].Value = Cuenta;

        //    SqlCmd.Parameters.Add("@Auxiliar", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Auxiliar"].Value = Auxiliar;

        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "Auxiliares");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        //public DataSet RptMovAux(string Cia, System.DateTime FechaDesde, System.DateTime FechaHasta, string Cuenta, string Auxiliar)
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_RptMovAux";

        //    SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cia"].Value = Cia;

        //    SqlCmd.Parameters.Add("@FechaDesde", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaDesde"].Value = FechaDesde;

        //    SqlCmd.Parameters.Add("@FechaHasta", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaHasta"].Value = FechaHasta;

        //    SqlCmd.Parameters.Add("@CuentaCont", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@CuentaCont"].Value = Cuenta;

        //    SqlCmd.Parameters.Add("@Auxiliar", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Auxiliar"].Value = Auxiliar;

        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "MovimientosAuxiliares");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        //public DataSet RptBalanceAuxiliares(string Cia, System.DateTime FechaHasta, string Cuenta, string Auxiliar)
        //{
        //    ConexionDB Conn = new ConexionDB();
        //    DataSet ObjDsListaFacturas = new DataSet();
        //    SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_Transacciones());
        //    SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

        //    ObjConexion.Open();

        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = ObjConexion;
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.CommandText = "sp_RptBalanceAuxiliares";

        //    SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Cia"].Value = Cia;

        //    SqlCmd.Parameters.Add("@FechaHasta", SqlDbType.Date);
        //    SqlCmd.Parameters["@FechaHasta"].Value = FechaHasta;

        //    SqlCmd.Parameters.Add("@CuentaCont", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@CuentaCont"].Value = Cuenta;

        //    SqlCmd.Parameters.Add("@Auxiliar", SqlDbType.NVarChar);
        //    SqlCmd.Parameters["@Auxiliar"].Value = Auxiliar;

        //    daListaFacturas = new SqlDataAdapter(SqlCmd);
        //    daListaFacturas.Fill(ObjDsListaFacturas, "BalanceAuxiliares");
        //    ObjConexion.Close();

        //    return ObjDsListaFacturas;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////AQUI SE VAN A TRABAJAR LOS NUEVOS DATASET///////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public DataSet Acceso(string User, string Clave)
        {
            //try
            //{
                ConexionDB Conn = new ConexionDB();
                DataSet ObjDsLogueo = new DataSet();
                SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
                SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

                ObjConexion.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;
                SqlCmd.CommandType = CommandType.StoredProcedure;
               

                SqlCmd.Parameters.Add("@User", SqlDbType.NVarChar);
                SqlCmd.Parameters["@User"].Value = User;

                SqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Clave"].Value = Clave;
                SqlCmd.CommandText = "GRLsp_LogInValidator";
                daListaFacturas = new SqlDataAdapter(SqlCmd);
                daListaFacturas.Fill(ObjDsLogueo, "Acceso");
                ObjConexion.Close();

                return ObjDsLogueo;
            }
        //    catch (Exception m)
        //    {
        //       return DataView
        //        throw;
        //    }

           
        //}

        public DataSet ConsultaCia(string Cia)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsLogueo = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_ConsultaCia";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsLogueo, "Cia");
            ObjConexion.Close();

            return ObjDsLogueo;
        }
    }
}
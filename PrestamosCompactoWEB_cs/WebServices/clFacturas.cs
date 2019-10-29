using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;
using WebServices.Models;




namespace WebServices
{
    public class clFacturas
    {



        public DataSet RegistraCias(string Columns)
        {
            string error = "";
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            try
            {
                SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
                ObjConexion.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spInsertMaestraCia";

                SqlCmd.Parameters.Add("@Columns", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Columns"].Value = Columns;


                daListaCobradores = new SqlDataAdapter(SqlCmd);

                //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
                daListaCobradores.Fill(ObjDsListaCobradores);
                ObjConexion.Close();
            }
            catch (Exception ex)
            {
              error = ex.Message.ToString();
               
                
                
            }
            finally
            {
                ObjConexion.Close();
            }
            if (error != "")
            {

                
            }
          

            return ObjDsListaCobradores;
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
            //daListaCobradores.Fill(ObjDsListaCobradores);
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
            //daListaContratos.Fill(ObjDsListaContratos);
            ObjConexion.Close();

            return ObjDsListaContratos;

        }


        public DataSet Parametros(string Cia)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaContratos = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaContratos = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_RptParametros";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            daListaContratos = new SqlDataAdapter(SqlCmd);

            daListaContratos.Fill(ObjDsListaContratos, "Select_ListadoContratos");
            //daListaContratos.Fill(ObjDsListaContratos);
            ObjConexion.Close();

            return ObjDsListaContratos;

        }



        public Boolean RegistraClientes(GRL_MaestroClientes model)
        {
            try
            {

           
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spInsertMaestraClientes";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = model.Cia;

            SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Usuario"].Value = model.Usuario;

            SqlCmd.Parameters.Add("@CodClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CodClteApls"].Value = model.CodClteApls;

            SqlCmd.Parameters.Add("@NomClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@NomClteApls"].Value = model.NomClteApls;

            SqlCmd.Parameters.Add("@ApeClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@ApeClteApls"].Value = model.ApeClteApls;

            SqlCmd.Parameters.Add("@DireccionClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@DireccionClteApls"].Value = model.DireccionClteApls;

            SqlCmd.Parameters.Add("@TelefonosClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@TelefonosClteApls"].Value = model.TelefonosClteApls;

            SqlCmd.Parameters.Add("@CelularClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CelularClteApls"].Value = model.CelularClteApls;

            SqlCmd.Parameters.Add("@CedRncClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CedRncClteApls"].Value = model.CedRncClteApls;

            SqlCmd.Parameters.Add("@EmpresaL", SqlDbType.NVarChar);
            SqlCmd.Parameters["@EmpresaL"].Value = model.EmpresaL;

            SqlCmd.Parameters.Add("@E_mailClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@E_mailClteApls"].Value = model.E_mailClteApls;

                SqlCmd.ExecuteNonQuery();

            //daListaCobradores = new SqlDataAdapter(SqlCmd);

            ////daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            //daListaCobradores.Fill(ObjDsListaCobradores);
            //ObjConexion.Close();

                
            return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public Boolean EliminaCliente(GRL_MaestroClientes model)
        {
            try
            {

            

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spEliminaMaestroClientes";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = model.Cia;

            SqlCmd.Parameters.Add("@CedulaRnc", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CedulaRnc"].Value = model.CedRncClteApls;

                SqlCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public Boolean ActualizaCliente(GRL_MaestroClientes model)
        {


            try
            {

           
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spActualizaMaestroClientes";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = model.Cia;

            SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Usuario"].Value = model.Usuario;

            SqlCmd.Parameters.Add("@CodClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CodClteApls"].Value = model.CodClteApls;

            SqlCmd.Parameters.Add("@NomClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@NomClteApls"].Value = model.NomClteApls;

            SqlCmd.Parameters.Add("@ApeClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@ApeClteApls"].Value = model.ApeClteApls;

            SqlCmd.Parameters.Add("@DireccionClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@DireccionClteApls"].Value = model.DireccionClteApls;

            SqlCmd.Parameters.Add("@TelefonosClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@TelefonosClteApls"].Value = model.TelefonosClteApls;

            SqlCmd.Parameters.Add("@CelularClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CelularClteApls"].Value = model.CelularClteApls;

            SqlCmd.Parameters.Add("@CedRncClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CedRncClteApls"].Value = model.CedRncClteApls;

            SqlCmd.Parameters.Add("@EmpresaL", SqlDbType.NVarChar);
            SqlCmd.Parameters["@EmpresaL"].Value = model.EmpresaL;

            SqlCmd.Parameters.Add("@E_mailClteApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@E_mailClteApls"].Value = model.E_mailClteApls;


            SqlCmd.ExecuteNonQuery();     
                return true;
            }
            catch (Exception EX)
            {

                return false;
            }
        }



        public Boolean RegistraPrestamos(PTC_MaestroPrestamos model)
        {

            try
            {

            
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spInsertaMaestroPrestamos";
                SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Cia"].Value = model.Cia;

                SqlCmd.Parameters.Add("@CodigoCliente", SqlDbType.NVarChar);
                SqlCmd.Parameters["@CodigoCliente"].Value = "0";

                SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Contrato"].Value = model.Contrato;

                SqlCmd.Parameters.Add("@MontoPtm", SqlDbType.NVarChar);
                SqlCmd.Parameters["@MontoPtm"].Value = model.MontoPtm;

                //SqlCmd.Parameters.Add("@CuotasPtm", SqlDbType.SmallInt);
                //SqlCmd.Parameters["@CuotasPtm"].Value = model.CuotasPtm;

                //SqlCmd.Parameters.Add("@InteresPtm", SqlDbType.NVarChar);
                //SqlCmd.Parameters["@InteresPtm"].Value = "0";
                //SqlCmd.Parameters["@InteresPtm"].Value = model.InteresPtm ;

                //SqlCmd.Parameters.Add("@FrecuenciaCuotaPtm", SqlDbType.TinyInt);
                //SqlCmd.Parameters["@FrecuenciaCuotaPtm"].Value = model.FrecuenciaCuotaPtm;

                //SqlCmd.Parameters.Add("@TasaIntPtm", SqlDbType.Float);
                //SqlCmd.Parameters["@TasaIntPtm"].Value = model.TasaIntPtm;

                //SqlCmd.Parameters.Add("@TasaMoraPtm", SqlDbType.Float);
                //SqlCmd.Parameters["@TasaMoraPtm"].Value = model.TasaMoraPtm;

                //SqlCmd.Parameters.Add("@Cobrador", SqlDbType.NVarChar);
                //SqlCmd.Parameters["@Cobrador"].Value = model.Cobrador;

                //SqlCmd.Parameters.Add("@NotaPtm", SqlDbType.NVarChar);
                //SqlCmd.Parameters["@NotaPtm"].Value = model.NotaPtm;




                SqlCmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception EX)
            {

                return false;
            }

        }




        public DataSet EliminaPrestamo(string Contrato)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spEliminaMaestroPrestamos";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = Contrato;


            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }


        public DataSet ActualizaPrestamo(string Contrato)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spActualizaMaestroPrestamos";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = Contrato;


            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }

        public Boolean RegistraMovPrestamos(PTC_PagosDePrestamo model)
        {

            try
            {


                ConexionDB Conn = new ConexionDB();
                DataSet ObjDsListaCobradores = new DataSet();
                SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
                SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
                ObjConexion.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spInsertMovimientoContrato";
                SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Cia"].Value = model.Cia;

                SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Contrato"].Value = model.Contrato;

                SqlCmd.Parameters.Add("@TipoDocCont", SqlDbType.NVarChar);
                SqlCmd.Parameters["@TipoDocCont"].Value = model.TipoDocCont;

                SqlCmd.Parameters.Add("@NumDocCont", SqlDbType.NVarChar);
                SqlCmd.Parameters["@NumDocCont"].Value = model.NumDocCont;

                SqlCmd.Parameters.Add("@CodigoCobrador", SqlDbType.NVarChar);
                SqlCmd.Parameters["@CodigoCobrador"].Value = model.CodigoCobrador;

                //SqlCmd.Parameters.Add("@MovDocCont", SqlDbType.NVarChar);
                //SqlCmd.Parameters["@MovDocCont"].Value = model.MovDocCont;

                SqlCmd.Parameters.Add("@ValorPagoCapital", SqlDbType.NVarChar);
                SqlCmd.Parameters["@ValorPagoCapital"].Value = model.ValorPagoCapital;

                SqlCmd.Parameters.Add("@ValorPagoInteres", SqlDbType.NVarChar);
                SqlCmd.Parameters["@ValorPagoInteres"].Value = model.ValorPagoInteres;

                SqlCmd.Parameters.Add("@ValorPagoMora", SqlDbType.NVarChar);
                SqlCmd.Parameters["@ValorPagoMora"].Value = model.ValorPagoMora;

                SqlCmd.Parameters.Add("@ValorPagoOtros", SqlDbType.NVarChar);
                SqlCmd.Parameters["@ValorPagoOtros"].Value = model.ValorPagoOtros;




                SqlCmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception EX)
            {

                return false;
            }

        }



        public DataSet EliminaMovimientosaContratos(string Columns)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            try
            {
              
               
               
                SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
                ObjConexion.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spEliminaMovimientosaContratos";

                SqlCmd.Parameters.Add("@Columns", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Columns"].Value = Columns;


                daListaCobradores = new SqlDataAdapter(SqlCmd);

                //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
                daListaCobradores.Fill(ObjDsListaCobradores);
                ObjConexion.Close();
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            finally
            {
                ObjConexion.Close();
            }

           

            return ObjDsListaCobradores;
        }





        public DataSet GetInfoCliente(string CedRncClte, string Cia)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectInfoClientes";

            SqlCmd.Parameters.Add("@CedRncCliente", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CedRncCliente"].Value = CedRncClte;

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;


            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }


        public DataSet GetPrestamoInfo(string NoPrestamo, string Cia)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectMaestroPrestamos";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = NoPrestamo;


            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }


        public DataSet GetTemporalVencido(string NoPrestamo, string Cia, DateTime FechaConsulta, int MostrarMora)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_TemporalVencido";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = NoPrestamo;

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@FechaConsulta", SqlDbType.DateTime);
            SqlCmd.Parameters["@FechaConsulta"].Value = FechaConsulta;

            SqlCmd.Parameters.Add("@MostrarMora", SqlDbType.Int);
            SqlCmd.Parameters["@MostrarMora"].Value = MostrarMora;



            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }



        public DataSet GetConsPrestamo(string Contrato, string Cia)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectConsultaContrato";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = Contrato;


            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }

        public DataSet GetConsulPagosPrestamos(string NoPrestamo, string Cia, string FechaConsulta)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectPagosDePrestamos";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = NoPrestamo;


            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;


            SqlCmd.Parameters.Add("@FechaConsulta", SqlDbType.Date);
            SqlCmd.Parameters["@FechaConsulta"].Value = Convert.ToDateTime(FechaConsulta);

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }
        public DataSet GetCuotasPrestamo(string NoPrestamo, string Cia)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectCuotasPrestamos";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = NoPrestamo;


            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }



        public DataSet GetMovimientoPrestamo(string NoPrestamo, string Cia)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spSelectMovimientoContratos";

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = NoPrestamo;

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }





        //public bool RegistraCias(SEG_MaestroCias model)
        //{
        //    DataICDigitalDataContext db = new DataICDigitalDataContext();
        //    db.SEG_MaestroCias.InsertOnSubmit(model);
        //    db.SubmitChanges();
        //    return true;
        //}


        //--------Registra Clientes Insert

        //public string Cia { get; set; }
        //public string FechaHoraReg { get; set; }
        //public string Usuario { get; set; }
        //public string CedulaoRNC { get; set; }
        //public string Codigo { get; set; }
        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public string NombreNegocio { get; set; }
        //public string DireccionCobro { get; set; }
        //public string Telefono { get; set; }
        //public string Celular { get; set; }
        //public bool RegistraClientes(GRL_MaestroClientes model)
        //{
        //    DataICDigitalDataContext db = new DataICDigitalDataContext();
        //    db.GRL_MaestroClientes.InsertOnSubmit(model);
        //    db.SubmitChanges();
        //    return true;
        //}





        public DataSet ConsultaApls()
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaMembresias = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaMembresias = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spConsultaApls";



            daListaMembresias = new SqlDataAdapter(SqlCmd);
            
            daListaMembresias.Fill(ObjDsListaMembresias, "Agregar");
            ObjConexion.Close();

            return ObjDsListaMembresias;
        }

        public DataSet Select_ListadoClientes(string Cia)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaClient = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
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
        


        //Dataset donde se obtendra la tabla que generará el menu dinamico
        public DataSet MenuDinamico(string Usuario, string Cia, string CodigoApls)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);


            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GeneraMenu";

            SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Usuario"].Value = Usuario;

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@CodigoApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CodigoApls"].Value = CodigoApls;

            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas);
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }

        //tablas para generar la cabecera del menu dinamico
        public DataSet MenuCabecera(string Usuario, string Cia, string CodigoApls)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);


            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GeneraMenuCabecera";

            SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Usuario"].Value = Usuario;

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@CodigoApls", SqlDbType.NVarChar);
            SqlCmd.Parameters["@CodigoApls"].Value = CodigoApls;

            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas);
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }


        public DataSet ListadoDeCobros(string Cia, string FechaDesde, string FechaHasta ,int TipoMov, string Contrato, string CodigoCobrador)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_RptListadoCobroRealizado";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@FechaDesde", SqlDbType.DateTime);
            SqlCmd.Parameters["@FechaDesde"].Value = FechaDesde;

            SqlCmd.Parameters.Add("@FechaHasta", SqlDbType.DateTime);
            SqlCmd.Parameters["@FechaHasta"].Value = FechaHasta;

            SqlCmd.Parameters.Add("@TipoMov", SqlDbType.Int);
            SqlCmd.Parameters["@TipoMov"].Value = TipoMov;

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = Contrato;

            SqlCmd.Parameters.Add("@Cobrador", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cobrador"].Value = CodigoCobrador;



            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas, "CobrosRealizados");
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }




        public DataSet ContratosDelMes(string Cia, string FechaDesde, string FechaHasta, string CodigoCobrador)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_RptContratosDelMes";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@FechaDesde", SqlDbType.DateTime);
            SqlCmd.Parameters["@FechaDesde"].Value = FechaDesde;

            SqlCmd.Parameters.Add("@FechaHasta", SqlDbType.DateTime);
            SqlCmd.Parameters["@FechaHasta"].Value = FechaHasta;
         
            SqlCmd.Parameters.Add("@Cobrador", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cobrador"].Value = CodigoCobrador;
            
            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas, "ContratosDelMes");
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }

    

        public DataSet UltimaCuotaDePrestamos(string Cia, string Fecha, string CodigoCobrador)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_RptUltimaCuotaContrato";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@Fecha", SqlDbType.Date);
            SqlCmd.Parameters["@Fecha"].Value = Fecha;

            SqlCmd.Parameters.Add("@Cobrador", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cobrador"].Value = CodigoCobrador;


            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas, "UltimaCuotaDePrestamos");
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }



        public DataSet PrestamosConBalance(string Cia, string FechaHasta, string CodigoCobrador, string Contrato)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_BalanceInteresYComision";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = Contrato;

            SqlCmd.Parameters.Add("@Cobrador", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cobrador"].Value = (CodigoCobrador ==null)? "": CodigoCobrador;

            SqlCmd.Parameters.Add("@FechaConsulta", SqlDbType.Date);
            SqlCmd.Parameters["@FechaConsulta"].Value = FechaHasta;


       


            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas, "PrestamosConBalance");
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }
        

               public DataSet CuotasVencidasYNoSaldadas(string Cia, string FechaHasta, string CodigoCobrador, string Contrato)
        {
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaFacturas = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaFacturas = default(SqlDataAdapter);

            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_TemporalVencido";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Contrato"].Value = Contrato;

            //SqlCmd.Parameters.Add("@Cobrador", SqlDbType.NVarChar);
            //SqlCmd.Parameters["@Cobrador"].Value = (CodigoCobrador == null) ? "" : CodigoCobrador;

            SqlCmd.Parameters.Add("@FechaConsulta", SqlDbType.Date);
            SqlCmd.Parameters["@FechaConsulta"].Value = FechaHasta;
            
            //SqlCmd.Parameters.Add("@MostrarMora", SqlDbType.Int);
            //SqlCmd.Parameters["@MostrarMora"].Value = 0;

            daListaFacturas = new SqlDataAdapter(SqlCmd);
            daListaFacturas.Fill(ObjDsListaFacturas, "CuotasVencidas");
            ObjConexion.Close();

            return ObjDsListaFacturas;
        }



        public DataSet ValidaCedORnc(string Cia, string CedRncClte)
        {
          


                ConexionDB Conn = new ConexionDB();
                DataSet ObjDsListaCobradores = new DataSet();
                SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
                SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
                ObjConexion.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_ConsultaClienteCedORnc";

                SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Cia"].Value = Cia;
                
                SqlCmd.Parameters.Add("@CedulaORnc", SqlDbType.NVarChar);
                SqlCmd.Parameters["@CedulaORnc"].Value = CedRncClte;
                
                //SqlCmd.ExecuteNonQuery();
                daListaCobradores = new SqlDataAdapter(SqlCmd);
                daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
                ObjConexion.Close();
            //if (ObjDsListaCobradores.Tables[0].Rows.Count>=1)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //    //daListaCobradores.Fill(ObjDsListaCobradores);
            //    //ObjConexion.Close();   
            return ObjDsListaCobradores;

        }
        public bool ValidaCedORnc2(string CedRncClte)
        {
            bool respuesta = false;
            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            SqlCommand SqlCmd = new SqlCommand();
            try
            {
                ObjConexion.Open();

              
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spConcultarCedula_Rnc";

                

                SqlCmd.Parameters.Add("@Cedula_Rnc", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Cedula_Rnc"].Value = CedRncClte;
                daListaCobradores = new SqlDataAdapter(SqlCmd);
                        daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
                ObjConexion.Close();
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            finally
            {
                ObjConexion.Close();
            }


            if ((ObjDsListaCobradores.Tables[0].Rows.Count)>0)
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }

            return respuesta;
        }



        public DataSet VerificaRalacion(string Cia, string CodigoCobrador, string FechaConsulta)
        {
           
       

                ConexionDB Conn = new ConexionDB();
                DataSet ObjDsListaCobradores = new DataSet();
                SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
                SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
                ObjConexion.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_SelectRelacionCobrador";

                SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Cia"].Value = Cia;

                SqlCmd.Parameters.Add("@COBRADOR", SqlDbType.NVarChar);
                SqlCmd.Parameters["@COBRADOR"].Value = CodigoCobrador;

                SqlCmd.Parameters.Add("@FechaConsulta", SqlDbType.Date);
                SqlCmd.Parameters["@FechaConsulta"].Value = FechaConsulta;



            daListaCobradores = new SqlDataAdapter(SqlCmd);
            //daListaCobradores.Fill(ObjDsListaCobradores, "Result");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();
            return ObjDsListaCobradores;


        }




        public DataSet GenerarRelacion(string Cia, string Usuario, string CodigoCobrador, string FechaConsulta, int EliminaRelacion)
        {



            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "sp_GeneraRelacionCobrador";

            SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Cia"].Value = Cia;

            SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
            SqlCmd.Parameters["@Usuario"].Value = Usuario ;

            SqlCmd.Parameters.Add("@COBRADOR", SqlDbType.NVarChar);
            SqlCmd.Parameters["@COBRADOR"].Value = CodigoCobrador;

            SqlCmd.Parameters.Add("@FechaConsulta", SqlDbType.Date);
            SqlCmd.Parameters["@FechaConsulta"].Value = FechaConsulta;

            SqlCmd.Parameters.Add("@EliminaRelacion", SqlDbType.Int);
            SqlCmd.Parameters["@EliminaRelacion"].Value = EliminaRelacion;



            daListaCobradores = new SqlDataAdapter(SqlCmd);
            daListaCobradores.Fill(ObjDsListaCobradores, "ResultadoRel");
            ObjConexion.Close();
            
            


            return ObjDsListaCobradores;

        }



        public DataSet ActualizaTablasdePrestamo(string Cia, string Usuario, string Contrato, string CuotasOriginales, string BALANCE, string MontoPtm, float TasaInteres, string FechaContrato, string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns, string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales, string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales, string Redondea)
        {

      
                ConexionDB Conn = new ConexionDB();
                DataSet ObjDsListaCobradores = new DataSet();
                SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
                SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
                ObjConexion.Open();

                decimal balance = 100;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = ObjConexion;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_ActualizaRecalculo";


                SqlCmd.Parameters.Add("@Cia", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Cia"].Value = Cia;

                SqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Usuario"].Value = Usuario;

                SqlCmd.Parameters.Add("@Contrato", SqlDbType.NVarChar);
                SqlCmd.Parameters["@Contrato"].Value = Contrato;

                SqlCmd.Parameters.Add("@CuotasOriginales", SqlDbType.NVarChar);
                SqlCmd.Parameters["@CuotasOriginales"].Value = CuotasOriginales;

                SqlCmd.Parameters.Add("@BALANCE", SqlDbType.Decimal);
                SqlCmd.Parameters["@BALANCE"].Value = Convert.ToDecimal(BALANCE);

                SqlCmd.Parameters.Add("@MontoPtm", SqlDbType.Decimal);
                SqlCmd.Parameters["@MontoPtm"].Value = Convert.ToDecimal(MontoPtm);

                SqlCmd.Parameters.Add("@TasaInteres", SqlDbType.Float);
                SqlCmd.Parameters["@TasaInteres"].Value = TasaInteres;

                SqlCmd.Parameters.Add("@FechaContrato", SqlDbType.DateTime);
                SqlCmd.Parameters["@FechaContrato"].Value = FechaContrato;

                SqlCmd.Parameters.Add("@Fecha1raCuota", SqlDbType.DateTime);
                SqlCmd.Parameters["@Fecha1raCuota"].Value = Fecha1raCuota;

                SqlCmd.Parameters.Add("@NoCuotas", SqlDbType.Int);
                SqlCmd.Parameters["@NoCuotas"].Value = Cuota;

                SqlCmd.Parameters.Add("@NoCuotasOtros", SqlDbType.Int);
                SqlCmd.Parameters["@NoCuotasOtros"].Value = NoCuotasOtros;

                SqlCmd.Parameters.Add("@Vencimiento ", SqlDbType.TinyInt);
                SqlCmd.Parameters["@Vencimiento "].Value = Vencimiento;

                SqlCmd.Parameters.Add("@AbsOIns", SqlDbType.TinyInt);
                SqlCmd.Parameters["@AbsOIns"].Value = AbsOIns;

                SqlCmd.Parameters.Add("@Frecuencia", SqlDbType.TinyInt);
                SqlCmd.Parameters["@Frecuencia"].Value = Frecuencia;

                SqlCmd.Parameters.Add("@TipoTabla", SqlDbType.TinyInt);
                SqlCmd.Parameters["@TipoTabla"].Value = 1;

                SqlCmd.Parameters.Add("@Inicial", SqlDbType.Decimal);
                SqlCmd.Parameters["@Inicial"].Value = Inicial;

                SqlCmd.Parameters.Add("@Traspaso", SqlDbType.Decimal);
                SqlCmd.Parameters["@Traspaso"].Value = Traspaso;

                SqlCmd.Parameters.Add("@Registro", SqlDbType.Decimal);
                SqlCmd.Parameters["@Registro"].Value = Registro;

                SqlCmd.Parameters.Add("@Seguro", SqlDbType.Decimal);
                SqlCmd.Parameters["@Seguro"].Value = Seguro;

                SqlCmd.Parameters.Add("@Exoneracion", SqlDbType.Decimal);
                SqlCmd.Parameters["@Exoneracion"].Value = Exoneracion;

                SqlCmd.Parameters.Add("@Legal", SqlDbType.Decimal);
                SqlCmd.Parameters["@Legal"].Value = Legal;

                SqlCmd.Parameters.Add("@Otros", SqlDbType.Decimal);
                SqlCmd.Parameters["@Otros"].Value = Otros;

                SqlCmd.Parameters.Add("@CuotasEspeciales", SqlDbType.TinyInt);
                SqlCmd.Parameters["@CuotasEspeciales"].Value = CuotasEspeciales;

                SqlCmd.Parameters.Add("@CantCuotasEspeciales", SqlDbType.Int);
                SqlCmd.Parameters["@CantCuotasEspeciales"].Value = CuotasEspeciales;

                SqlCmd.Parameters.Add("@str#CuotasEspeciales", SqlDbType.NVarChar);
                SqlCmd.Parameters["@str#CuotasEspeciales"].Value = strCuotasEspeciales;

                SqlCmd.Parameters.Add("@strValorCuotasEspeciales", SqlDbType.NVarChar);
                SqlCmd.Parameters["@strValorCuotasEspeciales"].Value = strValorCuotasEspeciales;

                SqlCmd.Parameters.Add("@Redondea", SqlDbType.TinyInt);
                SqlCmd.Parameters["@Redondea"].Value = Redondea;

                daListaCobradores = new SqlDataAdapter(SqlCmd);

                //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
                daListaCobradores.Fill(ObjDsListaCobradores);
                ObjConexion.Close();

                return ObjDsListaCobradores;

             }





    public DataSet CreaTablaDeAmortizacion(string MontoPtm, float TasaInteres, string FechaContrato,
        string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns,
        string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, 
        string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales,
        string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales,
        string Redondea)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            SqlDataAdapter daListaCobradores = default(SqlDataAdapter);
            ObjConexion.Open();

            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = ObjConexion;

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "spCrearTablaAmortizacion";

            SqlCmd.Parameters.Add("@MontoPtm", SqlDbType.Decimal);
            SqlCmd.Parameters["@MontoPtm"].Value = Convert.ToDecimal(MontoPtm);

            SqlCmd.Parameters.Add("@TasaInteres", SqlDbType.Float);
            SqlCmd.Parameters["@TasaInteres"].Value = TasaInteres;

            SqlCmd.Parameters.Add("@FechaContrato", SqlDbType.DateTime);
            SqlCmd.Parameters["@FechaContrato"].Value = FechaContrato;

            SqlCmd.Parameters.Add("@Fecha1raCuota", SqlDbType.DateTime);
            SqlCmd.Parameters["@Fecha1raCuota"].Value = Fecha1raCuota;

            SqlCmd.Parameters.Add("@NoCuotas", SqlDbType.Int);
            SqlCmd.Parameters["@NoCuotas"].Value = Cuota;

            SqlCmd.Parameters.Add("@NoCuotasOtros", SqlDbType.Int);
            SqlCmd.Parameters["@NoCuotasOtros"].Value = NoCuotasOtros;

            SqlCmd.Parameters.Add("@Vencimiento", SqlDbType.TinyInt);
            SqlCmd.Parameters["@Vencimiento"].Value = Vencimiento;

            SqlCmd.Parameters.Add("@AbsOIns", SqlDbType.TinyInt);
            SqlCmd.Parameters["@AbsOIns"].Value = AbsOIns;

            SqlCmd.Parameters.Add("@Frecuencia", SqlDbType.TinyInt);
            SqlCmd.Parameters["@Frecuencia"].Value = Frecuencia;

            SqlCmd.Parameters.Add("@TipoTabla", SqlDbType.TinyInt);
            SqlCmd.Parameters["@TipoTabla"].Value = 1;

            SqlCmd.Parameters.Add("@Inicial", SqlDbType.Decimal);
            SqlCmd.Parameters["@Inicial"].Value = Inicial;

            SqlCmd.Parameters.Add("@Traspaso", SqlDbType.Decimal);
            SqlCmd.Parameters["@Traspaso"].Value = Traspaso;

            SqlCmd.Parameters.Add("@Registro", SqlDbType.Decimal);
            SqlCmd.Parameters["@Registro"].Value = Registro;

            SqlCmd.Parameters.Add("@Seguro", SqlDbType.Decimal);
            SqlCmd.Parameters["@Seguro"].Value = Seguro;

            SqlCmd.Parameters.Add("@Exoneracion", SqlDbType.Decimal);
            SqlCmd.Parameters["@Exoneracion"].Value = Exoneracion;

            SqlCmd.Parameters.Add("@Legal", SqlDbType.Decimal);
            SqlCmd.Parameters["@Legal"].Value = Legal;

            SqlCmd.Parameters.Add("@Otros", SqlDbType.Decimal);
            SqlCmd.Parameters["@Otros"].Value = Otros;

            SqlCmd.Parameters.Add("@CuotasEspeciales", SqlDbType.TinyInt);
            SqlCmd.Parameters["@CuotasEspeciales"].Value = CuotasEspeciales;

            SqlCmd.Parameters.Add("@CantCuotasEspeciales", SqlDbType.Int);
            SqlCmd.Parameters["@CantCuotasEspeciales"].Value = CuotasEspeciales;

            SqlCmd.Parameters.Add("@str#CuotasEspeciales", SqlDbType.NVarChar);
            SqlCmd.Parameters["@str#CuotasEspeciales"].Value = strCuotasEspeciales;

            SqlCmd.Parameters.Add("@strValorCuotasEspeciales", SqlDbType.NVarChar);
            SqlCmd.Parameters["@strValorCuotasEspeciales"].Value = strValorCuotasEspeciales;

            SqlCmd.Parameters.Add("@Redondea", SqlDbType.TinyInt);
            SqlCmd.Parameters["@Redondea"].Value = Redondea;


            daListaCobradores = new SqlDataAdapter(SqlCmd);

            //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
            daListaCobradores.Fill(ObjDsListaCobradores);
            ObjConexion.Close();

            return ObjDsListaCobradores;
        }

    //-------------------------------------------------------------------------------------------------//
        public DataSet InsertGeneric(string TableName, string Columns)
        {

            ConexionDB Conn = new ConexionDB();
            DataSet ObjDsListaCobradores = new DataSet();
            SqlConnection ObjConexion = new SqlConnection(Conn.ObtenerConexion_PrestamosCompactoWEB());
            ObjConexion.Open();
            try
            {
                if (ObjConexion.State == ConnectionState.Open)
                {
                    SqlDataAdapter daListaCobradores = default(SqlDataAdapter);


                    decimal balance = 100;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = ObjConexion;

                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = "sp_InsertGeneric";


                    SqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                    SqlCmd.Parameters["@TableName"].Value = TableName;

                    SqlCmd.Parameters.Add("@Columns", SqlDbType.NVarChar);
                    SqlCmd.Parameters["@Columns"].Value = Columns;

                    daListaCobradores = new SqlDataAdapter(SqlCmd);

                    //daListaCobradores.Fill(ObjDsListaCobradores, "Resultado");
                    daListaCobradores.Fill(ObjDsListaCobradores);
                    ObjConexion.Close();
                }


            }
            catch (SqlException ex)
            {
                ex.State.ToString();
                ex.HResult.ToString();
            }
            catch (Exception ex)
            {

                    ex.Message.ToString();
              
            }
            finally
            {
                ObjConexion.Close();
            }
           
            
        
           

            return ObjDsListaCobradores;

        }

    }
}
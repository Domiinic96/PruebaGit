using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod()]
        public DataSet Acceso(string User, string Clave)
        {
            AccesoDB DB = new AccesoDB();
            return DB.Acceso(User, Clave);
        }

        [WebMethod()]
        public DataSet ConsultaCia(string Cia)
        {
            AccesoDB DB = new AccesoDB();
            return DB.ConsultaCia(Cia);
        }

        //[WebMethod]
        //public DataSet ConsultaParametros() {
        //    AccesoDB DB = new AccesoDB();
        //    return DB.ConsultaParametros();
        //}

        //[WebMethod]
        //public DataSet MayorGeneral(string Cia, DateTime FechaMayor, int CuadrePrestamo)
        //{
        //    AccesoDB DB = new AccesoDB();
        //    return DB.MayorGeneral(Cia, FechaMayor, CuadrePrestamo);
        //}

        //[WebMethod]
        //public DataSet Balanza(string Cia, string MesCadena, string TableName, string Usuario, string Pc)
        //{
        //    AccesoDB DB = new AccesoDB();
        //    return DB.Balanza(Cia, MesCadena, TableName, Usuario, Pc);
        //}

        //[WebMethod]
        //public DataSet Auxiliares(string Cia, string FechaHasta, string Cuenta, string Auxiliar) {
        //    AccesoDB DB = new AccesoDB();
        //    return DB.Auxiliares(Cia, FechaHasta, Cuenta, Auxiliar);
        //}

        //[WebMethod]
        //public DataSet DiarioGeneral(string Cia, DateTime FechaDesde, DateTime FechaHasta, string TipoDoc) {
        //    AccesoDB DB = new AccesoDB();
        //    return DB.DiarioGeneral(Cia, FechaDesde, FechaHasta, TipoDoc);
        //}

        //[WebMethod]
        //public DataSet Cuentas(string Cia, DateTime FechaCuentas, int cuadre)
        //{
        //    AccesoDB DB = new AccesoDB();
        //    return DB.Cuentas(Cia, FechaCuentas, cuadre);
        //}

        //[WebMethod]
        //public DataSet RptMovAux(string Cia, DateTime FechaDesde, DateTime FechaHasta, string Cuenta, string Auxiliar) {
        //    AccesoDB DB = new AccesoDB();
        //    return DB.RptMovAux(Cia, FechaDesde, FechaHasta, Cuenta, Auxiliar);
        //}

        //[WebMethod]
        //public DataSet RptBalanceAuxiliares(string Cia, DateTime FechaHasta, string Cuenta, string Auxiliar) { 
        //AccesoDB DB = new AccesoDB();
        //return DB.RptBalanceAuxiliares(Cia, FechaHasta, Cuenta, Auxiliar);
        //}

        //[WebMethod]
        //public bool RegistraCuentas(CNT_MaestroCuenta model)
        //{
        //    WSRegistraCuentas RegCuentas = new WSRegistraCuentas();
        //    return RegCuentas.RegistraCuentas(model);
        //}

        //[WebMethod]
        //public bool RegCodificaRecibosEmitidos(MaestroRc model)
        //{
        //    WSCodificaRecibosEmitidos RegCodEmi = new WSCodificaRecibosEmitidos();
        //    return RegCodEmi.RegCodificaRecibosEmitidos(model);
        //}

        //[WebMethod]
        //public DataSet SelAux_MaestraAuxiliares()
        //{
        //    WSRegistraCuentas SelAux = new WSRegistraCuentas();
        //    return SelAux.SelAux_MaestraAuxiliares();
        //}

        //[WebMethod]
        //public DataSet Sel_ConvRecRegDep()
        //{
        //    WSConvierteRecibosEnRegistrosDeDepositos SelRegDep = new WSConvierteRecibosEnRegistrosDeDepositos();
        //    return SelRegDep.Sel_ConvRecRegDep();
        //}

        //[WebMethod]
        //public DataSet Selec_MaestraConceptoRc()
        //{
        //    WSEmiteReciboDeCaja SelConcepto = new WSEmiteReciboDeCaja();
        //    return SelConcepto.Selec_MaestraConceptoRc();
        //}

        //public DataSet Selec_MaestraCliente()
        //{
        //    WSEmiteReciboDeCaja SelCliente = new WSEmiteReciboDeCaja();
        //    return SelCliente.Selec_MaestraCliente();
        //}

        //[WebMethod]
        //public DataSet Selecc_MaestraConceptoRc()
        //{
        //    WSRegistraConceptoParaRecibos SelConcepto = new WSRegistraConceptoParaRecibos();
        //    return SelConcepto.Selecc_MaestraConceptoRc();
        //}

        //[WebMethod]
        //public DataSet Selecc_MaestraCuenta()
        //{
        //    WSConsultaCuentaDeCatalogo SelCuenta = new WSConsultaCuentaDeCatalogo();
        //    return SelCuenta.Selecc_MaestraCuenta();
        //}

        //[WebMethod]
        //public bool Reg_MaestraCliente(GRL_MaestroClientes model)
        //{
        //    WSRegistraMaestraDeAuxiliares RegAux = new WSRegistraMaestraDeAuxiliares();
        //    return RegAux.MaestraCliente(model);
        //}

        //[WebMethod]
        //public DataSet Selec_ReciboCodificado()
        //{
        //    WSCodificaRecibosEmitidos SelRecCod = new WSCodificaRecibosEmitidos();
        //    return SelRecCod.Selec_ReciboCodificado();
        //}

        //[WebMethod]
        //public string SelAux_MaestraAuxiliares2(string codigo)
        //{
        //    WSRegistraCuentas SelAux = new WSRegistraCuentas();
        //    return SelAux.SelAux_MaestraAuxiliares2(codigo);
        //}

        //[WebMethod]
        //public string[] SelBco(string codigo)
        //{
        //    WSConvierteRecibosEnRegistrosDeDepositos SelRegDep = new WSConvierteRecibosEnRegistrosDeDepositos();
        //    return SelRegDep.SelBco(codigo);
        //}

        //[WebMethod]
        //public string SelCli(string codigo)
        //{
        //    WSEmiteReciboDeCaja SelRegDep = new WSEmiteReciboDeCaja();
        //    return SelRegDep.SelCli(codigo);
        //}

        //[WebMethod]
        //public string SelConcepto(string codigo)
        //{
        //    WSRegistraConceptoParaRecibos SelCon = new WSRegistraConceptoParaRecibos();
        //    return SelCon.SelConcepto(codigo);
        //}

        //[WebMethod]
        //public string SelCuenta(string codigo)
        //{
        //    WSConsultaCuentaDeCatalogo SelCuen = new WSConsultaCuentaDeCatalogo();
        //    return SelCuen.SelCuenta(codigo);
        //}

        //[WebMethod]
        //public string SelCuenta1(string codigo)
        //{
        //    WSMovimientosDeContabilidad SelCuen1 = new WSMovimientosDeContabilidad();
        //    return SelCuen1.SelCuenta1(codigo);
        //}

        //[WebMethod]
        //public string SelCuenta2(string codigo)
        //{
        //    WSConsultaCuentas SelCuen2 = new WSConsultaCuentas();
        //    return SelCuen2.SelCuenta2(codigo);
        //}

        //[WebMethod]
        //public string SelAux_MaestraAuxiliares3(string codigo)
        //{
        //    WSMovimientosDeContabilidad SelAux1 = new WSMovimientosDeContabilidad();
        //    return SelAux1.SelAux_MaestraAuxiliares3(codigo);
        //}

        //[WebMethod]
        //public string SelAux_MaestraAuxiliares4(string codigo)
        //{
        //    WSConsultaCuentas SelAux2 = new WSConsultaCuentas();
        //    return SelAux2.SelAux_MaestraAuxiliares4(codigo);
        //}

        //[WebMethod]
        //public string SelAux_MaestraAuxiliares5(string codigo)
        //{
        //    WSConsultaCuentaDeCatalogo SelAux3 = new WSConsultaCuentaDeCatalogo();
        //    return SelAux3.SelAux_MaestraAuxiliares5(codigo);
        //}

        //[WebMethod]
        //public DataSet Selec_MaestraCuenta()
        //{
        //    WSMovimientosDeContabilidad SelCuenta = new WSMovimientosDeContabilidad();
        //    return SelCuenta.Selec_MaestraCuenta();
        //}

        //[WebMethod]
        //public DataSet SeleAux_MaestraAuxiliares()
        //{
        //    WSMovimientosDeContabilidad SelAux = new WSMovimientosDeContabilidad();
        //    return SelAux.SeleAux_MaestraAuxiliares();
        //}

        //[WebMethod]
        //public DataSet Selec_MaestraCuenta1()
        //{
        //    WSConsultaCuentas SelCuenta = new WSConsultaCuentas();
        //    return SelCuenta.Selec_MaestraCuenta1();
        //}

        //[WebMethod]
        //public DataSet SeleAux_MaestraAuxiliares1()
        //{
        //    WSConsultaCuentas SelAux = new WSConsultaCuentas();
        //    return SelAux.SeleAux_MaestraAuxiliares1();
        //}

        //[WebMethod]
        //public bool RegistraMovimientosDeContabilidad(CNT_MovimientosContabilidad model)
        //{
        //    WSMovimientosDeContabilidad RegMovimientosDeCont = new WSMovimientosDeContabilidad();
        //    return RegMovimientosDeCont.RegMovimientosDeContabilidad(model);
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////AQUI SE VAN A TRABAJAR LOS NUEVOS WEBMETHOD/////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        //[WebMethod]
        //public bool RegistraCias(SEG_MaestroCias model)
        //{
        //    clFacturas RegCias = new clFacturas();
        //    return RegCias.RegistraCias(model);
        //}

        [WebMethod]
        public DataSet RegistraCias(string Columns )
        {
            clFacturas RegCias = new clFacturas();
            return RegCias.RegistraCias(Columns);
        }


        [WebMethod]
        public Boolean RegistraClientes(GRL_MaestroClientes model)
        {
            clFacturas RegCliente = new clFacturas();
            return RegCliente.RegistraClientes(model);
        }


        [WebMethod]
        public DataSet ValidaCedORnc(string Cia, string CedRncClte)
        {
            clFacturas ValCedORnc = new clFacturas();
            return ValCedORnc.ValidaCedORnc(Cia, CedRncClte);
        }


        [WebMethod]
        public DataSet GenerarRelacion(string Cia, string Usuario, string CodigoCobrador, string FechaConsulta, int EliminaRelacion )
        {
            clFacturas GeneraRel = new clFacturas();
            return GeneraRel.GenerarRelacion(Cia, Usuario, CodigoCobrador, FechaConsulta, EliminaRelacion);
        }


        [WebMethod]
        public DataSet VerificaRelacion(string  cia, string CodigoCobrador, string FechaConsulta)
        {
            clFacturas VerificaRel   = new clFacturas();
            return VerificaRel.VerificaRalacion(cia, CodigoCobrador, FechaConsulta);
        }



        [WebMethod]
        public Boolean EliminaCliente(GRL_MaestroClientes model)
        {
            clFacturas EliminsCliente = new clFacturas();
            return EliminsCliente.EliminaCliente(model);
        }


        

        [WebMethod]
        public Boolean ActualizaCliente(GRL_MaestroClientes model)
        {
            clFacturas ActCliente = new clFacturas();
            return ActCliente.ActualizaCliente(model);
        }


        [WebMethod]
        public Boolean RegistraPrestamos(PTC_MaestroPrestamos model)
        {
            clFacturas RegPrestamos = new clFacturas();
            return RegPrestamos.RegistraPrestamos(model);
        }



        [WebMethod]
        public DataSet EliminaPrestamo(string Contrato)
        {
            clFacturas EliminsPrestamo = new clFacturas();
            return EliminsPrestamo.EliminaPrestamo(Contrato);
        }


        [WebMethod]
        public DataSet ActualizaPrestamo(string Contrato)
        {
            clFacturas ActPrestamo = new clFacturas();
            return ActPrestamo.ActualizaPrestamo(Contrato);
        }



        //[WebMethod]
        //public DataSet RegistraMovimientosaContratos(string Columns)
        //{
        //    clFacturas RegMovContratos = new clFacturas();
        //    return RegMovContratos.RegistraMovimientosaContratos(Columns);
        //}


        [WebMethod]
        public DataSet GetClienteInfo(string CedRncClte, string Cia)
        {
            clFacturas GetInfo = new clFacturas();
            return GetInfo.GetInfoCliente(CedRncClte, Cia);
        }

        [WebMethod]
        public DataSet GetPrestamoInfo(string NoPrestamo, string Cia)
        {
            clFacturas GetPInfo = new clFacturas();
            return GetPInfo.GetPrestamoInfo(NoPrestamo, Cia);
        }

        [WebMethod]
        public DataSet GetCuotasPrestamo(string NoPrestamo, string Cia)
        {
            clFacturas GetCuotaInfo = new clFacturas();
            return GetCuotaInfo.GetCuotasPrestamo(NoPrestamo, Cia);
        }

        [WebMethod]
        public DataSet GetConsulPagosPrestamos(string NoPrestamo, string Cia, string FechaConsulta)
        {
            clFacturas GetCuotaInfo = new clFacturas();
            return GetCuotaInfo.GetConsulPagosPrestamos(NoPrestamo, Cia, FechaConsulta);
        }

        [WebMethod]
        public DataSet GetTemporalVencido(string NoPrestamo, string Cia, DateTime FechaConsulta, int MostrarMora)
        {
            clFacturas GetTemVenc = new clFacturas();
            return GetTemVenc.GetTemporalVencido(NoPrestamo, Cia, FechaConsulta, MostrarMora);
        }


        [WebMethod]
        public Boolean RegistraMovPrestamos(PTC_PagosDePrestamo model)
        {
            clFacturas RegMovPrestamos = new clFacturas();
            return RegMovPrestamos.RegistraMovPrestamos(model);
        }


        [WebMethod]
        public DataSet GetMovimientoPrestamo(string NoPrestamo, string Cia)
        {
            clFacturas GetMovInfo = new clFacturas();
            return GetMovInfo.GetMovimientoPrestamo(NoPrestamo, Cia);
        }




        //[WebMethod]
        //public DataSet ActualizaMovimientosaContratos(string Columns)
        //{
        //    clFacturas ActMovContratos = new clFacturas();
        //    return ActMovContratos.ActualizaMovimientosaContratos(Columns);
        //}

        [WebMethod]
        public DataSet EliminaMovimientosaContratos(string Columns)
        {
            clFacturas EliminaMovContratos = new clFacturas();
            return EliminaMovContratos.EliminaMovimientosaContratos(Columns);
        }

        [WebMethod()]
        public DataSet ConsultaApls()
        {
            clFacturas ConsultaApls = new clFacturas();
            return ConsultaApls.ConsultaApls();
        }

        //[WebMethod]
        //public DataSet RegistraCias(string Columns)
        //{
        //    clFacturas RegCias = new clFacturas();
        //    return RegCias.RegistraCias(Columns);
        //}

        [WebMethod]
        public DataSet GetConsPrestamo(string Contrato, string Cia)
        {
            clFacturas GetConsInfo = new clFacturas();
            return GetConsInfo.GetConsPrestamo(Contrato, Cia);
        }


        [WebMethod]
        public DataSet Select_ListadoClientes(string Cia)
        {
            clFacturas SelectListadoClientes = new clFacturas();
            return SelectListadoClientes.Select_ListadoClientes(Cia);
        }

        [WebMethod]
        public DataSet Select_ListadoCobradores()
        {
            clFacturas SelectListadoCobradores = new clFacturas();
            return SelectListadoCobradores.Select_ListadoCobradores();
        }
        
                 [WebMethod]
        public DataSet CreaTablaDeAmortizacion(string MontoPtm ,float TasaInteres, string FechaContrato, string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns, string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales, string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales, string Redondea)
        {
        clFacturas TablaDeAmortizacion = new clFacturas();
        return TablaDeAmortizacion.CreaTablaDeAmortizacion(MontoPtm, TasaInteres, FechaContrato, Fecha1raCuota, Cuota, NoCuotasOtros, Vencimiento, AbsOIns, Frecuencia, TipoTabla, Inicial, Traspaso, Registro, Seguro, Exoneracion, Legal, Otros, CuotasEspeciales, CantCuotasEspeciales, strCuotasEspeciales, strValorCuotasEspeciales, Redondea);
       }

        [WebMethod]
        public DataSet ActualizaTablasdePrestamo(string Cia, string Usuario, string Contrato, string CuotasOriginales, string BALANCE, string MontoPtm, float TasaInteres, string FechaContrato, string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns, string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales, string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales, string Redondea)
        {
            clFacturas ActualizaTablasPr = new clFacturas();
            return ActualizaTablasPr.ActualizaTablasdePrestamo(Cia, Usuario, Contrato, CuotasOriginales, BALANCE, MontoPtm, TasaInteres, FechaContrato, Fecha1raCuota, Cuota, NoCuotasOtros, Vencimiento, AbsOIns, Frecuencia, TipoTabla, Inicial, Traspaso, Registro, Seguro, Exoneracion, Legal, Otros, CuotasEspeciales, CantCuotasEspeciales, strCuotasEspeciales, strValorCuotasEspeciales, Redondea);
        }


        [WebMethod]
        public DataSet Parametros( string Cia)
        {
            clFacturas Param = new clFacturas();
            return Param.Parametros(Cia);
        }

        [WebMethod]
        public DataSet Select_ListadoContratos()
        {
            clFacturas SelectListadoContrato = new clFacturas();
            return SelectListadoContrato.Select_ListadoContratos();
        }

        [WebMethod]
        public DataSet Select_ListadoDocumentos()
        {
            clFacturas SelectListadoDocumentos = new clFacturas();
            return SelectListadoDocumentos.Select_ListadoDocumentos();
        }

        [WebMethod]
         public DataSet ListadoDeCobros(string Cia, string FechaDesde, string FechaHasta ,int TipoMov, string Contrato, string CodigoCobrador) {
           clFacturas ListCobros = new clFacturas();
            return ListCobros.ListadoDeCobros(Cia, FechaDesde, FechaHasta,TipoMov, Contrato, CodigoCobrador);
        }


     

            [WebMethod]
         public DataSet UltimaCuotaDePrestamos(string Cia, string Fecha, string CodigoCobrador)
        {
            clFacturas UltCuota = new clFacturas();
            return UltCuota.UltimaCuotaDePrestamos(Cia, Fecha, CodigoCobrador);
        }


        [WebMethod]
        public DataSet PrestamosConBalance(string Cia, string FechaHasta, string CodigoCobrador, string Contrato )
        {
            clFacturas PConBalance = new clFacturas();
            return PConBalance.PrestamosConBalance(Cia, FechaHasta, CodigoCobrador, Contrato);
        }


        [WebMethod]
        public DataSet CuotasVencidasYNoSaldadas(string Cia, string FechaHasta, string CodigoCobrador, string Contrato)
        {
            clFacturas CuotasVenc = new clFacturas();
            return CuotasVenc.CuotasVencidasYNoSaldadas(Cia, FechaHasta, CodigoCobrador, Contrato);
        }


        [WebMethod]
        public DataSet ContratoDelMes(string Cia, string FechaDesde, string FechaHasta, string CodigoCobrador)
        {
            clFacturas ContraDelMes = new clFacturas();
            return ContraDelMes.ContratosDelMes(Cia, FechaDesde, FechaHasta, CodigoCobrador);
        }
        [WebMethod]
        public DataSet InsertGeneric(string TableName, string Columns)
        {
            clFacturas insertgeneric = new clFacturas();
            return insertgeneric.InsertGeneric(TableName, Columns);
        }

        [WebMethod]
        public DataSet menuDinamico(string usuario, string cia, string codigoApls)
        {
            clFacturas menu = new clFacturas();
            return menu.MenuDinamico(usuario,cia,codigoApls);
        }

        [WebMethod]
        public DataSet menuCabecera(string usuario, string cia, string codigoApls)
        {
            clFacturas menu = new clFacturas();
            return menu.MenuCabecera(usuario, cia, codigoApls);
        }
    }
}

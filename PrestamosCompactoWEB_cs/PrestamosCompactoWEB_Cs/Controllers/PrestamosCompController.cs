using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrestamosCompactoWEB_Cs.Models;
using WebServices;

namespace PrestamosCompactoWEB_Cs.Controllers
{
    public class PrestamosCompController : Controller
    {
        // GET: Contabilidad
        VariablesGlobales vg = new VariablesGlobales(); //para poder invocar las variables que tengo en la clase Variables Golbales

        public ActionResult PRSC_Index()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;
            if ((Session["Cliente"] == null))
            {
                Session["Cliente"] = "Activo";
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult RegistraModificaEliminaClientes()

        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;
            string Cia = "001";//ESTO NO VA FIJO!! SOLO ES DE PRUEBA
           
            
           var db = vg.WS.Select_ListadoClientes(Cia);


            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoClientes
                       {
                           CodCliente = m.Field<string>("Cod_Cliente"),
                           NombreCliente = m.Field<string>("Nombre_Cliente"),
                           ApellidoCliente = m.Field<string>("Apellido_Cliente"),
                           Cedula = m.Field<string>("Cedula")
                       };

            ViewBag.Model = qrym;

            return View();
        }

        public ActionResult RegistraMaestradePrestamo()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;


            string Cia = Session["CodigoCia"].ToString();
            var db = vg.WS.Select_ListadoClientes(Cia);

            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoClientes
                       {
                           CodCliente = m.Field<string>("Cod_Cliente"),
                           NombreCliente = m.Field<string>("Nombre_Cliente"),
                           ApellidoCliente = m.Field<string>("Apellido_Cliente"),
                           Cedula = m.Field<string>("Cedula")
                       };

            ViewBag.ModelCliente = qrym;

            //////////////////////////////////////////////////////////////////////////////////////

            var db2= vg.WS.Select_ListadoCobradores();


            DataTable dt2 = db2.Tables[0];

            var qrym2 = from m in dt2.AsEnumerable().AsQueryable()
                       select new Select_ListadoCobradores
                       {
                           CodCobrador = m.Field<string>("CodigoOficial"),
                           NombreCobrador = m.Field<string>("Nombre_Cobrador")
                       };

            ViewBag.ModelCobrador = qrym2;

            //////////////////////////////////////////////////////////////////////////////////////

            var db3 = vg.WS.Select_ListadoContratos();


            DataTable dt3 = db3.Tables[0];

            var qrym3 = from m in dt3.AsEnumerable().AsQueryable()
                        select new Select_ListadoContratos
                        {
                            Contrato = m.Field<string>("Contrato"),
                            NomClteApls = m.Field<string>("NomClteApls"),
                            ApeClteApls = m.Field<string>("ApeClteApls"),
                            FechaPtm = m.Field<DateTime>("FechaPtm"),
                            MontoPtm = m.Field<decimal>("MontoPtm")
                        };

            ViewBag.ModelNPrestamo = qrym3;

            return View();
        }



        public ActionResult RegistraMovimientosaContratos()

        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db1 = vg.WS.Select_ListadoCobradores();
           

            DataTable dt1 = db1.Tables[0];

            var qrym1 = from m in dt1.AsEnumerable().AsQueryable()
                        select new Select_ListadoCobradores
                        {
                            CodCobrador = m.Field<string>("CodigoOficial"),
                            NombreCobrador = m.Field<string>("Nombre_Cobrador")
                        };

            ViewBag.ModelCobrador = qrym1;

            //////////////////////////////////////////////////////////////////////////////////////

            var db2 = vg.WS.Select_ListadoContratos();


            DataTable dt2 = db2.Tables[0];

            var qrym2 = from m in dt2.AsEnumerable().AsQueryable()
                        select new Select_ListadoContratos
                        {
                            Contrato = m.Field<string>("Contrato"),
                            NomClteApls = m.Field<string>("NomClteApls"),
                            ApeClteApls = m.Field<string>("ApeClteApls"),
                            FechaPtm = m.Field<DateTime>("FechaPtm"),
                            MontoPtm = m.Field<decimal>("MontoPtm")
                        };

            ViewBag.ModelNPrestamo = qrym2;

            //////////////////////////////////////////////////////////////////////////////////////

            var db3 = vg.WS.Select_ListadoDocumentos();


            DataTable dt3 = db3.Tables[0];

            var qrym3 = from m in dt3.AsEnumerable().AsQueryable()
                        select new Select_ListadoDocumentos
                        {
                            IDTipoDoc = m.Field<string>("IDTipoDoc"),
                            Descripcion = m.Field<string>("Descripcion")
                        };

            ViewBag.ModelTipoDoc = qrym3;

            return View();
        }

        [HttpPost]
        public ActionResult RegistraMovimientosaContratos(RegistraMovimientosaContratos model)
            
        {

           
            return RedirectToAction("GeneraRecibo", "Plantillas", new { NoPrestamo = model.NoPrestamo,   CedulaCliente= model.CedulaCliente,  NombreApellidoCliente = model.NombreApellidoCliente,  Movimiento = model.Movimiento,  NoDocumento = model.NoDocumento,  TipoDocumento = model.TipoDocumento,  FechaRc = model.Fecha,  codigoCobrador = model.codigoCobrador,  NombreCobrador = model.NombreCobrador,  Comentario = model.Comentario,  Pendientes = model.Pendientes,  Pagadas = model.Pagadas,  BalanceAlCobro = model.BalanceAlCobro,  FormaPagos = model.FormaPagos,  Capital = model.Capital,  Interes = model.Interes,  Otros = model.Otros,  Mora = model.Mora,  Total = model.Total, report = "ReciboDeContrato" });
        }


        public JsonResult GetMovimientoPrestamo(string Contrato)
        {
            string Cia = Session["CodigoCia"].ToString();
            
            var db = vg.WS.GetMovimientoPrestamo(Contrato, Cia);
            //var db = vg.WS.GetPrestamoInfo(Contrato, Cia);
            //var dbCuotas = vg.WS.GetCuotasPrestamo(Contrato, Cia);

            //GetPrestamoInfo

            DataTable dt = db.Tables[0];
            //DataTable dtCuotas = dbCuotas.Tables[0];

                    var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new RegistraMovimientosaContratos
                        {
                            NoPrestamo = m.Field<string>("Contrato"),
                            CedulaCliente = m.Field<string>("CedRncClteApls"),
                            NombreApellidoCliente = m.Field<string>("NombreCliente"),
                          // Movimiento = m.Field<byte>("MovDocCont"),
                            NoDocumento = m.Field<string>("NumDocCont"),
                            TipoDocumento = m.Field<string>("TipoDocCont"),
                            //Fecha = m.Field<DateTime>("FechaDocCont"),
                            codigoCobrador = m.Field<string>("CodigoCobrador"),
                            //Comentario = m.Field<string>("OtrosPtm"),
                            //Pendientes = m.Field<int>("TasaIntPtm"),
                            //Pagadas = m.Field<int>("TasaMoraPtm"),
                            //BalanceAlCobro = m.Field<decimal>("NombreCobrador"),
                            Capital = m.Field<decimal>("ValorPagoCapital"),
                            Interes = m.Field<decimal>("ValorPagoInteres"),
                            Otros = m.Field<decimal>("ValorPagoOtros"),
                            Mora = m.Field<decimal>("ValorpagoMora"),
                            Total = m.Field<decimal>("Total")
                        }).ToList();

            var obj = new { data = qrym.Select(x => new RegistraMovimientosaContratos { NoPrestamo = x.NoPrestamo ,CedulaCliente = x.CedulaCliente, NombreApellidoCliente = x.NombreApellidoCliente, Movimiento = x.Movimiento, NoDocumento = x.NoDocumento, TipoDocumento = x.TipoDocumento, Fecha = x.Fecha, codigoCobrador = x.codigoCobrador, Comentario = x.Comentario, Pendientes = x.Pendientes, Pagadas = x.Pagadas, BalanceAlCobro = x.BalanceAlCobro, Capital = x.Capital, Interes = x.Interes, FormaPagos = x.FormaPagos, Otros = x.Otros, Mora = x.Mora, Total = x.Total }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }


        public JsonResult GetInfoMaestroPrestamos(string Contrato)
        {
            string Cia = Session["CodigoCia"].ToString();

            var db = vg.WS.GetPrestamoInfo(Contrato, Cia);
            Session["dtCuotas"] = vg.WS.GetCuotasPrestamo(Contrato, Cia).Tables[0];

            DateTime FechaConsulta = DateTime.Now.Date;
            int MostrarMora = 0;
            DataTable dt = db.Tables[0];


            var dbTemporal = vg.WS.GetTemporalVencido(Contrato, Cia, FechaConsulta, MostrarMora);

            DataTable dbTemporal2 = dbTemporal.Tables[0];
            decimal Balance = 0;
            for (int x = 0; x <= dbTemporal2.Rows.Count - 1; x++)
            {
                Balance += Convert.ToDecimal(dbTemporal2.Rows[x]["ValorCuotaCap"]);
            }

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new RegistraMaestradePrestamo
                        {
                            CedulaCliente = m.Field<string>("CedRncClteApls"),
                            NombreApellido = m.Field<string>("NombreCliente"),
                            MontoPrestamo = m.Field<decimal>("MontoPtm").ToString(),
                            NoCuotas = m.Field<Int16>("CuotasPtm").ToString(),
                            FechaPrestamo = m.Field<DateTime>("FechaPtm").ToString("dd/MM/yyyy"),
                            FrecuenciaPagos = m.Field<byte>("FrecuenciaCuotaPtm").ToString(),
                            CodigoCobradorAsignado = m.Field<string>("Cobrador"),
                            ValorOtros = m.Field<decimal>("OtrosPtm").ToString(),
                            TasaInteres = m.Field<decimal>("TasaIntPtm").ToString(),
                            TasaMora = m.Field<decimal>("TasaMoraPtm").ToString(),
                            NombreCobradorAsignado = m.Field<string>("NombreCobrador"),
                            CuotasOtros = m.Field<short>("CuotasTraspPtm").ToString(),
                            FormaPagos = m.Field<byte>("Vencimiento").ToString(),
                            Balance = Balance.ToString(),
                            CuotasARecalcular = dbTemporal2.Rows.Count.ToString(),
                            NotaPtm = m.Field<string>("NotaPtm").ToString()

                        }).ToList();



            var obj = new { data = qrym.Select(x => new RegistraMaestradePrestamo { CedulaCliente = x.CedulaCliente, NombreApellido = x.NombreApellido, MontoPrestamo = x.MontoPrestamo, NoCuotas = x.NoCuotas, FechaPrestamo = x.FechaPrestamo, FrecuenciaPagos = x.FrecuenciaPagos, CodigoCobradorAsignado = x.CodigoCobradorAsignado, ValorOtros = x.ValorOtros, TasaInteres = x.TasaInteres, TasaMora = x.TasaMora, NombreCobradorAsignado = x.NombreCobradorAsignado, CuotasOtros = x.CuotasOtros, FormaPagos = x.FormaPagos, Balance = x.Balance, CuotasARecalcular = x.CuotasARecalcular, NotaPtm = x.NotaPtm }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }


        public JsonResult GetPrestamoInfo(string Contrato )
        {
            string Cia = Session["CodigoCia"].ToString();

          var db =  vg.WS.GetPrestamoInfo(Contrato, Cia);
            Session["dtCuotas"] = vg.WS.GetCuotasPrestamo(Contrato, Cia).Tables[0];
    
            DateTime FechaConsulta = DateTime.Now.Date;
            int MostrarMora = 0;
            DataTable dt = db.Tables[0];
       

            var dbTemporal = vg.WS.GetTemporalVencido(Contrato, Cia, FechaConsulta, MostrarMora);

            DataTable dbTemporal2 = dbTemporal.Tables[0];
            decimal Balance = 0;
            for (int x = 0; x <= dbTemporal2.Rows.Count - 1; x++)
            {
                Balance += Convert.ToDecimal(dbTemporal2.Rows[x]["ValorCuotaCap"]);
            }

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new RecalcularTablasdePrestamo
                        {
                            CedulaCliente = m.Field<string>("CedRncClteApls"),
                            NombreApellido = m.Field<string>("NombreCliente"),
                            MontoPrestamo = m.Field<decimal>("MontoPtm").ToString(),
                            NoCuotas = m.Field<Int16>("CuotasPtm").ToString(),
                            FechaPrestamo = m.Field<DateTime>("FechaPtm").ToString("dd/MM/yyyy"),
                            FrecuenciaPagos = m.Field<byte>("FrecuenciaCuotaPtm").ToString(),
                            CodigoCobradorAsignado = m.Field<string>("Cobrador"),
                            ValorOtros = m.Field<decimal>("OtrosPtm").ToString(),
                            TasaInteres = m.Field<decimal>("TasaIntPtm").ToString(),
                            TasaMora = m.Field<decimal>("TasaMoraPtm").ToString(),
                            NombreCobradorAsignado = m.Field<string>("NombreCobrador"),
                            CuotasOtros = m.Field<short>("CuotasTraspPtm").ToString(),
                            FormaPagos = m.Field<byte>("Vencimiento").ToString(),
                            Balance = Balance.ToString(),
                            CuotasARecalcular = dbTemporal2.Rows.Count.ToString(),
                            NotaPtm = m.Field<string>("NotaPtm").ToString()

                        }).ToList();

             

            var obj = new { data = qrym.Select(x => new RecalcularTablasdePrestamo { CedulaCliente = x.CedulaCliente, NombreApellido = x.NombreApellido, MontoPrestamo = x.MontoPrestamo, NoCuotas = x.NoCuotas,  FechaPrestamo = x.FechaPrestamo, FrecuenciaPagos = x.FrecuenciaPagos, CodigoCobradorAsignado = x.CodigoCobradorAsignado, ValorOtros = x.ValorOtros, TasaInteres = x.TasaInteres, TasaMora = x.TasaMora, NombreCobradorAsignado  = x.NombreCobradorAsignado, CuotasOtros = x.CuotasOtros, FormaPagos = x.FormaPagos, Balance = x.Balance, CuotasARecalcular = x.CuotasARecalcular, NotaPtm = x.NotaPtm }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }


        public JsonResult LoadCuotas(string Monto)
        {
            DataRow drow;
            decimal saldo1 = 0;
            decimal Capital = 0;
            decimal Interes = 0;
            decimal Otros = 0;
            DataTable dtCuotas = new DataTable();
            dtCuotas = (DataTable)Session["dtCuotas"];

            Session.Remove("dtCuotas");
            Session["dtCuotas"] = null;

            saldo1 = Convert.ToDecimal(Monto);
            for (int x = 0; x <= dtCuotas.Rows.Count - 1; x++)
            {
                saldo1 -= Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaCap"]);
                Capital += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaCap"]);
                Interes += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaInt"]);
                Otros += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaOtros"]);

                dtCuotas.Rows[x]["Saldo"] = saldo1.ToString("###,###,##0.00");
            }

            drow = dtCuotas.NewRow();
            drow["Contrato"] = "";
            drow["CuotaNumPtm"] = "";
            drow["FechaVencCuota"] = "01/01/2000";
            drow["Saldo"] = Convert.ToDecimal(Monto).ToString("###,###,##0.00");
            drow["ValorCuotaCap"] = "0";
            drow["ValorCuotaInt"] = "0";
            drow["ValorCuotaOtros"] = "0";

            dtCuotas.Rows.Add(drow);



            drow = dtCuotas.NewRow();
            drow["Contrato"] = "";
            drow["CuotaNumPtm"] = "ZZZ";
            drow["FechaVencCuota"] = "01/01/2000";
            drow["Saldo"] = "Totales:";
            drow["ValorCuotaCap"] = Capital;
            drow["ValorCuotaInt"] = Interes;
            drow["ValorCuotaOtros"] = Otros;

            dtCuotas.Rows.Add(drow);



            ConsultaVerTablaDetalle cons = new ConsultaVerTablaDetalle();

            cons.ConsultaVerTablaDetalles = (from i in dtCuotas.AsEnumerable().AsEnumerable()
                                             orderby i.Field<string>("CuotaNumPtm")
                                             select new ConsultaVerTabla
                                             {
                                                 Cuota = i.Field<string>("CuotaNumPtm"),
                                                 FechaVencCuota = i.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy"),
                                                 Saldo = i.Field<string>("Saldo"),
                                                 ValorCuota = (i.Field<decimal>("ValorCuotaCap") + i.Field<decimal>("ValorCuotaInt") + i.Field<decimal>("ValorCuotaOtros")).ToString("###,###,##0.00"),
                                                 Capital = i.Field<decimal>("ValorCuotaCap").ToString("###,###,##0.00"),
                                                 Interes = i.Field<decimal>("ValorCuotaInt").ToString("###,###,##0.00"),
                                                 Otros = i.Field<decimal>("ValorCuotaOtros").ToString("###,###,##0.00")
                                             }).ToList();



            var obj = new { data = cons.ConsultaVerTablaDetalles.Select(x => new ConsultaVerTabla { Cuota = x.Cuota, FechaVencCuota = x.FechaVencCuota, Saldo = x.Saldo, ValorCuota = x.ValorCuota, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarRegPrestamos(RegistraMaestradePrestamo model)
         {
            DateTime FechaHoraReg = DateTime.Now.Date;


            if ((vg.WS.RegistraPrestamos(new WebServices.PTC_MaestroPrestamos
            {
                Cia = @Session["CodigoCia"].ToString(),
                Usuario = @Session["Usuario"].ToString(),
                Contrato = model.NoPrestamo,
                MontoPtm = Convert.ToDecimal(model.MontoPrestamo),
                //CuotasPtm = model.NoCuotas,               
                FrecuenciaCuotaPtm = model.FrecuenciaPago,
                //TasaIntPtm = model.TasaInteres,
                //TasaMoraPtm = model.TasaMora,
                Cobrador = model.codigoCobradorAsignado,
                NotaPtm = model.NotaPtm
            })) == true)

            {
                ViewBag.PasoI = "Prestamo Registrado Correctamente";
                return RedirectToAction("RegistraMaestradePrestamo", "PrestamosComp");
            }
            else
            {
                Session["Paso"] = "Error, verifique los datos que esta tratando de registrar.";

                return RedirectToAction("RegistraMestradePrestamo", "PrestamosComp");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarRegMovPrestamos(RegistraMovimientosaContratos model)
        {
            DateTime FechaHoraReg = DateTime.Now.Date;


            if ((vg.WS.RegistraMovPrestamos(new WebServices.PTC_PagosDePrestamo
            {
                Cia = @Session["CodigoCia"].ToString(),
                Usuario = @Session["Usuario"].ToString(),
                Contrato = model.NoPrestamo,
                //FechaDocCont = model.Fecha,
                TipoDocCont = model.TipoDocumento,
                NumDocCont = model.NoDocumento,
                CodigoCobrador = model.codigoCobrador,
                MovDocCont = model.Movimiento,
                ValorPagoCapital = model.Capital,
                ValorPagoInteres = model.Interes,
                ValorPagoMora = model.Mora,
                ValorPagoOtros = model.Otros
            })) == true)

            {
                ViewBag.PasoI = "Prestamo Registrado Correctamente";
                return RedirectToAction("RegistraMovimientosaContratos", "PrestamosComp");
            }
            else
            {
                Session["Paso"] = "Error, verifique los datos que esta tratando de registrar.";

                return RedirectToAction("RegistraMovimientosaContratos", "PrestamosComp");
            }
        }

        public ActionResult CargaDescargaCobrosDesdeDispMovil()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            return View();
        }

        public ActionResult RecalcularTablasdePrestamo()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db = vg.WS.Select_ListadoContratos();


            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                        select new Select_ListadoContratos
                        {
                            Contrato = m.Field<string>("Contrato"),
                            NomClteApls = m.Field<string>("NomClteApls"),
                            ApeClteApls = m.Field<string>("ApeClteApls"),
                            FechaPtm = m.Field<DateTime>("FechaPtm"),
                            MontoPtm = m.Field<decimal>("MontoPtm")
                        };

            ViewBag.ModelNPrestamo = qrym;

            return View();
        }

        public JsonResult ActualizaTablasdePrestamo( string Contrato, string CuotasOriginales, string BALANCE, string MontoPtm, float TasaInteres, string FechaContrato, string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns, string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales, string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales, string Redondea, string CuotasOriginal, RecalcularTablasdePrestamo model)
        {
            string Cia = Session["CodigoCia"].ToString();
            string Usuario = Session["Usuario"].ToString();
            //string Cia = @Session["CodigoCia"].ToString();
            var db = vg.WS.ActualizaTablasdePrestamo( Cia,  Usuario,  Contrato,  CuotasOriginales, BALANCE, MontoPtm, TasaInteres, Convert.ToDateTime(FechaContrato).ToString("yyyy-MM-dd"), Convert.ToDateTime(Fecha1raCuota).ToString("yyyy-MM-dd"), Cuota, NoCuotasOtros, Vencimiento, AbsOIns, Frecuencia, Convert.ToByte(TipoTabla).ToString(), Convert.ToDecimal(Inicial).ToString(), Convert.ToDecimal(Traspaso).ToString(), Convert.ToDecimal(Registro).ToString(), Convert.ToDecimal(Seguro).ToString(), Convert.ToDecimal(Exoneracion).ToString(), Convert.ToDecimal(Legal).ToString(), Convert.ToDecimal(Otros).ToString(), CuotasEspeciales, CantCuotasEspeciales, strCuotasEspeciales, strValorCuotasEspeciales, Redondea);

            DataTable dt = db.Tables[0];

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new DescripcionError
                        {
                            CodError = m.Field<string>("Codigo"),
                            Descrip = m.Field<string>("Descripcion")
                     
                     
                        }).ToList();
          

            var obj = new { data = qrym.Select(x => new DescripcionError { CodError = x.CodError, Descrip = x.Descrip }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;





        }

        public ActionResult GenerarRelaciondeCobradores()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db = vg.WS.Select_ListadoCobradores();
            
            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                        select new Select_ListadoCobradores
                        {
                            CodCobrador = m.Field<string>("CodigoOficial"),
                            NombreCobrador = m.Field<string>("Nombre_Cobrador")
                        };

            ViewBag.ModelCobrador = qrym;

            return View();
        }

        public ActionResult ConsultaContrato()

        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db = vg.WS.Select_ListadoContratos();

            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoContratos
                       {
                           Contrato = m.Field<string>("Contrato"),
                           NomClteApls = m.Field<string>("NomClteApls"),
                           ApeClteApls = m.Field<string>("ApeClteApls"),
                           FechaPtm = m.Field<DateTime>("FechaPtm"),
                           MontoPtm = m.Field<decimal>("MontoPtm")
                       };

            ViewBag.ModelNPrestamo = qrym;

            return View();
        }

        public JsonResult ActualizaInfoConsultaContrato(string Contrato, string FechaConsulta)
        {
            string Cia = Session["CodigoCia"].ToString();

            if (FechaConsulta == "" || FechaConsulta == null) { FechaConsulta = DateTime.Now.Date.ToString("dd/MM/yyyy"); }

            Session["dtCuotas"] = vg.WS.GetCuotasPrestamo(Contrato, Cia).Tables[0];
            DataSet dsTemporal = vg.WS.GetTemporalVencido(Contrato, Cia, Convert.ToDateTime(FechaConsulta), 1);
            Session["dtCuotasVencidas"] = dsTemporal.Tables[0];
            Session["dtCalculoMora"] = dsTemporal.Tables[1];
            Session["dtMovimientos"] = vg.WS.GetConsulPagosPrestamos(Contrato, Cia, FechaConsulta).Tables[0];
            //GetPrestamoInfo

          
            var json = Json("", JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public JsonResult GetConsultaContrato(string Contrato,string FechaConsulta)
        {
            string Cia = Session["CodigoCia"].ToString();

            if (FechaConsulta == "" || FechaConsulta == null) { FechaConsulta = DateTime.Now.Date.ToString("dd/MM/yyyy"); }
            var db = vg.WS.GetConsPrestamo(Contrato, Cia);


            Session["dtCuotas"] = vg.WS.GetCuotasPrestamo(Contrato, Cia).Tables[0];
            DataSet dsTemporal = vg.WS.GetTemporalVencido(Contrato, Cia, Convert.ToDateTime(FechaConsulta), 1);
            Session["dtCuotasVencidas"] = dsTemporal.Tables[0];
            Session["dtCalculoMora"] = dsTemporal.Tables[1];
            Session["dtMovimientos"] = vg.WS.GetConsulPagosPrestamos(Contrato, Cia, FechaConsulta).Tables[0];
            //GetPrestamoInfo

            DataTable dt = db.Tables[0];
            //DataTable dtCuotas = dbCuotas.Tables[0];

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new ConsultaContrato
                        {
                            NoPrestamo = m.Field<string>("Contrato"),
                            CedulaCliente = m.Field<string>("CedRncClteApls"),
                            NombreApellido = m.Field<string>("NombreCliente"),
                            MontoPrestamo = m.Field<decimal>("MontoPtm"),
                            FechaPrestamo = m.Field<DateTime>("FechaPtm").ToString("dd/MM/yyyy"),
                            TasaInteres = m.Field<decimal>("TasaIntPtm"),
                            NoCuotas = m.Field<Int16>("CuotasPtm"),
                            Codigo = m.Field<string>("CodClteApls"),
                            NombreNegocio = m.Field<string>("EmpresaL"),
                            DireccionCobro = m.Field<string>("DireccionClteApls"),
                            CodigoCobradorAsignado = m.Field<string>("Cobrador"),
                            NombreCobradorAsignado = m.Field<string>("Nombre"),
                            Telefono = m.Field<string>("TelefonosClteApls"),
                            Celular = m.Field<string>("CelularClteApls"),
                            FechaConsulta = DateTime.Now.Date.ToString("dd/MM/yyyy")
                        }).ToList();



            var obj = new { data = qrym.Select(x => new ConsultaContrato { NoPrestamo = x.NoPrestamo, CedulaCliente = x.CedulaCliente, NombreApellido = x.NombreApellido, MontoPrestamo = x.MontoPrestamo, FechaPrestamo = x.FechaPrestamo, TasaInteres = x.TasaInteres, NoCuotas = x.NoCuotas, Codigo = x.Codigo, DireccionCobro = x.DireccionCobro, CodigoCobradorAsignado = x.CodigoCobradorAsignado, NombreCobradorAsignado = x.NombreCobradorAsignado, Telefono = x.Telefono, Celular = x.Celular, FechaConsulta = x.FechaConsulta, NombreNegocio = x.NombreNegocio }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult ConsultaAmortizacionparaPrestamos()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db2 = vg.WS.Select_ListadoContratos();


            DataTable dt2 = db2.Tables[0];

            var qrym2 = from m in dt2.AsEnumerable().AsQueryable()
                        select new Select_ListadoContratos
                        {
                            Contrato = m.Field<string>("Contrato"),
                            NomClteApls = m.Field<string>("NomClteApls"),
                            ApeClteApls = m.Field<string>("ApeClteApls"),
                            FechaPtm = m.Field<DateTime>("FechaPtm"),
                            MontoPtm = m.Field<decimal>("MontoPtm")
                        };

            ViewBag.ModelNPrestamo = qrym2;

            return View();
        }

        public JsonResult GetConsultaAmortizacion(string Contrato)
        {
            string Cia = Session["CodigoCia"].ToString();

            var db = vg.WS.GetPrestamoInfo(Contrato, Cia);
            Session["dtCuotas"] = vg.WS.GetCuotasPrestamo(Contrato, Cia).Tables[0];

            DateTime FechaConsulta = DateTime.Now.Date;
            int MostrarMora = 0;
            DataTable dt = db.Tables[0];


            var dbTemporal = vg.WS.GetTemporalVencido(Contrato, Cia, FechaConsulta, MostrarMora);

            DataTable dbTemporal2 = dbTemporal.Tables[0];
            decimal Balance = 0;
            for (int x = 0; x <= dbTemporal2.Rows.Count - 1; x++)
            {
                Balance += Convert.ToDecimal(dbTemporal2.Rows[x]["ValorCuotaCap"]);
            }

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new RecalcularTablasdePrestamo
                        {
                            CedulaCliente = m.Field<string>("CedRncClteApls"),
                            NombreApellido = m.Field<string>("NombreCliente"),
                            MontoPrestamo = m.Field<decimal>("MontoPtm").ToString(),
                            NoCuotas = m.Field<Int16>("CuotasPtm").ToString(),
                            FechaPrestamo = m.Field<DateTime>("FechaPtm").ToString("dd/MM/yyyy"),
                            FrecuenciaPagos = m.Field<byte>("FrecuenciaCuotaPtm").ToString(),
                            CodigoCobradorAsignado = m.Field<string>("Cobrador"),
                            ValorOtros = m.Field<decimal>("OtrosPtm").ToString(),
                            TasaInteres = m.Field<decimal>("TasaIntPtm").ToString(),
                            TasaMora = m.Field<decimal>("TasaMoraPtm").ToString(),
                            NombreCobradorAsignado = m.Field<string>("NombreCobrador"),
                            CuotasOtros = m.Field<Int16>("CuotasTraspPtm").ToString(),
                            FormaPagos = m.Field<byte>("Vencimiento").ToString(),
                            Balance = Balance.ToString(),
                            CuotasARecalcular = dbTemporal2.Rows.Count.ToString()
                        }).ToList();



            var obj = new { data = qrym.Select(x => new RecalcularTablasdePrestamo { CedulaCliente = x.CedulaCliente, NombreApellido = x.NombreApellido, MontoPrestamo = x.MontoPrestamo, NoCuotas = x.NoCuotas, FechaPrestamo = x.FechaPrestamo, FrecuenciaPagos = x.FrecuenciaPagos, CodigoCobradorAsignado = x.CodigoCobradorAsignado, ValorOtros = x.ValorOtros, TasaInteres = x.TasaInteres, TasaMora = x.TasaMora, NombreCobradorAsignado = x.NombreCobradorAsignado, CuotasOtros = x.CuotasOtros, FormaPagos = x.FormaPagos, Balance = x.Balance, CuotasARecalcular = x.CuotasARecalcular }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult UltimaCuotaDePrestamos()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;


            Parametros();
            var db = vg.WS.Select_ListadoCobradores();



            DataTable dt = db.Tables[0];
            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoCobradores
                       {
                           CodCobrador = m.Field<string>("CodigoOficial"),
                           NombreCobrador = m.Field<string>("Nombre_Cobrador")
                       };

            ViewBag.ModelCobrador = qrym;
            return View();
        }

        [HttpPost]
        public ActionResult UltimaCuotaDePrestamos(UltimaCuotaDePrestamos model)
        {
            List<ReporteUltimaCuotaDeContrato> Tabla = null;
            DataTable DT;

            try
            {
                if (Convert.ToDateTime(model.Fecha) == null)
                {
                    ViewBag.Invalid = "Aviso, la fecha desde no puede ser mayor a la fecha hasta.";
                    return View();
                }

                if(model.CodigoCobrador == null)
                {
                    model.CodigoCobrador = "";
                }
                DT = vg.WS.UltimaCuotaDePrestamos(Session["CodigoCia"].ToString(), Convert.ToDateTime(model.Fecha).ToString("yyyy-MM-dd"), model.CodigoCobrador).Tables["UltimaCuotaDePrestamos"];

                Tabla = (from m in DT.AsEnumerable().AsQueryable()
                         orderby m.Field<string>("Cobrador"), m.Field<DateTime>("FechaPtm")
                         select new ReporteUltimaCuotaDeContrato
                         {
                          
                             Contrato = m.Field<string>("Contrato"),
                             CodigoCliente = m.Field<string>("CodigoCliente"),
                             NombreCliente = m.Field<string>("NombreApls"),
                             CuotasPtm = m.Field<Int16>("CuotasPtm"),
                             FechaPtm = m.Field<DateTime>("UltimaFecha"),
                             MontoPtm = m.Field<decimal>("MontoPtm"),
                             CodigoCobrador =m.Field<string>("Cobrador"),
                             NombreCobrador = m.Field<string>("Nombre"),
                         }).ToList();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fecha", "Esta fecha no es válida.");
                return View(model);
            }

            Session["RptUltimaCuota"] = Tabla;
            return RedirectToAction("GeneraReporte", "Plantillas", new { report = "UltimaCuota",  FechaHasta = model.Fecha, FormaReporte = 0, CodigoCobrador = model.CodigoCobrador, NombreCobrador = model.NombreCobrador });
        }

        public ActionResult ReporteContratoDelMes()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            Parametros();
            var db = vg.WS.Select_ListadoCobradores();
            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                        select new Select_ListadoCobradores
                        {
                            CodCobrador = m.Field<string>("CodigoOficial"),
                            NombreCobrador = m.Field<string>("Nombre_Cobrador")
                        };

            ViewBag.ModelCobrador = qrym;

            return View();
        }

        public void Parametros()
        {
         
            var db = vg.WS.Parametros(Session["CodigoCia"].ToString());
            
            DataTable dt = db.Tables[0];

            ViewBag.ModelFecha = dt.Rows[0]["FechaControlMasAntigua"];
            
        }

        [HttpPost]
        public ActionResult ReporteContratoDelMes(ReporteContratoDelMes model)
        {
            //List<CobrosRealizados> Tabla = null;
            List<ContratoDelMes> Tabla = null;
            DataTable DT;


                try
                {
                    if (Convert.ToDateTime(model.FechaDesde) > Convert.ToDateTime(model.FechaHasta))
                    {
                        ViewBag.Invalid = "Aviso, la fecha desde no puede ser mayor a la fecha hasta.";
                        return View();
                    }

                    if (Convert.ToDateTime(model.FechaDesde).Year != Convert.ToDateTime(model.FechaHasta).Year && Convert.ToDateTime(model.FechaDesde).Month != Convert.ToDateTime(model.FechaHasta).Month)
                    {
                        ViewBag.Invalid = "Aviso, la fecha desde no puede ser mayor a la fecha hasta.";
                        return View();
                    }

                    if (model.Contrato == null)
                    {
                       Convert.ToString(model.Contrato = ""); 
                    }
                    if(model.CodigoCobrador == null)
                    {
                       Convert.ToString(model.CodigoCobrador = "");
                    }   
               
                    DT = vg.WS.ContratoDelMes(Session["CodigoCia"].ToString(), Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd"), model.CodigoCobrador).Tables["ContratosDelMes"];

                    Tabla = (from m in DT.AsEnumerable().AsQueryable()
                             orderby m.Field<string>("Cobrador"), m.Field<DateTime>("FechaPtm")
                             select new ContratoDelMes
                          
                         {  
                             Contrato = m.Field<string>("Contrato"),
                             NombreCliente = m.Field<string>("NomClteApls"),
                             MontoPtm = m.Field<decimal>("MontoPtm"),
                             InteresPtm = m.Field<decimal>("InteresPtm"),
                             CuotasPtm = m.Field<Int16>("CuotasPtm"),
                             FechaPtm = m.Field<DateTime>("FechaPtm"),
                             CodigoCobrador = m.Field<string>("Cobrador"),
                             NombreCobrador = m.Field<string>("Nombre"),
                             TasaInteres = m.Field<decimal>("TasaIntPtm"),
                             Vencimiento = m.Field<DateTime>("FechaVenc")
                         }).ToList();

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Fecha", "Esta fecha no es válida.");
                return View(model);
            }

            Session["RptContratosDelMes"] = Tabla;
            return RedirectToAction("GeneraReporte", "Plantillas", new { report = "ContratosDelMes", FechaDesde = model.FechaDesde, FechaHasta = model.FechaHasta, FormaReporte = Convert.ToByte(model.FormaReporte), CodigoCobrador = model.CodigoCobrador, NombreCobrador = model.NombreCobrador });
        }

        public ActionResult ListadoDeCobrosRealizados()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

           
            Parametros();
            var db = vg.WS.Select_ListadoCobradores();

           
            
            DataTable dt = db.Tables[0];
            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoCobradores
                       {
                           CodCobrador = m.Field<string>("CodigoOficial"),
                           NombreCobrador = m.Field<string>("Nombre_Cobrador")
                       };

            ViewBag.ModelCobrador = qrym;

            return View();
        }
        [HttpPost]

        public ActionResult ListadoDeCobrosRealizados(ListadoDeCobrosRealizados model)
        {
            //List<CobrosRealizados> Tabla = null;
            List<CobrosRealizados> Tabla = null;
            DataTable DT;

            try
            {
                if (Convert.ToDateTime(model.FechaDesde) > Convert.ToDateTime(model.FechaHasta))
                {
                    ViewBag.Invalid = "Aviso, la fecha desde no puede ser mayor a la fecha hasta.";
                    return View();
                }

                if (Convert.ToDateTime(model.FechaDesde).Year != Convert.ToDateTime(model.FechaHasta).Year && Convert.ToDateTime(model.FechaDesde).Month != Convert.ToDateTime(model.FechaHasta).Month)
                {
                    ViewBag.Invalid = "Aviso, la fecha desde no puede ser mayor a la fecha hasta.";
                    return View();


                }


                byte OR = Convert.ToByte(model.OrdenadoPor);
                byte FR = Convert.ToByte(model.FormaReporte);


                if (model.Contrato == null)
                {
                    Convert.ToString(model.Contrato = "");
                }
                if (model.CodigoCobrador == null)
                {
                    Convert.ToString(model.CodigoCobrador = "");
                }

                DT = vg.WS.ListadoDeCobros(Session["CodigoCia"].ToString() , Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd"), model.TipoMovimiento, model.Contrato, model.CodigoCobrador).Tables["CobrosRealizados"];
                if (model.OrdenadoPor == 1)
                {

                    Tabla = (from m in DT.AsEnumerable().AsQueryable()
                             orderby m.Field<string>("CodigoCobrador"), m.Field<DateTime>("FechaDocCont"), m.Field<string>("NomClteApls")
                             select new CobrosRealizados
                             {
                                 Cia = m.Field<string>("Cia"),
                                 //FechaDesde = m.Field<System.DateTime>("CuentaCont"),
                                 FechaDocCont = m.Field<System.DateTime>("FechaDocCont"),
                                 TipoMovimiento = m.Field<byte>("MovDocCont"),
                                 //CodigoCobrador = m.Field<string>("CodigoCobrador"),
                                 //NombreCobrador = m.Field<string>("Nombre"),
                                 NombreCliente = m.Field<string>("NomClteApls"),
                                 Capital = m.Field<decimal>("ValorPagoCapital"),
                                 Interes = m.Field<decimal>("ValorPagoInteres"),
                                 Mora = m.Field<decimal>("ValorPagoMora"),
                                 Otros = m.Field<decimal>("ValorPagoOtros"),
                                 Contrato = m.Field<string>("Contrato"),
                                 NoDocumento = m.Field<string>("NumDocCont"),
                                 TipoDocumento = m.Field<string>("TipoDocCont"),
                                 Total = m.Field<decimal>("Total"),
                                 OrdenadoPor = OR,
                                 FormaReporte =FR

                             }).ToList();

                }
                else
                {
                    Tabla = (from m in DT.AsEnumerable().AsQueryable()
                             orderby m.Field<string>("CodigoCobrador"), m.Field<DateTime>("FechaDocCont")
                             select new CobrosRealizados
                             {
                                 Cia = m.Field<string>("Cia"),
                                 //FechaDesde = m.Field<System.DateTime>("CuentaCont"),
                                 FechaDocCont = m.Field<System.DateTime>("FechaDocCont"),
                                 TipoMovimiento = m.Field<byte>("MovDocCont"),
                                 CodigoCobrador = m.Field<string>("CodigoCobrador"),
                                 NombreCobrador = m.Field<string>("Nombre"),
                                 NombreCliente = m.Field<string>("NomClteApls"),
                                 Capital = m.Field<decimal>("ValorPagoCapital"),
                                 Interes = m.Field<decimal>("ValorPagoInteres"),
                                 Mora = m.Field<decimal>("ValorPagoMora"),
                                 Otros = m.Field<decimal>("ValorPagoOtros"),
                                 Contrato = m.Field<string>("Contrato"),
                                 NoDocumento = m.Field<string>("NumDocCont"),
                                 TipoDocumento = m.Field<string>("TipoDocCont"),
                                 Total = m.Field<decimal>("Total"),
                                 FormaReporte = FR
                             }).ToList();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fecha", "Esta fecha no es válida.");
                return View(model);
            }

            Session["RptCobrosRealizados"] = Tabla;
            return RedirectToAction("GeneraReporte", "Plantillas", new { report = "CobrosRealizados", FechaDesde = model.FechaDesde, FechaHasta = model.FechaHasta, FormaReporte = Convert.ToByte(model.FormaReporte), CodigoCObrador= model.CodigoCobrador, NombreCobrador = model.NombreCobrador });
        }

        public ActionResult ReporteBalancesDeContratos()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db = vg.WS.Select_ListadoCobradores();


            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoCobradores
                       {
                           CodCobrador = m.Field<string>("CodigoOficial"),
                           NombreCobrador = m.Field<string>("Nombre_Cobrador")
                       };

            ViewBag.ModelCobrador = qrym;

            return View();
        }

        [HttpPost]
        public ActionResult ReporteBalancesDeContratos(ReporteBalancesDeContratos model)

        {
            //List<CobrosRealizados> Tabla = null;
            List<ContratosConBalance> Tabla = null;
            DataTable DT;

            try
            {
                if(model.Contrato== null)
                {
                    model.Contrato = "";
                }
                DT = vg.WS.PrestamosConBalance(Session["CodigoCia"].ToString(),Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd"), model.CodigoCobrador, model.Contrato).Tables["PrestamosConBalance"];
                Tabla = (from m in DT.AsEnumerable().AsQueryable()
                         orderby m.Field<string>("Cobrador")
                         select new ContratosConBalance
                         {
                             //Cia = m.Field<string>("Cia"),
                             Cobrador = m.Field<string>("Cobrador"),
                             Contrato = m.Field<string>("Contrato"),
                             NombreClte = m.Field<string>("NombreCliente"),
                             CuotasVenc = Decimal.ToInt32(m.Field<decimal>("CuotasVencidas")),
                             DiasVenc = m.Field<decimal>("DiasVencidas"),
                             capital = m.Field<decimal>("ValorCuotaCap"),
                             interes = m.Field<decimal>("ValorCuotaInt"),
                             mora = m.Field<decimal>("ValorCuotaMora"),
                             comision = m.Field<decimal>("ValorCuotaCom"),
                             otros = m.Field<decimal>("ValorCuotaOtr"),

                         }).ToList();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fecha", "Esta fecha no es válida.");
                return View(model
                    );
            }

            Session["RptPrestamosConBalance"] = Tabla;
            return RedirectToAction("GeneraReporte", "Plantillas", new { report = "PrestamosConBalance", FechaHasta = model.FechaHasta, NombreCobrador = model.Cobrador, FormaReporte = 0 });
        }

        public JsonResult ValidaCedulaClte(string CedRncClte, string CedRncClteLetra)
        {
            
            string Cia = Session["CodigoCia"].ToString();
            bool existeoriginal =false;
            bool existeconletra = false;
            string resul="";
            var Resultado = vg.WS.ValidaCedORnc(Cia,CedRncClte);

            DataTable dt = Resultado.Tables[0];

            if (dt.Rows.Count > 0)
            {
                //Si estoy creando una cedula con Letra: 
                //  -Validar que la cedula Original exista en la base de datos
                //  -Que no existe ella misma

                if (CedRncClteLetra != "")
                {
                    for (int x = 0; x <= dt.Rows.Count - 1; x++)
                    {
                        if ((string)dt.Rows[x]["Cedula"] == CedRncClte)
                        {
                            existeoriginal = true;
                        }
                        if ((string)dt.Rows[x]["Cedula"] == CedRncClteLetra)
                        {
                            existeconletra = true;
                        }

                    } //for
                    if (existeoriginal == false)
                    {
                        resul = "101"; // la cedula original no existe en la base de datos
                    }
                    if (existeconletra == true)
                    {
                        resul = "102"; // la cedula con letra existe en la base de datos
                    }
                }
                else
                {
                    for (int x = 0; x <= dt.Rows.Count - 1; x++)
                    {
                        if ((string)dt.Rows[x]["Cedula"] == CedRncClte)
                        {
                            existeoriginal = true;
                        }
                    } //for
                    if (existeoriginal == true)
                    {
                        resul = "102"; // la cedula original no existe en la base de datos
                    }

                }
            }
            else
            {
                if (CedRncClteLetra != "")
                {
                    resul = "101"; // la cedula original no existe en la base de datos
                }
                else
                {
                    resul = "100";
                }
            }

            //Resultado = vg.WS.ValidaCedORnc(Cia, CedRncClte);


            //var obj = new { data = q.Sele(x => new RegistraModificaEliminaClientes { CedulaoRNC = x.CedulaoRNC }) };

            //var json = Json(Resultado, JsonRequestBehavior.AllowGet);
            //json.MaxJsonLength = 500000000;
            return Json(resul);


        }

        public ActionResult CuotasVencidasYNoSaldadas()
        {
            Session["Men"] = 1;
            Session["Menu"] = 1;
            Session["Sesion"] = 1;
            Session["Cerrar"] = 3;

            var db = vg.WS.Select_ListadoCobradores();

            Parametros();

            DataTable dt = db.Tables[0];

            var qrym = from m in dt.AsEnumerable().AsQueryable()
                       select new Select_ListadoCobradores
                       {
                           CodCobrador = m.Field<string>("CodigoOficial"),
                           NombreCobrador = m.Field<string>("Nombre_Cobrador")
                       };

            ViewBag.ModelCobrador = qrym;

            return View();
        }

        [HttpPost]
        public ActionResult CuotasVencidasYNoSaldadas(CuotasVencidasYNoSaldadas model)
        {
            //List<CobrosRealizados> Tabla = null;
            List<RptCuotasVencidasYNoSaldadas> Tabla = null;
            DataTable DT;

            try
            {
                if (model.Contrato == null)
                {
                    model.Contrato = "";
                }
                DT = vg.WS.CuotasVencidasYNoSaldadas(Session["CodigoCia"].ToString(), Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd"), model.CodigoCobrador, model.Contrato).Tables["CuotasVencidas"];
                Tabla = (from m in DT.AsEnumerable().AsQueryable()
                         //orderby m.Field<string>("CodigoCobrador"
                         select new RptCuotasVencidasYNoSaldadas
                         {
                             //Cia = m.Field<string>("Cia"),
                             Contrato = m.Field<string>("Contrato"),
                             //NombreClte = m.Field<string>("Nombre_Cliente"),
                             //capital = m.Field<decimal>("ValorCuotaCap"),
                             //interes = m.Field<decimal>("ValorCuotaInt"),
                             //comision = m.Field<decimal>("ValorCuotaCom"),
                             //otros = m.Field<decimal>("ValorCuotaOtr"),
                             //FechaVenc = m.Field<DateTime>("FechaVencCuota"),
                             //mora = m.Field<decimal>("Mora"),
                             //otros = m.Field<decimal>("OtrosPtm"),

                         }).ToList();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Fecha", "Esta fecha no es válida.");
                return View(model
                    );
            }

            Session["RptCuotasVencida"] = Tabla;
            return RedirectToAction("GeneraReporte", "Plantillas", new { report = "CuotasVencidas", FechaHasta = model.FechaHasta, CodigoCObrador = model.CodigoCobrador, NombreCobrador = model.NombreCobrador, FormaReporte = 0 });
        }

        public JsonResult GetClienteInfo(string CedRncClte )
        {
          string Cia = Session["CodigoCia"].ToString();
            
          var db =  vg.WS.GetClienteInfo(CedRncClte, Cia);

            DataTable dt = db.Tables[0];

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                       select new RegistraModificaEliminaClientes
                       {
                       Codigo = m.Field<string>("CodClteApls"),
                       CedulaoRNC = m.Field<string>("CedRncClteApls"),
                       Nombre = m.Field<string>("NomClteApls"),
                       Apellido = m.Field<string>("ApeClteApls"),
                       DireccionCobro = m.Field<string>("DireccionClteApls"),
                       NombreNegocio = m.Field<string>("EmpresaL"),
                       Telefono = m.Field<string>("TelefonosClteApls"),
                       Celular = m.Field<string>("CelularClteApls"),
                       Email = m.Field<string>("E_mailClteApls")

                       }).ToList();

            var obj = new { data = qrym.Select(x => new RegistraModificaEliminaClientes { Codigo = x.Codigo, CedulaoRNC = x.CedulaoRNC, Nombre = x.Nombre, Apellido = x.Apellido, DireccionCobro = x.DireccionCobro, NombreNegocio = x.NombreNegocio, Telefono = x.Telefono, Celular = x.Celular, Email = x.Email}) };
          
            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarRegCliente(RegistraModificaEliminaClientes model)
        {
            DateTime FechaHoraReg = DateTime.Now.Date;

           
            if ((vg.WS.RegistraClientes(new WebServices.GRL_MaestroClientes
            {
                Cia = @Session["CodigoCia"].ToString(),
                Usuario = @Session["Usuario"].ToString(),
                CodClteApls = (model.Codigo==null)? "EN PROCESO": model.Codigo,
                NomClteApls = model.Nombre,
                ApeClteApls = model.Apellido,
                DireccionClteApls = model.DireccionCobro,
                CedRncClteApls = model.CedulaoRNC,
                TelefonosClteApls = model.Telefono,
                CelularClteApls = model.Celular,
                EmpresaL = model.NombreNegocio,
                E_mailClteApls = model.Email
            })) == true)

            {
                ViewBag.PasoI = "Cliente Registrado";
                return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
            }
            else
            {
                Session["Paso"] = "Error";


                return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminaCliente(RegistraModificaEliminaClientes model)
        {

            if ((vg.WS.EliminaCliente(new WebServices.GRL_MaestroClientes
            {
                Cia = @Session["CodigoCia"].ToString(),
                CedRncClteApls = model.CedulaoRNC,
            })) == true)

            {
                ViewBag.PasoI = "Cliente Registrado";
                return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
            }
            else
            {
                Session["Paso"] = "Error";


                return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizaCliente(RegistraModificaEliminaClientes model)
        {
            

            if ((vg.WS.ActualizaCliente(new WebServices.GRL_MaestroClientes
            {
                Cia = @Session["CodigoCia"].ToString(),
                Usuario = @Session["Usuario"].ToString(),
                CodClteApls = model.Codigo ,
                NomClteApls = model.Nombre,
                ApeClteApls = model.Apellido,
                DireccionClteApls = model.DireccionCobro,
                CedRncClteApls = model.CedulaoRNC,
                TelefonosClteApls = model.Telefono,
                CelularClteApls = model.Celular,
                EmpresaL = model.NombreNegocio,
                E_mailClteApls = model.Email
            })) == true)

            {
                ViewBag.PasoI = "Cliente Registrado";
                return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
            }
            else
            {
                Session["Paso"] = "Error";
                return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistraPrestamos(RegistraMaestradePrestamo model)
        {
            DateTime FechaHoraReg = DateTime.Now.Date;
            string Columns;


            //Columns = "'" + @Session["CodigoCia"].ToString() + "','JASQ322 ','" + model.NoPrestamo +
            //"','" + model.MontoPrestamo + "','" + model.NoCuotas + "','" + model.CuotasOtros + "','" + model.Interes + "','" + model.FrecuenciaPago + "','" + model.TasaInteres +
            //    "','" + model.TasaMora + "','" + model.codigoCobradorAsignado + "','" + model.DetallesNegociacion + "'";
            // vg.WS.RegistraClientes(Columns);

            //','" + model. + "','" + model + "','" + model + "','" + model + "

           return RedirectToAction("RegistraMaestradePrestamo", "PrestamosComp");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminaContrato(RegistraMaestradePrestamo model)
        {

            string Contrato;

        

             Contrato = model.NoPrestamo;
            vg.WS.EliminaPrestamo(Contrato);

            return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminaActualiza(RegistraMaestradePrestamo model)
        {

            string Contrato;

            Contrato = model.NoPrestamo;
            vg.WS.ActualizaPrestamo(Contrato);

            return RedirectToAction("RegistraModificaEliminaClientes", "PrestamosComp");
        }


        public JsonResult VerCuotas(string MontoPtm,float TasaInteres, string FechaContrato, string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns, string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales, string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales, string Redondea, string CuotasOriginal)

        {
         

            var db = vg.WS.CreaTablaDeAmortizacion(MontoPtm,TasaInteres, Convert.ToDateTime(FechaContrato).ToString("yyyy-MM-dd"), Convert.ToDateTime(Fecha1raCuota).ToString("yyyy-MM-dd"), Cuota, NoCuotasOtros, Vencimiento, AbsOIns, Frecuencia, Convert.ToByte(TipoTabla).ToString(), Convert.ToDecimal(Inicial).ToString(), Convert.ToDecimal(Traspaso).ToString(), Convert.ToDecimal(Registro).ToString(), Convert.ToDecimal(Seguro).ToString(), Convert.ToDecimal(Exoneracion).ToString(), Convert.ToDecimal(Legal).ToString(), Convert.ToDecimal(Otros).ToString(), CuotasEspeciales, CantCuotasEspeciales, strCuotasEspeciales, strValorCuotasEspeciales, Redondea);


            DataTable dt = db.Tables[0];
 


            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new RecalcularTablaNuevasCuotas
                        {
                            Cuota = (m.Field<string>("Cuota") == "")? m.Field<string>("Cuota"): Convert.ToString(Convert.ToInt32(m.Field<string>("Cuota")) + (Convert.ToInt32(CuotasOriginal) - Convert.ToInt32(Cuota))).PadLeft(3,'0'),
                            FechaVencCuota = m.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy"),
                            ValorCuota = m.Field<decimal>("ValorCuota").ToString(),
                            Saldo = m.Field<decimal>("Saldo").ToString(),
                            Capital = m.Field<decimal>("Capital").ToString(),
                            Interes = m.Field<decimal>("Intereses").ToString(),
                            Otros = m.Field<decimal>("Otros").ToString()     
                        }).ToList();

            var obj = new { data = qrym.Select(x => new RecalcularTablaNuevasCuotas { Cuota = x.Cuota, Saldo = x.Saldo, ValorCuota = x.ValorCuota, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros, FechaVencCuota = x.FechaVencCuota }) };


            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;

            //return Json(r, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ConsultaCuotasAmortizacion(string MontoPtm, float TasaInteres, string FechaContrato, string Fecha1raCuota, string Cuota, string NoCuotasOtros, string Vencimiento, string AbsOIns, string Frecuencia, string TipoTabla, string Inicial, string Traspaso, string Registro, string Seguro, string Exoneracion, string Legal, string Otros, string CuotasEspeciales, string CantCuotasEspeciales, string strCuotasEspeciales, string strValorCuotasEspeciales, string Redondea, string CuotasOriginal)

        {

            var db = vg.WS.CreaTablaDeAmortizacion(MontoPtm, TasaInteres, Convert.ToDateTime(FechaContrato).ToString("yyyy-MM-dd"), Convert.ToDateTime(Fecha1raCuota).ToString("yyyy-MM-dd"), Cuota, NoCuotasOtros, Vencimiento, AbsOIns, Frecuencia, Convert.ToByte(TipoTabla).ToString(), Convert.ToDecimal(Inicial).ToString(), Convert.ToDecimal(Traspaso).ToString(), Convert.ToDecimal(Registro).ToString(), Convert.ToDecimal(Seguro).ToString(), Convert.ToDecimal(Exoneracion).ToString(), Convert.ToDecimal(Legal).ToString(), Convert.ToDecimal(Otros).ToString(), CuotasEspeciales, CantCuotasEspeciales, strCuotasEspeciales, strValorCuotasEspeciales, Redondea);


            DataTable dt = db.Tables[0];
            Session["dtInfoReporteTabla"] = db.Tables[0];

            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new RecalcularTablaNuevasCuotas
                        {
                            Cuota = (m.Field<string>("Cuota") == "") ? m.Field<string>("Cuota") : Convert.ToString(Convert.ToInt32(m.Field<string>("Cuota")) + (Convert.ToInt32(CuotasOriginal) - Convert.ToInt32(Cuota))).PadLeft(3, '0'),
                            FechaVencCuota = m.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy"),
                            ValorCuota = m.Field<decimal>("ValorCuota").ToString(),
                            Saldo = m.Field<decimal>("Saldo").ToString(),
                            Capital = m.Field<decimal>("Capital").ToString(),
                            Interes = m.Field<decimal>("Intereses").ToString(),
                            Otros = m.Field<decimal>("Otros").ToString()
                        }).ToList();

            var obj = new { data = qrym.Select(x => new RecalcularTablaNuevasCuotas { Cuota = x.Cuota, Saldo = x.Saldo, ValorCuota = x.ValorCuota, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros, FechaVencCuota = x.FechaVencCuota }) };


            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;

            //return Json(r, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult ConsultaAmortizacionparaPrestamos(ConsultaAmortizacionparaPrestamos model)

        {
            List<ListaCosultaAmortizacion> Tabla = null;
            DataTable DT;
            DT = (DataTable)Session["dtInfoReporteTabla"];
            Session.Remove("dtInfoReporteTabla");
            Session["dtInfoReporteTabla"] = null;

            Tabla = (from m in DT.AsEnumerable().AsQueryable()
                     select new ListaCosultaAmortizacion
                     {
                         Cuota = (m.Field<string>("Cuota") == "") ? m.Field<string>("Cuota") : Convert.ToString(Convert.ToInt32(m.Field<string>("Cuota"))).PadLeft(3, '0'),
                         ValorCuota = m.Field<decimal>("ValorCuota").ToString(),
                        Saldo = m.Field<decimal>("Saldo").ToString(),
                        FechaVencCuota = m.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy"),
                        Capital = m.Field<decimal>("Capital").ToString(),
                        Interes = m.Field<decimal>("Intereses").ToString(),
                        //Comision = m.Field<decimal>("Comision").ToString(),
                        Otros = m.Field<decimal>("Otros").ToString()
                        }).ToList();


            Session["RptTasaDePrestamo"] = Tabla;
            return RedirectToAction("GeneraReporteConsulta", "Plantillas", new { NombreApellidoCliente = model.NombreApellidoCliente, MontoPrestamo = model.MontoPrestamo, TasaInteres = model.TasaInteres, Otros = model.Otros, Frecuencia = model.FrecuenciaPagos, report = "TasaDeRendimientoDePrestamo" });


        }


        public JsonResult GenerarRelacion(string CodigoCobrador, string FechaConsulta,int EliminaRelacion)
        {
            string Cia = Session["CodigoCia"].ToString();
            string Usuario = Session["Usuario"].ToString();

            var db = vg.WS.GenerarRelacion(Cia, Usuario, CodigoCobrador, FechaConsulta, EliminaRelacion);

            DataTable dt = db.Tables[0];



            var qrym = (from m in dt.AsEnumerable().AsQueryable()
                        select new GenerarTablaDeRelacion
                        {
                           
                            Contrato = m.Field<string>("Contrato"),
                            Nombre = m.Field<string>("NombreCliente"),
                            Cuota = m.Field<string>("Cuota"),
                            Capital = m.Field<decimal>("ValorCuotaCap").ToString(),
                            Interes = m.Field<decimal>("ValorCuotaInt").ToString(),
                            Otros = (m.Field<decimal>("ValorCuotaCom") + m.Field<decimal>("ValorCuotaLeg") + m.Field<decimal>("ValorCuotaOtr")).ToString(),
                            Total = (m.Field<decimal>("ValorCuotaCom") + m.Field<decimal>("ValorCuotaLeg") + m.Field<decimal>("ValorCuotaOtr")+ m.Field<decimal>("ValorCuotaCap") + m.Field<decimal>("ValorCuotaInt")).ToString(),
                        }).ToList();
            //

            var obj = new { data = qrym.Select(x => new GenerarTablaDeRelacion { Contrato = x.Contrato, Nombre = x.Nombre.Substring(0, (x.Nombre.Length < 25) ? x.Nombre.Length : 25), Cuota = x.Cuota, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros, Total = x.Total  }) };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VerificaRelacion(string CodigoCobrador, string FechaConsulta)
        {
            string Cia = Session["CodigoCia"].ToString();
            string Resultado;
            //string Usuario = Session["Usuario"].ToString();

            DataTable  dt = vg.WS.VerificaRelacion(Cia, CodigoCobrador, FechaConsulta).Tables[0];
             if(dt.Rows.Count > 0)
            {
                Resultado = "true";
            }
            else
            {
                Resultado = "false";
            }
            
            return Json(Resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VerCuotasAmortizacion(string Saldo, int Cuota)
        {

            DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("Campo1", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Campo2", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Campo3", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Campo4", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Campo5", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Campo6", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Campo7", typeof(System.String)));
            //dt.Columns.Add("Monto", typeof(int));
            //DataRow dr1 = dt.NewRow();
            //dr1["Campo1"] = " ";
            //dr1["Campo2"] = " ";
            //dr1["Campo3"] = Saldo;
            //dr1["Campo4"] = " ";
            //dr1["Campo5"] = " ";
            //dr1["Campo6"] = " ";
            //dr1["Campo7"] = " ";
            //dt.Rows.Add(dr1);

            //for (int x = 1; x <= Cuota; x++)
            //{



            //    DataRow dr2 = dt.NewRow();
            //    dr2["Campo1"] = x.ToString().PadLeft(3, '0');
            //    dr2["Campo2"] = "12/12/2018";
            //    dr2["Campo3"] = 700.00;
            //    dr2["Campo4"] = 200.00;
            //    dr2["Campo5"] = 500.00;
            //    dr2["Campo6"] = 300.00;
            //    dr2["Campo7"] = 100.00;
            //    dt.Rows.Add(dr2);

            //}

            //DataRow dr3 = dt.NewRow();
            //dr3["Campo1"] = " ";
            //dr3["Campo2"] = " ";
            //dr3["Campo3"] = "Totales: ";
            //dr3["Campo4"] =  "" ;
            //dr3["Campo5"] = " suma";
            //dr3["Campo6"] = " suma";
            //dr3["Campo7"] = " ";
            //dt.Rows.Add(dr3);






            //dt.Rows.Add(1);
            //dt.Rows.Add(2);
            //dt.Rows.Add(3);





            //List<RegistraMaestradePrestamo> list = new List<RegistraMaestradePrestamo>();



            var r = (from p in dt.AsEnumerable().AsQueryable()
                     select new RegistraMaestradePrestamo { Cuota = p.Field<string>("Campo1"), Fecha = p.Field<string>("Campo2"), Saldo = p.Field<string>("Campo3"), ValorCuota = p.Field<string>("Campo4"), Capital = p.Field<string>("Campo5"), Interes = p.Field<string>("Campo6"), Otros = p.Field<string>("Campo7") }).ToList();
            //select new RegistraMaestradePrestamo { Cuota = p.Field<string>("Campo1"), Fecha = p.Field<DateTime>("Campo2"), Saldo = p.Field<decimal>("Campo3"), ValorCuota = p.Field<decimal>("Campo4"), Capital = p.Field<decimal>("Campo5"), Interes = p.Field<decimal>("Campo6"), Otros = p.Field<decimal>("Campo7") }).ToList();


            return Json(r, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Salir()
        {
            Session.Abandon();
            Session["Sesion"] = 1;
            Session["Session"] = 0;
            return RedirectToAction("Login", "Account");
        }

        public JsonResult ConsultaLoadCuotas(string Monto)
        {
            DataRow drow;
            decimal saldo1 = 0;
            decimal Capital = 0;
            decimal Interes = 0;
            decimal Otros = 0;
            DataTable dtCuotas = new DataTable();
            dtCuotas = (DataTable)Session["dtCuotas"];

            Session.Remove("dtCuotas");
            Session["dtCuotas"] = null;

            saldo1 = Convert.ToDecimal(Monto);
            for (int x = 0; x <= dtCuotas.Rows.Count - 1; x++)
            {
                saldo1 -= Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaCap"]);

                Capital += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaCap"]);
                Interes += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaInt"]);
                Otros += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaOtros"]);

                dtCuotas.Rows[x]["Saldo"] = saldo1.ToString("###,###,##0.00");
            }

            drow = dtCuotas.NewRow();
            drow["Contrato"] = "";
            drow["CuotaNumPtm"] = "";
            drow["FechaVencCuota"] = "01/01/2000";
            drow["Saldo"] = Convert.ToDecimal(Monto).ToString("###,###,##0.00");
            drow["ValorCuotaCap"] = "0";
            drow["ValorCuotaInt"] = "0";
            drow["ValorCuotaOtros"] = "0";

            dtCuotas.Rows.Add(drow);



            drow = dtCuotas.NewRow();
            drow["Contrato"] = "";
            drow["CuotaNumPtm"] = "ZZZ";
            drow["FechaVencCuota"] = "01/01/2000";
            drow["Saldo"] = "Totales:";
            drow["ValorCuotaCap"] = Capital;
            drow["ValorCuotaInt"] = Interes;
            drow["ValorCuotaOtros"] = Otros;

            dtCuotas.Rows.Add(drow);

            ConsultaVerTablaDetalle cons = new ConsultaVerTablaDetalle();

            cons.ConsultaVerTablaDetalles = (from i in dtCuotas.AsEnumerable().AsEnumerable()
                                             orderby i.Field<string>("CuotaNumPtm")
                                             select new ConsultaVerTabla
                                             {
                                                 Cuota = i.Field<string>("CuotaNumPtm"),
                                                 FechaVencCuota = i.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy"),
                                                 Saldo = i.Field<string>("Saldo"),
                                                 ValorCuota = (i.Field<decimal>("ValorCuotaCap") + i.Field<decimal>("ValorCuotaInt") + i.Field<decimal>("ValorCuotaOtros")).ToString("###,###,##0.00"),
                                                 Capital = i.Field<decimal>("ValorCuotaCap").ToString("###,###,##0.00"),
                                                 Interes = i.Field<decimal>("ValorCuotaInt").ToString("###,###,##0.00"),
                                                 Otros = i.Field<decimal>("ValorCuotaOtros").ToString("###,###,##0.00")
                                             }).ToList();



            var obj = new { data = cons.ConsultaVerTablaDetalles.Select(x => new ConsultaVerTabla { Cuota = x.Cuota, FechaVencCuota = x.FechaVencCuota, Saldo = x.Saldo, ValorCuota = x.ValorCuota, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public JsonResult ConsultaLoadMovimientos(string Monto)
        {
            DataRow drow;
            decimal saldo1 = 0;
            decimal Capital = 0;
            decimal Interes = 0;
            decimal Otros = 0;
            DataTable dtMovimientos = new DataTable();
            dtMovimientos = (DataTable)Session["dtMovimientos"];

            Session.Remove("dtMovimientos");
            Session["dtMovimientos"] = null;

            drow = dtMovimientos.NewRow();
            drow["Contrato"] = "";
            drow["FechaDocCont"] = "01/01/2000";
            drow["Documento"] = "Inicial";
            drow["ValorPagoCapital"] = "0";
            drow["ValorPagoInteres"] = "0";
            drow["ValorPagoMora"] = "0";

            dtMovimientos.Rows.Add(drow);

            saldo1 = Convert.ToDecimal(Monto);
            for (int x = 0; x <= dtMovimientos.Rows.Count - 1; x++)
            {
                //saldo1 -= Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaCap"]);

                //Capital += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaCap"]);
                //Interes += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaInt"]);
                //Otros += Convert.ToDecimal(dtCuotas.Rows[x]["ValorCuotaOtros"]);

                //dtCuotas.Rows[x]["Saldo"] = saldo1.ToString("###,###,##0.00");
            }

            //drow = dtMovimientos.NewRow();
            //drow["Contrato"] = "";
            //drow["CuotaNumPtm"] = "ZZZ";
            //drow["FechaVencCuota"] = "01/01/2000";
            //drow["Saldo"] = "Totales:";
            //drow["ValorCuotaCap"] = Capital;
            //drow["ValorCuotaInt"] = Interes;
            //drow["ValorCuotaOtros"] = Otros;

            //dtCuotas.Rows.Add(drow);



            ConsultaMovimientosDetalle cons = new ConsultaMovimientosDetalle();

            cons.ConsultaMovimientosDetalles = (from i in dtMovimientos.AsEnumerable().AsEnumerable()
                                                orderby i.Field<DateTime>("FechaDocCont"), i.Field<string>("Movimiento")
                                                select new ConsultaMovimientos
                                                {
                                                    Fecha = i.Field<DateTime>("FechaDocCont").ToString("dd/MM/yyyy"),
                                                    Documento = i.Field<string>("Documento"),
                                                    Movimiento = i.Field<string>("Movimiento"),
                                                    Capital = i.Field<decimal>("ValorPagoCapital").ToString("###,###,##0.00"),
                                                    Interes = i.Field<decimal>("ValorPagoInteres").ToString("###,###,##0.00"),
                                                    Otros = "0.00",
                                                    Mora = i.Field<decimal>("ValorPagoMora").ToString("###,###,##0.00"),
                                                    Total = (i.Field<decimal>("ValorPagoCapital") + i.Field<decimal>("ValorPagoInteres") + i.Field<decimal>("ValorPagoMora")).ToString("###,###,##0.00")
                                                }).ToList();



            var obj = new { data = cons.ConsultaMovimientosDetalles.Select(x => new ConsultaMovimientos { Fecha = x.Fecha, Documento = x.Documento, Movimiento = x.Movimiento, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros, Mora = x.Mora, Total = x.Total }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public JsonResult ConsultaLoadCuotasVencidas(string FechaConsulta)
        {
            DataRow drow;
            decimal Capital = 0;
            decimal Interes = 0;
            decimal Otros = 0;
            decimal Total = 0;

            DataTable dtCuotasVencidas = new DataTable();
            dtCuotasVencidas = (DataTable)Session["dtCuotasVencidas"];

            Session.Remove("dtCuotasVencidas");
            Session["dtCuotasVencidas"] = null;

            for (int x = 0; x <= dtCuotasVencidas.Rows.Count - 1; x++)
            {
                if (Convert.ToDateTime(dtCuotasVencidas.Rows[x]["FechaVencCuota"]) <= Convert.ToDateTime(FechaConsulta))
                {
                    Capital += Convert.ToDecimal(dtCuotasVencidas.Rows[x]["ValorCuotaCap"]);
                    Interes += Convert.ToDecimal(dtCuotasVencidas.Rows[x]["ValorCuotaInt"]);
                    Otros += Convert.ToDecimal(dtCuotasVencidas.Rows[x]["ValorCuotaOtr"]);
                    Total += Convert.ToDecimal(dtCuotasVencidas.Rows[x]["ValorCuotaCap"]) + Convert.ToDecimal(dtCuotasVencidas.Rows[x]["ValorCuotaInt"]) + Convert.ToDecimal(dtCuotasVencidas.Rows[x]["ValorCuotaOtr"]);
                }
            }

            drow = dtCuotasVencidas.NewRow();
            drow["Cuota"] = "Totales: ";
            drow["FechaVencCuota"] = "01/01/2000";
            drow["ValorCuotaCap"] = Capital;
            drow["ValorCuotaInt"] = Interes;
            drow["ValorCuotaOtr"] = Otros;

            dtCuotasVencidas.Rows.Add(drow);


            ConsultaCuotasVencidasDetalle cons = new ConsultaCuotasVencidasDetalle();

            cons.ConsultaCuotasVencidasDetalles = (from i in dtCuotasVencidas.AsEnumerable().AsEnumerable()
                                                   where i.Field<DateTime>("FechaVencCuota") <= Convert.ToDateTime(FechaConsulta)
                                                   orderby i.Field<string>("Cuota")
                                                   select new ConsultaCuotasVencidas
                                                   {
                                                       Cuota = i.Field<string>("Cuota"),
                                                       Capital = i.Field<decimal>("ValorCuotaCap").ToString("###,###,##0.00"),
                                                       Interes = i.Field<decimal>("ValorCuotaInt").ToString("###,###,##0.00"),
                                                       Otros = i.Field<decimal>("ValorCuotaOtr").ToString("###,###,##0.00"),
                                                       Total = (i.Field<decimal>("ValorCuotaCap") + i.Field<decimal>("ValorCuotaInt") + i.Field<decimal>("ValorCuotaOtr")).ToString("###,###,##0.00"),
                                                       Fecha = i.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy")
                                                   }).ToList();



            var obj = new { data = cons.ConsultaCuotasVencidasDetalles.Select(x => new ConsultaCuotasVencidas { Cuota = x.Cuota, Capital = x.Capital, Interes = x.Interes, Otros = x.Otros, Total = x.Total, Fecha = x.Fecha }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public JsonResult ConsultaLoadCalculoMora()
        {
            decimal Calculo = 0;
            DataRow drow;
            DataTable dtCalculoMora = new DataTable();
            dtCalculoMora = (DataTable)Session["dtCalculoMora"];

            Session.Remove("dtCalculoMora");
            Session["dtCalculoMora"] = null;

            for (int x = 0; x <= dtCalculoMora.Rows.Count - 1; x++)
            {
                Calculo += Convert.ToDecimal(dtCalculoMora.Rows[x]["MoraCalculada"]);
            }

            drow = dtCalculoMora.NewRow();
            drow["Cuota"] = "Total:";
            drow["MoraCalculada"] = Calculo;
            drow["FechaVencCuota"] = "01/01/2000";
            drow["ValorCuota"] = 0;
            drow["DiasMora"] = 0;

            drow["TasaMora"] = 0;

            dtCalculoMora.Rows.Add(drow);

            ConsultaCalculoMoraDetalle cons = new ConsultaCalculoMoraDetalle();

            cons.ConsultaCalculoMoraDetalles = (from i in dtCalculoMora.AsEnumerable().AsEnumerable()
                                                orderby i.Field<DateTime>("FechaVencCuota")
                                                select new ConsultaCalculoMora
                                                {
                                                    Cuota = i.Field<string>("Cuota"),
                                                    Fecha = i.Field<DateTime>("FechaVencCuota").ToString("dd/MM/yyyy"),
                                                    Valor = i.Field<decimal>("ValorCuota").ToString(),
                                                    Dias = i.Field<decimal>("DiasMora").ToString(),
                                                    Calculo = i.Field<decimal>("MoraCalculada").ToString(),
                                                    TasaAnual = i.Field<decimal>("TasaMora").ToString() + " %"
                                                }).ToList();



            var obj = new { data = cons.ConsultaCalculoMoraDetalles.Select(x => new ConsultaCalculoMora { Cuota = x.Cuota, Fecha = x.Fecha, Valor = x.Valor, Dias = x.Dias, Calculo = x.Calculo, TasaAnual = x.TasaAnual }) };

            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

    }
}


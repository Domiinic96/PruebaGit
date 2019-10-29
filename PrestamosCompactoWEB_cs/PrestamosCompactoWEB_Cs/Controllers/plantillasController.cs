using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using System.Text;
using PrestamosCompactoWEB_Cs.Models;
using System.Data;






namespace PrestamosCompactoWEB_Cs.Controllers
{
    public class plantillasController : Controller
    {

        //GET: plantillas
        int pag = 1;
        double lValorCuotaOriginal;
        string strConcepto, strConceptoCompletivo, strCuota, lPrimeraCuota;
        VariablesGlobales vg = new VariablesGlobales(); //para poder invocar las variables que tengo en la clase Variables Golbales
        //iTextSharp.text.Image Imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\ICDIGITAL105\Documents\Visual Studio 2015\Projects\Web_ICDigital_Cs\Web_ICDigital_Cs\Content\Images\LogoPrueba.png");
        Document document = new Document(PageSize.A4, 10, 10, 10, 10);
       
        public ActionResult Index()
        {
            return View();
        }


        public string RowsCobrosRealizados(string FechaDesde, string FechaHasta, byte FormaReporte, string CodigoCobrador, string NombreCobrador)


        {            
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            DateTime FechaDia = Convert.ToDateTime("01/01/2015");
            DateTime FechaAnt = Convert.ToDateTime("01/01/2015");
            decimal TgCapital = 0;
            decimal TgInteres = 0;
            decimal TgMora = 0;
            decimal TgOtros = 0;
            decimal TrCapital = 0;
            decimal TrInteres = 0;
            decimal TrMora = 0;
            decimal TrOtros = 0;
            decimal TcCapital = 0;
            decimal TcInteres = 0;
            decimal TcMora = 0;
            decimal TcOtros = 0;
            decimal TCapitalDia = 0;
            decimal TInteresDia = 0;
            decimal TMoraDia = 0;
            decimal TOtrosDia = 0;
            string Tipomov;
            string VendAnterior ="";

            decimal dmora = 0;
            decimal dinteres = 0;
            decimal dotros = 0;


            StringBuilder lTabla = new StringBuilder();
            StringBuilder lTabla1 = new StringBuilder();
            StringBuilder TablaDia = new StringBuilder();

            //int pag = 1;
            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");
 

            row0 = "<table>";
            row += "<tr>";
            row += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";   
            row += "<td class=' negrita' colspan='3'>PRESTIN</td>";
            row += "<td colspan='4'>&nbsp;</td>";
            row += "<td  class='Derecha'colspan='3'> Pág. : {npag} de {fpag}</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            row += "<td class='' colspan='4'>Listado de Cobros Realizados</td>";
            row += "</tr>";
            row += "<tr>";
            if (CodigoCobrador != "")
            {
                row += "<td Class='' colspan='2'>" + CodigoCobrador + "-" + NombreCobrador +"</td>";
            }
            else
            { 
            row += "<td Class='' colspan='2'>&nbsp;</td>";
            }
            row += "<td  colspan='5'>Desde: " + FechaDesde + " &nbsp;&nbsp;&nbsp; Hasta: " + FechaHasta + "</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td colspan='7' class='expadin'>&nbsp;</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<th>Cliente</th>";
            row += "<th>Contrato</th>";
            row += "<th>Documento</th>";
            row += "<th>Mov.</th>";
            row += "<th>Dia</th>";
            row += "<th class='dvalor'>Capital</th>";
            row += "<th class='dvalor'>Intereses</th>";
            row += "<th class='dvalor'>Mora</th>";
            row += "<th class='dvalor'>Otros</th>";
            row += "<th class='dvalor'>Total</th>";
            row += "</tr>";
          
     
            lTabla.Append(row0);
            lTabla.Append(row);

            lTabla = lTabla.Replace("{npag}", pag.ToString());         


            List<CobrosRealizados> i = (List<CobrosRealizados>)Session["RptCobrosRealizados"];

            for (int c = 0; c <= i.Count  -1 ; c++)
            {
                if (FormaReporte == 0 && VendAnterior != i[c].CodigoCobrador)
                {
                    if (c != 0)
                    {                        
                        lTabla.Append(TotalDia(TCapitalDia, TInteresDia, TMoraDia, TOtrosDia));

                        if (cont == 56)
                        {
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());
                            lTabla.Append(row);
                            cont = 0;
                        }
                        lTabla.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                             "<td class='centro negrita dvalor'  colspan='2' >Total General " + "</td>" +
                             "<td class='centro negrita'>" + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TgCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TgMora).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TgOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TgCapital + TgInteres + TgMora + TgOtros).ToString("N")) + "</td>" +
                          "</tr>"));
                        cont += 4;

                        if (cont == 56)
                        {
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());
                            lTabla.Append(row);
                            cont = 0;
                        }

                        for (int xx = 2; xx <= 56 - cont; xx = xx + 2)
                        {


                            lTabla.Append("<tr>" +
                          "<td class='dobserv'></td>" +
                          "<td class='medcol centro'></td>" +
                           "<td class='medcol centro'></td>" +
                           "<td class='medcol'></td>" +
                           "<td class='medDIa'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor negrita'></td>" +
                           "</tr>");
                        }
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }
                    lTabla1.Clear();
                    lTabla1.Append("<tr>" +
                             "<td class='dobserv negrita'>" + i[c].CodigoCobrador + "-" + i[c].NombreCobrador + "</td>" +
                              "</tr>");

                    cont += 2;
                    lTabla.Append(lTabla1.ToString());

                    if (cont == 56)
                    {
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }


                }

                if ( c != 0 && FechaAnt != Convert.ToDateTime(i[c].FechaDocCont) && VendAnterior == i[c].CodigoCobrador)
                    {

                    lTabla.Append(TotalDia(TCapitalDia, TInteresDia, TMoraDia, TOtrosDia));
                    cont += 2;
                    TCapitalDia = 0;
                    TInteresDia = 0;
                    TMoraDia = 0;
                    TOtrosDia = 0;


                    if (cont == 56)
                    {
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }

                    //lTabla.Append(TablaDia.ToString());

                }

                Tipomov = "";
                if (i[c].TipoMovimiento  == 0)
                {
                    Tipomov = "Debito";
                }
                else if(i[c].TipoMovimiento == 1) //Credito
                    {
                    Tipomov = "Credito";
                }
       
               
                lTabla1.Clear();
                lTabla1.Append("<tr>" +
               "<td class='dobserv'>" + i[c].NombreCliente+ "</td>" +
               "<td class='medcol'>" + i[c].Contrato + "</td>" +
                "<td class='medcol'>" + i[c].TipoDocumento +"-"+ i[c].NoDocumento + "</td>" +
                "<td class='medcol'>" + Tipomov  + "</td>" +
                "<td class='medDIa'>" + Convert.ToDateTime(i[c].FechaDocCont).ToString("dd") + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].Capital).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].Interes).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].Mora).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].Otros).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].Total).ToString("N")) + "</td>" +
                "</tr>");

                lTabla.Append(lTabla1.ToString());

                cont += 2;
                if (cont == 56)
                {
                    pag += 1;
                    lTabla = lTabla.Replace("{npag}", pag.ToString());
                    lTabla.Append(row);
                    cont = 0;
                }

                TgCapital = TgCapital + i[c].Capital;
                TgInteres = TgInteres + i[c].Interes;
                TgMora = TgMora + i[c].Mora;
                TgOtros = TgOtros + i[c].Otros;

                TCapitalDia = TCapitalDia + i[c].Capital;
                TInteresDia= TInteresDia + i[c].Interes;
                TMoraDia = TMoraDia + i[c].Mora;
                TOtrosDia = TOtrosDia + i[c].Otros;

                TrCapital = TgCapital;
                TrInteres = TgInteres;
                TrMora = TgMora;
                TgOtros = TgOtros;
                
                VendAnterior = i[c].CodigoCobrador;
                FechaAnt = Convert.ToDateTime(i[c].FechaDocCont);


            }


            lTabla.Append(TotalDia(TCapitalDia, TInteresDia, TMoraDia, TOtrosDia));

        lTabla.Append("<tr>" +
                            "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                            "<td class='centro negrita dvalor'  colspan='2' >Total General "  + "</td>" +
                            "<td class='centro negrita'>" + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TgCapital.ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TgMora).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TgOtros).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TgCapital + TgInteres + TgMora + TgOtros).ToString("N")) + "</td>" +
                         "</tr>"));


            lTabla = lTabla.Replace("{npag}", pag.ToString());
            pag += 1; 
            lTabla = lTabla.Replace("{fpag}", pag.ToString());
            lTabla = lTabla.Replace("{Fecha}", Fecha.ToString());
            lTabla = lTabla.Replace("{Hora}", Hora.ToString());
            cont += 4;
            for (int xx = 2; xx <= 56 - cont; xx = xx + 2)
            {                
                lTabla.Append("<tr>" +
              "<td class='dobserv'></td>" +
              "<td class='medcol centro'></td>" +
               "<td class='medcol centro'></td>" +
               "<td class='medcol'></td>" +
               "<td class='medDIa'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor negrita'></td>" +
               "</tr>");
            }
            lTabla.Append("</table>");
            
            lTabla.Append(GeneraResumenDetalle(i, FechaDesde, FechaHasta));

            return lTabla.ToString();
        }


        public string GeneraResumenDetalle(List<CobrosRealizados> i, string FechaDesde, string FechaHasta)
        {
            string rowResumen = string.Empty;
            string rowResumen1 = string.Empty;
            StringBuilder lTablaResumen = new StringBuilder();
            string VendAnterior = "";
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            decimal tcCapital = 0;
            decimal tcInteres = 0;
            decimal tcMora = 0;
            decimal tcOtros = 0;

            decimal TgCapital = 0;
            decimal TgInteres = 0;
            decimal TgMora = 0;
            decimal TgOtros = 0;
            decimal TrCapital = 0;
            decimal TrInteres = 0;
            decimal TrMora = 0;
            decimal TrOtros = 0;
            string TipoDoc ="";
            string NombreCobrador = "";

            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");

            rowResumen1 = "<table>";
            rowResumen += "<tr>";
            rowResumen += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            rowResumen += "<td class=' negrita' colspan='3'>PRESTIN</td>";
            rowResumen += "<td colspan='2'>&nbsp;</td>";
            rowResumen += "<td  class='Derecha'colspan='1'> Pág. : {npag} de {fpag}</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            rowResumen += "<td class='' colspan='4'>Listado de Cobros Realizados</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";

            rowResumen += "<td Class='' colspan='2'>&nbsp;</td>";
            rowResumen += "<td  colspan='5'>Desde: " + FechaDesde + " &nbsp;&nbsp;&nbsp; Hasta: " + FechaHasta + "</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td colspan='7' class='expadin'>&nbsp;</td>";
            rowResumen += "</tr>";

            rowResumen += "<tr>";                        
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='font'>Resumen</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "</tr>";
            //rowResumen += "<tr>";
            //rowResumen += "<th>&nbsp;</th>";
            //rowResumen += "<th>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "</tr>";
            lTablaResumen.Append(rowResumen1);
            lTablaResumen.Append(rowResumen);

            lTablaResumen.Append("<tr>" +
                           "<td class='dobserv negrita' colspan='2'>Cobrador</td>" +
                           "<td class='centro negrita'>Tipo Documento" + "</td>" +
                           "<td class='dvalor negrita'> Capital" + "</td>" +
                           "<td class='dvalor negrita'>Interes</td>" +
                           "<td class='dvalor negrita'>Mora</td>" +
                           "<td class='dvalor negrita'>Otros</td>" +
                           "<td class='dvalor negrita'>Total</td>" +
                        "</tr>");


            for (int c = 0; c <= i.Count - 1; c++)

            {

                if (c != 0 && VendAnterior != i[c].CodigoCobrador)
                {

                    if (cont == 56)
                    {
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                        lTablaResumen.Append(rowResumen);
                        cont = 0;
                    }

                    lTablaResumen.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, (NombreCobrador.Length < 25) ? NombreCobrador.Length : 25) + "</td>" +
                             "<td class='centro'> " + TipoDoc + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                          "</tr>"));

                    TrCapital = 0;
                    TrInteres = 0;
                    TrMora = 0;
                    TrOtros = 0;

                
                    // dmora = 0;
                    // dinteres = 0;
                    //dotros = 0;



                    lTablaResumen.Append("<tr>" +
                    "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                    "<td class='centro negrita dvalor'> Total Cobrador </td>" +
                    "<td class='negrita dvalor '>" + string.Format((tcCapital.ToString("N")) + "</td>" +
                    "<td class='negrita dvalor'>" + string.Format((tcInteres).ToString("N")) + "</td>" +
                    "<td class='negrita dvalor'>" + string.Format((tcMora).ToString("N")) + "</td>" +
                    "<td class='negrita dvalor'>" + string.Format((tcOtros).ToString("N")) + "</td>" +
                    "<td class='negrita dvalor'>" + string.Format((tcCapital + tcInteres + tcMora + tcOtros).ToString("N")) + "</td>" +
                    "</tr>"));

                    tcCapital = 0;
                    tcInteres = 0;
                    tcMora = 0;
                    tcOtros = 0;

                    cont += 2;


                    cont += 2;
                }

                if (c != 0 && TipoDoc != i[c].TipoDocumento)
                {
                    if (cont == 56)
                    {
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                        lTablaResumen.Append(rowResumen);
                        cont = 0;
                    }

                    lTablaResumen.Append("<tr>"+
                        "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, (NombreCobrador.Length < 25)? NombreCobrador.Length : 25) + "</td>" +
                             "<td class='centro'> " + TipoDoc + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                          "</tr>"));

                    TrCapital = 0;
                    TrInteres = 0;
                    TrMora = 0;
                    TrOtros = 0;

                    cont += 2;
                }
              

                if (i[c].TipoMovimiento == 0)
                {
                    TrCapital = TrCapital + i[c].Capital;
                    TrInteres = TrInteres + i[c].Interes;
                    TrMora = TrMora + i[c].Mora;
                    TrOtros = TrOtros + i[c].Otros;

                    TgCapital = TgCapital + i[c].Capital;
                    TgInteres = TgInteres + i[c].Interes;
                    TgMora = TgMora + i[c].Mora;
                    TgOtros = TgOtros + i[c].Otros;
                    tcCapital = tcCapital + i[c].Capital;
                }
                else if(i[c].TipoMovimiento == 1) //Credito
                {
                    TrCapital = TrCapital - i[c].Capital;
                    TrInteres = TrInteres - i[c].Interes;
                    TrMora = TrMora - i[c].Mora;
                    TrOtros = TrOtros - i[c].Otros;


                    TgCapital = TgCapital - i[c].Capital;
                    TgInteres = TgInteres - i[c].Interes;
                    TgMora = TgMora - i[c].Mora;
                    TgOtros = TgOtros - i[c].Otros;

                    tcCapital = tcCapital - i[c].Capital;
                    tcInteres = tcInteres - i[c].Interes;
                    tcMora = tcMora - i[c].Mora;
                    tcOtros = tcOtros - i[c].Otros;

                }
 

                VendAnterior = i[c].CodigoCobrador;
                NombreCobrador = i[c].NombreCobrador.PadRight(25, ' ');
                TipoDoc = i[c].TipoDocumento;
            }

            if (cont == 56)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }
                      


            lTablaResumen.Append("<tr>" +
                            "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, (NombreCobrador.Length < 25) ? NombreCobrador.Length : 25) + "</td>" +
                            "<td class='centro'> " + TipoDoc + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                         "</tr>"));
            cont += 2;

            if (cont == 56)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                 "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                 "<td class='centro negrita dvalor'> Total Cobrador </td>" +
                 "<td class='negrita dvalor '>" + string.Format((tcCapital.ToString("N")) + "</td>" +
                 "<td class='negrita dvalor'>" + string.Format((tcInteres).ToString("N")) + "</td>" +
                 "<td class='negrita dvalor'>" + string.Format((tcMora).ToString("N")) + "</td>" +
                 "<td class='negrita dvalor'>" + string.Format((tcOtros).ToString("N")) + "</td>" +
                 "<td class='negrita dvalor'>" + string.Format((tcCapital + tcInteres + tcMora + tcOtros).ToString("N")) + "</td>" +
                 "</tr>"));

            tcCapital = 0;
            tcInteres = 0;
            tcMora = 0;
            tcOtros = 0;

            cont += 2;

            if (cont == 56)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                           "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                           "<td class='centro negrita dvalor'> Total General </td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgCapital.ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgMora).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgOtros).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgCapital + TgInteres + TgMora + TgOtros).ToString("N")) + "</td>" +
                        "</tr>"));
            cont += 2;



            lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{fpag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{Fecha}", Fecha.ToString());
            lTablaResumen = lTablaResumen.Replace("{Hora}", Hora.ToString());

            lTablaResumen.Append("</table>");



            return lTablaResumen.ToString();

        }

        public string GeneraResumenResumido(string FechaDesde, string FechaHasta)
        {
            string rowResumen = string.Empty;
            string rowResumen1 = string.Empty;
            StringBuilder lTablaResumen = new StringBuilder();
            string VendAnterior = "";
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;

            decimal TgCapital = 0;
            decimal TgInteres = 0;
            decimal TgMora = 0;
            decimal TgOtros = 0;
            decimal TrCapital = 0;
            decimal TrInteres = 0;
            decimal TrMora = 0;
            decimal TrOtros = 0;
            string TipoDoc = "";
            string NombreCobrador = "";



            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");
            List<CobrosRealizados> i = (List<CobrosRealizados>)Session["RptCobrosRealizados"];




            rowResumen1 = "<table>";
            rowResumen += "<tr>";
            rowResumen += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            rowResumen += "<td class=' negrita' colspan='3'>"+ Session["NombreCia"].ToString().Substring(0, (Session["NombreCia"].ToString().Length < 48) ? Session["NombreCia"].ToString().Length : 48) +" </td>";
            rowResumen += "<td colspan='2'>&nbsp;</td>";
            rowResumen += "<td  class='Derecha'colspan='1'> Pág. : {npag} de {fpag}</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            rowResumen += "<td class='' colspan='4'>Listado de Cobros Realizados</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";

            rowResumen += "<td Class='' colspan='2'>&nbsp;</td>";
            rowResumen += "<td  colspan='5'>Desde: " + FechaDesde + " &nbsp;&nbsp;&nbsp; Hasta: " + FechaHasta + "</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td colspan='7' class='expadin'>&nbsp;</td>";
            rowResumen += "</tr>";

            rowResumen += "<tr>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='font'>Resumen</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            rowResumen += "</tr>";
            //rowResumen += "<tr>";
            //rowResumen += "<th>&nbsp;</th>";
            //rowResumen += "<th>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "<th class='dvalor'>&nbsp;</th>";
            //rowResumen += "</tr>";
            lTablaResumen.Append(rowResumen1);
            lTablaResumen.Append(rowResumen);

            lTablaResumen.Append("<tr>" +
                           "<td class='dobserv negrita' colspan='2'>Cobrador</td>" +
                           "<td class='centro negrita'>Documento " + "</td>" +
                           "<td class='dvalor negrita'> Capital" + "</td>" +
                           "<td class='dvalor negrita'>Interes</td>" +
                           "<td class='dvalor negrita'>Mora</td>" +
                           "<td class='dvalor negrita'>Otros</td>" +
                           "<td class='dvalor negrita'>Total</td>" +
                        "</tr>");


            for (int c = 0; c <= i.Count - 1; c++)

            {

                if (c != 0 && VendAnterior != i[c].CodigoCobrador)
                {

                    if (cont == 56)
                    {
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                        lTablaResumen.Append(rowResumen);
                        cont = 0;
                    }

                    lTablaResumen.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, 25) + "</td>" +
                             "<td class='centro'> " + TipoDoc + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                          "</tr>"));

                    TrCapital = 0;
                    TrInteres = 0;
                    TrMora = 0;
                    TrOtros = 0;

                    cont += 2;
                }

                if (c != 0 && TipoDoc != i[c].TipoDocumento)
                {
                    if (cont == 56)
                    {
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                        lTablaResumen.Append(rowResumen);
                        cont = 0;
                    }

                    lTablaResumen.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, 25) + "</td>" +
                             "<td class='centro'> " + TipoDoc + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                          "</tr>"));

                    TrCapital = 0;
                    TrInteres = 0;
                    TrMora = 0;
                    TrOtros = 0;

                    cont += 2;
                }


                if (i[c].TipoMovimiento == 0)
                {
                    TrCapital = TrCapital + i[c].Capital;
                    TrInteres = TrInteres + i[c].Interes;
                    TrMora = TrMora + i[c].Mora;
                    TrOtros = TrOtros + i[c].Otros;

                    TgCapital = TgCapital + i[c].Capital;
                    TgInteres = TgInteres + i[c].Interes;
                    TgMora = TgMora + i[c].Mora;
                    TgOtros = TgOtros + i[c].Otros;
                }
                else if (i[c].TipoMovimiento == 1) //Credito
                {
                    TrCapital = TrCapital - i[c].Capital;
                    TrInteres = TrInteres - i[c].Interes;
                    TrMora = TrMora - i[c].Mora;
                    TrOtros = TrOtros - i[c].Otros;


                    TgCapital = TgCapital - i[c].Capital;
                    TgInteres = TgInteres - i[c].Interes;
                    TgMora = TgMora - i[c].Mora;
                    TgOtros = TgOtros - i[c].Otros;
                }


                VendAnterior = i[c].CodigoCobrador;
                NombreCobrador = i[c].NombreCobrador.PadRight(25, ' ');
                TipoDoc = i[c].TipoDocumento;
            }

            if (cont == 56)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                            "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, (NombreCobrador.Length < 25) ? NombreCobrador.Length : 25) + "</td>" +
                            "<td class='centro'> " + TipoDoc + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                         "</tr>"));
            cont += 2;

            if (cont == 56)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                           "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                           "<td class='centro negrita dvalor'> Total General: </td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgCapital.ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgMora).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgOtros).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgCapital + TgInteres + TgMora + TgOtros).ToString("N")) + "</td>" +
                        "</tr>"));
            cont += 2;



            lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{fpag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{Fecha}", Fecha.ToString());
            lTablaResumen = lTablaResumen.Replace("{Hora}", Hora.ToString());

            lTablaResumen.Append("</table>");



            return lTablaResumen.ToString();

        }


        public string TotalDia(decimal TCapitalDia, decimal TInteresDia, decimal TMoraDia, decimal TOtrosDia)
        {
            string lTabla;
           

            List<CobrosRealizados> i = (List<CobrosRealizados>)Session["RptCobrosRealizados"];

            lTabla = "<tr>" +
                                    "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                                    "<td class='centro negrita dvalor'  colspan='2' >Total Del Día " + "</td>" +
                                    "<td class='centro negrita'>" + "</td>" +
                                    "<td class='dvalor negrita'>" + string.Format((TCapitalDia).ToString("N")) + "</td>" +
                                    "<td class='dvalor negrita'>" + string.Format((TInteresDia).ToString("N")) + "</td>" +
                                    "<td class='dvalor negrita'>" + string.Format((TMoraDia).ToString("N")) + "</td>" +
                                    "<td class='dvalor negrita'>" + string.Format((TMoraDia).ToString("N")) + "</td>" +
                                    "<td class='dvalor negrita'>" + string.Format((TCapitalDia + TInteresDia + TMoraDia + TOtrosDia).ToString("N")) + "</td>" +
                                 "</tr>";


            //lTabla.Append("<tr>" +
            //           "<td class='dobserv'>.</td>" +
            //           "<td class='medcol centro'>.</td>" +
            //            "<td class='medcol centro'>.</td>" +
            //            "<td class='medcol'>.</td>" +
            //            "<td class='medDIa'>.</td>" +
            //            "<td class='dvalor'>.</td>" +
            //            "<td class='dvalor'>.</td>" +
            //            "<td class='dvalor'>.</td>" +
            //            "<td class='dvalor'>.</td>" +
            //            "<td class='dvalor negrita'>.</td>" +
            //            "</tr>");

            return lTabla;
        }


        public string RowsContratoDelMes(string FechaDesde, string FechaHasta, byte FormaReporte, string CodigoCobrador, string NombreCobrador)

        {
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            DateTime FechaDia = Convert.ToDateTime("01/01/2015");
            DateTime FechaAnt = Convert.ToDateTime("01/01/2015");
            decimal TcMonto = 0;
            decimal TcInteres = 0;
            string VendAnterior = "";
            int PrestamosNuevos= 0;
            int PrestamosNuevosCobrador = 0;

            StringBuilder lTabla = new StringBuilder();
            StringBuilder lTabla1 = new StringBuilder();
            StringBuilder TablaDia = new StringBuilder();

           
            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");


            if(FormaReporte == 0)
            { 
            row0 = "<table>";
            row += "<tr>";
            row += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            row += "<td class=' negrita' colspan='3'>"+Session["NombreCia"].ToString().Substring(0, (Session["NombreCia"].ToString().Length < 48) ? Session["NombreCia"].ToString().Length : 48) + "</td>";
            row += "<td colspan='3'>&nbsp;</td>";
            row += "<td  class='Derecha'colspan='3'> Pág. : {npag} de {fpag}</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            row += "<td class='' colspan='4'>Reporte Detallado del Mes</td>";
            row += "</tr>";
            row += "<tr>";
            if (CodigoCobrador != "")
            {
                row += "<td Class='' colspan='2'>" + CodigoCobrador + "-" + NombreCobrador + "</td>";
            }
            else
            {
                row += "<td Class='' colspan='2'>&nbsp;</td>";
            }
            row += "<td  colspan='5'>Desde: " + FechaDesde + " &nbsp;&nbsp;&nbsp; Hasta: " + FechaHasta + "</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td colspan='8' class='expadin'>&nbsp;</td>";
            row += "</tr>";
            if (FormaReporte == 0)
            {
                row += "<tr>";
                row += "<th class='medcol'>Contrato</th>";
                row += "<th colspan= '3'>Cliente</th>";
                row += "<th class='centro' >Fecha</th>";
                row += "<th class='dvalor medVal'>Monto</th>";
                row += "<th class='dvalor medVal'>Intereses</th>";
                row += "<th class='dvalor'>Tasa%</th>";
                row += "<th class='centro'>Cuotas</th>";
                row += "<th  colspan='2'class='medVec'>Vencimiento</th>";
                row += "</tr>";
            }
            else
            {
                row += "<tr>";
                row += "<th>&nbsp;</th>";
                row += "<th>&nbsp;</th>";
                row += "<th>&nbsp;</th>";
                row += "<th>&nbsp;</th>";
                row += "<th>&nbsp;</th>";
                row += "<th class='dvalor'>&nbsp;</th>";
                row += "<th class='dvalor'>&nbsp;</th>";
                row += "<th class='dvalor'>&nbsp;</th>";
                row += "<th class='dvalor'>&nbsp;</th>";
                row += "<th class='dvalor'>&nbsp;</th>";
                row += "</tr>";
            }
            lTabla.Append(row0);
            lTabla.Append(row);

            lTabla = lTabla.Replace("{npag}", pag.ToString());
            }
            List<ContratoDelMes> i = (List<ContratoDelMes>)Session["RptContratosDelMes"];

            for (int c = 0; c <= i.Count - 1; c++)
            {
                if (FormaReporte == 0 && VendAnterior != i[c].CodigoCobrador)
                {
                    if (c != 0)
                    {

                        if (cont == 80)
                        {
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());
                            lTabla.Append(row);
                            cont = 0;
                        }

                            lTabla.Append("<tr>" +
                            "<td class='dobserv negrita' colspan='2'>Total De Prestamos Nuevos: " + PrestamosNuevosCobrador + "</td>" +
                            "<td class='centro negrita'></td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "<td class='negrita dvalor '>" + string.Format((TcMonto.ToString("N")) + "</td>" +
                            "<td class='negrita dvalor'>" + string.Format((TcInteres).ToString("N")) + "</td>" +
                            "</tr>"));
                        PrestamosNuevosCobrador = 0;
                        TcMonto = 0;
                        TcInteres = 0;
                        cont += 2;

                        if (cont == 80)
                        {
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());
                            lTabla.Append(row);
                            cont = 0;
                        }

                        for (int xx = 0; xx <= 80 - cont; xx = xx + 2)
                        {


                            lTabla.Append("<tr>" +
                          "<td class='dobserv'></td>" +
                          "<td class='medcol centro'></td>" +
                           "<td class='medcol centro'></td>" +
                           "<td class='medcol'></td>" +
                           "<td class='medDIa'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>"+
                           "<td class='dvalor negrita'></td>" +
                           "</tr>");
                        }
                        pag += 1;
                        lTabla.Append(row);
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        cont = 0;
                    }
                    lTabla1.Clear();
                    lTabla1.Append("<tr>" +
                             "<td class='dobserv negrita'colspan='2'>" + i[c].CodigoCobrador + "-" + i[c].NombreCobrador + "</td>" +
                              "</tr>");

                    cont += 2;
                    lTabla.Append(lTabla1.ToString());

                    if (cont == 80)
                    {
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }


                }

                if(FormaReporte==0)
                { 
                lTabla1.Clear();
                lTabla1.Append("<tr>" +
               "<td class='medcol centro'>" + i[c].Contrato + "</td>" +
               "<td class='dobserv' colspan='2'>" + i[c].NombreCliente.Substring(0,(i[c].NombreCliente.Length < 30)? i[c].NombreCliente.Length:30) + "</td>" +
               "<td></td>"+
               "<td class='medFec'>" + Convert.ToDateTime(i[c].FechaPtm).ToString("dd/MM/yyyy") + "</td>" +
               "<td class='dvalor medVal'>" + string.Format((i[c].MontoPtm).ToString("N")) + "</td>" +
                "<td class='dvalor medVal'>" + string.Format((i[c].InteresPtm).ToString("N")) + "</td>" +
                "<td class='dvalor'>"+i[c].TasaInteres+"</td>" +
                "<td class='centro'>" + i[c].CuotasPtm + "</td>" +
                "<td class='medVec' colspan='2'>" + Convert.ToDateTime(i[c].Vencimiento).ToString("dd/MM/yyyy") + "</td>" +
                "<td class='dvalor'> </td>" +
                "</tr>");

                lTabla.Append(lTabla1.ToString());

                cont += 2;
                if (cont == 80)
                {
                    pag += 1;
                    lTabla = lTabla.Replace("{npag}", pag.ToString());
                    lTabla.Append(row);
                    cont = 0;
                }

                }
                PrestamosNuevos = PrestamosNuevos + 1;
                PrestamosNuevosCobrador = PrestamosNuevosCobrador + 1;


                TcMonto = TcMonto + i[c].MontoPtm;
                TcInteres = TcInteres + i[c].InteresPtm;

                VendAnterior = i[c].CodigoCobrador;
                FechaAnt = Convert.ToDateTime(i[c].FechaPtm);


            }

            if(FormaReporte == 0)
            { 
            lTabla.Append("<tr>" +
                                "<td class='dobserv negrita' colspan='2'>Total De Prestamos Nuevos: " + PrestamosNuevos +"</td>" +
                                "<td class='centro negrita'></td>" +
                                "<td></td>" +
                                 "<td></td>" +
                                "<td class='negrita dvalor'>" + string.Format((TcMonto.ToString("N")) + "</td>" +
                                "<td class='negrita dvalor'>" + string.Format((TcInteres).ToString("N")) + "</td>" +
                             "</tr>"));


            lTabla = lTabla.Replace("{npag}", pag.ToString());
            pag += 1;
            lTabla = lTabla.Replace("{fpag}", pag.ToString());
            lTabla = lTabla.Replace("{Fecha}", Fecha.ToString());
            lTabla = lTabla.Replace("{Hora}", Hora.ToString());
            cont += 2;
            
            for (int xx = 0; xx <= 80 - cont; xx = xx + 2)
            {
                lTabla.Append("<tr>" +
              "<td class='dobserv'></td>" +
              "<td class='medcol centro'></td>" +
               "<td class='medcol centro'></td>" +
               "<td class='medcol'></td>" +
               "<td class='medDIa'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor negrita'></td>" +
               "</tr>");
            }
            lTabla.Append("</table>");
            }
            lTabla.Append(GeneraResumenDetalleMes(i, FechaDesde, FechaHasta));

            return lTabla.ToString();
        }


        public string GeneraResumenDetalleMes(List<ContratoDelMes> i, string FechaDesde, string FechaHasta)
        {
            string rowResumen = string.Empty;
            string rowResumen1 = string.Empty;
            StringBuilder lTablaResumen = new StringBuilder();
            string VendAnterior = "";
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;

            decimal tgMonto = 0;
            decimal TgInteres = 0;
            decimal TgMora = 0;
            decimal TgOtros = 0;
            decimal TcMonto = 0;
            decimal TcInteres = 0;
            decimal TrMora = 0;
            decimal TrOtros = 0;
            string TipoDoc = "";
            string NombreCobrador = "";



            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");

            

            rowResumen1 = "<table>";
            rowResumen += "<tr>";
            rowResumen += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            rowResumen += "<td class=' negrita' colspan='3'>"+ Session["NombreCia"].ToString().Substring(0, (Session["NombreCia"].ToString().Length < 48) ? Session["NombreCia"].ToString().Length : 48) + "</td>";
            rowResumen += "<td colspan='1'>&nbsp;</td>";
            rowResumen += "<td  class='Derecha'colspan='2'> Pág. : {npag} de {fpag}</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            rowResumen += "<td class='' colspan='4'>Listado de Cobros Realizados</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";

            rowResumen += "<td Class='' colspan='2'>&nbsp;</td>";
            rowResumen += "<td  colspan='5'>Desde: " + FechaDesde + " &nbsp;&nbsp;&nbsp; Hasta: " + FechaHasta + "</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td colspan='7' class='expadin'>&nbsp;</td>";
            rowResumen += "</tr>";

            rowResumen += "<tr>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th class='dvalor medVal'>&nbsp;</th>";
            rowResumen += "<th class='font medVal'>Resumen</th>";
            rowResumen += "<th class='dvalor medVal'>&nbsp;</th>";
            rowResumen += "<th class='dvalor medVal'>&nbsp;</th>";
            rowResumen += "</tr>";
      
            lTablaResumen.Append(rowResumen1);
            lTablaResumen.Append(rowResumen);

            lTablaResumen.Append("<tr>" +
                           "<td class='dobserv negrita' colspan='2'>Cobrador</td>" +
                           "<td class='negrita'>&nbsp;</td>" +
                           "<td class='dvalor negrita medVal'>Monto</td>" +
                           "<td class='dvalor negrita medVal'>Interes</td>" +
                           "<td class='dvalor negrita medVal'>Total</td>" +
                        "</tr>");


            for (int c = 0; c <= i.Count - 1; c++)

            {

                if (c != 0 && VendAnterior != i[c].CodigoCobrador)
                {

                    if (cont == 80)
                    {
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                        lTablaResumen.Append(rowResumen);
                        cont = 0;
                    }

                    lTablaResumen.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, 25) + "</td>" +
                             "<td class='negrita'>&nbsp;</td>" +
                             "<td class='dvalor medVal'>" + string.Format((TcMonto.ToString("N")) + "</td>" +
                             "<td class='dvalor medVal'>" + string.Format((TcInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor medVal'>" + string.Format((TcMonto + TcInteres).ToString("N")) + "</td>" +
                          "</tr>"));

                    TcMonto = 0;
                    TcInteres = 0;
                    cont += 2;
                }

                if (cont == 80)
                    {
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                        lTablaResumen.Append(rowResumen);
                        cont = 0;
                    }

                cont += 2;

                        TcMonto = TcMonto + i[c].MontoPtm;
                        TcInteres = TcInteres + i[c].InteresPtm;
                    
                        tgMonto = tgMonto + i[c].MontoPtm;
                        TgInteres = TgInteres + i[c].InteresPtm;

                        VendAnterior = i[c].CodigoCobrador;
                        NombreCobrador = i[c].NombreCobrador.PadRight(25, ' ');
            }

            if (cont == 80)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                            "<td class='dobserv' colspan='2'>" + VendAnterior + "-" + NombreCobrador.Substring(0, 25) + "</td>" +
                           "<td class='negrita'>&nbsp;</td>" +
                            "<td class='dvalor medVal'>" + string.Format((TcMonto.ToString("N")) + "</td>" +
                            "<td class='dvalor medVal'>" + string.Format((TcInteres).ToString("N")) + "</td>" +
                            "<td class='dvalor medVal'>" + string.Format((TcMonto + TcInteres).ToString("N")) + "</td>" +
                         "</tr>"));
            cont += 2;

            if (cont == 80)
            {
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                lTablaResumen.Append(rowResumen);
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                           "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                           "<td class='centro negrita dvalor'>  </td>" +
                           "<td class='dvalor negrita medVal'>" + string.Format((tgMonto.ToString("N")) + "</td>" +
                           "<td class='dvalor negrita medVal'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita medVal'>" + string.Format((tgMonto + TgInteres).ToString("N")) + "</td>" +
                        "</tr>"));
            cont += 2;



            lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{fpag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{Fecha}", Fecha.ToString());
            lTablaResumen = lTablaResumen.Replace("{Hora}", Hora.ToString());

            lTablaResumen.Append("</table>");



            return lTablaResumen.ToString();

        }


        public string RowsUltimaCuota(string FechaHasta,  string CodigoCobrador, string NombreCobrador)


        {
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            DateTime FechaDia = Convert.ToDateTime("01/01/2015");
            DateTime FechaAnt = Convert.ToDateTime("01/01/2015");
            decimal TcMonto = 0;
            decimal TcInteres = 0;
            string VendAnterior = "";
            int PrestamosNuevos = 0;
            int PrestamosNuevosCobrador = 0;

            StringBuilder lTabla = new StringBuilder();
            StringBuilder lTabla1 = new StringBuilder();
            StringBuilder TablaDia = new StringBuilder();


            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");

            //Variable para almacenar el nombre de la compañia, Substring de 48
          
                row0 = "<table>";
                row += "<tr>";
                row += "<td class='medcolpe'></td>";
                row += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
                row += "<td class=' negrita' colspan='3'>"+ Session["NombreCia"].ToString().Substring(0, (Session["NombreCia"].ToString().Length < 48) ? Session["NombreCia"].ToString().Length : 48) + "</td>";
                row += "<td colspan='3'>&nbsp;</td>";
                row += "<td  class='Derecha'colspan='2'> Pág. : {npag} de {fpag}</td>";
                row += "</tr>";
                row += "<tr>";
                row += "<td class='medcolpe'></td>";
                row += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
                row += "<td class='' colspan='6'>Listado de Prestamos que Pagaran la Ultima Cuota </td>";
                row += "</tr>";
                row += "<tr>";

            if (CodigoCobrador != "")
                {
                row += "<td class='medcolpe'></td>";
                row += "<td Class='' colspan='2'>" + CodigoCobrador + "-" + NombreCobrador + "</td>";
                }
                else
                {
                    row += "<td Class='' colspan='2'>&nbsp;</td>";
                }
                row += "<td  colspan='5'>Fecha Hasta: " + Fecha + "</td>";
                row += "</tr>";
                row += "<tr>";
                row += "<td colspan='5' class='expadin'>&nbsp;</td>";
                row += "</tr>";


                    row += "<tr>";
                    row += "<td class='medcolpe'></td>";
                    row += "<th class='medcol'>Contrato</th>";
                    row += "<th colspan= '5'>Cliente</th>";
                    row += "<th class='centro'>Cuotas</th>";
                    row += "<th class='centro medFec' >Fecha</th>";
                    row += "<th class='dvalor medVal'>Monto</th>";
            row += "</tr>";
             
                lTabla.Append(row0);
                lTabla.Append(row);

                lTabla = lTabla.Replace("{npag}", pag.ToString());
            
            List<ReporteUltimaCuotaDeContrato> i = (List<ReporteUltimaCuotaDeContrato>)Session["RptUltimaCuota"];

            for (int c = 0; c <= i.Count - 1; c++)
            {
                if (VendAnterior != i[c].CodigoCobrador)
                {
                    if (c != 0)
                    {

                        if (cont == 80)
                        {
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());
                            lTabla.Append(row);
                            cont = 0;
                        }

                        lTabla.Append("<tr>" +
                        "<td class='medcolpe'></td>" +
                        "<td class='dobserv negrita' colspan='2'></td>" +
                        "<td class='centro negrita'></td>" +
                        "<td></td>" +
                        "<td></td>" +
                        "<td></td>" +
                           "<td></td>" +
                        "<td></td>" +
                        "<td class='negrita dvalor '>" + string.Format((TcMonto.ToString("N")) + "</td>" +
                        //"<td class='negrita dvalor'>" + string.Format((TcInteres).ToString("N")) + "</td>" +
                        "</tr>"));
                        PrestamosNuevosCobrador = 0;
                        TcMonto = 0;
                        TcInteres = 0;
                        cont += 2;

                        if (cont == 80)
                        {
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());
                            lTabla.Append(row);
                            cont = 0;
                        }

                        for (int xx = 0; xx <= 80 - cont; xx = xx + 2)
                        {


                            lTabla.Append("<tr>" +
                          "<td class='dobserv'></td>" +
                          "<td class='medcol centro'></td>" +
                           "<td class='medcol centro'></td>" +
                           "<td class='medcol'></td>" +
                           "<td class='medDIa'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor negrita'></td>" +
                           "</tr>");
                        }
                        pag += 1;
                        lTabla.Append(row);
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        cont = 0;
                    }
                    lTabla1.Clear();
               
                    lTabla1.Append("<tr>" +
                             "<td class='medcolpe'></td>" +
                             "<td class='dobserv negrita'colspan='2'>" + i[c].CodigoCobrador + "-" + i[c].NombreCobrador + "</td>" +
                              "</tr>");
                  
                    cont += 2;
                    lTabla.Append(lTabla1.ToString());

                    if (cont == 80)
                    {
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }


                }

              
                    lTabla1.Clear();
                    lTabla1.Append("<tr>" +
                   "<td class='medcolpe'></td>"+
                   "<td class='medcol'>" + i[c].Contrato + "</td>" +
                   "<td class='dobserv' colspan='4'>"+ i[c].CodigoCliente +"-"+ i[c].NombreCliente.Substring(0, (i[c].NombreCliente.Length < 30) ? i[c].NombreCliente.Length : 30) + "</td>" +
                   "<td></td>" +
                   "<td class='dvalor medFec'>" + i[c].CuotasPtm +"/" + i[c].CuotasPtm + "</td>" +
                   "<td class='medFec centro'>" + Convert.ToDateTime(i[c].FechaPtm).ToString("dd/MM/yyyy") + "</td>" +
                   "<td class='dvalor medVal'>" + string.Format((i[c].MontoPtm).ToString("N")) + "</td>" +
                   // "<td class='dvalor'> </td>" +
                    "</tr>");

                    lTabla.Append(lTabla1.ToString());

                    cont += 2;
                    if (cont == 80)
                    {
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }
                    

                TcMonto = TcMonto + i[c].MontoPtm;
             

                VendAnterior = i[c].CodigoCobrador;
                FechaAnt = Convert.ToDateTime(i[c].FechaPtm);


            }

        
                lTabla.Append("<tr>" +
                                    "<td class='medcolpe'></td>" +
                                    "<td class='dobserv negrita' colspan='2'></td>" +
                                    "<td class='centro negrita'></td>" +
                                    "<td></td>" +
                                    "<td></td>" +
                                    "<td></td>" +
                                    "<td></td>" +
                                    "<td></td>" +
                                    "<td class='negrita dvalor'>" + string.Format((TcMonto.ToString("N")) + "</td>" +
                                    //"<td class='negrita dvalor'>" + string.Format((TcInteres).ToString("N")) + "</td>" +
                                 "</tr>"));


                lTabla = lTabla.Replace("{npag}", pag.ToString());
                lTabla = lTabla.Replace("{fpag}", pag.ToString());
                lTabla = lTabla.Replace("{Fecha}", Fecha.ToString());
                lTabla = lTabla.Replace("{Hora}", Hora.ToString());
                cont += 2;

                for (int xx = 0; xx <= 80 - cont; xx = xx + 2)
                {
                    lTabla.Append("<tr>" +
                  "<td class='dobserv'></td>" +
                  "<td class='medcol centro'></td>" +
                   "<td class='medcol centro'></td>" +
                   "<td class='medcol'></td>" +
                   "<td class='medDIa'></td>" +
                   "<td class='dvalor'></td>" +
                   "<td class='dvalor'></td>" +
                   "<td class='dvalor'></td>" +
                   "<td class='dvalor'></td>" +
                   "<td class='dvalor negrita'></td>" +
                   "</tr>");
                }
                lTabla.Append("</table>");
         
            //lTabla.Append(GeneraResumenDetalleMes(i, FechaDesde, FechaHasta));

            return lTabla.ToString();
        }

        public string RowsPrestamosConBalance(string FechaHasta, string NombreCobrador)


        {
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            DateTime FechaDia = Convert.ToDateTime("01/01/2015");
            DateTime FechaAnt = Convert.ToDateTime("01/01/2015");
            decimal TgCapital = 0;
            decimal TgInteres = 0;
            decimal TgComision = 0;
            decimal TgMora = 0;
            decimal TgOtros = 0;
            decimal TrCapital = 0;
            decimal TrInteres = 0;
            decimal TrComision = 0;
            decimal TrMora = 0;
            decimal TrOtros = 0;
            decimal TcCapital = 0;
            decimal TcInteres = 0;
            decimal TcComision = 0;
            decimal TcMora = 0;
            decimal TcOtros = 0;
            decimal TCapitalDia = 0;
            decimal TInteresDia = 0;
            decimal TComisionDia = 0;
            decimal TMoraDia = 0;
            decimal TOtrosDia = 0;
            string Tipomov;
            string VendAnterior = "";

            StringBuilder lTabla = new StringBuilder();
            StringBuilder lTabla1 = new StringBuilder();
            StringBuilder TablaDia = new StringBuilder();

            //int pag = 1;
            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");


            row0 = "<table>";
            row += "<tr>";
            row += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            row += "<td class=' negrita' colspan='3'>PRESTIN</td>";
            row += "<td colspan='4'>&nbsp;</td>";
            row += "<td  class='Derecha'colspan='3'> Pág. : {npag} de {fpag}</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            row += "<td class='' colspan='4'>Reporte de Prestamos Con Balance</td>";
            row += "</tr>";
            row += "<tr>";            
            row += "<td Class='' colspan='2'>" + NombreCobrador + "</td>";
            row += "<td  colspan='5'>Hasta: " + FechaHasta + "</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td colspan='7' class='expadin'>&nbsp;</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<th class='medcol'>Contrato</th>";
            row += "<th>Cliente</th>";
            row += "<th class='centro'>Cuotas Venc.</th>";
            row += "<th class='centro'>Dias Venc.</th>";
            row += "<th class='dvalor'>Capital</th>";
            row += "<th class='dvalor'>Intereses</th>";
            row += "<th class='dvalor'>Comision</th>";
            row += "<th class='dvalor'>Mora</th>";
            row += "<th class='dvalor'>Otros</th>";
            row += "<th class='dvalor'>Total</th>";

            row += "</tr>";


            lTabla.Append(row0);
            lTabla.Append(row);

            lTabla = lTabla.Replace("{npag}", pag.ToString());


            List<ContratosConBalance> i = (List<ContratosConBalance>)Session["RptPrestamosConBalance"];

            for (int c = 0; c <= i.Count - 1; c++)
            {
                if (VendAnterior != i[c].Cobrador)  //Cambio de Cobrador
                {
                    if (c != 0)
                    {
                        //lTabla.Append(TotalDia(TCapitalDia, TInteresDia, TMoraDia, TOtrosDia));

                        if (cont == 56)
                        {
                            lTabla.Append(row);
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());                            
                            cont = 0;
                        }
                        lTabla.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                             "<td class='centro negrita dvalor'  colspan='2' >Total Cobrador " + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TrComision).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor negrita'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                          "</tr>"));
                        cont += 4; //Sumarle 4 para que se pueda generar bien los encabezados de las siguiente paginas


                        TrCapital = 0;
                        TrInteres = 0;
                        TrComision = 0;
                        TrMora = 0;
                        TrOtros = 0;

                        if (cont == 56)
                        {
                            lTabla.Append(row);
                            pag += 1;
                            lTabla = lTabla.Replace("{npag}", pag.ToString());                            
                            cont = 0;
                        }

                        for (int xx = 2; xx <= 56 - cont; xx = xx + 2)
                        {


                            lTabla.Append("<tr>" +
                          "<td class='dobserv'></td>" +
                          "<td class='medcol centro'></td>" +
                           "<td class='medcol centro'></td>" +
                           "<td class='medcol'></td>" +
                           "<td class='medDIa'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "<td class='dvalor'></td>" +
                           "</tr>");
                        }

                        lTabla.Append(row);
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        
                        cont = 0;
                    }
                    lTabla1.Clear();
                    lTabla1.Append("<tr>" +
                             "<td class='dobserv negrita' colspan='2'>" + i[c].Cobrador + "</td>" +
                              "</tr>");

                    cont += 2;
                    lTabla.Append(lTabla1.ToString());

                    if (cont == 56)
                    {
                        lTabla.Append(row);
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());                        
                        cont = 0;
                    }

                }



                lTabla1.Clear();
                lTabla1.Append("<tr>" +
               "<td class='medcol'>" + i[c].Contrato + "</td>" +
               "<td class='dobserv'>" + i[c].NombreClte.Substring(0,(i[c].NombreClte.Length<50)? i[c].NombreClte.Length:50) + "</td>" +
               "<td class='medcol centro'>" + i[c].CuotasVenc + "</td>" +
               "<td class='medcol centro'>" + i[c].DiasVenc +"</td>" +               
                "<td class='dvalor'>" + string.Format((i[c].capital).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].interes).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].comision).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].mora).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].otros).ToString("N")) + "</td>" +
                "<td class='dvalor'>" + string.Format((i[c].capital+ i[c].interes+ i[c].comision+ i[c].mora+ i[c].otros).ToString("N")) + "</td>" +
                //"<td class='dvalor negrita'>" + string.Format((i[c].Total).ToString("N")) + "</td>" +
                "</tr>");              

                lTabla.Append(lTabla1.ToString());
                cont += 2;

                if (cont == 56)
                {
                    lTabla.Append(row);
                    pag += 1;
                    lTabla = lTabla.Replace("{npag}", pag.ToString());                    
                    cont = 0;
                }

                TrCapital = TrCapital + i[c].capital;
                TrInteres = TrInteres + i[c].interes;
                TrComision= TrComision + i[c].comision;
                TrMora = TrMora + i[c].mora;
                TrOtros = TrOtros + i[c].otros;

                TgCapital = TgCapital + i[c].capital;
                TgInteres = TgInteres + i[c].interes;
                TgComision = TgComision + i[c].comision;
                TgMora = TgMora + i[c].mora;
                TgOtros = TgOtros + i[c].otros;
                

                
                VendAnterior = i[c].Cobrador;

            }            

            lTabla.Append("<tr>" +
                            "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                            "<td class='centro negrita dvalor'  colspan='2' >Total Cobrador " + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TrComision).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                            "<td class='dvalor negrita'>" + string.Format((TrCapital + TrInteres + TrMora + TrOtros).ToString("N")) + "</td>" +
                         "</tr>"));
            cont += 2;

            if (cont == 56)
            {
                lTabla.Append(row);
                pag += 1;
                lTabla = lTabla.Replace("{npag}", pag.ToString());
                cont = 0;
            }


            lTabla.Append("<tr>" +
                           "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                           "<td class='centro negrita dvalor'  colspan='2' >Total General " + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgCapital.ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgComision).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgMora).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgOtros).ToString("N")) + "</td>" +
                           "<td class='dvalor negrita'>" + string.Format((TgCapital + TgInteres + TgMora + TgOtros).ToString("N")) + "</td>" +
                        "</tr>"));
            cont += 4;

            //if (cont == 56)
            //{
            //    lTabla.Append(row);
            //    pag += 1;
            //    lTabla = lTabla.Replace("{npag}", pag.ToString());
            //    cont = 0;
            //}


            lTabla = lTabla.Replace("{npag}", pag.ToString());
            lTabla = lTabla.Replace("{fpag}", pag.ToString());
            lTabla = lTabla.Replace("{Fecha}", Fecha.ToString());
            lTabla = lTabla.Replace("{Hora}", Hora.ToString());

            for (int xx = 2; xx <= 56 - cont; xx = xx + 2)
            {
                lTabla.Append("<tr>" +
              "<td class='dobserv'></td>" +
              "<td class='medcol centro'></td>" +
               "<td class='medcol centro'></td>" +
               "<td class='medcol'></td>" +
               "<td class='medDIa'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor'></td>" +
               "<td class='dvalor negrita'>....</td>" +
               "</tr>");
            }
            lTabla.Append("</table>");
            

            lTabla.Append(GeneraResumenDetallePrestamosConBalance(i,  FechaHasta));

            return lTabla.ToString();
        }

        public string GeneraResumenDetallePrestamosConBalance(List<ContratosConBalance> i, string FechaHasta)
        {
            string rowResumen = string.Empty;
            string rowResumen1 = string.Empty;
            StringBuilder lTablaResumen = new StringBuilder();
            string VendAnterior = "";
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            decimal tcCapital = 0;
            decimal tcInteres = 0;
            decimal tcMora = 0;
            decimal tcOtros = 0;

            decimal TgCapital = 0;
            decimal TgInteres = 0;
            decimal TgComision = 0;
            decimal TgMora = 0;
            decimal TgOtros = 0;
            decimal TrCapital = 0;
            decimal TrInteres = 0;
            decimal TrComision = 0;
            decimal TrMora = 0;
            decimal TrOtros = 0;
            string TipoDoc = "";
            string NombreCobrador = "";
            long cantiPrestamos = 0;

            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");
             
            rowResumen1 = "<table>";
            rowResumen += "<tr>";
            rowResumen += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            rowResumen += "<td class=' negrita' colspan='3'>PRESTIN</td>";
            rowResumen += "<td colspan='4'>&nbsp;</td>";
            rowResumen += "<td  class='Derecha'colspan='3'> Pág. : {npag} de {fpag}</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td Class= 'Derecha' colspan='2'>Hora : {Hora}</td>";
            rowResumen += "<td class='' colspan='4'>Reporte de Prestamos Con Balance</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td Class='' colspan='2'>&nbsp;</td>";
            rowResumen += "<td  colspan='5'>Hasta: " + FechaHasta + "</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";
            rowResumen += "<td colspan='7' class='expadin'>&nbsp;</td>";
            rowResumen += "</tr>";
            rowResumen += "<tr>";            
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th class='font'>Resumen</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "<th>&nbsp;</th>";
            rowResumen += "</tr>";


            lTablaResumen.Append(rowResumen1);
            lTablaResumen.Append(rowResumen);

            lTablaResumen.Append("<tr>" +
                                "<td class='dobserv negrita' colspan='2'>Cobrador</td>" +
                                "<td class='negrita'>Cantidad Prest.</td>" +
                                "<td class='dvalor negrita'>Capital</td>" +
                                "<td class='dvalor negrita'>Interes</td>" +
                                "<td class='dvalor negrita'>Comision</td>" +
                                "<td class='dvalor negrita'>Mora</td>" +
                                "<td class='dvalor negrita'>Otros</td>" +
                                "<td class='dvalor negrita'>Total</td>" +
                                "</tr>");

            for (int c = 0; c <= i.Count - 1; c++)
            {

                    if (c != 0 && VendAnterior != i[c].Cobrador)
                    {
                    

                    if (cont == 56)
                    {
                        lTablaResumen.Append(rowResumen);
                        pag += 1;
                        lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());                        
                        cont = 0;
                    }

                    lTablaResumen.Append("<tr>" +
                             "<td class='dobserv' colspan='2'>" + VendAnterior + "</td>" +
                             "<td class='centro'> " + cantiPrestamos.ToString() + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrComision).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                             "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrComision + TrMora + TrOtros).ToString("N")) + "</td>" +
                          "</tr>"));

                    cont += 2;

                    TrCapital = 0;
                    TrInteres = 0;
                    TrComision = 0;
                    TrMora = 0;
                    TrOtros = 0;
                    cantiPrestamos = 0;
 
                }                                   
                
                TrCapital = TrCapital + i[c].capital;
                TrInteres = TrInteres + i[c].interes;
                TrComision = TrComision + i[c].comision;                
                TrMora = TrMora + i[c].mora;
                TrOtros = TrOtros + i[c].otros;

                TgCapital = TgCapital + i[c].capital;
                TgInteres = TgInteres + i[c].interes;
                TrComision = TgComision + i[c].comision;
                TgMora = TgMora + i[c].mora;
                TgOtros = TgOtros + i[c].otros;
                cantiPrestamos += 1;


                VendAnterior = i[c].Cobrador;
                //NombreCobrador = i[c].NombreCobrador.PadRight(25, ' ');
                
            }

            if (cont == 56)
            {
                lTablaResumen.Append(rowResumen);
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
                cont = 0;
            }

            lTablaResumen.Append("<tr>" +
                            "<td class='dobserv' colspan='2'>" + VendAnterior + "</td>" +
                            "<td class='centro'> " + cantiPrestamos.ToString() + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrCapital.ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrInteres).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrComision).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrMora).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrOtros).ToString("N")) + "</td>" +
                            "<td class='dvalor'>" + string.Format((TrCapital + TrInteres + TrComision + TrMora + TrOtros).ToString("N")) + "</td>" +
                         "</tr>"));

            cont += 2;

            if (cont == 56)
            {
                lTablaResumen.Append(rowResumen);
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());                
                cont = 0;
            }




            lTablaResumen.Append("<tr>" +
                     "<td class='dobserv' colspan='2'>&nbsp;</td>" +
                     "<td class='negrita  centro'> " + "Total General " + "</td>" +
                     "<td class='negrita dvalor'>" + string.Format((TgCapital.ToString("N")) + "</td>" +
                     "<td class='negrita dvalor'>" + string.Format((TgInteres).ToString("N")) + "</td>" +
                     "<td class='negrita dvalor'>" + string.Format((TgComision).ToString("N")) + "</td>" +
                     "<td class='negrita dvalor'>" + string.Format((TgMora).ToString("N")) + "</td>" +
                     "<td class='negrita dvalor'>" + string.Format((TgOtros).ToString("N")) + "</td>" +
                     "<td class='negrita dvalor'>" + string.Format((TgCapital + TgInteres + TgComision + TgMora + TgOtros).ToString("N")) + "</td>" +
                  "</tr>"));
            cont += 2;

            if (cont == 56)
            {
                lTablaResumen.Append(rowResumen);
                pag += 1;
                lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());                
                cont = 0;
            }
             

            lTablaResumen = lTablaResumen.Replace("{npag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{fpag}", pag.ToString());
            lTablaResumen = lTablaResumen.Replace("{Fecha}", Fecha.ToString());
            lTablaResumen = lTablaResumen.Replace("{Hora}", Hora.ToString());

            lTablaResumen.Append("</table>");



            return lTablaResumen.ToString();

        }

        public string RowsTasaRendimientoDePrestamos(string NombreApellidoCliente, string MontoPrestamo, string TasaInteres, string Otros, string Frecuencia)

        {
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            DateTime FechaDia = Convert.ToDateTime("01/01/2015");
            DateTime FechaAnt = Convert.ToDateTime("01/01/2015");
            decimal TVCuota = 0;
            decimal TVInteres = 0;
            decimal TVComision = 0;
            decimal TVCapital = 0;
            string VendAnterior = "";
            int PrestamosNuevos = 0;
            int PrestamosNuevosCobrador = 0;

            StringBuilder lTabla = new StringBuilder();
            StringBuilder lTabla1 = new StringBuilder();
            StringBuilder TablaDia = new StringBuilder();


            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");
            if (Frecuencia == "1")
            {
                Frecuencia = "Diario.";
            }
            else if (Frecuencia == "2")
            {
                Frecuencia = "Semanal.";
            }
            else if (Frecuencia == "3")
            {
                Frecuencia = "Interdiario.";
            }
            else if (Frecuencia == "4")
            {
                Frecuencia = "Mensual.";
            }

            row0 = "<table>";
            row += "<tr>";
            row += "<td Class='' colspan='3'>Fecha: {Fecha} </td>";
            row += "<td class=' negrita' colspan='3'>" + Session["NombreCia"].ToString().Substring(0, (Session["NombreCia"].ToString().Length < 48) ? Session["NombreCia"].ToString().Length : 48) + "</td>";
            row += "<td colspan='3'>&nbsp;</td>";
            row += "<td  class='Derecha'colspan='3'> Pág. : {npag} de {fpag}</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td Class= 'Derecha' colspan='3'>Hora : {Hora}</td>";
            row += "<td class='' colspan='4'>Tasa de Rendimiendo de Prestamo</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td Class='negrita' colspan='4'>Cliente: "+NombreApellidoCliente+"</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td Class='negrita' colspan='3'>Monto a Amortizar: " + MontoPrestamo + "</td>";
            row += "<td Class='negrita' colspan='3'>Frecuencia de pago: " + Frecuencia + "</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td colspan='10' class='expadin'>&nbsp;</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<th class='medcol'>Cuota</th>";
            row += "<th class='medcol'>Fecha</th>";
            row += "<th class='dvalor'>Valor Cuota  </th>";
            row += "<th class='dvalor'colspan='2'>Interes</th>";
            row += "<th class='dvalor'colspan='2'>Comision</th>";
            row += "<th class='dvalor'colspan='2'>Capital</th>";
            row += "<th class='dvalor'colspan='2'>Saldo</th>";
            //row += "<th></th>";
            row += "</tr>";
        

            lTabla.Append(row0);
            lTabla.Append(row);

            lTabla = lTabla.Replace("{npag}", pag.ToString());
        
        List<ListaCosultaAmortizacion> i = (List<ListaCosultaAmortizacion>)Session["RptTasaDePrestamo"];

            for (int c = 1; c <= i.Count - 1; c++)
            {
                lTabla1.Clear();
                lTabla1.Append("<tr>" +
                "<td class='medcol centro'>"+i[c].Cuota+"</td>" +
                "<td class='dobserv'>"+i[c].FechaVencCuota+"</td>" +
                "<td class='dvalor'>"+i[c].ValorCuota+"</td>" +
                "<td class='dvalor'colspan='2'>" + string.Format(Convert.ToDecimal(i[c].Interes).ToString("N")) + "</td>" +
                "<td class='dvalor' colspan='2'>" + string.Format(Convert.ToDecimal(i[c].Comision).ToString("N")) + "</td>" +
                "<td class='dvalor'colspan='2'>" + string.Format(Convert.ToDecimal(i[c].Capital).ToString("N")) + "</td>" +
                "<td class='dvalor' colspan='2'>" + string.Format(Convert.ToDecimal(i[c].Saldo).ToString("N")) + "</td>" +
                "<td></td>" +
                "</tr>");

                    lTabla.Append(lTabla1.ToString());

                    cont += 2;
                    if (cont == 80)
                    {
                        pag += 1;
                        lTabla = lTabla.Replace("{npag}", pag.ToString());
                        lTabla.Append(row);
                        cont = 0;
                    }

                
                //PrestamosNuevos = PrestamosNuevos + 1;
                //PrestamosNuevosCobrador = PrestamosNuevosCobrador + 1;

                TVCuota = TVCuota + Convert.ToDecimal(i[c].ValorCuota);
                TVInteres = TVInteres + Convert.ToDecimal(i[c].Interes);
                TVComision = TVComision + Convert.ToDecimal(i[c].Comision);
                TVCapital = TVCapital + Convert.ToDecimal(i[c].Capital);

                //VendAnterior = i[c].CodigoCobrador;
                //FechaAnt = Convert.ToDateTime(i[c].FechaPtm);


            }

        
                lTabla.Append("<tr>" +
                                "<td class='medcol centro'></td>" +
                                "<td class='dobserv'> </td>" +
                                "<td class='dvalor negrita'>" + string.Format(Convert.ToDecimal(TVCuota).ToString("N")) + "</td>" +
                                "<td class='dvalor negrita' colspan='2'>" + string.Format(Convert.ToDecimal(TVInteres).ToString("N")) + "</td>" +
                                "<td class='dvalor negrita'colspan='2'>" + string.Format(Convert.ToDecimal(TVComision).ToString("N")) + "</td>" +
                                "<td class='dvalor negrita' colspan='2'>" + string.Format(Convert.ToDecimal(TVCapital).ToString("N")) + "</td>" +
                                 "<td class='dvalor' colspan='2'></td>" +
                                 "<td></td>" +
                                 "</tr>");


                lTabla = lTabla.Replace("{npag}", pag.ToString());
                lTabla = lTabla.Replace("{fpag}", pag.ToString());
                lTabla = lTabla.Replace("{Fecha}", Fecha.ToString());
                lTabla = lTabla.Replace("{Hora}", Hora.ToString());
                cont += 2;

                //for (int xx = 0; xx <= 80 - cont; xx = xx + 2)
                //{
                //    lTabla.Append("<tr>" +
                //  "<td class='dobserv'></td>" +
                //  "<td class='medcol centro'></td>" +
                //   "<td class='medcol centro'></td>" +
                //   "<td class='medcol'></td>" +
                //   "<td class='medDIa'></td>" +
                //   "<td class='dvalor'></td>" +
                //   "<td class='dvalor'></td>" +
                //   "<td class='dvalor'></td>" +
                //   "<td class='dvalor'></td>" +
                //   "<td class='dvalor negrita'></td>" +
                //   "</tr>");
                //}
                lTabla.Append("</table>");
            
            //lTabla.Append(GeneraResumenDetalleMes(i, FechaDesde, FechaHasta));

            return lTabla.ToString();
        }

        public string RowsReciboDeContrato(string NoPrestamo, string CedulaCliente, string NombreApellidoCliente, byte Movimiento, string NoDocumento, string TipoDocumento, string FechaRc, string codigoCobrador, string NombreCobrador, string Comentario, decimal Pendientes, decimal Pagadas, decimal BalanceAlCobro, bool FormaPagos, decimal Capital, decimal Interes, decimal Otros, decimal Mora, decimal Total)


        {
            string row0 = string.Empty;
            string row = string.Empty;
            string Tabla = string.Empty;
            string Tabla1 = string.Empty;
            int cont = 0;
            string NumDoc = string.Empty;
            DateTime FechaDia = Convert.ToDateTime("01/01/2015");
            DateTime FechaAnt = Convert.ToDateTime("01/01/2015");
            decimal TcMonto = 0;
            decimal TcInteres = 0;
            string VendAnterior = "";
            int PrestamosNuevos = 0;
            int PrestamosNuevosCobrador = 0;
              string strValorLetra;
            StringBuilder lTabla = new StringBuilder();
            StringBuilder lTabla1 = new StringBuilder();
            StringBuilder TablaDia = new StringBuilder();
            
            NumeroALetra a = new NumeroALetra();
            string Fecha = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string Hora = DateTime.Now.ToString("hh:mm:ss tt");


            //Variable para almacenar el nombre de la compañia, Substring de 48
            row0 = "<table>";
            row += "<tr>";
            row += "<td Class='negrita' colspan='2'> " + Session["NombreCia"].ToString().Substring(0, (Session["NombreCia"].ToString().Length < 48) ? Session["NombreCia"].ToString().Length : 48) + "</td>";
            row += "<td class=' negrita' colspan='3'></td>";
            row += "<td colspan='3'>&nbsp;</td>";
            row += "<td Class='' colspan='2'>Documento:</td>";
            row += "</tr>";
            row += "<tr>";
            
            row += "<td Class= 'Derecha' colspan='2'>Tel.:</td>";
            row += "<td class=' negrita' colspan='3'></td>";
            row += "<td colspan='3'>&nbsp;</td>";
            row += "<td Class='' colspan='2'>Fecha: {Fecha} </td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td class=''></td>";
            row += "<td Class= 'Derecha' colspan='2'></td>";
            row += "<td class='negrita' colspan='3'>RECIBO DE COBRO</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td class='medcolpe'></td>";
            row += "<td Class='' colspan='2'>&nbsp;</td>";
            row += "</tr>";
            row += "<tr>";
            row += "<td colspan='5' class='expadin'>&nbsp;</td>";
            row += "</tr>";

            row += "<tr>";
            row += "<td class='Nombre negrita'>Nombre Cliente:</td>";
            row += "<th colspan='4'>"+ NombreApellidoCliente+"</th>";
            row += "<td class='medDIa'></td>";
            row += "<td class='Prestamos negrita'>Prestamos:</td>";
            row += "<th class='RayaMed' colspan='1'>" +  NoPrestamo + "</th>";
            row += "</tr>";


        
            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='4'></td>";
            row += "<td class='medDIa'></td>";
            row += "<td class='Prestamos negrita'>Capital:</td>";
            row += "<th class='RayaMed' colspan='1'>" + Capital + "</th>";
            row += "</tr>";

            strValorLetra = a.Numero2Letra(Convert.ToString(Pagadas), 0, 2, "PESOS", "", eSexo.Masculino, eSexo.Masculino);

            row += "<tr>";
            row += "<td class='Nombre negrita'>Suma De:</td>";
            row += "<th colspan='4'>"+ strValorLetra + "</th>";//RUTINA DE CONVERTIR DE NUMERO A LETRAS
            row += "<td class='medDIa'></td>";
            row += "<td class='Prestamos negrita'>Interes:</td>";
            row += "<th class='RayaMed' colspan='1'>" + Interes + "</th>";
            row += "</tr>";

            
            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='4'></td>";
            row += "<td class='medDIa'></td>";
            row += "<td class='Prestamos negrita'>Otro:</td>";
            row += "<th class='RayaMed' colspan='1'>" +  Otros + "</th>";
            row += "</tr>";

            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='4'></td>";
            row += "<td class='medDIa'></td>";
            row += "<td class='Prestamos negrita'>Mora:</td>";
            row += "<th class='RayaMed' colspan='1'>"+ Mora+"</th>";
            row += "</tr>";


            row += "<tr>";
            row += "<td class='Nombre negrita'>PorConceto De:</td>";
            row += "<th colspan='4'>"+ Comentario+"</th>";
            row += "<td class='medDIa'></td>";
            row += "<td class='PrestamosG negrita'>TOTAL:</td>";
            row += "<th class='RayaMed' colspan='1'>" +  Total + "</th>";
            row += "</tr>";


            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='4'></td>";
            row += "<td class='medDIa'></td>";
            row += "<td class='PrestamosG negrita'colspan='2'></td>";
            row += "<td class='RayaMed' ></td>";
            row += "</tr>";



            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='4'></td>";
            row += "<td class='medDIa'></td>";
            row += "<th class='PrestamosG negrita'colspan='2'></th>";
            row += "<td class='RayaMed' ></td>";
            row += "</tr>";

            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='4'></td>";
            row += "<td class='medDIa'></td>";
            row += "<td class='PrestamosG negrita centro'colspan='2'>Recibido Por</td>";
            row += "<td class='RayaMed' ></td>";
            row += "</tr>";
            
            row += "<tr>";
            row += "<td class='Nombre negrita'></td>";
            row += "<td colspan='7' class='centro'>Esta empresa no es responsable de dinero entregado sin recibo.</td>";
            row += "</tr>";

            lTabla.Append(row0);
            lTabla.Append(row);

            lTabla = lTabla.Replace("{npag}", pag.ToString());
            lTabla = lTabla.Replace("{fpag}", pag.ToString());
            lTabla = lTabla.Replace("{Fecha}", Fecha.ToString());
            lTabla = lTabla.Replace("{Hora}", Hora.ToString());
       
            lTabla.Append("</table>");

            return lTabla.ToString();
        }

        
        public ActionResult GeneraReporte(string report, string FechaDesde, string FechaHasta, byte FormaReporte, string CodigoCobrador, string NombreCobrador)
        {
           
            byte[] bytes = null;
            StreamReader reader = new StreamReader(Server.MapPath("~/Views/Plantillas/" + report + ".html"));
            string htmlText = reader.ReadToEnd();
            string css = report;

            //Este bloque selecciona una plantilla
            
            if (report == "CobrosRealizados" )
            {
                if(FormaReporte == 0)
                { 
                    htmlText = htmlText.Replace("{Rows}", RowsCobrosRealizados(FechaDesde, FechaHasta, FormaReporte, CodigoCobrador, NombreCobrador));
                }
                else if(FormaReporte == 1)
                {
                    htmlText = htmlText.Replace("{Rows}", GeneraResumenResumido(FechaDesde, FechaHasta));
                }
            }
            else if(report == "ContratosDelMes")
            {
                htmlText = htmlText.Replace("{Rows}", RowsContratoDelMes(FechaDesde, FechaHasta, FormaReporte, CodigoCobrador, NombreCobrador));
            }
            else if (report == "PrestamosConBalance") {
                    htmlText = htmlText.Replace("{Rows}", RowsPrestamosConBalance(FechaHasta, NombreCobrador));
            }
            else if (report == "UltimaCuota")
            {
                     htmlText = htmlText.Replace("{Rows}", RowsUltimaCuota(FechaHasta, CodigoCobrador, NombreCobrador));
            }

         



            bytes = Encoding.UTF8.GetBytes(htmlText);

            using (MemoryStream input = new MemoryStream(bytes))
            {
                MemoryStream output = new MemoryStream();
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);
        
                if (report != "CobrosRealsizados" && report != "UltimaCuota" && report != "ContratosDelMes")
                {
                    document.SetPageSize(PageSize.A4.Rotate());
                }
       
                string nombrearchivo = "Reporte.pdf";
                string filePath = Server.MapPath("~/Reportes/");
                //PdfWriter.GetInstance(document, new FileStream(filePath + "\\\\" + nombrearchivo, FileMode.Create));
                  PdfWriter.GetInstance(document, new FileStream(filePath + "\\" + nombrearchivo, FileMode.Create));

                dynamic writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;

                document.Open();

                HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
                htmlContext.SetAcceptUnknown(true);
                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                cssResolver.AddCssFile(Server.MapPath("~/Content/" + css + ".css"), true);

                CssResolverPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
                XMLWorker pdfworker = new XMLWorker(pipeline, true);
                XMLParser p = new XMLParser(true, pdfworker, new UTF8Encoding());

                
                try
                    {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, input, new FileStream(Server.MapPath("~/Content/" + css + ".css"), FileMode.Open, FileAccess.Read));
                }
                catch
                {
                    string aa = null;
                    aa = "";
                }
                finally
                {
                    pdfworker.Close();
                }

                document.Close();
            }

            return DownloadFile("Reporte.pdf");
        }



public ActionResult GeneraReporteConsulta(string report, string NombreApellidoCliente, string MontoPrestamo, string TasaInteres, string Otros, string Frecuencia)
             
{

    byte[] bytes = null;
    StreamReader reader = new StreamReader(Server.MapPath("~/Views/Plantillas/" + report + ".html"));
    string htmlText = reader.ReadToEnd();
    string css = report;

    //Este bloque selecciona una plantilla



    if (report == "TasaDeRendimientoDePrestamo")
    {
        htmlText = htmlText.Replace("{Rows}", RowsTasaRendimientoDePrestamos(NombreApellidoCliente, MontoPrestamo, TasaInteres,Otros, Frecuencia));
    }

    bytes = Encoding.UTF8.GetBytes(htmlText);
    using (MemoryStream input = new MemoryStream(bytes))
    {
        MemoryStream output = new MemoryStream();
        Document document = new Document(PageSize.A4, 10, 10, 10, 10);

        if (report != "TasaDeRendimientoDePrestamo")
        {
            document.SetPageSize(PageSize.A4.Rotate());
        }

        string nombrearchivo = "Reporte.pdf";
        string filePath = Server.MapPath("~/Reportes/");
        //PdfWriter.GetInstance(document, new FileStream(filePath + "\\\\" + nombrearchivo, FileMode.Create));
        PdfWriter.GetInstance(document, new FileStream(filePath + "\\" + nombrearchivo, FileMode.Create));

        dynamic writer = PdfWriter.GetInstance(document, output);
        writer.CloseStream = false;

        document.Open();

        HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
        htmlContext.SetAcceptUnknown(true);
        htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

        ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
        cssResolver.AddCssFile(Server.MapPath("~/Content/" + css + ".css"), true);

        CssResolverPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
        XMLWorker pdfworker = new XMLWorker(pipeline, true);
        XMLParser p = new XMLParser(true, pdfworker, new UTF8Encoding());


        try
        {
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, input, new FileStream(Server.MapPath("~/Content/" + css + ".css"), FileMode.Open, FileAccess.Read));
        }
        catch
        {
            string aa = null;
            aa = "";
        }
        finally
        {
            pdfworker.Close();
        }

        document.Close();
    }

    return DownloadFile("Reporte.pdf");
}







public ActionResult GeneraRecibo(string NoPrestamo,string CedulaCliente ,string NombreApellidoCliente ,byte Movimiento ,string NoDocumento ,string TipoDocumento ,string Fecha ,string codigoCobrador ,string NombreCobrador ,string Comentario ,decimal Pendientes ,decimal Pagadas ,decimal BalanceAlCobro ,bool FormaPagos ,decimal Capital ,decimal Interes ,decimal Otros ,decimal Mora ,decimal Total , string report)
        {
            
            byte[] bytes = null;
            StreamReader reader = new StreamReader(Server.MapPath("~/Views/Plantillas/" + report + ".html"));
            string htmlText = reader.ReadToEnd();
            string css = report;

            //Este bloque selecciona una plantilla

            if (report == "ReciboDeContrato")
            {
                htmlText = htmlText.Replace("{Rows}", RowsReciboDeContrato( NoPrestamo,  CedulaCliente,  NombreApellidoCliente,  Movimiento,  NoDocumento,  TipoDocumento,  Fecha,  codigoCobrador,  NombreCobrador,  Comentario,  Pendientes,  Pagadas,  BalanceAlCobro,  FormaPagos,  Capital,  Interes,  Otros,  Mora,  Total));
            }
          
            bytes = Encoding.UTF8.GetBytes(htmlText);

            using (MemoryStream input = new MemoryStream(bytes))
            {
                MemoryStream output = new MemoryStream();
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                if (report != "CobrosRealsizados" && report != "UltimaCuota" && report != "ReciboDeContrato")
                {
                    document.SetPageSize(PageSize.A4.Rotate());
                }

                string nombrearchivo = "Reporte.pdf";
                string filePath = Server.MapPath("~/Reportes/");
                //PdfWriter.GetInstance(document, new FileStream(filePath + "\\\\" + nombrearchivo, FileMode.Create));
                PdfWriter.GetInstance(document, new FileStream(filePath + "\\" + nombrearchivo, FileMode.Create));

                dynamic writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;

                document.Open();

                HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
                htmlContext.SetAcceptUnknown(true);
                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                cssResolver.AddCssFile(Server.MapPath("~/Content/" + css + ".css"), true);

                CssResolverPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
                XMLWorker pdfworker = new XMLWorker(pipeline, true);
                XMLParser p = new XMLParser(true, pdfworker, new UTF8Encoding());


                try
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, input, new FileStream(Server.MapPath("~/Content/" + css + ".css"), FileMode.Open, FileAccess.Read));
                }
                catch
                {
                    string aa = null;
                    aa = "";
                }
                finally
                {
                    pdfworker.Close();
                }

                document.Close();
            }

            return DownloadFile("Reporte.pdf");
        }



        public ActionResult DownloadFile(string pdf)
        {
            string filename = pdf;
            string filepath = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory + "/Reportes/") + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            dynamic cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }



       }

    }












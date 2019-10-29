using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
namespace PrestamosCompactoWEB_Cs.Models
{
    public enum eSexo { Femenino = 0, Masculino = 1 }

    public class NumeroALetra
    {
        string m_Sexo1;
        string m_Sexo2;
        long m_LenSexo1;

        string[] unidad = new string[10];
        string[] decena = new string[10];
        string[] centena = new string[11];
        string[] deci = new string[10];
        string[] otros = new string[16];
        string sDecimal = "";  // 'Signo decimal a usar
        string sDecimalNo = ""; // 'Signo no decimal

        public NumeroALetra()
        {

        }



        public string Numero2Letra(string strNum,
                                   long La = 0L,
                                   long NumDecimales = 2L,
                                   string sMonedas = "",
                                   string sCentimos = "",
                                   eSexo SexoMoneda = eSexo.Masculino,
                                   eSexo SexoCentimos = eSexo.Masculino)
        {
            //    '----------------------------------------------------------
            //' Convierte el número strNum en letras          (28/Feb/91)
            //' Versión para Windows                          (25/Oct/96)
            //' Variables estáticas                           (15/May/97)
            //' Parche de "Esteve" <esteve@mur.hnet.es>       (20/May/97)
            //' Revisión para decimales                       (10/Jul/97)
            //' Permite indicar el sexo de la moneda          (06/Ene/99)
            //' y de los centimos... nunca se sabe...
            //' Corregido fallo de los decimales cuando       (13/Ene/99)
            //' tienen ceros a la derecha.
            //'
            //' La moneda debe especificarse en singular, ya que la función
            //' se encarga de convertirla en plural.
            //' Se puede indicar el número de decimales a devolver
            //' por defecto son dos.
            //'-------------------------------------------------------------

            long iHayDecimal; // 'Posición del signo decimal

            string sEntero;
            string sFraccion;
            Single fFraccion;
            string sNumero;
            string sSexoCents;
            eSexo SexoAntMoneda = 0;
            eSexo SexoAntCentimos;

            int num;

            //'Esta variable fueron declarado por Diogenes Gil Para fines de Controlar
            //'algunos defecto de la DLL

            string strDecimal;
            string strEntero;

            dynamic com = null;


            //' Para tener en cuenta el sexo de los céntimos (20/Jul/00)
            //' m_Sexo2 se usa para indicar el plural de las monedas,
            //' sSexoCents sustituirá a esa variable cuando se calculen los céntimos

            if (SexoCentimos == eSexo.Femenino)
            {
                sSexoCents = "as";
            }
            else
            {
                sSexoCents = "os";
            }

            //'Dependiendo del "sexo" indicado, usar las terminaciones
            if (SexoMoneda == eSexo.Femenino)
            {
                m_Sexo1 = "a";
                m_Sexo2 = "as";
            }
            else
            {
                m_Sexo1 = "";
                m_Sexo2 = "os";
            }
            //'por si se cambia en el trascurso el sexo de la moneda
            if (SexoMoneda != SexoAntMoneda)
            {
                //////unidad[2] = ""; //No sabemos para que lo usan

                SexoAntMoneda = SexoMoneda;
            }
            m_LenSexo1 = m_Sexo1.Length;

            //'Si se especifica, se usarán
            sMonedas = sMonedas.Trim(' ');

            if (sMonedas.Length != 0)
            {
                sMonedas = " " + sMonedas + " ";
            }
            else
            {
                sMonedas = " ";
            }

            sCentimos = sCentimos.Trim(' ');
            if (sCentimos.Trim(' ').Length != 0)
            {
                sCentimos = " " + sCentimos + " ";
            }
            else
            {
                sCentimos = " ";
            }

            //'Si no se especifica el ancho...

            if (La != 0)
            {
                sNumero = string.Empty.PadRight(Convert.ToInt32(La), ' ');
            }
            else
            {
                sNumero = "";
            }

            //'Comprobar el signo decimal y devolver los adecuados a la config. regional

            strNum = ConvDecimal(strNum, sDecimal, sDecimalNo);

            //'Comprobar si tiene decimales
            iHayDecimal = strNum.IndexOf(sDecimal); //iHayDecimal = instr(strNum, sDecimal);
            if (iHayDecimal != -1)
            {
                sEntero = strNum.Substring(0, Convert.ToInt32(iHayDecimal));
                //sEntero = Left$(strNum, iHayDecimal - 1)

                sFraccion = strNum.Substring(Convert.ToInt32(iHayDecimal) + 1) + string.Empty.PadRight(Convert.ToInt32(NumDecimales), '0');
                //sFraccion = Mid$(strNum, iHayDecimal +1) &String$(NumDecimales, "0")

                //'obligar a que tenga dos cifras
                //'
                //'pero habría que redondear el resto...
                //'por ejemplo:
                //'   .256 sería .26 y
                //'   .254 sería .25
                //'Pero esto otro no se haría:
                //'.25499 no pasaría a .255 y después a .26
                //'
                //'*sFraccion = Left$(sFraccion, NumDecimales + 1)
                //'*fFraccion = Int((Val(sFraccion) / 100) * 10 + 0.5) * 10
                //'*sFraccion = Left$(CStr(fFraccion), NumDecimales)
                //'
                //' NO hacer cálculos de redondeo ni nada de nada             (08/Jul/00)
                //'
                //' De esta forma se dirá:
                //'   ,06 con seis
                //'   ,50 con cincuenta
                //'

                sFraccion = sFraccion.Substring(0, Convert.ToInt32(NumDecimales)); //sFraccion = Left$(sFraccion, NumDecimales)

                //'
                //'* En las fracciones los ceros a la derecha no tienen significado
                //'----------------------------------------------------------------------
                //' Pero si tenemos: 125.50 si que tiene significado,         (08/Jul/00)
                //' ya que tal y como está ahora, diría con 5 en lugar de cincuenta
                //' Así que si se ponen NumDecimales mayor de 2,
                //' hay que ser consecuentes con los resultados.
                //'----------------------------------------------------------------------
                //'*Do While Right$(sFraccion, 1) = "0"
                //'*    sFraccion = Left$(sFraccion, Len(sFraccion) - 1)
                //'*Loop
                //'
                fFraccion = Convert.ToSingle(sFraccion);
                //' Si no hay decimales... no agregar nada...
                strDecimal = sFraccion; //'para pasar el numero de decimal
                strEntero = strNum;
                if (fFraccion < 1)
                {
                    if (sMonedas.Trim(' ').Length != 0) //if Len(Trim$(sMoneda)) 
                    {
                        sMonedas = Pluralizar(sNumero, sMonedas);
                    }
                    strNum = (UnNumero(sEntero, m_Sexo1) + sMonedas).TrimStart(' ');  //strNum = RTrim$(UnNumero(sEntero, m_Sexo1) & sMonedas)

                    if (La != 0)
                    {
                        sNumero = strNum.Substring(0, Convert.ToInt32(La)); //LSet sNumero = strNum
                    }
                    else
                    {
                        sNumero = strNum;
                    }

                    //'***********************************************************************
                    //'Complementar la el resultado de esta funcion
                    //'modificado por Diogenes Y Hector Para que el resultado sea mas eficiente
                    //'***********************************************************************

                    com = sNumero.IndexOf("con");  //com = InStr(1, sNumero, "CON")
                    if (Convert.ToDecimal(strEntero) >= 2)  //If Val(strEntero) >= 2 Then
                    {
                        if (com > 0)
                        {
                            if (sNumero.Substring(com + 4, 2) == 1)  //If Mid(sNumero, com + 4, 2) = 1 Then
                            {
                                return (sNumero.Trim() + " CENTAVO").ToUpper();  //Numero2Letra = UCase(sNumero & " CENTAVO")
                            }
                            else
                            {
                                return (sNumero.Trim() + " CENTAVOS").ToUpper();  //Numero2Letra = UCase(sNumero & " CENTAVOS")
                            }
                        }
                        else
                        {
                            return (sNumero.Trim() + " CON 00 CENTAVOS").ToUpper();  // Numero2Letra = UCase(sNumero & " CON 00 CENTAVOS")
                        }
                    }
                    else
                    {
                        com = sNumero.IndexOf("con"); //com = InStr(1, sNumero, "CON")
                        if (com != -1)
                        {
                            if (sNumero.Substring(com + 4, 2) == 1)  //If Mid(sNumero, com + 4, 2) = 1 Then
                            {
                                return (sNumero + "  CENTAVO").ToUpper();  // Numero2Letra = UCase(sNumero & "  CENTAVO")
                            }
                            else
                            {
                                return (sNumero + "  CENTAVOS").ToUpper();  //Numero2Letra = UCase(sNumero & "  CENTAVOS")
                            }
                        }
                        else
                        {
                            return (sNumero + " CON 00 CENTAVOS").ToUpper();  // Numero2Letra = UCase(sNumero & " CON 00 CENTAVOS")
                        }

                    }
                    //'end declaraction de el proceso Diogenes Hector

                    //'Numero2Letra = sNumero ' esta variable le desvuelve la traducion a la function anteriormente
                    //exit function;
                }

                if (sMonedas.Trim(' ').Length != 0)  //If Len(Trim$(sMoneda)) Then
                {
                    sMonedas = Pluralizar(sEntero, sMonedas);
                }

                sEntero = UnNumero(sEntero, m_Sexo1);

                if (sCentimos.Trim(' ').Length != 0)  //If Len(Trim$(sCentimos)) Then
                {
                    sCentimos = Pluralizar(sFraccion, sCentimos);
                }

                //' Para el sexo de los decimales
                //' no se si esto puede cambiar, pero por si ocurre...
                //'
                //' Sustituimos el plural de las monedas,                     (20/Jul/00)
                //' para adecuarla a los céntimos,
                //' ya que en España, la moneda es femenino, pero los céntimos masculino.
                m_Sexo2 = sSexoCents;

                if (SexoCentimos == eSexo.Masculino)  //If SexoCentimos = eSexo.Masculino Then
                {
                    sFraccion = UnNumero(sFraccion, "");
                }
                else
                {
                    sFraccion = UnNumero(sFraccion, "a");
                }
                //'
                //'strNum = sEntero & sMoneda & " pesos con " & sFraccion & sCentimos

                if (Convert.ToDecimal(strNum) >= 2)  //If Val(strNum) >= 2 Then
                {
                    strNum = sEntero + sMonedas.TrimEnd() + " CON " + string.Format(strDecimal, "00") + sCentimos;  //strNum = sEntero & sMoneda & " CON " & Format(CLng(strDecimal), "00") & sCentimos
                }
                else
                {
                    strNum = sEntero + sMonedas.TrimEnd() + " CON " + string.Format(strDecimal, "00") + sCentimos;  //strNum = sEntero & sMoneda & " CON " & Format(CLng(strDecimal), "00") & sCentimos
                }

                if (La != 0)  //If Lo Then
                {
                    sNumero = strNum.TrimEnd(' ').Substring(0, Convert.ToInt32(La));  //LSet(sNumero, RTrim$(strNum))
                }
                else
                {
                    sNumero = strNum.TrimEnd(' ');  //sNumero = RTrim$(strNum)
                }
                //'***********************************************************************
                //'Complementar el resultado de esta funcion
                //'modificado por Diogenes Y Hector Para que el resultado sea mas eficiente
                //'***********************************************************************

                com = sNumero.IndexOf("CON"); //com = InStr(1, sNumero, "CON")

                if (int.TryParse(strNum, out num)) //If Val(strNum) >= 2 Then
                {
                    if (com != -1)  //If com > 0 Then
                    {
                        if (sNumero.Substring(com + 4, 2) == 1)  //If Mid(sNumero, com + 4, 2) = 1 Then
                        {
                            return (sNumero.Trim() + " CENTAVO").ToUpper();  //Numero2Letra = UCase(sNumero & "  CENTAVO")
                        }
                        else
                        {
                            return (sNumero.Trim() + " CENTAVOS").ToUpper();  //Numero2Letra = UCase(sNumero & "  CENTAVOS")
                        }
                    }
                    else
                    {
                        return (sNumero.Trim() + " CON 00 CENTAVOS").ToUpper();  //Numero2Letra = UCase(sNumero & " CON 00 CENTAVOS")
                    }
                }
                else
                {
                    com = sNumero.IndexOf("CON"); //com = InStr(1, sNumero, "CON")

                    if (com != -1)  //If com > 0 Then
                    {
                        if (sNumero.Substring(com + 4, 2) == "1")  //If Mid(sNumero, com + 4, 2) = 1 Then
                        {
                            return (sNumero.Trim() + " CENTAVO").ToUpper();  //Numero2Letra = UCase(sNumero & "  CENTAVO")
                        }
                        else
                        {
                            return (sNumero.Trim() + " CENTAVOS").ToUpper();  //Numero2Letra = UCase(sNumero & "  CENTAVOS")
                        }
                    }
                    else
                    {
                        return (sNumero.Trim() + " CON 00 CENTAVOS").ToUpper();  //Numero2Letra = UCase(sNumero & " CON 00 CENTAVOS")
                    }
                }

                //'end declaction de el proceso de Diogenes Hector

                //'Numero2Letra = sNumero ' esta variable le desvuelve la traducion a la function anteriormente
            }
            else
            {
                if (sMonedas.Trim(' ').Length != 0)  //If Len(Trim$(sMoneda)) Then
                {
                    sMonedas = Pluralizar(strNum, sMonedas);  //sMoneda = Pluralizar(strNum, sMoneda)
                }
                strNum = (UnNumero(strNum, m_Sexo1) + sMonedas).TrimEnd(' ');  //strNum = RTrim$(UnNumero(strNum, m_Sexo1) & sMoneda)

                if (La != 0)  //If Lo Then
                {
                    sNumero = strNum.Substring(0, Convert.ToInt32(La));  //LSet(sNumero, strNum)
                }
                else
                {
                    sNumero = strNum;
                }
                return sNumero.ToUpper().Trim();  //Numero2Letra = sNumero
            }
        }

        public string ConvDecimal(string strNume, string sDecimal1 = ",", string sDecimalNo1 = ".")
        {
            //' Asigna el signo decimal adecuado (o lo intenta)               (10/Ene/99)
            //' Devuelve una cadena con el signo decimal del sistema
            string sNumero;
            long i;
            long j;

            //On Error Resume Next        //' Si se produce un error, continuar (07/Jul/00)

            //' Averiguar el signo decimal
            sDecimal = sDecimal1;
            sDecimalNo = sDecimalNo1;

            sNumero = string.Format("{0:0.0}", 25.5);
            if (sNumero.IndexOf(".") != -1)  //If InStr(sNumero, ".") Then
            {
                strNume = strNume.Replace(",", "");
                sDecimal = ".";
                sDecimalNo = ",";
            }
            else
            {
                sDecimal = ",";
                sDecimalNo = ".";
            }

            strNume = strNume.Trim(' ');
            if (strNume.Substring(0, 1) == sDecimalNo)
            {
                strNume = strNume.Remove(0, 1).Insert(0, sDecimal); //Mid$(strNum, 1, 1) = sDecimal
            }

            //' Si el número introducido contiene signos no decimales
            j = 0;
            i = 0;
            do
            {
                i = strNume.IndexOf(sDecimalNo, Convert.ToInt32(i)); //    InStr(i, strNum, sDecimalNo, CompareMethod.Text);
                if (i != -1)
                {
                    j = j + 1;
                    i = i + 1;
                }
            } while (i != -1);

            if (j == 1)
            {
                //' cambiar ese símbolo por un espacio, si sólo hay uno de esos signos
                //i = InStr(strNume, sDecimalNo)

                i = strNume.IndexOf(sDecimalNo);

                if (i != -1)
                {
                    if (strNume.Contains(sDecimal) == true)
                    { //if InStr(strNume, sDecimal) {
                        strNume = strNume.Remove(Convert.ToInt32(i), 1).Insert(Convert.ToInt32(i), " "); //Mid$(strNume, i, 1) = " ";
                    }
                    else
                    {
                        strNume = strNume.Remove(Convert.ToInt32(i), 1).Insert(Convert.ToInt32(i), sDecimal); //Mid$(strNume, i, 1) = sDecimal;
                    }
                }
            }
            else
            {
                //'En caso de que tenga más de uno de estos símbolos
                //'convertirlos de manera adecuada.
                //'Por ejemplo:
                //'si el signo decimal es la coma:
                //'   1,250.45 sería 1.250,45 y quedaría en 1250,45
                //'si el signo decimal es el punto:
                //'   1.250,45 sería 1,250.45 y quedaría en 1250.45
                //'
                //'Aunque no se arreglará un número erróneo:
                //'si el signo decimal es la coma:
                //'   1,250,45 será lo mismo que 1,25
                //'   12,500.25 será lo mismo que 12,50
                //'si el signo decimal es el punto:
                //'   1.250.45 será lo mismo que 1.25
                //'   12.500,25 será lo mismo que 12.50
                //'
                i = 0;
                do
                {
                    i = strNume.IndexOf(sDecimalNo, Convert.ToInt32(i));    //i = InStr(i, strNume, sDecimalNo, CompareMethod.Text)
                    if (i != -1)
                    {
                        j = j - 1;
                        if (j == 0)
                        {
                            strNume = strNume.Remove(Convert.ToInt32(i), 1).Insert(Convert.ToInt32(i), sDecimal); //Mid$(strNum, i, 1) = sDecimal
                        }
                        else
                        {
                            strNume = strNume.Remove(Convert.ToInt32(i), 1).Insert(Convert.ToInt32(i), " "); //Mid$(strNum, i, 1) = " ";
                        }
                        i = i + 1;
                    }

                } while (i != -1);
            }

            j = 0;
            //' Quitar los espacios que haya por medio
            do
            {
                i = strNume.IndexOf(" "); //i = InStr(strNum, " ")
                if (i != -1) //If i = 0 Then Exit Do
                {
                    strNume = strNume.Substring(0, Convert.ToInt32(i)) + strNume.Substring(Convert.ToInt32(i) + 1); //strNum = Left$(strNum, i - 1) & Mid$(strNum, i + 1)
                }
            } while (i != -1);

            return strNume;
        }

        public string Pluralizar(
                    string sNumero,
                    string sMoneda,
                    Boolean bCadaPalabra = false)
        {
            //'--------------------------------------------------------------------------
            //' Pluraliza la moneda, si el valor de número es distinto de uno
            //'
            //' Ahora es una función pública                                  (07/Jul/00)
            //'
            //' Parámetros:
            //'   sNumero         Importe, para saber si hay que pluralizar o no
            //'   sMoneda         Cadena con la palabra a pluralizar
            //'   bCadaPalabra    Si se pluralizan todas las palabras         (08/Jul/00)
            //'--------------------------------------------------------------------------
            double dblTotal;
            string sTmp;
            long i;

            if (sMoneda.Trim(' ').Length != 0)  //Len(Trim$(sMoneda)) 
            {
                //' He quitado el Val             (08/Jul/00)
                //'dblTotal = Val(sNumero)
                //'
                //' Si entra una cadena vacia, da error                       (08/Jul/00)
                if (sNumero.Length == 0) //Len(sNumero) = 0 
                {
                    sNumero = "0";
                }

                dblTotal = Convert.ToDouble(sNumero);
                //'
                if (dblTotal != 1.0)   //If dblTotal <> 1.0# Then
                {
                    sMoneda = sMoneda.Trim(' ');  //sMoneda = Trim$(sMoneda)
                    //' Si se pluralizan todas las palabras                   (08/Jul/00)
                    if (bCadaPalabra)   //If bCadaPalabra Then
                    {

                        sMoneda = sMoneda + " ";

                        sTmp = "";    //'' Modificado por Diogenes Gil y Manuel E.Trinidad Urraca(02 / Dic / 2002)

                        for (i = 1; i <= sMoneda.Length; i++) //For i = 1 To Len(sMoneda)
                        {
                            if (sMoneda.Substring(Convert.ToInt32(i), 1) == " ") //Mid$(sMoneda, i, 1) = " " 
                            {
                                //' pluralizar
                                if ("aeiou".IndexOf(sTmp.Substring(sTmp.Length - 1, 1).ToLower()) != -1)  //InStr("aeiou", Right$(sTmp, 1))
                                {
                                    sTmp = sTmp + "s";
                                }
                                else if ("s".IndexOf(sTmp.Substring(sTmp.Length - 1, 1).ToLower()) != -1)  //InStr("S", Right$(sTmp, 1))
                                {
                                    sTmp = " " + sTmp + " ";
                                }
                                else
                                {
                                    sTmp = sTmp + "es";
                                }
                            }
                            sTmp = sTmp + sMoneda.Substring(Convert.ToInt32(i), 1);  //sTmp = sTmp & Mid$(sMoneda, i, 1)
                        }
                        sMoneda = " " + sTmp.Trim(' ') + " ";  //sMoneda = " " + Trim$(sTmp) + " ";
                    }
                    else
                    {
                        if ("aeiou".IndexOf(sMoneda.Substring(sMoneda.Length - 1, 1).ToLower()) != -1)  //InStr("aeiou", Right$(sMoneda, 1)) Then
                        {
                            sMoneda = " " + sMoneda + "s ";
                        }
                        else if ("s".IndexOf(sMoneda.Substring(sMoneda.Length - 1, 1).ToLower()) != -1)  //InStr("S", Right$(sMoneda, 1))
                        {  //InStr("S", Right$(sMoneda, 1)) Then
                            sMoneda = " " + sMoneda + " ";
                        }
                        else
                        {
                            sMoneda = " " + sMoneda + "es ";
                        }
                    }
                }
            }
            //Pluralizar = sMoneda
            return sMoneda;
        }

        private void InicializarArrays()
        {
            //'Asignar los valores
            unidad[1] = "un" + m_Sexo1;
            unidad[2] = "dos";
            unidad[3] = "tres";
            unidad[4] = "cuatro";
            unidad[5] = "cinco";
            unidad[6] = "seis";
            unidad[7] = "siete";
            unidad[8] = "ocho";
            unidad[9] = "nueve";

            decena[1] = "diez";
            decena[2] = "veinte";
            decena[3] = "treinta";
            decena[4] = "cuarenta";
            decena[5] = "cincuenta";
            decena[6] = "sesenta";
            decena[7] = "setenta";
            decena[8] = "ochenta";
            decena[9] = "noventa";

            centena[1] = "ciento";
            centena[2] = "doscient" + m_Sexo2;
            centena[3] = "trescient" + m_Sexo2;
            centena[4] = "cuatrocient" + m_Sexo2;
            centena[5] = "quinient" + m_Sexo2;
            centena[6] = "seiscient" + m_Sexo2;
            centena[7] = "setecient" + m_Sexo2;
            centena[8] = "ochocient" + m_Sexo2;
            centena[9] = "novecient" + m_Sexo2;
            centena[10] = "cien";                //'Parche

            deci[1] = "dieci";
            deci[2] = "veinti";
            deci[3] = "treinta y ";
            deci[4] = "cuarenta y ";
            deci[5] = "cincuenta y ";
            deci[6] = "sesenta y ";
            deci[7] = "setenta y ";
            deci[8] = "ochenta y ";
            deci[9] = "noventa y ";

            otros[1] = "1";
            otros[2] = "2";
            otros[3] = "3";
            otros[4] = "4";
            otros[5] = "5";
            otros[6] = "6";
            otros[7] = "7";
            otros[8] = "8";
            otros[9] = "9";
            otros[10] = "10";
            otros[11] = "once";
            otros[12] = "doce";
            otros[13] = "trece";
            otros[14] = "catorce";
            otros[15] = "quince";
        }

        private string UnNumero(string strNum,
                                string Sexo1)
        {
            //'----------------------------------------------------------
            //'Esta es la rutina principal                    (10/Jul/97)
            //'Está separada para poder actuar con decimales
            //'----------------------------------------------------------
            double dblNumero;

            Boolean Negativo;
            int l;
            Boolean Una;
            Boolean Millon;
            Boolean Millones;
            long vez;
            long MaxVez;
            long k;
            string strQ;
            string strB;
            string strU;
            string strD;
            string strC;
            long iA;
            //'
            string[] strN;
            string Sexo1Ant;

            //'Si se amplia este valor... no se manipularán bien los números
            const int cAncho = 12;
            const int cGrupos = (cAncho / 3) + 1;

            //'Por si se especifica el sexo, para el caso de los decimales
            //'que siempre será masculino
            Sexo1Ant = m_Sexo1;
            m_Sexo1 = Sexo1;

            m_LenSexo1 = m_Sexo1.Length;
            //'
            //' idea aportada por Harvey Triana
            //' para no tener que estar reinicializando continuamente los arrays
            //'
            //' Se ve que lo anterior fallaba si se usaba varias veces seguidas (05/Mar/99)
            if (unidad[1] != ("un" + Sexo1))   // If unidad(1) <> "un" & Sexo1 Then
            {
                InicializarArrays();
            }
            //    '
            //'    If m_Sexo1 <> Sexo1Ant Then
            //'        unidad(2) = ""
            //'    End If
            //'    '
            //'    If unidad(2) <> "dos" Then
            //'        InicializarArrays
            //'    End If
            //    '

            //    'Si se produce un error que se pare el mundo!!!
            //On Local Error GoTo 0

            if (strNum.Length == 0)  //If Len(strNum) = 0 Then
            {
                strNum = "0";
            }

            dblNumero = Math.Abs(Convert.ToDouble(strNum));
            Negativo = (dblNumero != Convert.ToDouble(strNum));
            strNum = Convert.ToString(dblNumero).TrimEnd(' ').TrimStart(' ');  //strNum = LTrim$(RTrim$(str$(dblNumero)))
            l = strNum.Length;

            if (dblNumero < 1)
            {
                return "cero";
            }
            //'
            Una = true;
            Millon = false;
            Millones = false;
            if (l < 4) Una = false;
            if (dblNumero > 999999) Millon = true;
            if (dblNumero > 1999999) Millones = true;
            strB = "";
            strQ = strNum;
            vez = 0;

            strN = new string[cGrupos];

            //ReDim strN(1 To cGrupos)
            strQ = strNum.PadLeft(cAncho + strNum.Length, '0').Substring(strNum.PadLeft(cAncho + strNum.Length, '0').Length - cAncho, cAncho); //strQ = Right$(String$(cAncho, "0") &strNum, cAncho)
            for (k = strQ.Length; k >= 1; k = k - 3)  //For k = Len(strQ) To 1 Step - 3
            {
                vez = vez + 1;
                strN[vez] = strQ.Substring(Convert.ToInt32(k) - 3, 3);  //strN(vez) = Mid$(strQ, k -2, 3)
            }
            MaxVez = cGrupos - 1;
            for (k = cGrupos - 1; k >= 1; k = k - 1)  //For k = cGrupos To 1 Step - 1
            {
                if (strN[k] == "000")  //If strN(k) = "000" Then
                {
                    MaxVez = MaxVez - 1;
                }
                else
                {
                    break;
                }
            }

            for (vez = 1; vez <= MaxVez; vez++)  //For vez = 1 To MaxVez
            {
                strU = "";
                strD = "";
                strC = "";
                strNum = strN[vez];
                l = strNum.Length;
                k = Convert.ToInt64(strNum.Substring(strNum.Length - 2, 2));  //k = Val(Right$(strNum, 2))
                if (strNum.Substring(strNum.Length - 1, 1) == "0")  //If Right$(strNum, 1) = "0" Then
                {
                    k = Convert.ToInt64(Math.Truncate(Convert.ToDecimal(k) / 10)); //k = k \ 10
                    strD = decena[k];
                }
                else if (k > 10 && k < 16)  //ElseIf k > 10 And k< 16 Then
                {
                    k = Convert.ToInt64(strNum.Substring(l - 2, 2));  //k = Val(Mid$(strNum, l -1, 2))
                    strD = otros[k];
                }
                else
                {
                    strU = unidad[Convert.ToInt32(strNum.Substring(strNum.Length - 1, 1))];  //strU = unidad(Val(Right$(strNum, 1)))
                    if (l - 1 > 0)  //If l -1 > 0 Then
                    {
                        k = Convert.ToInt64(strNum.Substring(l - 2, 1));  //k = Val(Mid$(strNum, l -1, 1))
                        strD = deci[k];
                    }
                }
                //'---Parche de Esteve
                if ((l - 2) > 0)
                {
                    k = Convert.ToInt64(strNum.Substring(l - 3, 1));  //k = Val(Mid$(strNum, l - 2, 1))
                    //'Con esto funcionará bien el 100100, por ejemplo...
                    if (k == 1)                             //'Parche
                    {
                        if (Convert.ToDecimal(strNum) == 100) //'Parche
                        {
                            k = 10;                         //'Parche
                        }                                   //'Parche
                    }
                    strC = centena[k] + " ";
                }
                //'------
                if (strU == "uno" && strB.Substring(0, 4) == " mil") strU = "";  //If strU = "uno" And Left$(strB, 4) = " mil" Then strU = ""
                strB = strC + strD + strU + " " + strB;

                if (vez == 1 || vez == 3)
                {
                    if (strN[vez + 1] != "000") strB = " mil " + strB;  //If strN(vez + 1) <> "000" Then strB = " mil " & strB
                }
                if (vez == 2 && Millon)  //If vez = 2 And Millon Then
                {
                    if (Millones)  //If Millones Then
                    {
                        if (strB.Trim(' ') == "")   //If Trim(strB) = "" Then
                        {
                            strB = " millones de " + strB;
                        }
                        else
                        {
                            strB = " millones " + strB;
                        }
                    }
                    else
                    {
                        if (strB.Trim(' ') == "")
                        {
                            strB = "un millón de " + strB;
                        }
                        else
                        {
                            strB = "un millón " + strB;
                        }
                    }
                }
            }
            strB = strB.Trim(' ');
            if (strB.Substring((strB.Length - 3 < 0) ? 0 : strB.Length - 3, (strB.Length - 3 < 0) ? 0 : 3) == "uno")  //If Right$(strB, 3) = "uno" Then
            {
                strB = strB.Substring(0, strB.Length - 1) + m_Sexo1; // strB = Left$(strB, Len(strB) - 1) & m_Sexo1  '"a"
            }
            do                              //'Quitar los espacios dobles que haya por medio
            {
                iA = strB.IndexOf("  ");  //iA = InStr(strB, "  ")
                if (iA == -1) break;
                strB = strB.Substring(0, Convert.ToInt32(iA)) + strB.Substring(Convert.ToInt32(iA) + 1);  //strB = Left$(strB, iA -1) &Mid$(strB, iA +1)
            } while (iA != -1);
            //'
            if (strB.Substring(0, (strB.Length >= 5) ? 5 + Convert.ToInt32(m_LenSexo1) : strB.Length) == ("un" + m_Sexo1 + " un")) //If Left$(strB, 5 + m_LenSexo1) = "un" & m_Sexo1 & " un" Then
            {
                strB = strB.Substring(3 + Convert.ToInt32(m_LenSexo1)); //strB = Mid$(strB, 4 + m_LenSexo1)
            }
            //'---Nueva comparación                                     (01:16 25/Ene/99)
            if (strB.Substring(1, (strB.Length > 5) ? 5 : strB.Length - 1) == "un un")  //If Left$(strB, 5) = "un un" Then
            {
                strB = strB.Substring(3);  //strB = Mid$(strB, 4)
            }
            //'
            //' Comprobar sólo si se especifica "un* mil ",                   (05/Mar/99)
            //' no "un* mil" ya que puede ser "un* millón"
            //'If Left$(strB, 6 + m_LenSexo1) = "un" & m_Sexo1 & " mil" Then
            if (strB.Substring(0, (strB.Length > 7 + Convert.ToInt32(m_LenSexo1)) ? 7 + Convert.ToInt32(m_LenSexo1) : strB.Length) == ("un" + m_Sexo1 + " mil ")) //If Left$(strB, 7 + m_LenSexo1) = "un" & m_Sexo1 & " mil " Then
            {
                strB = strB.Substring(3 + Convert.ToInt32(m_LenSexo1));  //strB = Mid$(strB, 4 + m_LenSexo1)
                                                                         //' Puede que el importe sea sólo "un mil" o "una mil"            (19/Ago/00)
            }
            else if (strB == ("un" + m_Sexo1 + " mil"))  //ElseIf strB = "un" & m_Sexo1 & " mil" Then
            {
                strB = strB.Substring(3 + Convert.ToInt32(m_LenSexo1));  //strB = Mid$(strB, 4 + m_LenSexo1)
            }
            //'
            //'---Nueva comparación                                     (15:11 25/Ene/99)
            //'If Left$(strB, 6) = "un mil" Then
            //' Que debe estar así, para que no quite "un millón"             (05/Mar/99)
            if (strB.Substring(0, (strB.Length > 7) ? 7 : strB.Length) == "un mil ") // If Left$(strB, 7) = "un mil " Then
            {
                strB = strB.Substring(3);  //strB = Mid$(strB, 4)
            }
            //'
            //if (strB.Substring(if (strB.Length > 15)  strB.Length - 15 , 1 ,))

            if (strB.Substring((strB.Length > 15) ? (strB.Length + Convert.ToInt32(m_LenSexo1)) - 15 : 0, (strB.Length > 15) ? (strB.Length + Convert.ToInt32(m_LenSexo1)) - ((strB.Length + Convert.ToInt32(m_LenSexo1)) - 15) : strB.Length) != ("millones mil un" + m_Sexo1))  //If Right$(strB, 15 + m_LenSexo1) <> "millones mil un" & m_Sexo1 Then
            {
                iA = strB.IndexOf("millones mil un" + m_Sexo1);  //iA = InStr(strB, "millones mil un" & m_Sexo1)
                if (iA != -1) strB = strB.Substring(0, Convert.ToInt32(iA) + 8) + strB.Substring(Convert.ToInt32(iA) + 13);  //If iA Then strB = Left$(strB, iA +8) &Mid$(strB, iA +13)
            }

            //'---Nueva comparación                                   (15:13 25/Ene/99)
            if (strB.Substring((strB.Length > 15) ? strB.Length - 15 : 0, (strB.Length > 15) ? strB.Length - (strB.Length - 15) : strB.Length) != "millones mil un") //If Right$(strB, 15) <> "millones mil un" Then
            {
                iA = strB.IndexOf("millones mil un");  //iA = InStr(strB, "millones mil un")
                if (iA != -1) strB = strB.Substring(1, Convert.ToInt32(iA) + 8) + strB.Substring(Convert.ToInt32(iA) + 13);  //If iA Then strB = Left$(strB, iA +8) +Mid$(strB, iA +13)
            }
            //'
            //' De algo sirve que la gente pruebe las rutinas...              (05/Mar/99)
            //' ¡¡¡ Gracias gente !!!
            if (Millones)
            {
                //' Comprobación de -as ??? millones
                //' convertir en -os ??? millones
                //' Pero sólo si el sexo es femenino
                if (m_Sexo1 == "a")
                {
                    //'If (strB Like "*as * millones*") Then
                    //' Usar un bucle Do por si hay varias coincidencias      (07/Dic/00)
                    do   //Do While(strB Like "*as * millones*")
                    {
                        //' Buscar la primera terminación "as " y cambiar por "os "
                        k = strB.IndexOf("as ");  //k = InStr(strB, "as ")
                        if (k != -1)
                        {
                            strB = strB.Remove(Convert.ToInt32(k), "os ".Length).Insert(Convert.ToInt32(k), "os ");  //Mid$(strB, k) = "os "
                        }
                    } while (strB.IsLike("*as * millones*") == true);
                    //'End If
                    //' La comparación anterior no funciona con x00 millones  (30/Jun/00)
                    //'If (strB Like "*as millones*") Then
                    //' Usar un bucle Do por si hay varias coincidencias      (07/Dic/00)
                    do   // Do While(strB Like "*as millones*")
                    {
                        //' Buscar la primera terminación "as " y cambiar por "os "
                        k = strB.IndexOf("as millones");  //k = InStr(strB, "as millones")
                        if (k != -1)
                        {
                            strB.Remove(Convert.ToInt32(k), "os millones".Length).Insert(Convert.ToInt32(k), "os millones");  //Mid$(strB, k) = "os millones";
                        }
                    } while (strB.Contains("as millones") == true);
                    //'End If
                    //'
                    //'
                    //'------------------------------------------------------------------
                    //' Comprobar si dice algo así ...una millones            (08/Jul/00)
                    //' Por ejemplo en 821.xxx.xxx decia ochocientos veintiuna millones
                    //'------------------------------------------------------------------
                    k = strB.IndexOf("una mill");  //k = InStr(strB, "una mill")
                    if (k != -1)
                    {
                        strB = strB.Substring(0, Convert.ToInt32(k) + 1) + strB.Substring(Convert.ToInt32(k) + 3);  //strB = Left$(strB, k +1) &Mid$(strB, k +3)
                    }
                    //'
                    //'
                }
            }
            //'
            //'
            //'--------------------------------------------------------------------------
            //' Cambiar los veintiun por veintiún, etc por sus acentuadas     (08/Jul/00)
            do
            {
                k = strB.IndexOf("veintiun ");  //k = InStr(strB, "veintiun ")
                if (k != -1)
                {
                    strB = strB.Remove(Convert.ToInt32(k), "veintiún ".Length).Insert(Convert.ToInt32(k), "veintiún ");  //Mid$(strB, k) = "veintiún "
                }
            } while (k != -1);
            //' El veintidos creo que nunca lo he acentuado...                (08/Jul/00)
            //' pero en la enciclopedia consultada lo acentúa
            do
            {
                k = strB.IndexOf("veintidos ");  //k = InStr(strB, "veintidos ")
                if (k != -1)
                {
                    strB = strB.Remove(Convert.ToInt32(k), "veintidós ".Length).Insert(Convert.ToInt32(k), "veintidós ");  // Mid$(strB, k) = "veintidós "
                }
            } while (k != -1);
            do
            {
                k = strB.IndexOf("veintitres ");  //k = InStr(strB, "veintitres ")
                if (k != -1)
                {
                    strB = strB.Remove(Convert.ToInt32(k), "veintitrés ".Length).Insert(Convert.ToInt32(k), "veintitrés ");  //Mid$(strB, k) = "veintitrés "
                }
            } while (k != -1);
            do
            {
                k = strB.IndexOf("veintiseis ");  //k = InStr(strB, "veintiseis ")
                if (k != -1)
                {
                    strB = strB.Remove(Convert.ToInt32(k), "veintiséis ".Length).Insert(Convert.ToInt32(k), "veintiséis ");  //Mid$(strB, k) = "veintiséis "
                }
            } while (k != -1);
            //'--------------------------------------------------------------------------
            //'
            //'
            if (strB.Substring((strB.Length > 6) ? strB.Length - 6 : 0, (strB.Length > 6) ? 6 : strB.Length) == "ciento")   //If Right$(strB, 6) = "ciento" Then
            {
                strB = strB.Substring(0, (strB.Length - 2 >= 0) ? strB.Length - 2 : 0);  //strB = Left$(strB, Len(strB) - 2)
            }
            if (Negativo) strB = "menos " + strB; //If Negativo Then strB = "menos " & strB

            //UnNumero = Trim$(strB)

            //' Restablecer el valor anterior
            m_Sexo1 = Sexo1Ant;
            m_LenSexo1 = m_Sexo1.Length; //m_LenSexo1 = Len(m_Sexo1)

            return strB.Trim(' ');
        }
    }
}


function IsNumeric(valor) {
    var log = valor.lenngth; var sw = "S";

    for (x = 0; x < log; x++) {
        v1 = valor.substr(x, 1);
        v2 = parseInt(v1);

        if (isNaN(v2)) { sw = "N"; }
    }
    if (sw == "S") { return true; }

    else { return false; }
}


function isNumber(n)
{
    var number = n.charAt(n.length - 1);
    if (isNaN(parseInt(number))) n = n.substr(0, n.length - 1);
    if (n.length > 11) n = n.substr(0, 12);
    return (n);
}

function isNumberPlus(n)
{
    var number = n.charAt(n.length - 1);
    var snumber = number + n.charAt(n.length - 2);
    if (isNaN(parseInt(number)) && number != "-") n = n.substr(0, n.length - 1);
    if (snumber == "--") n = n.substr(0, n.length - 1);
    if (n.length > 13) n = n.substr(0, 14);
    return (n);
}

var primerslap = false;
var segundoslap = false;


function formateafecha(fecha,FechaMinima)
{
    var aniominimo = FechaMinima.substr(6, 4);
    //alert(aniominimo);
  
    
       


    var ArregloMes = new Array(6);
    ArregloMes[0] = '04';
    ArregloMes[1] = '06';
    ArregloMes[2] = '09';
    ArregloMes[3] = '11';
    ArregloMes[4] = '02';

    var long = fecha.length;
    var dia;
    var mes;
    var ano;

    if ((long >= 2) && (primerslap == false)) {
        dia = fecha.substr(0, 2);

        if ((IsNumeric(dia) == true) && (dia <= 31) && (dia != "00")) 
        {
            fecha = fecha.substr(0, 2) + "/" + fecha.substr(3, 7);
            primerslap = true;
        }
        else 
        {
            fecha = "";
            primerslap = false;
        }
    }
    else
    {
        dia = fecha.substr(0, 1);
        if (IsNumeric(dia) == false) { fecha = ""; }

        if ((long <= 2) && (primerslap = true))
        {
            fecha = fecha.substr(0, 1);
            primerslap = false;
        }
    }
    if ((long >= 5) && (segundoslap == false))
    {
        mes = fecha.substr(3, 2);
        if ((IsNumeric(mes) == true) && (mes <= 12) && (mes != "00"))
        {
            fecha = fecha.substr(0, 5) + "/" + fecha.substr(6, 4);
            segundoslap = true;
        }
        else
        {
            fecha = fecha.substr(0, 3);
            segundoslap = false;
        }
    }
    else
    {
        if ((long <= 5) && (segundoslap = true))
        {
            fecha = fecha.substr(0, 4);
            segundoslap = false;
        }
    }
    if (long >= 7)
    {
        ano = fecha.substr(6, 4);
        if (IsNumeric(ano) == false) { fecha = fecha.substr(0, 6); }

        else
        {
            if (long == 10)
            {
                if ((ano == 0) || (ano < aniominimo) || (ano > 2030)) { fecha = fecha.substr(0, 6); }
            }
        }
    }
    if (long >= 10)
    {
        fecha = fecha.substr(0, 10);
        dia = fecha.substr(0, 2);
        mes = fecha.substr(3, 2);
        ano = fecha.substr(6, 4);

        if (((ano % 4) != 0) && (mes == 02) && (dia > 28)) { fecha = fecha.substr(0, 2) + "/"; }

        for (x = 0; x < 4; x++)
        {
            if ((mes == ArregloMes[x]) && (dia > 30)) { fecha = fecha.substr(0, 2) + "/"; }
        }
    }
    if (long >= 4)
    {
        fecha = fecha.substr(0, 10);
        dia = fecha.substr(0, 2);
        mes = fecha.substr(3, 2);
        ano = fecha.substr(6, 4);

        for (x = 0; x < 5; x++)
        {
            if ((mes == ArregloMes[x]) && (dia > 30)) { fecha = fecha.substr(0, 2) + "/"; }
        }
    }
    return (fecha);
}

function formatCurrency(num) {
  num = num.toString().replace(/\$|\,/g,'');
  if(isNaN(num))
  num = "0";
  sign = (num == (num = Math.abs(num)));
  num = Math.floor(num*100+0.50000000001);
  cents = num%100;
  //alert(cents);
  num = Math.floor(num/100).toString();
  if(cents<10)
  cents = "0" + cents;
  for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
  num = num.substring(0,num.length-(4*i+3))+','+
  num.substring(num.length-(4*i+3));
  //return (((sign)?'':'-') + '$' + num + '.' + cents);
  return (((sign)?'':'-')  + num + '.' + cents);
 }
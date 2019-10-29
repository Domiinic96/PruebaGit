using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaParagit.Models
{
    public class Global
    {
       public List<GeneraMenuCabecera_Result> genera(){
            List<GeneraMenu_Result> generaMenu_Results = new List<GeneraMenu_Result>();
            List<GeneraMenuCabecera_Result> menu = new List<GeneraMenuCabecera_Result>();
            try
            {
                using (var db = new TransaccionesConn())
                {
                    menu = db.GeneraMenuCabecera("user01", "101", "140").ToList();
                    generaMenu_Results = db.GeneraMenu("user01", "101", "140").ToList();

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                
            }
            return menu;
        }

        public List<GeneraMenu_Result> generamenu()
        {
            List<GeneraMenu_Result> generaMenu_Results = new List<GeneraMenu_Result>();
           try
            {
                using (var db = new TransaccionesConn())
                {
                  
                    generaMenu_Results = db.GeneraMenu("user01", "101", "140").ToList();

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
            return generaMenu_Results;
        }

    }
}
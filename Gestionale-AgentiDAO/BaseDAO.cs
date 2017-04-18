using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Web;

namespace Gestionale_AgentiDAO
{
    public class BaseDAO
        {
            public static SQLiteConnection GetConnection()
            {
                try
                {
                String path = HttpContext.Current.Server.MapPath("~/test.db");
                SQLiteConnection cn = new SQLiteConnection("Data Source="+ path + ";Version=3;foreign keys=true");                
                cn.Open();
                return cn;
                }
                catch (Exception ex)
                {
                    String msg = "Si è verificato un errore durante la creazione della connessione col DB";
                    throw new Exception(msg, ex);
                }                
            }
        }
    }

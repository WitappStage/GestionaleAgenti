using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;

namespace Gestionale_AgentiDAO
{
    public class CreazioneDB
        {
            public static void CreaDB()
            {
            SQLiteConnection.CreateFile("C:\\Users\\admin\\Desktop\\STAGE\\GESTIONALE-AGENTI\\Libreria-Gestionale-Agente\\database\\test.db");
            }    
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;

namespace Gestionale_AgentiDAO
{
    public class PopolaAgenti : BaseDAO
    {
        public static void InserisciAdmin()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "INSERT INTO Agenti ([Nome],[Cognome],[Email],[Password]) VALUES ('Giovanni', 'Pugliese', 'admin', 'admin')";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void InserisciUtenteProva()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "INSERT INTO Agenti ([Nome],[Cognome],[Email],[Password]) VALUES ('Simone', 'Mazzola', 'simonemazzola', 'simonemazzola')";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}

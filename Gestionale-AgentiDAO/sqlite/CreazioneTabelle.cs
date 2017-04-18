using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;

namespace Gestionale_AgentiDAO
{
    public class CreazioneTabelle : BaseDAO
    {
        public static void CreaTabellaAgenti()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Agenti]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [Nome] [varchar](50) NOT NULL, [Cognome] [varchar](50) NOT NULL, [Email] [varchar](50) NOT NULL, [Password] [varchar](20) NOT NULL)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaAllegati()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Allegati]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [Url] [varchar](800) NOT NULL, [Titolo][varchar](50) NOT NULL, [AgenteId] INTEGER NOT NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaAppuntamenti()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Appuntamenti]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [data] [datetime] NOT NULL, [clienteId] INTEGER NOT NULL, [descrizione] [nvarchar](200) NULL, [agenteId] INTEGER NOT NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT, FOREIGN KEY(ClienteId) REFERENCES Clienti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaClienti()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Clienti]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [RagioneSociale] [varchar](50) NOT NULL, [SedeLegale][varchar](100) NOT NULL, [PartitaIva] [varchar](50) NOT NULL, [CodiceFiscale] [varchar](50) NULL, [Email] [varchar](50) NULL, [Pec] [varchar](50) NOT NULL, [Telefono] [varchar](50) NOT NULL, [Referente] [varchar](50) NOT NULL, [RefTelefono] [varchar](50) NULL, [RefEmail] [varchar](50) NULL, [AgenteId] INTEGER NOT NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaContratti()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Contratti]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [Data] [varchar](50) NOT NULL, [ClienteId] INTEGER NOT NULL, [Note] [varchar](200) NULL, [UrlAllegato] [varchar](800) NOT NULL, [AgenteId] INTEGER NOT NULL, [Importo] [decimal](18, 2) NOT NULL, [Esito] [varchar](50) NULL, [Mensile] [decimal](18, 2) NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT, FOREIGN KEY(ClienteId) REFERENCES Clienti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaFatture()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Fatture]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [ClienteId] INTEGER NOT NULL, [Importo][decimal](18, 2) NOT NULL, [Provvigione] [varchar](50) NOT NULL, [UrlAllegato] [varchar](800) NOT NULL, [Esito] [varchar](50) NOT NULL, [AgenteId] INTEGER NOT NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT, FOREIGN KEY(ClienteId) REFERENCES Clienti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaOfferte()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Offerte]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [Data] [varchar](50) NOT NULL, [ClienteId] INTEGER NOT NULL, [Note] [varchar](300) NULL, [Importo] [decimal](18, 2) NOT NULL, [UrlAllegato] [varchar](800) NOT NULL, [AgenteId] INTEGER NOT NULL, [Mensile] [decimal](18, 2) NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT, FOREIGN KEY(ClienteId) REFERENCES Clienti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaTabellaRichieste()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE TABLE [Richieste]([id] INTEGER PRIMARY KEY AUTOINCREMENT, [Data] [varchar](50) NOT NULL, [ClienteId] INTEGER NOT NULL, [Settore] [varchar](50) NOT NULL, [Note] [varchar](500) NOT NULL, [AgenteId] INTEGER NOT NULL, FOREIGN KEY(AgenteId) REFERENCES Agenti(id) ON DELETE RESTRICT, FOREIGN KEY(ClienteId) REFERENCES Clienti(id) ON DELETE RESTRICT)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }

        public static void CreaIndiciUnivociClienti()
        {
            SQLiteConnection cn = GetConnection();
            string sql = "CREATE UNIQUE INDEX ix_univocita ON Clienti (RagioneSociale, AgenteId)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cn);
            cmd.ExecuteNonQuery();
            string sql2 = "CREATE UNIQUE INDEX ix_univocita2 ON Clienti (PartitaIva, AgenteId)";
            SQLiteCommand cmd2 = new SQLiteCommand(sql2, cn);
            cmd2.ExecuteNonQuery();
        }        
    }
}

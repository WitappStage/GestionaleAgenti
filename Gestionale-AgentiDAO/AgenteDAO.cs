using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class AgenteDAO : BaseDAO
    {
        public static bool VerificaLogin(string username, string password)
        {            
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [Id],[Email],[Password] FROM [Agenti] WHERE Email=@pEmail";
                SQLiteParameter pEmail = new SQLiteParameter("pEmail", username);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pEmail);

                dr = cmd.ExecuteReader();

                Agente tmpAgente = new Agente();
                
                if (dr.Read())
                {                    
                    tmpAgente.Email = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpAgente.Password = (dr.IsDBNull(2) ? null : dr.GetString(2));

                    if (tmpAgente.Password == password)
                    {
                        Agente.idSessione = (dr.IsDBNull(0) ? -1 : dr.GetInt32(0));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel Login", ex);
            }
            finally
            {
                dr.Close();           
                cn.Close();
            }
        }

        public static Agente GetAgente(int idAgente)
        {
            Agente tmpAgente= new Agente();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [Nome], [Cognome], [Email], [Password] FROM [Agenti] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idAgente);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpAgente.Id = dr.GetInt32(0);
                    tmpAgente.Nome = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpAgente.Cognome = (dr.IsDBNull(2) ? null : dr.GetString(2));
                    tmpAgente.Email = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpAgente.Password = (dr.IsDBNull(4) ? null : dr.GetString(4));

                    return tmpAgente;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento dell'agente", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static List<Agente> GetListAgenti()
        {
            List<Agente> retList = new List<Agente>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT id, nome, cognome, email, password " +
                  "FROM [Agenti]";
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Agente tmpAgente = new Agente();
                    tmpAgente.Id = (dr.IsDBNull(0)? -1 : dr.GetInt32(0));
                    tmpAgente.Nome = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpAgente.Cognome = (dr.IsDBNull(2) ? null : dr.GetString(2));
                    tmpAgente.Email = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpAgente.Password = (dr.IsDBNull(4) ? null : dr.GetString(4));

                        retList.Add(tmpAgente);
                    }

                    return retList;                
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento degli agenti", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }
    }
}

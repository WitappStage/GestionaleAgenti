using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class AllegatoDAO : BaseDAO
    {
        public static List<Allegato> GetListAllegati(int agenteId) //FUNZIONE PER OTTENERE LA LISTA DI TUTTI GLI Allegati CONTENUTE NEL DB
        {
            List<Allegato> retList = new List<Allegato>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT al.id, al.url, al.titolo, al.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                      "FROM [Allegati] al " +
                      "JOIN [Agenti] ag ON (al.agenteid = ag.id) ";
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Allegato tmpAllegato = new Allegato();
                        tmpAllegato.Id = dr.GetInt32(0);
                        tmpAllegato.Url = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpAllegato.Titolo = (dr.IsDBNull(2) ? null : dr.GetString(2));
                        tmpAllegato.AgenteId = (dr.IsDBNull(3) ? -1 : dr.GetInt32(3));
                        tmpAllegato.NominativoAgente = (dr.IsDBNull(4) ? null : dr.GetString(4));

                        retList.Add(tmpAllegato);
                    }

                    return retList;
                }
                else
                {
                    sql = "SELECT al.id, al.url, al.titolo, al.agenteId" +
                      "FROM [Allegati] al " +
                      "WHERE al.agenteId = @pAgenteId";

                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Allegato tmpAllegato = new Allegato();
                        tmpAllegato.Id = dr.GetInt32(0);
                        tmpAllegato.Url = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpAllegato.Titolo = (dr.IsDBNull(2) ? null : dr.GetString(2));
                        tmpAllegato.AgenteId = (dr.IsDBNull(3) ? -1 : dr.GetInt32(3));

                        retList.Add(tmpAllegato);
                    }

                    return retList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento degli Allegati", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Allegato GetAllegato(int idAllegato) //FUNZIONE PER OTTENERE UN SINGOLO Allegato (UTILE IN CASO DI RICHIESTA DI MODIFICHE)
        {
            Allegato tmpAllegato = new Allegato();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [url], [titolo] FROM [Allegati] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idAllegato);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpAllegato.Id = dr.GetInt32(0);
                    tmpAllegato.Url = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpAllegato.Titolo = (dr.IsDBNull(2) ? null : dr.GetString(2));
                    tmpAllegato.AgenteId = (dr.IsDBNull(3) ? -1 : dr.GetInt32(3));
                    return tmpAllegato;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento dell'Allegato", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }

        }

        public static bool InsertAllegato(Allegato Allegato) //FUNZIONE DI INSERIMENTO DI UN Allegato NEL DB
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "INSERT into [Allegati]([url],[titolo],[agenteId]) " +
                      "VALUES (@pUrl,@pTitolo,@pAgenteId)";
                SQLiteParameter pUrl = new SQLiteParameter("pUrl", Allegato.Url);
                SQLiteParameter pTitolo = new SQLiteParameter("pTitolo", Allegato.Titolo);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", Allegato.AgenteId);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                cmd.Parameters.Add(pUrl);
                cmd.Parameters.Add(pTitolo);
                cmd.Parameters.Add(pAgenteId);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'inserimento dell'Allegato", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteAllegato(string url)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Allegati] WHERE [Url] = @pUrl";

                SQLiteParameter pUrl = new SQLiteParameter("pUrl", url);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pUrl);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la cancellazione di un allegato.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool EsisteAllegato(string url) //FUNZIONE PER VERIFICARE L'ESISTENZA DI ALLEGATO
        {
            Allegato tmpAllegato = new Allegato();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [url], [titolo], [agenteId] FROM [Allegati] WHERE [url]=@pUrl";
                SQLiteParameter pUrl = new SQLiteParameter("pUrl", url);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pUrl);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpAllegato.Id = dr.GetInt32(0);
                    tmpAllegato.Url = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpAllegato.Titolo = (dr.IsDBNull(2) ? null : dr.GetString(2));
                    tmpAllegato.AgenteId = (dr.IsDBNull(3) ? -1 : dr.GetInt32(3));
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la verifica dell'esistenza dell'Allegato", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }
    }
}

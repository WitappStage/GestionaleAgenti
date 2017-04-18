using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class ContrattoDAO : BaseDAO
    {
        public static List<Contratto> GetListContratti(int agenteId) //FUNZIONE PER OTTENERE LA LISTA DI TUTTI I Contratti CONTENUTI NEL DB
        {
            List<Contratto> retList = new List<Contratto>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.esito, o.note, o.importo, o.mensile, o.urlallegato, cl.ragionesociale, o.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                                          "FROM [Contratti] o " +
                                          "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                                          "JOIN [Agenti] ag ON (o.agenteid = ag.id) ";
                    
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Contratto tmpContratto = new Contratto();
                        tmpContratto.Id = dr.GetInt32(0);
                        tmpContratto.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpContratto.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpContratto.Esito = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpContratto.Note = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpContratto.Importo = (dr.IsDBNull(5) ? -1 : dr.GetDecimal(5));
                        tmpContratto.Mensile = (dr.IsDBNull(6) ? -1 : dr.GetDecimal(6));
                        tmpContratto.UrlAllegato = (dr.IsDBNull(7) ? null : dr.GetString(7));
                        tmpContratto.NominativoCliente = (dr.IsDBNull(8) ? string.Empty : dr.GetString(8));
                        tmpContratto.AgenteId = (dr.IsDBNull(9) ? -1 : dr.GetInt32(9));
                        tmpContratto.NominativoAgente = (dr.IsDBNull(10) ? string.Empty : dr.GetString(10));

                        retList.Add(tmpContratto);
                    }
                }
                else
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.esito, o.note, o.importo, o.mensile, o.urlallegato, cl.ragionesociale, o.agenteId " +
                      "FROM [Contratti] o " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                      "WHERE o.agenteId = @pAgenteId";

                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Contratto tmpContratto = new Contratto();
                        tmpContratto.Id = dr.GetInt32(0);
                        tmpContratto.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpContratto.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpContratto.Esito = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpContratto.Note = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpContratto.Importo = (dr.IsDBNull(5) ? -1 : dr.GetDecimal(5));
                        tmpContratto.Mensile = (dr.IsDBNull(6) ? -1 : dr.GetDecimal(6));
                        tmpContratto.UrlAllegato = (dr.IsDBNull(7) ? null : dr.GetString(7));
                        tmpContratto.NominativoCliente = (dr.IsDBNull(8) ? string.Empty : dr.GetString(8));
                        tmpContratto.AgenteId = (dr.IsDBNull(9) ? -1 : dr.GetInt32(9));

                        retList.Add(tmpContratto);
                    }
                }
                

                return retList;
            }
            catch (Exception ex)
            {

                throw new Exception("Errore durante l'ottenimento dei Contratti", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Contratto GetContratto(int idContratto) //FUNZIONE PER OTTENERE UN SINGOLO Contratto (UTILE IN CASO DI RICHIESTA DI MODIFICHE)
        {
            Contratto tmpContratto = new Contratto();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;

            try
            {
                sql = "SELECT [id], [data], [clienteid], [esito], [note], [importo], [mensile], [urlallegato], [agenteId] FROM [Contratti] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idContratto);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpContratto.Id = dr.GetInt32(0);
                    tmpContratto.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpContratto.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                    tmpContratto.Esito = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpContratto.Note = (dr.IsDBNull(4) ? null : dr.GetString(4));
                    tmpContratto.Importo = (dr.IsDBNull(5) ? -1 : dr.GetDecimal(5));
                    tmpContratto.Mensile = (dr.IsDBNull(6) ? -1 : dr.GetDecimal(6));
                    tmpContratto.UrlAllegato = (dr.IsDBNull(7) ? null : dr.GetString(7));
                    tmpContratto.AgenteId = (dr.IsDBNull(8) ? -1 : dr.GetInt32(8));
                    return tmpContratto;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento del Contratto", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static bool InsertContratto(Contratto Contratto) //FUNZIONE DI INSERIMENTO DI UN Contratto NEL DB
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "INSERT into [Contratti]([data],[clienteid],[esito],[note],[importo],[mensile],[urlallegato],[agenteId]) " +
                    "VALUES (@pData,@pClienteId,@pEsito,@pNote,@pImporto,@pMensile,@pUrlAllegato,@pAgenteId)";
                SQLiteParameter pData = new SQLiteParameter("pData", Contratto.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", Contratto.ClienteId);
                SQLiteParameter pEsito = new SQLiteParameter("pEsito", Contratto.Esito);
                SQLiteParameter pNote = new SQLiteParameter("pNote", Contratto.Note);
                SQLiteParameter pImporto = new SQLiteParameter("pImporto", Contratto.Importo);
                SQLiteParameter pMensile = new SQLiteParameter("pMensile", Contratto.Mensile);
                SQLiteParameter pUrlAllegato = new SQLiteParameter("pUrlAllegato", Contratto.UrlAllegato);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", Contratto.AgenteId);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pEsito);
                cmd.Parameters.Add(pNote);
                cmd.Parameters.Add(pImporto);
                cmd.Parameters.Add(pMensile);
                cmd.Parameters.Add(pUrlAllegato);
                cmd.Parameters.Add(pAgenteId);

                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'inserimento del Contratto", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteContratto(Contratto contratto)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Contratti] WHERE [id] = @pId";

                SQLiteParameter pId = new SQLiteParameter("pId", contratto.Id);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la cancellazione di un contratto.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool UpdateContratto(Contratto contratto)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "UPDATE [Contratti] SET " +
                      "[Data] = @pData, " +
                      "[ClienteId] = @pClienteId, " +
                      "[Esito] = @pEsito, " +
                      "[Note] = @pNote, " +
                      "[UrlAllegato] = @pUrlAllegato " +
                      "WHERE [id] = @pId";

                SQLiteParameter pData = new SQLiteParameter("pData", contratto.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", contratto.ClienteId);
                SQLiteParameter pEsito = new SQLiteParameter("pEsito", contratto.Esito);
                SQLiteParameter pNote = new SQLiteParameter("pNote", contratto.Note);
                SQLiteParameter pUrlAllegato = new SQLiteParameter("pUrlAllegato", contratto.UrlAllegato);
                SQLiteParameter pId = new SQLiteParameter("pId", contratto.Id);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pEsito);
                cmd.Parameters.Add(pNote);
                cmd.Parameters.Add(pUrlAllegato);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la modifica del contratto.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class RichiestaDAO : BaseDAO
    {
        public static List<Richiesta> GetListRichieste(int agenteId) //FUNZIONE PER OTTENERE LA LISTA DI TUTTE LE Richieste CONTENUTE NEL DB
        {
            List<Richiesta> retList = new List<Richiesta>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.note, cl.ragionesociale, o.settore, o.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                      "FROM [Richieste] o " +
                      "JOIN [Agenti] ag ON (o.agenteid = ag.id) " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) ";
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Richiesta tmpRichiesta = new Richiesta();
                        tmpRichiesta.Id = dr.GetInt32(0);
                        tmpRichiesta.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpRichiesta.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpRichiesta.Note = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpRichiesta.NominativoCliente = (dr.IsDBNull(4) ? string.Empty : dr.GetString(4));
                        tmpRichiesta.Settore = (dr.IsDBNull(5) ? null : dr.GetString(5));
                        tmpRichiesta.AgenteId = (dr.IsDBNull(6) ? -1 : dr.GetInt32(6));
                        tmpRichiesta.NominativoAgente = (dr.IsDBNull(7) ? null : dr.GetString(7));

                        retList.Add(tmpRichiesta);
                    }

                    return retList;
                }
                else
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.note, o.settore, cl.ragionesociale, o.agenteId " +
                      "FROM [Richieste] o " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                      "WHERE o.agenteId = @pAgenteId";
                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Richiesta tmpRichiesta = new Richiesta();
                        tmpRichiesta.Id = dr.GetInt32(0);
                        tmpRichiesta.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpRichiesta.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpRichiesta.Note = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpRichiesta.Settore = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpRichiesta.NominativoCliente = (dr.IsDBNull(5) ? string.Empty : dr.GetString(5));
                        tmpRichiesta.AgenteId = (dr.IsDBNull(6) ? -1 : dr.GetInt32(6));

                        retList.Add(tmpRichiesta);
                    }

                    return retList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento delle Richieste", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Richiesta GetRichiesta(int idRichiesta) //FUNZIONE PER OTTENERE UNA SINGOLA Richiesta (UTILE IN CASO DI RICHIESTA DI MODIFICHE)
        {
            Richiesta tmpRichiesta = new Richiesta();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [data], [clienteid], [note], [settore], [agenteId] FROM [Richieste] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idRichiesta);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpRichiesta.Id = dr.GetInt32(0);
                    tmpRichiesta.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpRichiesta.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                    tmpRichiesta.Note = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpRichiesta.Settore = (dr.IsDBNull(4) ? null : dr.GetString(4));
                    tmpRichiesta.AgenteId = (dr.IsDBNull(5) ? -1 : dr.GetInt32(5));

                    return tmpRichiesta;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento della Richiesta", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static bool InsertRichiesta(Richiesta Richiesta) //FUNZIONE DI INSERIMENTO DI UNA Richiesta NEL DB
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {

                sql = "INSERT into [Richieste]([data],[clienteid],[note],[settore],[agenteId]) " +
                "VALUES (@pData,@pClienteId,@pNote,@pSettore,@pAgenteId)";
                SQLiteParameter pData = new SQLiteParameter("pData", Richiesta.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", Richiesta.ClienteId);
                SQLiteParameter pNote = new SQLiteParameter("pNote", Richiesta.Note);
                SQLiteParameter pSettore = new SQLiteParameter("pSettore", Richiesta.Settore);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", Richiesta.AgenteId);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pNote);
                cmd.Parameters.Add(pSettore);
                cmd.Parameters.Add(pAgenteId);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'inserimento della Richiesta", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteRichiesta(Richiesta richiesta)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Richieste] WHERE [id] = @pId";

                SQLiteParameter pId = new SQLiteParameter("pId", richiesta.Id);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la cancellazione di una richiesta.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool UpdateRichiesta(Richiesta richiesta)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "UPDATE [Richieste] SET " +
                      "[Data] = @pData, " +
                      "[ClienteId] = @pClienteId, " +
                      "[Note] = @pNote, " +
                      "[Settore] = @pSettore, " +
                      "[AgenteId] = @pAgenteId " +
                      "WHERE [id] = @pId";

                SQLiteParameter pData = new SQLiteParameter("pData", richiesta.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", richiesta.ClienteId);
                SQLiteParameter pNote = new SQLiteParameter("pNote", richiesta.Note);
                SQLiteParameter pSettore = new SQLiteParameter("pSettore", richiesta.Settore);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", richiesta.AgenteId);
                SQLiteParameter pId = new SQLiteParameter("pId", richiesta.Id);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pNote);
                cmd.Parameters.Add(pSettore);
                cmd.Parameters.Add(pAgenteId);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la modifica della richiesta.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class OffertaDAO : BaseDAO
    {
        public static List<Offerta> GetListOfferte(int agenteId) //FUNZIONE PER OTTENERE LA LISTA DI TUTTE LE OFFERTE CONTENUTE NEL DB
        {
            List<Offerta> retList = new List<Offerta>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.note, o.importo, o.mensile, o.urlallegato, cl.ragionesociale, o.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                      "FROM [Offerte] o " +
                      "JOIN [Agenti] ag ON (o.agenteid = ag.id) " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) "; 
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Offerta tmpOfferta = new Offerta();
                        tmpOfferta.Id = dr.GetInt32(0);
                        tmpOfferta.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpOfferta.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpOfferta.Note = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpOfferta.Importo = (dr.IsDBNull(4) ? -1 : dr.GetDecimal(4));
                        tmpOfferta.Mensile = (dr.IsDBNull(5) ? -1 : dr.GetDecimal(5));
                        tmpOfferta.UrlAllegato = (dr.IsDBNull(6) ? null : dr.GetString(6));
                        tmpOfferta.NominativoCliente = (dr.IsDBNull(7) ? string.Empty : dr.GetString(7));
                        tmpOfferta.AgenteId = (dr.IsDBNull(8) ? -1 : dr.GetInt32(8));
                        tmpOfferta.NominativoAgente = (dr.IsDBNull(9) ? null : dr.GetString(9));

                        retList.Add(tmpOfferta);
                    }

                    return retList;
                }
                else
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.note, o.importo, o.mensile, o.urlallegato, cl.ragionesociale, o.agenteId " +
                      "FROM [Offerte] o " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                      "WHERE o.agenteId = @pAgenteId";
                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Offerta tmpOfferta = new Offerta();
                        tmpOfferta.Id = dr.GetInt32(0);
                        tmpOfferta.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpOfferta.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpOfferta.Note = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpOfferta.Importo = (dr.IsDBNull(4) ? -1 : dr.GetDecimal(4));
                        tmpOfferta.Mensile = (dr.IsDBNull(5) ? -1 : dr.GetDecimal(5));
                        tmpOfferta.UrlAllegato = (dr.IsDBNull(6) ? null : dr.GetString(6));
                        tmpOfferta.NominativoCliente = (dr.IsDBNull(7) ? string.Empty : dr.GetString(7));
                        tmpOfferta.AgenteId = (dr.IsDBNull(8) ? -1 : dr.GetInt32(8));

                        retList.Add(tmpOfferta);
                    }

                    return retList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento delle offerte",ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Offerta GetOfferta(int idOfferta) //FUNZIONE PER OTTENERE UNA SINGOLA OFFERTA (UTILE IN CASO DI RICHIESTA DI MODIFICHE)
        {
            Offerta tmpOfferta = new Offerta();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [data], [clienteid], [note], [importo], [mensile], [urlallegato], [agenteId] FROM [offerte] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idOfferta);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    tmpOfferta.Id = dr.GetInt32(0);
                    tmpOfferta.Data = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpOfferta.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                    tmpOfferta.Note = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpOfferta.Importo = (dr.IsDBNull(4) ? -1 : dr.GetDecimal(4));
                    tmpOfferta.Mensile = (dr.IsDBNull(5) ? -1 : dr.GetDecimal(5));
                    tmpOfferta.UrlAllegato = (dr.IsDBNull(6) ? null : dr.GetString(6));
                    tmpOfferta.AgenteId = (dr.IsDBNull(7) ? -1: dr.GetInt32(7));
                    return tmpOfferta;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento dell'offerta", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static bool InsertOfferta(Offerta offerta) //FUNZIONE DI INSERIMENTO DI UN'OFFERTA NEL DB
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {

                sql = "INSERT into [Offerte]([data],[clienteid],[note],[importo],[mensile],[urlallegato],[agenteId]) " +
                "VALUES (@pData,@pClienteId,@pNote,@pImporto,@pMensile,@pUrlAllegato,@pAgenteId)";
                SQLiteParameter pData = new SQLiteParameter("pData", offerta.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", offerta.ClienteId);
                SQLiteParameter pNote = new SQLiteParameter("pNote", offerta.Note);
                SQLiteParameter pImporto = new SQLiteParameter("pMensile", offerta.Mensile);
                SQLiteParameter pMensile = new SQLiteParameter("pImporto", offerta.Importo);
                SQLiteParameter pUrlAllegato = new SQLiteParameter("pUrlAllegato", offerta.UrlAllegato);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", offerta.AgenteId);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
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
                throw new Exception ("Errore con l'inserimento dell'offerta", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteOfferta(Offerta offerta)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Offerte] WHERE [id] = @pId";

                SQLiteParameter pId = new SQLiteParameter("pId", offerta.Id);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la cancellazione di un'offerta.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool UpdateOfferta(Offerta offerta)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "UPDATE [Offerte] SET " +
                      "[Data] = @pData, " +
                      "[ClienteId] = @pClienteId, " +
                      "[Note] = @pNote, " +
                      "[Importo] = @pImporto, " +
                      "[Mensile] = @pMensile, " +
                      "[UrlAllegato] = @pUrlAllegato " +
                      "WHERE [id] = @pId";

                SQLiteParameter pData = new SQLiteParameter("pData", offerta.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", offerta.ClienteId);
                SQLiteParameter pNote = new SQLiteParameter("pNote", offerta.Note);
                SQLiteParameter pImporto = new SQLiteParameter("pImporto", offerta.Importo);
                SQLiteParameter pMensile = new SQLiteParameter("pMensile", offerta.Mensile);
                SQLiteParameter pUrlAllegato = new SQLiteParameter("pUrlAllegato", offerta.UrlAllegato);
                SQLiteParameter pId = new SQLiteParameter("pId", offerta.Id);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pNote);
                cmd.Parameters.Add(pImporto);
                cmd.Parameters.Add(pMensile);
                cmd.Parameters.Add(pUrlAllegato);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la modifica dell'offerta.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

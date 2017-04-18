using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class FatturaDAO : BaseDAO
    {
        public static List<Fattura> GetListFatture(int agenteId) //FUNZIONE PER OTTENERE LA LISTA DI TUTTE LE Fatture CONTENUTE NEL DB
        {
            List<Fattura> retList = new List<Fattura>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT o.id, o.clienteid, o.esito, o.importo, o.urlallegato, o.provvigione, cl.ragioneSociale, o.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                          "FROM [Fatture] o " +
                          "JOIN [Agenti] ag ON (o.agenteid = ag.id) " +
                          "JOIN [Clienti] cl ON (o.clienteid = cl.id) ";

                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fattura tmpFattura = new Fattura();
                        tmpFattura.Id = dr.GetInt32(0);
                        tmpFattura.ClienteId = (dr.IsDBNull(1) ? -1 : dr.GetInt32(1));
                        tmpFattura.Esito = (dr.IsDBNull(2) ? null : dr.GetString(2));
                        tmpFattura.Importo = (dr.IsDBNull(3) ? -1 : dr.GetDecimal(3));
                        tmpFattura.UrlAllegato = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpFattura.Provvigione = (dr.IsDBNull(5) ? null : dr.GetString(5));
                        tmpFattura.NominativoCliente = (dr.IsDBNull(6) ? string.Empty : dr.GetString(6));
                        tmpFattura.AgenteId = (dr.IsDBNull(7) ? -1 : dr.GetInt32(7));
                        tmpFattura.NominativoAgente = (dr.IsDBNull(8) ? null : dr.GetString(8));

                        if (!(tmpFattura.Importo.ToString().Contains(',')))
                        {
                            tmpFattura.Importo = decimal.Parse(tmpFattura.Importo.ToString() + ",00");
                        }

                        retList.Add(tmpFattura);
                    }
                }
                else
                {
                    sql = "SELECT o.id, o.clienteid, o.esito, o.importo, o.urlallegato, o.provvigione, cl.ragioneSociale, o.agenteId " +
                          "FROM [Fatture] o " +
                          "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                          "WHERE o.agenteId = @pAgenteId";


                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fattura tmpFattura = new Fattura();
                        tmpFattura.Id = dr.GetInt32(0);
                        tmpFattura.ClienteId = (dr.IsDBNull(1) ? -1 : dr.GetInt32(1));
                        tmpFattura.Esito = (dr.IsDBNull(2) ? null : dr.GetString(2));
                        tmpFattura.Importo = (dr.IsDBNull(3) ? -1 : dr.GetDecimal(3));
                        tmpFattura.UrlAllegato = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpFattura.Provvigione = (dr.IsDBNull(5) ? null : dr.GetString(5));
                        tmpFattura.NominativoCliente = (dr.IsDBNull(6) ? string.Empty : dr.GetString(6));
                        tmpFattura.AgenteId = (dr.IsDBNull(7) ? -1 : dr.GetInt32(7));

                        retList.Add(tmpFattura);
                    }
                }

                return retList;
            }
            catch (Exception ex)
            {

                throw new Exception("Errore durante l'ottenimento delle Fatture", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Fattura GetFattura(int idFattura) //FUNZIONE PER OTTENERE UNA SINGOLA Fattura (UTILE IN CASO DI RICHIESTA DI MODIFICHE)
        {
            Fattura tmpFattura = new Fattura();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [clienteid], [esito], [importo], [provvigione], [urlallegato], [agenteId] FROM [Fatture] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idFattura);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpFattura.Id = dr.GetInt32(0);
                    tmpFattura.ClienteId = (dr.IsDBNull(1) ? -1 : dr.GetInt32(1));
                    tmpFattura.Esito = (dr.IsDBNull(2) ? null : dr.GetString(2));
                    tmpFattura.Importo = (dr.IsDBNull(3) ? -1 : dr.GetDecimal(3));
                    tmpFattura.Provvigione = (dr.IsDBNull(4) ? null : dr.GetString(4));
                    tmpFattura.UrlAllegato = (dr.IsDBNull(5) ? null : dr.GetString(5));
                    tmpFattura.AgenteId= (dr.IsDBNull(6) ? -1 : dr.GetInt32(6));

                    if (!(tmpFattura.Importo.ToString().Contains(',')))
                    {
                        tmpFattura.Importo = decimal.Parse(tmpFattura.Importo.ToString() + ",00");
                    }

                    return tmpFattura;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento della Fattura", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static bool InsertFattura(Fattura Fattura) //FUNZIONE DI INSERIMENTO DI UNA Fattura NEL DB
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "INSERT into [Fatture]([clienteid],[esito],[importo],[provvigione],[urlallegato],[agenteId]) " +
                      "VALUES (@pClienteId,@pEsito,@pImporto,@pProvvigione,@pUrlAllegato,@pAgenteId)";
                    SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", Fattura.ClienteId);
                    SQLiteParameter pEsito = new SQLiteParameter("pEsito", Fattura.Esito);
                    SQLiteParameter pImporto = new SQLiteParameter("pImporto", Fattura.Importo);
                    SQLiteParameter pProvvigione = new SQLiteParameter("pProvvigione", Fattura.Provvigione);
                    SQLiteParameter pUrlAllegato = new SQLiteParameter("pUrlAllegato", Fattura.UrlAllegato);
                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", Fattura.AgenteId);


                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                                   
                    cmd.Parameters.Add(pClienteId);
                    cmd.Parameters.Add(pEsito);
                    cmd.Parameters.Add(pImporto);
                    cmd.Parameters.Add(pProvvigione);
                    cmd.Parameters.Add(pUrlAllegato);
                    cmd.Parameters.Add(pAgenteId);

                    cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'inserimento della Fattura", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteFattura(Fattura fattura)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Fatture] WHERE [id] = @pId";

                SQLiteParameter pId = new SQLiteParameter("pId", fattura.Id);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la cancellazione di una fattura.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool UpdateFattura(Fattura fattura)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "UPDATE [Fatture] SET " +
                      "[ClienteId] = @pClienteId, " +
                      "[Importo] = @pImporto, " +
                      "[Provvigione] = @pProvvigione, " +
                      "[Esito] = @pEsito, " +
                      "[UrlAllegato] = @pUrlAllegato " +
                      "WHERE [id] = @pId";
                
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", fattura.ClienteId);
                SQLiteParameter pImporto = new SQLiteParameter("pImporto", fattura.Importo);
                SQLiteParameter pProvvigione = new SQLiteParameter("pProvvigione", fattura.Provvigione);
                SQLiteParameter pEsito = new SQLiteParameter("pEsito", fattura.Esito);
                SQLiteParameter pUrlAllegato = new SQLiteParameter("pUrlAllegato", fattura.UrlAllegato);
                SQLiteParameter pId = new SQLiteParameter("pId", fattura.Id);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pImporto);
                cmd.Parameters.Add(pProvvigione);
                cmd.Parameters.Add(pEsito);
                cmd.Parameters.Add(pUrlAllegato);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la modifica della fattura.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

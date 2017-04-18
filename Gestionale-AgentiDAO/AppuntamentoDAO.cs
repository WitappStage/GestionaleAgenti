using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;

namespace Gestionale_AgentiDAO
{
    public class AppuntamentoDAO : BaseDAO
    {
        public static List<Appuntamento> GetListAppuntamenti(int agenteId) //FUNZIONE PER OTTENERE LA LISTA DI TUTTI GLI Appuntamenti CONTENUTI NEL DB
        {
            List<Appuntamento> retList = new List<Appuntamento>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.descrizione, cl.ragionesociale, o.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                      "FROM [Appuntamenti] o " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                      "JOIN [Agenti] ag ON (o.agenteid = ag.id) ";


                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Appuntamento tmpAppuntamento = new Appuntamento();
                        tmpAppuntamento.Id = dr.GetInt32(0);
                        tmpAppuntamento.Data = (dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1));
                        tmpAppuntamento.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpAppuntamento.Descrizione = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpAppuntamento.NominativoCliente = (dr.IsDBNull(4) ? string.Empty : dr.GetString(4));
                        tmpAppuntamento.AgenteId = (dr.IsDBNull(5) ? -1 : dr.GetInt32(5));
                        tmpAppuntamento.NominativoAgente = (dr.IsDBNull(6) ? string.Empty : dr.GetString(6));


                        retList.Add(tmpAppuntamento);
                    }
                }

                else
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.descrizione, cl.ragionesociale, o.agenteId " +
                      "FROM [Appuntamenti] o " +
                      "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                      "WHERE o.agenteId = @pAgenteId";

                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Appuntamento tmpAppuntamento = new Appuntamento();
                        tmpAppuntamento.Id = dr.GetInt32(0);
                        tmpAppuntamento.Data = (dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1));
                        tmpAppuntamento.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpAppuntamento.Descrizione = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpAppuntamento.NominativoCliente = (dr.IsDBNull(4) ? string.Empty : dr.GetString(4));
                        tmpAppuntamento.AgenteId = (dr.IsDBNull(5) ? -1 : dr.GetInt32(5));

                        retList.Add(tmpAppuntamento);
                    }
                }
                

                return retList;
            }
            catch (Exception ex)
            {

                throw new Exception("Errore durante l'ottenimento degli Appuntamenti", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static List<Appuntamento> GetListAppuntamenti(int agenteId, DateTime dataSel) //FUNZIONE PER OTTENERE LA LISTA DEGLI APPUNTAMENTI ALLA DATA SELEZIONATA
        {
            List<Appuntamento> retList = new List<Appuntamento>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    {
                        sql = "SELECT o.id, o.data, o.clienteid, o.descrizione, cl.ragionesociale, o.agenteId, ag.nome || ' ' || ag.cognome as nominAgente " +
                          "FROM [Appuntamenti] o " +
                          "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                          "JOIN [Agenti] ag ON (o.agenteid = ag.id) " +
                          "WHERE strftime('%d',o.data) like @pGiornoSel " +
                          "AND strftime('%m',o.data) like @pMeseSel " +
                          "AND strftime('%Y',o.data) like @pAnnoSel ";

                        SQLiteParameter pGiornoSel = null;
                        if (dataSel.Date.Day < 10)
                        {
                            pGiornoSel = new SQLiteParameter("pGiornoSel", "0" + dataSel.Date.Day.ToString());

                        }
                        else
                        {
                            pGiornoSel = new SQLiteParameter("pGiornoSel", dataSel.Date.Day.ToString());

                        }
                        SQLiteParameter pMeseSel = null;
                        if (dataSel.Date.Month < 10)
                        {
                            pMeseSel = new SQLiteParameter("pMeseSel", "0" + dataSel.Date.Month.ToString());
                        }                            
                        else
                        {
                            pMeseSel = new SQLiteParameter("pMeseSel", dataSel.Date.Month.ToString());
                        }  
                                                  
                        SQLiteParameter pAnnoSel = new SQLiteParameter("pAnnoSel", dataSel.Date.Year.ToString());

                        SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                        cmd.Parameters.Add(pGiornoSel);
                        cmd.Parameters.Add(pMeseSel);
                        cmd.Parameters.Add(pAnnoSel);

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Appuntamento tmpAppuntamento = new Appuntamento();
                            tmpAppuntamento.Id = dr.GetInt32(0);
                            tmpAppuntamento.Data = (dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1));
                            tmpAppuntamento.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                            tmpAppuntamento.Descrizione = (dr.IsDBNull(3) ? null : dr.GetString(3));
                            tmpAppuntamento.NominativoCliente = (dr.IsDBNull(4) ? string.Empty : dr.GetString(4));
                            tmpAppuntamento.AgenteId = (dr.IsDBNull(5) ? -1 : dr.GetInt32(5));
                            tmpAppuntamento.NominativoAgente = (dr.IsDBNull(6) ? null : dr.GetString(6));

                            retList.Add(tmpAppuntamento);
                        }
                    }
                }
                else
                {
                    sql = "SELECT o.id, o.data, o.clienteid, o.descrizione, cl.ragionesociale, o.agenteId " +
                     "FROM [Appuntamenti] o " +
                     "JOIN [Clienti] cl ON (o.clienteid = cl.id) " +
                     "WHERE o.agenteId = @pAgenteId " +
                     "AND strftime('%d',o.data) like @pGiornoSel " +
                     "AND strftime('%m',o.data) like @pMeseSel " +
                     "AND strftime('%Y',o.data) like @pAnnoSel ";

                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);

                    SQLiteParameter pGiornoSel = null;
                    if (dataSel.Date.Day < 10)
                    {
                        pGiornoSel = new SQLiteParameter("pGiornoSel", "0" + dataSel.Date.Day.ToString());

                    }
                    else
                    {
                        pGiornoSel = new SQLiteParameter("pGiornoSel", dataSel.Date.Day.ToString());

                    }

                    SQLiteParameter pMeseSel = null;
                    if (dataSel.Date.Month < 10)
                    {
                        pMeseSel = new SQLiteParameter("pMeseSel", "0" + dataSel.Date.Month.ToString());
                    }
                    else
                    {
                        pMeseSel = new SQLiteParameter("pMeseSel", dataSel.Date.Month.ToString());
                    }

                    SQLiteParameter pAnnoSel = new SQLiteParameter("pAnnoSel", dataSel.Date.Year);

                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                    cmd.Parameters.Add(pAgenteId);
                    cmd.Parameters.Add(pGiornoSel);
                    cmd.Parameters.Add(pMeseSel);
                    cmd.Parameters.Add(pAnnoSel);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Appuntamento tmpAppuntamento = new Appuntamento();
                        tmpAppuntamento.Id = dr.GetInt32(0);
                        tmpAppuntamento.Data = (dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1));
                        tmpAppuntamento.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                        tmpAppuntamento.Descrizione = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpAppuntamento.NominativoCliente = (dr.IsDBNull(4) ? string.Empty : dr.GetString(4));
                        tmpAppuntamento.AgenteId = (dr.IsDBNull(5) ? -1 : dr.GetInt32(5));

                        retList.Add(tmpAppuntamento);
                    }
                }

                return retList;
            }
            catch (Exception ex)
            {

                throw new Exception("Errore durante l'ottenimento degli Appuntamenti", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Appuntamento GetAppuntamento(int idAppuntamento) //FUNZIONE PER OTTENERE UN SINGOLO Appuntamento (UTILE IN CASO DI RICHIESTA DI MODIFICHE)
        {
            Appuntamento tmpAppuntamento = new Appuntamento();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                sql = "SELECT [id], [data], [clienteid], [descrizione], [agenteId] FROM [Appuntamenti] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idAppuntamento);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpAppuntamento.Id = dr.GetInt32(0);
                    tmpAppuntamento.Data = (dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1));
                    tmpAppuntamento.ClienteId = (dr.IsDBNull(2) ? -1 : dr.GetInt32(2));
                    tmpAppuntamento.Descrizione = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpAppuntamento.AgenteId = (dr.IsDBNull(4) ? -1 : dr.GetInt32(4));

                    return tmpAppuntamento;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento dell'Appuntamento", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static bool InsertAppuntamento(Appuntamento Appuntamento) //FUNZIONE DI INSERIMENTO DI UN Appuntamento NEL DB
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "INSERT into [Appuntamenti]([data],[clienteid],[descrizione],[agenteId]) " +
                      "VALUES (@pData,@pClienteId,@pDescrizione,@pAgenteId)";
                    SQLiteParameter pData = new SQLiteParameter("pData", Appuntamento.Data);
                    SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", Appuntamento.ClienteId);
                    SQLiteParameter pDescrizione = new SQLiteParameter("pDescrizione", Appuntamento.Descrizione);
                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", Appuntamento.AgenteId);


                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                    cmd.Parameters.Add(pData);
                    cmd.Parameters.Add(pClienteId);
                    cmd.Parameters.Add(pDescrizione);
                    cmd.Parameters.Add(pAgenteId);

                    cmd.ExecuteNonQuery();             

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'inserimento dell'Appuntamento", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteAppuntamento(Appuntamento appuntamento)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Appuntamenti] WHERE [id] = @pId";

                SQLiteParameter pId = new SQLiteParameter("pId", appuntamento.Id);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la cancellazione di un appuntamento.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool UpdateAppuntamento (Appuntamento appuntamento)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "UPDATE [Appuntamenti] SET " +
                      "[Data] = @pData, " +
                      "[ClienteId] = @pClienteId, " +
                      "[Descrizione] = @pDescrizione, " +
                      "[AgenteId] = @pAgenteId " +
                      "WHERE [id] = @pId";

                SQLiteParameter pData = new SQLiteParameter("pData", appuntamento.Data);
                SQLiteParameter pClienteId = new SQLiteParameter("pClienteId", appuntamento.ClienteId);
                SQLiteParameter pDescrizione = new SQLiteParameter("pDescrizione", appuntamento.Descrizione);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", appuntamento.AgenteId);
                SQLiteParameter pId = new SQLiteParameter("pId", appuntamento.Id);


                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pData);
                cmd.Parameters.Add(pClienteId);
                cmd.Parameters.Add(pDescrizione);
                cmd.Parameters.Add(pAgenteId);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la modifica dell'appuntamento.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}


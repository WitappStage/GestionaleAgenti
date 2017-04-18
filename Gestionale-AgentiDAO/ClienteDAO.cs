using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaGestionaleAgente;
using System.Data.SQLite;


namespace Gestionale_AgentiDAO
{
    public class ClienteDAO : BaseDAO
    {
        public static List<Cliente> GetListClienti(int agenteId)
        {
            List<Cliente> retList = new List<Cliente>();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;
            try
            {
                if (agenteId == 1)
                {
                    sql = "SELECT cl.[id], cl.[RagioneSociale], cl.[SedeLegale], cl.[PartitaIva], cl.[CodiceFiscale], cl.[Email], cl.[Pec], cl.[Telefono], cl.[Referente], cl.[RefTelefono], cl.[RefEmail], cl.[AgenteId], (ag.nome || ' ' || ag.cognome) as nominAgente  " +
                      "FROM [Clienti] cl " +
                      "JOIN [Agenti] ag ON (cl.agenteid = ag.id)";

                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Cliente tmpCliente = new Cliente();
                        tmpCliente.Id = dr.GetInt32(0);
                        tmpCliente.RagioneSociale = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpCliente.SedeLegale = (dr.IsDBNull(2) ? null : dr.GetString(2));
                        tmpCliente.PartitaIva = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpCliente.CodiceFiscale = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpCliente.Email = (dr.IsDBNull(5) ? null : dr.GetString(5));
                        tmpCliente.Pec = (dr.IsDBNull(6) ? null : dr.GetString(6));
                        tmpCliente.Telefono = (dr.IsDBNull(7) ? null : dr.GetString(7));
                        tmpCliente.Referente = (dr.IsDBNull(8) ? null : dr.GetString(8));
                        tmpCliente.RefTelefono = (dr.IsDBNull(9) ? null : dr.GetString(9));
                        tmpCliente.RefEmail = (dr.IsDBNull(10) ? null : dr.GetString(10));
                        tmpCliente.AgenteId = (dr.IsDBNull(11) ? -1 : dr.GetInt32(11));
                        tmpCliente.NominativoAgente = (dr.IsDBNull(12) ? null : dr.GetString(12));

                        retList.Add(tmpCliente);
                    }
                }

                else
                {
                    sql = "SELECT [id], [RagioneSociale], [SedeLegale], [PartitaIva], [CodiceFiscale], [Email], [Pec], [Telefono], [Referente], [RefTelefono], [RefEmail], [AgenteId] " +
                      "FROM [Clienti] " +
                      "WHERE AgenteId = @pAgenteId";
                    SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", agenteId);
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(pAgenteId);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Cliente tmpCliente = new Cliente();
                        tmpCliente.Id = dr.GetInt32(0);
                        tmpCliente.RagioneSociale = (dr.IsDBNull(1) ? null : dr.GetString(1));
                        tmpCliente.SedeLegale = (dr.IsDBNull(2) ? null : dr.GetString(2));
                        tmpCliente.PartitaIva = (dr.IsDBNull(3) ? null : dr.GetString(3));
                        tmpCliente.CodiceFiscale = (dr.IsDBNull(4) ? null : dr.GetString(4));
                        tmpCliente.Email = (dr.IsDBNull(5) ? null : dr.GetString(5));
                        tmpCliente.Pec = (dr.IsDBNull(6) ? null : dr.GetString(6));
                        tmpCliente.Telefono = (dr.IsDBNull(7) ? null : dr.GetString(7));
                        tmpCliente.Referente = (dr.IsDBNull(8) ? null : dr.GetString(8));
                        tmpCliente.RefTelefono = (dr.IsDBNull(9) ? null : dr.GetString(9));
                        tmpCliente.RefEmail = (dr.IsDBNull(10) ? null : dr.GetString(10));
                        tmpCliente.AgenteId = (dr.IsDBNull(11) ? -1 : dr.GetInt32(11));

                        retList.Add(tmpCliente);
                    }
                }
                

                return retList;
            }
            catch (Exception ex)
            {

                throw new Exception ("Errore durante l'ottenimento dei Clienti", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static Cliente GetCliente(int idCliente)
        {
            Cliente tmpCliente = new Cliente();
            string sql = "";
            SQLiteConnection cn = GetConnection();
            SQLiteDataReader dr = null;

            try
            {
                sql = "SELECT [id], [RagioneSociale], [SedeLegale], [PartitaIva], [CodiceFiscale], [Email], [Pec], [Telefono], [Referente], [RefTelefono], [RefEmail], [agenteId] FROM [Clienti] WHERE [Id]=@pId";
                SQLiteParameter pId = new SQLiteParameter("pId", idCliente);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(pId);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tmpCliente.Id = dr.GetInt32(0);
                    tmpCliente.RagioneSociale = (dr.IsDBNull(1) ? null : dr.GetString(1));
                    tmpCliente.SedeLegale = (dr.IsDBNull(2) ? null : dr.GetString(2));
                    tmpCliente.PartitaIva = (dr.IsDBNull(3) ? null : dr.GetString(3));
                    tmpCliente.CodiceFiscale = (dr.IsDBNull(4) ? null : dr.GetString(4));
                    tmpCliente.Email = (dr.IsDBNull(5) ? null : dr.GetString(5));
                    tmpCliente.Pec = (dr.IsDBNull(6) ? null : dr.GetString(6));
                    tmpCliente.Telefono = (dr.IsDBNull(7) ? null : dr.GetString(7));
                    tmpCliente.Referente = (dr.IsDBNull(8) ? null : dr.GetString(8));
                    tmpCliente.RefTelefono = (dr.IsDBNull(9) ? null : dr.GetString(9));
                    tmpCliente.RefEmail = (dr.IsDBNull(10) ? null : dr.GetString(10));
                    tmpCliente.AgenteId = (dr.IsDBNull(11) ? -1 : dr.GetInt32(11));

                    return tmpCliente;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'ottenimento del cliente", ex);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        public static bool InsertCliente(Cliente cliente)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "INSERT into [Clienti]([RagioneSociale],[SedeLegale],[PartitaIva],[CodiceFiscale],[Email],[Pec],[Telefono],[Referente],[RefTelefono],[RefEmail],[AgenteId]) " +
                      "VALUES (@pRagioneSociale,@pSedeLegale,@pPartitaIva,@pCodiceFiscale,@pEmail,@pPec,@pTelefono,@pReferente,@pRefTelefono,@pRefEmail,@pAgenteId)";

                SQLiteParameter pRagioneSociale = new SQLiteParameter("pRagioneSociale", cliente.RagioneSociale);
                SQLiteParameter pSedeLegale = new SQLiteParameter("pSedeLegale", cliente.SedeLegale);
                SQLiteParameter pPartitaIva = new SQLiteParameter("pPartitaIva", cliente.PartitaIva);
                SQLiteParameter pCodiceFiscale = new SQLiteParameter("pCodiceFiscale", cliente.CodiceFiscale);
                SQLiteParameter pEmail = new SQLiteParameter("pEmail", cliente.Email);
                SQLiteParameter pPec = new SQLiteParameter("pPec", cliente.Pec);
                SQLiteParameter pTelefono = new SQLiteParameter("pTelefono", cliente.Telefono);
                SQLiteParameter pReferente = new SQLiteParameter("pReferente", cliente.Referente);
                SQLiteParameter pRefTelefono = new SQLiteParameter("pRefTelefono", cliente.RefTelefono);
                SQLiteParameter pRefEmail = new SQLiteParameter("pRefEmail", cliente.RefEmail);
                SQLiteParameter pAgenteId = new SQLiteParameter("pAgenteId", cliente.AgenteId);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                cmd.Parameters.Add(pRagioneSociale);
                cmd.Parameters.Add(pSedeLegale);
                cmd.Parameters.Add(pPartitaIva);
                cmd.Parameters.Add(pCodiceFiscale);
                cmd.Parameters.Add(pEmail);
                cmd.Parameters.Add(pPec);
                cmd.Parameters.Add(pTelefono);
                cmd.Parameters.Add(pReferente);
                cmd.Parameters.Add(pRefTelefono);
                cmd.Parameters.Add(pRefEmail);
                cmd.Parameters.Add(pAgenteId);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'inserimento del cliente", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool UpdateCliente(Cliente cliente)
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "UPDATE [Clienti] Set [RagioneSociale]=@pRagioneSociale, [SedeLegale]=@pSedeLegale ,[PartitaIva]=@pPartitaIva,[CodiceFiscale]=@pCodiceFiscale,[Email]=@pEmail,[Pec]=@pPec,[Telefono]=@pTelefono,[Referente]=@pReferente,[RefTelefono]=@pRefTelefono,[RefEmail]=@pRefEmail " +
                             "WHERE [Id]=@pId";

                SQLiteParameter pRagioneSociale = new SQLiteParameter("pRagioneSociale", cliente.RagioneSociale);
                SQLiteParameter pSedeLegale = new SQLiteParameter("pSedeLegale", cliente.SedeLegale);
                SQLiteParameter pPartitaIva = new SQLiteParameter("pPartitaIva", cliente.PartitaIva);
                SQLiteParameter pCodiceFiscale = new SQLiteParameter("pCodiceFiscale", cliente.CodiceFiscale);
                SQLiteParameter pEmail = new SQLiteParameter("pEmail", cliente.Email);
                SQLiteParameter pPec = new SQLiteParameter("pPec", cliente.Pec);
                SQLiteParameter pTelefono = new SQLiteParameter("pTelefono", cliente.Telefono);
                SQLiteParameter pReferente = new SQLiteParameter("pReferente", cliente.Referente);
                SQLiteParameter pRefTelefono = new SQLiteParameter("pRefTelefono", cliente.RefTelefono);
                SQLiteParameter pRefEmail = new SQLiteParameter("pRefEmail", cliente.RefEmail);
                SQLiteParameter pId = new SQLiteParameter("pId", cliente.Id);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                cmd.Parameters.Add(pRagioneSociale);
                cmd.Parameters.Add(pSedeLegale);
                cmd.Parameters.Add(pPartitaIva);
                cmd.Parameters.Add(pCodiceFiscale);
                cmd.Parameters.Add(pEmail);
                cmd.Parameters.Add(pPec);
                cmd.Parameters.Add(pTelefono);
                cmd.Parameters.Add(pReferente);
                cmd.Parameters.Add(pRefTelefono);
                cmd.Parameters.Add(pRefEmail);
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con l'aggiornamento del Cliente", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public static bool DeleteCliente(int idCliente)          
        {
            string sql = "";
            SQLiteConnection cn = GetConnection();
            try
            {
                sql = "DELETE FROM [Clienti] WHERE [Id]=@pId";
                
                SQLiteParameter pId = new SQLiteParameter("pId", idCliente);
                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                
                cmd.Parameters.Add(pId);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore con la cancellazione del Cliente, controlla che non sia presente in nessuna offerta, contratto, ecc.", ex);
            }
            finally
            {
                cn.Close();
            }
        } 
    }
}

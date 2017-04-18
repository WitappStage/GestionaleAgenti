using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Contratto
    {
        int id;
        string data;
        int clienteId;
        string nominativoCliente;
        string esito;
        string note;
        decimal importo;
        decimal mensile;
        string urlAllegato;
        int agenteId;
        string nominativoAgente;

        public Contratto(int id, string data, int clienteId, string nominativoCliente, string esito, string note, decimal importo, decimal mensile, string urlAllegato, int agenteId)
        {
            this.id = id;
            this.data = data;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.esito = esito;
            this.note = note;
            this.importo = importo;
            this.mensile = mensile;
            this.urlAllegato = urlAllegato;
            this.agenteId = agenteId;
            this.nominativoAgente = null;
        }

        public Contratto(int id)
        {
            this.id = id;
            this.data = null;
            this.clienteId = -1;
            this.nominativoCliente = null;
            this.esito = null;
            this.note = null;
            this.importo = -1;
            this.mensile = -1;
            this.urlAllegato = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Contratto()
        {
            this.id = -1;
            this.data = null;
            this.clienteId = -1;
            this.nominativoCliente = null;
            this.esito = null;
            this.note = null;
            this.importo = -1;
            this.mensile = -1;
            this.urlAllegato = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Contratto(int id, string data, int clienteId, string nominativoCliente, string esito, string note, decimal importo, decimal mensile, string urlAllegato, int agenteId, string nominativoAgente)
        {
            this.id = id;
            this.data = data;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.esito = esito;
            this.note = note;
            this.importo = importo;
            this.mensile = mensile;
            this.urlAllegato = urlAllegato;
            this.agenteId = agenteId;
            this.nominativoAgente = nominativoAgente;
        }

        // costruttore senza importo e mensile
        public Contratto(int id, string data, int clienteId, string nominativoCliente, string esito, string note, string urlAllegato, int agenteId)
        {
            this.id = id;
            this.data = data;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.esito = esito;
            this.note = note;
            this.urlAllegato = urlAllegato;
            this.agenteId = agenteId;
            this.nominativoAgente = null;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public int ClienteId
        {
            get
            {
                return clienteId;
            }

            set
            {
                clienteId = value;
            }
        }        

        public string NominativoCliente
        {
            get
            {
                return nominativoCliente;
            }

            set
            {
                nominativoCliente = value;
            }
        }

        public string Esito
        {
            get
            {
                return esito;
            }

            set
            {
                esito = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public decimal Importo
        {
            get
            {
                return importo;
            }

            set
            {
                importo = value;
            }
        }

        public decimal Mensile
        {
            get
            {
                return mensile;
            }

            set
            {
                mensile = value;
            }
        }

        public string UrlAllegato
        {
            get
            {
                return urlAllegato;
            }

            set
            {
                urlAllegato = value;
            }
        }

        public int AgenteId
        {
            get
            {
                return agenteId;
            }

            set
            {
                agenteId = value;
            }
        }

        public string NominativoAgente
        {
            get
            {
                return nominativoAgente;
            }

            set
            {
                nominativoAgente = value;
            }
        }
    }
}


        
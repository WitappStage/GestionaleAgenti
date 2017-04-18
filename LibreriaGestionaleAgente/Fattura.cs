using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Fattura
    {
        int id;
        int clienteId;
        string nominativoCliente;
        decimal importo;
        string provvigione;
        string esito;
        string urlAllegato;
        int agenteId;
        string nominativoAgente;

        public Fattura(int id, int clienteId, string nominativoCliente, decimal importo, string provvigione, string esito, string urlAllegato, int agenteId)
        {
            this.id = id;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.importo = importo;
            this.provvigione = provvigione;
            this.esito = esito;
            this.urlAllegato = urlAllegato;
            this.agenteId = agenteId;
            this.nominativoAgente = null;
        }

        public Fattura(int id)
        {
            this.id = id;
            this.clienteId = -1;
            this.nominativoCliente = null;
            this.importo = -1;
            this.provvigione = null;
            this.esito = null;
            this.urlAllegato = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Fattura()
        {
            this.id = -1;
            this.clienteId = -1;
            this.nominativoCliente = null;
            this.importo = -1;
            this.provvigione = null;
            this.esito = null;
            this.urlAllegato = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Fattura(int id, int clienteId, string nominativoCliente, decimal importo, string provvigione, string esito, string urlAllegato, int agenteId, string nominativoAgente)
        {
            this.id = id;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.importo = importo;
            this.provvigione = provvigione;
            this.esito = esito;
            this.urlAllegato = urlAllegato;
            this.agenteId = agenteId;
            this.nominativoAgente = nominativoAgente;
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

        public string Provvigione
        {
            get
            {
                return provvigione;
            }

            set
            {
                provvigione = value;
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

        
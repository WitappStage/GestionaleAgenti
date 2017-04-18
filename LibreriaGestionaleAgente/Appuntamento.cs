using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Appuntamento
    {
        int id;
        DateTime data;
        int clienteId;
        string nominativoCliente;
        string descrizione;
        int agenteId;
        string nominativoAgente;

        public Appuntamento(int id, DateTime data, int clienteId, string nominativoCliente, string descrizione, int agenteId)
        {
            this.id = id;
            this.data = data;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.descrizione = descrizione;
            this.agenteId = agenteId;
            this.nominativoAgente = null;
        }

        public Appuntamento(int id)
        {
            this.id = id;
            this.data = DateTime.MinValue;
            this.clienteId = -1;
            this.nominativoCliente = null;
            this.descrizione = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Appuntamento()
        {
            this.id = -1;
            this.data = DateTime.MinValue;
            this.clienteId = -1;
            this.nominativoCliente = null;
            this.descrizione = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Appuntamento(int id, DateTime data, int clienteId, string nominativoCliente, string descrizione, int agenteId, string nominativoAgente)
        {
            this.id = id;
            this.data = data;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.descrizione = descrizione;
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

        public DateTime Data
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

        public string Descrizione
        {
            get
            {
                return descrizione;
            }

            set
            {
                descrizione = value;
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

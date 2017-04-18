using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Richiesta
    {
        int id;
        string data;
        int clienteId;
        string nominativoCliente;
        string settore;
        string note;
        int agenteId;
        string nominativoAgente;

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

        public string Settore
        {
            get
            {
                return settore;
            }

            set
            {
                settore = value;
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

        public Richiesta(int id, string data, int clienteId, string nominativoCliente, string settore, string note, int agenteId, string nominativoAgente)
        {
            this.Id = id;
            this.Data = data;
            this.ClienteId = clienteId;
            this.NominativoCliente = nominativoCliente;
            this.Settore = settore;
            this.Note = note;
            this.AgenteId = agenteId;
            this.NominativoAgente = nominativoAgente;
        }

        public Richiesta(int id, string data, int clienteId, string nominativoCliente, string settore, string note, int agenteId)
        {
            this.Id = id;
            this.Data = data;
            this.ClienteId = clienteId;
            this.NominativoCliente = nominativoCliente;
            this.Settore = settore;
            this.Note = note;
            this.AgenteId = agenteId;
            this.NominativoAgente = null;
        }

        public Richiesta(int id)
        {
            this.Id = id;
            this.Data = null;
            this.ClienteId = -1;
            this.NominativoCliente = null;
            this.Settore = null;
            this.Note = null;
            this.AgenteId = -1;
            this.NominativoAgente = null;
        }

        public Richiesta()
        {
            this.Id = -1;
            this.Data = null;
            this.ClienteId = -1;
            this.NominativoCliente = null;
            this.Settore = null;
            this.Note = null;
            this.AgenteId = -1;
            this.NominativoAgente = null;
        }
    }
}

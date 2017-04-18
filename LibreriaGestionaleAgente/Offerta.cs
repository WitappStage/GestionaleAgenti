using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Offerta
    {
        int id;
        string data;
        int clienteId;
        string nominativoCliente;
        string note;
        decimal importo;
        decimal mensile;
        string urlAllegato;
        int agenteId;
        string nominativoAgente;


        /*INCAPSULAMENTO PROPRIETA' */

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

        /*COSTRUTTORE */

        public Offerta()
        {
            this.Id = -1;
            this.Data = null;
            this.ClienteId = -1;
            this.NominativoCliente = null;
            this.Note = null;
            this.Importo = -1;
            this.Mensile = -1;
            this.UrlAllegato = null;
            this.AgenteId = -1;
            this.nominativoAgente = null;

        }

        public Offerta(int id)
        {
            this.Id = id;
            this.Data = null;
            this.ClienteId = -1;
            this.NominativoCliente = null;
            this.Note = null;
            this.Importo = -1;
            this.Mensile = -1;
            this.UrlAllegato = null;
            this.AgenteId = -1;
            this.nominativoAgente = null;
        }

        public Offerta(int id, string data, int clienteId, string nominativoCliente, string note, decimal importo, decimal mensile, string urlAllegato, int agenteId)
        {
            this.Id = id;
            this.Data = data;
            this.ClienteId = clienteId;
            this.NominativoCliente = nominativoCliente;
            this.Note = note;
            this.Importo = importo;
            this.Mensile = mensile;
            this.UrlAllegato = urlAllegato;
            this.AgenteId = agenteId;
            this.nominativoAgente = null;
        }

        public Offerta(int id, string data, int clienteId, string nominativoCliente, string note, decimal importo, decimal mensile, string urlAllegato, int agenteId, string nominativoAgente)
        {
            this.id = id;
            this.data = data;
            this.clienteId = clienteId;
            this.nominativoCliente = nominativoCliente;
            this.note = note;
            this.importo = importo;
            this.mensile = Mensile;
            this.urlAllegato = urlAllegato;
            this.agenteId = agenteId;
            this.nominativoAgente = nominativoAgente;
        }
    }
}

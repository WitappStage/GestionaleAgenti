using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Allegato
    {
        int id;
        string url;
        string titolo;
        int agenteId;
        string nominativoAgente;

        public Allegato(int id, string url, string titolo, int agenteId, string nominativoAgente)
        {
            this.id = id;
            this.url = url;
            this.titolo = titolo;
            this.agenteId = agenteId;
            this.nominativoAgente = nominativoAgente;
        }

        public Allegato(int id, string url, string titolo, int agenteId)
        {
            this.id = id;
            this.url = url;
            this.titolo = titolo;
            this.agenteId = agenteId;
            this.nominativoAgente = null;
        }

        public Allegato(int id)
        {
            this.id = id;
            this.url = null;
            this.titolo = null;
            this.agenteId = -1;
            this.nominativoAgente = null;
        }

        public Allegato()
        {
            this.id = -1;
            this.url = null;
            this.titolo = null;
            this.agenteId = -1;
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

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Titolo
        {
            get
            {
                return titolo;
            }

            set
            {
                titolo = value;
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

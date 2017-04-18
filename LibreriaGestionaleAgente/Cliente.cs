using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Cliente
    {
        int id;
        string ragioneSociale;
        string sedeLegale;
        string partitaIva;
        string codiceFiscale;
        string email;
        string pec;
        string telefono;
        string referente;
        string refTelefono;
        string refEmail;
        int agenteId;
        string nominativoAgente;

        /* COSTRUTTORE */

        public Cliente(int id, string ragioneSociale, string sedeLegale, string partitaIva, string codiceFiscale, string email, string pec, string telefono, string referente, string refTelefono, string refEmail, int agenteId)
        {
            this.id = id;
            this.ragioneSociale = ragioneSociale;
            this.sedeLegale = sedeLegale;
            this.partitaIva = partitaIva;
            this.codiceFiscale = codiceFiscale;
            this.email = email;
            this.pec = pec;
            this.telefono = telefono;
            this.referente = referente;
            this.refTelefono = refTelefono;
            this.refEmail = refEmail;
            this.AgenteId = agenteId;
            this.nominativoAgente = null;
        }

        public Cliente()
        {
            this.id = -1;
            this.ragioneSociale = null;
            this.sedeLegale = null;
            this.partitaIva = null;
            this.codiceFiscale = null;
            this.email = null;
            this.pec = null;
            this.telefono = null;
            this.referente = null;
            this.refTelefono = null;
            this.refEmail = null;
            this.AgenteId = -1;
            this.nominativoAgente = null;
        }

        public Cliente(int id)
        {
            this.id = id;
            this.ragioneSociale = null;
            this.sedeLegale = null;
            this.partitaIva = null;
            this.codiceFiscale = null;
            this.email = null;
            this.pec = null;
            this.telefono = null;
            this.referente = null;
            this.refTelefono = null;
            this.refEmail = null;
            this.AgenteId = -1;
            this.nominativoAgente = null;
        }

        public Cliente(int id, string ragioneSociale, string sedeLegale, string partitaIva, string codiceFiscale, string email, string pec, string telefono, string referente, string refTelefono, string refEmail, int agenteId, string nominativoAgente)
        {
            this.id = id;
            this.ragioneSociale = ragioneSociale;
            this.sedeLegale = sedeLegale;
            this.partitaIva = partitaIva;
            this.codiceFiscale = codiceFiscale;
            this.email = email;
            this.pec = pec;
            this.telefono = telefono;
            this.referente = referente;
            this.refTelefono = refTelefono;
            this.refEmail = refEmail;
            this.agenteId = agenteId;
            this.nominativoAgente = nominativoAgente;
        }


        /* INCAPSULAMENTO PROPRIETA'*/
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

        public string RagioneSociale
        {
            get
            {
                return ragioneSociale;
            }

            set
            {
                ragioneSociale = value;
            }
        }

        public string SedeLegale
        {
            get
            {
                return sedeLegale;
            }

            set
            {
                sedeLegale = value;
            }
        }

        public string PartitaIva
        {
            get
            {
                return partitaIva;
            }

            set
            {
                partitaIva = value;
            }
        }

        public string CodiceFiscale
        {
            get
            {
                return codiceFiscale;
            }

            set
            {
                codiceFiscale = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Pec
        {
            get
            {
                return pec;
            }

            set
            {
                pec = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Referente
        {
            get
            {
                return referente;
            }

            set
            {
                referente = value;
            }
        }

        public string RefTelefono
        {
            get
            {
                return refTelefono;
            }

            set
            {
                refTelefono = value;
            }
        }

        public string RefEmail
        {
            get
            {
                return refEmail;
            }

            set
            {
                refEmail = value;
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

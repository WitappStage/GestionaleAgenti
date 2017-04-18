using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    public class Agente
    {
        public static int idSessione;
        int id;
        string nome;
        string cognome;
        string email;
        string password;

        public Agente(int id, string nome, string cognome, string email, string password)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.email = email;
            this.password = password;
        }

        public Agente()
        {
            this.id = -1;
            this.nome = null;
            this.cognome = null;
            this.email = null;
            this.password = null;
        }

        public int IdSessione
        {
            get
            {
                return idSessione;
            }

            set
            {
                idSessione = value;
            }
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

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Cognome
        {
            get
            {
                return cognome;
            }

            set
            {
                cognome = value;
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

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}

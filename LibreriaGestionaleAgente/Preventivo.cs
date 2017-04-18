using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaGestionaleAgente
{
    class Preventivo
    {
        public static decimal tmpPreventivo;
        public static decimal tmpMensile;

        public decimal TmpPreventivo
        {
            get
            {
                return tmpPreventivo;
            }

            set
            {
                tmpPreventivo = value;
            }
        }

        public decimal TmpMensile
        {
            get
            {
                return tmpMensile;
            }

            set
            {
                tmpMensile = value;
            }
        }
    }
}

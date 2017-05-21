using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    class Gastos
    {
        private string identificacion;
        private string nombre;
        private string tipoReparto;

        public string Identificacion
        {
            get
            {
                return identificacion;
            }

            set
            {
                identificacion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string TipoReparto
        {
            get
            {
                return tipoReparto;
            }

            set
            {
                tipoReparto = value;
            }
        }
    }
}

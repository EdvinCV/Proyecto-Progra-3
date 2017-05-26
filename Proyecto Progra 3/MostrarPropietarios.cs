using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    class MostrarPropietarios : Propietarios
    {
        private List<string> propiedades;

        public List<string> Propiedades
        {
            get
            {
                return propiedades;
            }

            set
            {
                propiedades = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    class Propiedades
    {
        private string tipo;
        private string codPropiedad;
        private int metrosCuadrados;
        private string codPropietario;
        List<string> listaGastos;

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string CodPropiedad
        {
            get
            {
                return codPropiedad;
            }

            set
            {
                codPropiedad = value;
            }
        }

        public int MetrosCuadrados
        {
            get
            {
                return metrosCuadrados;
            }

            set
            {
                metrosCuadrados = value;
            }
        }

        public List<string> ListaGastos
        {
            get
            {
                return listaGastos;
            }

            set
            {
                listaGastos = value;
            }
        }

        public string CodPropietario
        {
            get
            {
                return codPropietario;
            }

            set
            {
                codPropietario = value;
            }
        }
    }
}

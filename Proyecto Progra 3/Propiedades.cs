using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{ 
    //ESTA CLASE PADRE SE UTILIZA PARA GUARDAR LOS DATOS DE LAS PROPIEDADES EN GENERAL
    class Propiedades
    {
        private string codPropiedad;
        private int metrosCuadrados;
        private string codPropietario;
        private string NombrePropietario;
        private List<string> listaGastos;
        private string tipo;

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

        public string NombrePropietario1
        {
            get
            {
                return NombrePropietario;
            }

            set
            {
                NombrePropietario = value;
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
    }
}

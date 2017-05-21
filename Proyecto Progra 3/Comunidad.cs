using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    class Comunidad
    {
        private string identificacion;
        private string nombre;
        private string poblacion;
        private int numZonas;
        private int numPropietarios;
        private int totalGastos;

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

        public string Poblacion
        {
            get
            {
                return poblacion;
            }

            set
            {
                poblacion = value;
            }
        }

        public int NumZonas
        {
            get
            {
                return numZonas;
            }

            set
            {
                numZonas = value;
            }
        }

        public int NumPropietarios
        {
            get
            {
                return numPropietarios;
            }

            set
            {
                numPropietarios = value;
            }
        }

        public int TotalGastos
        {
            get
            {
                return totalGastos;
            }

            set
            {
                totalGastos = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    //ESTA CLASE HIJA SE UTLIZA PARA GUARDAR DATOS DE VIVIENDAS
    class PPropiedades : Propiedades
    {
        private string tipoVivienda;
        private int numDormitorios;

        public string TipoVivienda
        {
            get
            {
                return tipoVivienda;
            }

            set
            {
                tipoVivienda = value;
            }
        }

        public int NumDormitorios
        {
            get
            {
                return numDormitorios;
            }

            set
            {
                numDormitorios = value;
            }
        }
    }
}

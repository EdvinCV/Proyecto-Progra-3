using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    class GastosGenerados 
    {
        private string identificacion;
        private string descripcion;
        private int importe;
        private int tipoDeZona;

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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }

        public int TipoDeZona
        {
            get
            {
                return tipoDeZona;
            }

            set
            {
                tipoDeZona = value;
            }
        }
    }
}

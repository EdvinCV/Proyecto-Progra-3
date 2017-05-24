using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    //ESTA CLASE SE UTILIZA PARA GUARDAR LOS DATOS DE LOS GASTOS GENERADOS POR LA COMUNIDAD
    class GastosGenerados 
    {
        private string identificacion;
        private string descripcion;
        private int importe;
        private string tipoDeZona;

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

        public string TipoDeZona
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

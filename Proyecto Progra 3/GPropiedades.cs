using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    //ESTA CLASE HIJA SE UTILIZA PARA GUARDAR DATOS DE PROPIEDADES DE TIPO GARAGE 
    class GPropiedades : Propiedades
    {
        string abiertaCerrada;
        string bodega;

        public string AbiertaCerrada
        {
            get
            {
                return abiertaCerrada;
            }

            set
            {
                abiertaCerrada = value;
            }
        }

        public string Bodega
        {
            get
            {
                return bodega;
            }

            set
            {
                bodega = value;
            }
        }
    }
}

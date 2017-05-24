using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Progra_3
{
    //ESTA CLASE HIJA SE UTILIZA PARA GUARDAR DATOS ADICIONALES DE LOS LOCALES 
    class LPropiedades : Propiedades
    {
        string nombreComercial;
        string actividad;

        public string NombreComercial
        {
            get
            {
                return nombreComercial;
            }

            set
            {
                nombreComercial = value;
            }
        }

        public string Actividad
        {
            get
            {
                return actividad;
            }

            set
            {
                actividad = value;
            }
        }
    }
}

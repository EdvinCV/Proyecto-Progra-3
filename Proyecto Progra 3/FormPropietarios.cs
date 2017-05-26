using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Progra_3
{
    public partial class FormPropietarios : Form
    {
        List<PPropiedades> pisos = new List<PPropiedades>();
        List<GPropiedades> garajes = new List<GPropiedades>();
        List<LPropiedades> locales = new List<LPropiedades>();
        List<Propietarios> misPropietarios = new List<Propietarios>();
        List<MostrarPropietarios> mostrarPropietarios = new List<MostrarPropietarios>();
        public FormPropietarios()
        {
            InitializeComponent();
            //LEER ARCHIVO DE PROPIEDADES -----------------------------------------------------------------------------
            string nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Propiedades.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            Propiedades propiedadTemp = new Propiedades();
            PPropiedades pisoTemp = new PPropiedades();
            LPropiedades localTemp = new LPropiedades();
            GPropiedades garajeTemp = new GPropiedades();
            string tipo;
            while (reader.Peek() > -1)
            {
                tipo = reader.ReadLine();
                if (tipo == "P")
                {
                    pisoTemp.Tipo = tipo;
                    pisoTemp.CodPropiedad = reader.ReadLine();
                    pisoTemp.MetrosCuadrados = Convert.ToInt32(reader.ReadLine());
                    pisoTemp.CodPropietario = reader.ReadLine();
                    string h = reader.ReadLine();
                    while (h != "---")
                    {
                        pisoTemp.ListaGastos = new List<string>();
                        pisoTemp.ListaGastos.Add(h);
                        h = reader.ReadLine();
                    }
                    h = reader.ReadLine();
                    if (h == "VH")
                        pisoTemp.TipoVivienda = "Habitual";
                    else if (h == "VN")
                        pisoTemp.TipoVivienda = "No habitual";
                    pisoTemp.NumDormitorios = Convert.ToInt32(reader.ReadLine());
                    pisos.Add(pisoTemp);
                }
                else if (tipo == "L")
                {
                    localTemp.CodPropiedad = reader.ReadLine();
                    localTemp.MetrosCuadrados = Convert.ToInt32(reader.ReadLine());
                    localTemp.CodPropietario = reader.ReadLine();
                    string h = reader.ReadLine();
                    while (h != "---")
                    {
                        localTemp.ListaGastos = new List<string>();
                        localTemp.ListaGastos.Add(h);
                        h = reader.ReadLine();
                    }
                    localTemp.NombreComercial = reader.ReadLine();
                    localTemp.Actividad = reader.ReadLine();
                    locales.Add(localTemp);
                }
                else if (tipo == "G")
                {
                    garajeTemp.CodPropiedad = reader.ReadLine();
                    garajeTemp.MetrosCuadrados = Convert.ToInt32(reader.ReadLine());
                    garajeTemp.CodPropietario = reader.ReadLine();
                    string h = reader.ReadLine();
                    while (h != "---")
                    {
                        garajeTemp.ListaGastos.Add(h);
                        h = reader.ReadLine();
                    }
                    garajeTemp.AbiertaCerrada = reader.ReadLine();
                    if (reader.ReadLine() == "S")
                        garajeTemp.Bodega = "Bodega";
                    else if (reader.ReadLine() == "N")
                        garajeTemp.Bodega = "Sin Bodega";
                    garajes.Add(garajeTemp);
                }
                
            }
            reader.Close();
            //LEER ARCHIVOS DE PROPIETARIOS ------------------------------------------------------------------------
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Propietarios.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            Propietarios propTemp = new Propietarios();
            while (reader.Peek() > -1)
            {
                propTemp = new Propietarios();
                propTemp.Nombre = reader.ReadLine();
                propTemp.NIT1 = reader.ReadLine();
                propTemp.Correo = reader.ReadLine();
                misPropietarios.Add(propTemp);
            
            }
            reader.Close();
            //ALGORITMO
            MostrarPropietarios temp = new MostrarPropietarios();
            for(int a = 0; a < misPropietarios.Count; a++)
            {
                    for (int c = 0; c < pisos.Count; c++)
                    {   
                        if (misPropietarios[a].NIT1 == pisos[c].CodPropietario)
                        {   
                            temp = new MostrarPropietarios();
                            temp.Propiedades = new List<string>();
                            temp.Nombre = misPropietarios[a].Nombre;
                            temp.NIT1 = misPropietarios[a].NIT1;
                            temp.Correo = misPropietarios[a].Correo;
                            temp.Propiedades = new List<string>();
                            temp.Propiedades.Add(pisos[c].CodPropiedad);
                            mostrarPropietarios.Add(temp);
                        }
                    }
                    for (int c = 0; c < locales.Count; c++)
                    {
                        if (misPropietarios[a].NIT1 == locales[c].CodPropietario)
                        {
                            temp = new MostrarPropietarios();
                            temp.Propiedades = new List<string>();
                            temp.Nombre = misPropietarios[a].Nombre;
                            temp.NIT1 = misPropietarios[a].NIT1;
                            temp.Correo = misPropietarios[a].Correo;
                            temp.Propiedades.Add(pisos[c].CodPropiedad);
                            mostrarPropietarios.Add(temp);
                        }
                    }
                    for (int c = 0; c < garajes.Count; c++)
                    {
                        if (misPropietarios[a].NIT1 == garajes[c].CodPropietario)
                        {
                            temp = new MostrarPropietarios();
                            temp.Propiedades = new List<string>();
                            temp.Nombre = misPropietarios[a].Nombre;
                            temp.NIT1 = misPropietarios[a].NIT1;
                            temp.Correo = misPropietarios[a].Correo;
                            temp.Propiedades.Add(pisos[c].CodPropiedad);
                            mostrarPropietarios.Add(temp);
                        }
                    }
    
            }
            dataGridView1.DataSource = mostrarPropietarios;
            dataGridView1.Refresh();
        }
        

    }
}

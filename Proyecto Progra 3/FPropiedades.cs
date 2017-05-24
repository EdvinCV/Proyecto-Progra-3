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
    public partial class FPropiedades : Form
    {
        //Lista de pisos para guardar DATOS DE ARCHIVOS  
        List<PPropiedades> pisos = new List<PPropiedades>();
        //Lista de garajes para guardar DATOS DE ARCHIVOS
        List<GPropiedades> garajes = new List<GPropiedades>();
        //Lista de locales para guardar DATOS DE ARCHIVOS
        List<LPropiedades> locales = new List<LPropiedades>();
        //Lista de propietarios para guardar DATOS DE PROPIETARIOS
        List<Propietarios> misPropietarios = new List<Propietarios>();
        //Cantidad de propietarios
        int cantPropiedades = 0;
        //LISTA PARA MOSTRAR PROPIETARIOS Y PROPIEDADES DE PISOS
        List<PPropiedades> mostrarPisos = new List<PPropiedades>();
        //LISTA PARA MOSTRAR PROPIETARIOS Y PROPIEDADES DE LOCALES
        List<LPropiedades> mostrarLocales = new List<LPropiedades>();
        //LISTA PARA MOSTRAR PROPIETARIOS Y PROPIEDADES DE GARAJES
        List<GPropiedades> mostrarGarajes = new List<GPropiedades>();

        public FPropiedades()
        {
            InitializeComponent();
            //LEER ARCHIVO DE PROPIEDADES -----------------------------------------------------------------------------
            String nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Propiedades.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            //Objeto temporal de tipo piso para guardar pisos
            PPropiedades pisoTemp = new PPropiedades();
            //Objeto temporal de tipo local para guardar locales
            LPropiedades localTemp = new LPropiedades();
            //Objeto temporal de tipo garaje para guardar garajes
            GPropiedades garajeTemp = new GPropiedades();
            //Esta variable se utiliza para guardar el tipo de vivienda y poder compararla
            string tipo;
            while (reader.Peek() > -1)
            {
                tipo = reader.ReadLine();
                //Guardar datos de PISOS
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
                //Guardar datos de LOCALES
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
                //Guardar datos de GARAJES
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
                //Se van aumentando el numero de propiedades
                cantPropiedades++;
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
            //COMPARAR NIT DE PROPIETARIOS Y EL DE PROPIEDADES, Y LUEGO SE AGREGA A LA LISTA DE PISOS
            for(int i = 0; i < pisos.Count; i++)
            {
                for(int j = 0; j < misPropietarios.Count; j++)
                {
                    if(pisos[i].CodPropietario == misPropietarios[j].NIT1)
                    {
                        PPropiedades temp = new PPropiedades();
                        temp.NombrePropietario1 = misPropietarios[j].Nombre;
                        temp.MetrosCuadrados = pisos[i].MetrosCuadrados;
                        temp.NumDormitorios = pisos[i].NumDormitorios;
                        temp.Tipo = pisos[i].Tipo;
                        temp.TipoVivienda = pisos[i].TipoVivienda;
                        temp.ListaGastos = pisos[i].ListaGastos;
                        temp.CodPropiedad = pisos[i].CodPropiedad;
                        temp.CodPropietario = pisos[i].CodPropietario;
                        mostrarPisos.Add(temp);
                    }
                }
            }
            //COMPARAR NIT DE PROPIETARIOS Y EL DE PROPIEDADES, Y LUEGO SE AGREGA A LA LISTA DE LOCALES
            for (int i = 0; i < locales.Count; i++)
            {
                for (int j = 0; j < misPropietarios.Count; j++)
                {
                    if (locales[i].CodPropietario == misPropietarios[j].NIT1)
                    {
                        LPropiedades temp = new LPropiedades();
                        temp.NombrePropietario1 = misPropietarios[j].Nombre;
                        temp.MetrosCuadrados = locales[i].MetrosCuadrados;
                        temp.Tipo = locales[i].Tipo;
                        temp.ListaGastos = locales[i].ListaGastos;
                        temp.CodPropiedad = locales[i].CodPropiedad;
                        temp.CodPropietario = locales[i].CodPropietario;
                        temp.NombreComercial = locales[i].NombreComercial;
                        temp.Actividad = locales[i].Actividad;
                        temp.Tipo = locales[i].Tipo;
                        mostrarLocales.Add(temp);
                    }
                }
            }
            //
            //COMPARAR NIT DE PROPIETARIOS Y EL DE PROPIEDADES, Y LUEGO SE AGREGA A LA LISTA DE GARAJES
            for (int i = 0; i < garajes.Count; i++)
            {
                for (int j = 0; j < misPropietarios.Count; j++)
                {
                    if (garajes[i].CodPropietario == misPropietarios[j].NIT1)
                    {
                        GPropiedades temp = new GPropiedades();
                        temp.NombrePropietario1 = misPropietarios[j].Nombre;
                        temp.MetrosCuadrados = garajes[i].MetrosCuadrados;
                        temp.Tipo = garajes[i].Tipo;
                        temp.ListaGastos = garajes[i].ListaGastos;
                        temp.CodPropiedad = garajes[i].CodPropiedad;
                        temp.CodPropietario = garajes[i].CodPropietario;
                        temp.AbiertaCerrada = garajes[i].AbiertaCerrada;
                        temp.Bodega = garajes[i].Bodega;
                        temp.Tipo = garajes[i].Tipo;
                        mostrarGarajes.Add(temp);
                    }
                }
            }
            //MOSTRAR DATOS EN DATAGRIDVIEW'S
            label5.Text = Convert.ToString(cantPropiedades);
            dataGridView1.DataSource = mostrarPisos;
            dataGridView1.Refresh();
            dataGridView2.DataSource = mostrarLocales;
            dataGridView2.Refresh();
            dataGridView3.DataSource = mostrarGarajes;
            dataGridView3.Refresh();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FPropiedades_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

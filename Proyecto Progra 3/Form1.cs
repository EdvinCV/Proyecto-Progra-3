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
    public partial class Form1 : Form
    {
        //Lista para guardar datos de la comunidad
        List<Comunidad> miComunidad = new List<Comunidad>();
        //Lista para guardar datos de los tipos de gastos
        List<Gastos> misGastos = new List<Gastos>();
        //Lista para guardar datos de tipo PROPIEDADES PISO 
        List<PPropiedades> pisos = new List<PPropiedades>();
        //Lista para guardar datos de tipo PROPIEDADES LOCAL
        List<LPropiedades> locales = new List<LPropiedades>();
        //Lista para guardar datos de tipo PROPIEDADES GARAJE
        List<GPropiedades> garajes = new List<GPropiedades>();
        //Lista para guardar datos de los propietarios
        List<Propietarios> misPropietarios = new List<Propietarios>();
        //Lista para guardar datos de los gastos generados por la comunidad
        List<GastosGenerados> misGastosGenerados = new List<GastosGenerados>();
        //Variable que guarda la cantidad de propietarios de la comunidad 
        int cantidadPropietarios = 0;
        //Variable para guardar la cantidad de zonas que existen en la comunidad
        int cantidadZonas = 0;
        //Gastos totales de la comunidad
        int gastosTotales = 0;
        //Variable que guarda la cantidad de propiedades
        int cantidadPropiedades = 0;
         
        public Form1()
        {
            InitializeComponent();
            //LEER ARCHIVO COMUNIDAD---------------------------------------------------------------------------------------
            string nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Comunidad.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            Comunidad temp = new Comunidad();
            while (reader.Peek() > -1)
            {
                temp.Identificacion = reader.ReadLine();
                temp.Nombre = reader.ReadLine();
                temp.Poblacion = reader.ReadLine();
                temp.NumZonas = 5;
                temp.NumPropietarios = 10;
                temp.TotalGastos = 1000;
                miComunidad.Add(temp);
            }
            reader.Close();
            //LEER ARCHIVO DE DEFINICION DE GASTOS--------------------------------------------------------------------------
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Gastos.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            Gastos gastoTemporal = new Gastos();

            while (reader.Peek() > -1)
            {
                gastoTemporal = new Gastos();
                gastoTemporal.Identificacion = reader.ReadLine();
                gastoTemporal.Nombre = reader.ReadLine();
                gastoTemporal.TipoReparto = reader.ReadLine();
                misGastos.Add(gastoTemporal);
                cantidadZonas++;
            }
            reader.Close();
            //LEER ARCHIVO DE PROPIEDADES -----------------------------------------------------------------------------
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Propiedades.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
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
                    else if(reader.ReadLine() == "N")
                        garajeTemp.Bodega = "Sin Bodega";
                    garajes.Add(garajeTemp);
                }
                cantidadPropiedades++;
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
                cantidadPropietarios++;
            }
            reader.Close();
            //LEER ARCHIVOS DE LOS GASTOS DE LA COMUNIDAD
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Gastos Generados.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            GastosGenerados gastosTemp = new GastosGenerados();
            while (reader.Peek() > -1)
            {
                gastosTemp = new GastosGenerados();
                gastosTemp.Identificacion = reader.ReadLine();
                gastosTemp.Descripcion = reader.ReadLine();
                gastosTemp.Importe = Convert.ToInt32(reader.ReadLine());
                gastosTemp.TipoDeZona = reader.ReadLine();
                misGastosGenerados.Add(gastosTemp);
            }
            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Calcular la cantidad total de gastos de la cantidad
            for (int i = 0; i < misGastosGenerados.Count; i++)
            {
                gastosTotales += misGastosGenerados[i].Importe;
            }
            //Inicializar FORM
            FResumen mostrarResumen = new FResumen(miComunidad[0].Nombre, cantidadPropiedades, cantidadPropietarios, gastosTotales, cantidadZonas);
            //Mostrar Form
            mostrarResumen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FPropiedades mostrarPropiedades = new FPropiedades();
            mostrarPropiedades.Show();
        }
        
    }
}

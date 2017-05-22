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
        //Lista para guardar datos de las propiedades 
        List<Propiedades> misPropiedades = new List<Propiedades>();
        //Lista para guardar datos de los propietarios
        List<Propietarios> misPropietarios = new List<Propietarios>();
        //Variable que guarda la cantidad de propietarios de la comunidad 
        int cantidadPropietarios = 0;
        //Lista para guardar datos de los gastos generados por la comunidad
        List<GastosGenerados> misGastosGenerados = new List<GastosGenerados>();
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
            }
            reader.Close();
            //LEER ARCHIVO DE PROPIEDADES -----------------------------------------------------------------------------
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Propiedades.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            Propiedades propiedadTemp = new Propiedades();
            while (reader.Peek() > -1)
            {
                propiedadTemp = new Propiedades();
                propiedadTemp.Tipo = reader.ReadLine();
                propiedadTemp.CodPropiedad = reader.ReadLine();
                propiedadTemp.MetrosCuadrados = Convert.ToInt32(reader.ReadLine());
                propiedadTemp.CodPropietario = reader.ReadLine();
                propiedadTemp.ListaGastos = new List<string>();
                //Leer lista de gastos
                string h = reader.ReadLine();
                while (h != "---")
                {
                    propiedadTemp.ListaGastos.Add(h);
                    h = reader.ReadLine();
                }
                misPropiedades.Add(propiedadTemp);
                cantidadPropietarios++;
            }
            reader.Close();
            //LEER ARCHIVOS DE PROPIETARIOS ------------------------------------------------------------------------
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Propietarios.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            Propietarios propTemp = new Propietarios();
            while(reader.Peek() > -1)
            {
                propTemp = new Propietarios();
                propTemp.Nombre = reader.ReadLine();
                propTemp.NIT1 = reader.ReadLine();
                propTemp.Correo = reader.ReadLine();
                misPropietarios.Add(propTemp);
            }
            reader.Close();
            //LEER ARCHIVOS DE LOS GASTOS DE LA COMUNIDAD
            nombreArchivo = "C:\\Users\\EdvinCV\\Desktop\\Archivos Comunidad\\Gastos Generados.txt";
            stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            GastosGenerados gastosTemp = new GastosGenerados();
            while(reader.Peek() > -1)
            {
                gastosTemp = new GastosGenerados();
                gastosTemp.Identificacion = reader.ReadLine();
                gastosTemp.Descripcion = reader.ReadLine();
                gastosTemp.Importe = Convert.ToInt32(reader.ReadLine());
                gastosTemp.TipoDeZona = reader.ReadLine();
                misGastosGenerados.Add(gastosTemp);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = misPropietarios;
            dataGridView1.Refresh();    
        }
    }
}

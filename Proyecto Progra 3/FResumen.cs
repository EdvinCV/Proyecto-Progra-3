using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Progra_3
{
    public partial class FResumen : Form
    {
        private void label5_Click(object sender, EventArgs e)
        {

        }
        
        public FResumen()
        {
            InitializeComponent();
        }
        //ESTE METODO CONSTRUCTOR SE INICIALIZA CON LAS VARIABLES A MOSTRAR EN RESUMEN
        public FResumen(String NComunidad, int Propiedades, int Propietarios, int Gastos, int Zonas)
        {
            InitializeComponent();
            label7.Text = NComunidad;
            label8.Text = Convert.ToString(Zonas);
            label9.Text = Convert.ToString(Propiedades);
            label10.Text = Convert.ToString(Propietarios);
            label11.Text = Convert.ToString(Gastos);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FResumen_Load(object sender, EventArgs e)
        {

        }
    }
}

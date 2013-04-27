using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Cuadro.Direccion direccion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point p=new Point (100,100);
            Pen a=new Pen (Color.Red);

            Cuadro c = new Cuadro(p, 10, a, Color.Green, Cuadro.Estado.Estatico,Cuadro.Direccion.ninguna);
            c.Draw(e);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==46)
            {
                direccion=Cuadro.Direccion.izquierda;
            }
            if (e.KeyChar == 47)
            {
                direccion = Cuadro.Direccion.arriba;
            }
            if (e.KeyChar == 48)
            {
                direccion = Cuadro.Direccion.derecha;
            }
            if (e.KeyChar == 49)
            {
                direccion = Cuadro.Direccion.abajo;
            }
        }
    }
}

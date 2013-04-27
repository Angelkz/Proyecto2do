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

        public Cuadro c = new Cuadro(new Point(100, 100), 10, new Pen(Color.Red), Color.Green, Cuadro.Estado.Estatico, Cuadro.Direccion.ninguna);
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
            
            c.Draw(e);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
         /*   if(e.KeyChar=='a')
            {
                direccion=Cuadro.Direccion.izquierda;
            }
            else if (e.KeyChar =='w')
            {
                direccion = Cuadro.Direccion.arriba;
            }
            else if (e.KeyChar == 'd')
            {
                direccion = Cuadro.Direccion.derecha;
            }
            else if (e.KeyChar == 's')
            {
                direccion = Cuadro.Direccion.abajo;
            }
            else { direccion = Cuadro.Direccion.ninguna; }

            c.movimiento(direccion);
            this.Refresh();*/
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 37)
            {
                direccion = Cuadro.Direccion.izquierda;
            }
            else if (e.KeyValue == 38)
            {
                direccion = Cuadro.Direccion.arriba;
            }
            else if (e.KeyValue == 39)
            {
                direccion = Cuadro.Direccion.derecha;
            }
            else if (e.KeyValue == 40)
            {
                direccion = Cuadro.Direccion.abajo;
            }
            else { direccion = Cuadro.Direccion.ninguna; }

            c.movimiento(direccion);
            this.Refresh();
        }
    }
}

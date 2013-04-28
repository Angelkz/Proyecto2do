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
        List<Obstaculo> barreras = new List<Obstaculo>();
        
        public Form1()
        {
            InitializeComponent();
            barreras.Add(new Obstaculo(new Point(100,250),20,10,new Pen(Color.Blue),Color.Blue));
            barreras.Add(new Obstaculo(new Point(200, 250), 10, 20, new Pen(Color.Blue), Color.Blue));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            c.Draw(e);
            foreach (Obstaculo b in barreras)
                b.Draw(e);
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
                c.estado = Cuadro.Estado.Movimiento;
            }
            else if (e.KeyValue == 38)
            {
                direccion = Cuadro.Direccion.arriba;
                c.estado = Cuadro.Estado.Movimiento;
            }
            else if (e.KeyValue == 39)
            {
                direccion = Cuadro.Direccion.derecha;
                c.estado = Cuadro.Estado.Movimiento;
            }
            else if (e.KeyValue == 40)
            {
                direccion = Cuadro.Direccion.abajo;
                c.estado = Cuadro.Estado.Movimiento;
            }
            else 
            { direccion = Cuadro.Direccion.ninguna;
                c.estado = Cuadro.Estado.Estatico;
            }
            for (int x = 0; x < 300; x++)
            {
                c.movimiento(direccion);
                foreach (Obstaculo b in barreras)
                    b.Colicion(c);
                this.Refresh();
                if(c.estado==Cuadro.Estado.Estatico)
                    break;
            }
            
        }
    }
}

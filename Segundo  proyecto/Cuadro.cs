using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Cuadro
    {
        Point posicion;
        int lado;
        Pen contorno;
        Color fondo;
        public enum Estado { Estatico, Movimiento};
        public enum Direccion {arrriba,abajo,derecha,izquierda}
        Estado estado;
        Direccion direccion;

        public Cuadro(Point p, int l, Pen c, Color f, Estado e)
        {
            this.posicion = p; this.lado = l; this.contorno = c; this.fondo = f; this.estado = e;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(contorno, posicion.X - 10, posicion.Y - 10, lado, lado);
        }



       

    }
}

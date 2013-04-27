using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Elemento
    {
        public Point posicion;
        public int lado;
        public Pen contorno;
        public Color fondo;
        public Elemento(Point p,int l,Pen c,Color f)
        {
            posicion = p; lado = l; contorno = c; fondo = f;
        } 
    }

    public  class Cuadro:Elemento
    {
        public enum Estado { Estatico, Movimiento};
        public enum Direccion {arriba,abajo,derecha,izquierda,ninguna}
        Estado estado;
        Direccion direccion;
        
        public Cuadro(Point p, int l, Pen c, Color f, Estado e, Direccion d):base (p,l,c,f)
        {
            this.estado = e; this.direccion = d;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(contorno, posicion.X - 10, posicion.Y - 10, lado, lado);
        }
        
        public Point getPosicion()
        { 
            return posicion; 
        }

        //public void movimiento(Direccion d)
        //{
            //if (d == Direccion.izquierda)
            // Relacionar metodo estatico con variable publica  //posicion.X--; 
        //}
      }

    /*public class Obstaculo : Elemento
    {
        
    }*/

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

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
        public Estado estado;
        public Direccion direccion;
        
        public Cuadro(Point p, int l, Pen c, Color f, Estado e, Direccion d):base (p,l,c,f)
        {
            this.estado = e; this.direccion = d;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(contorno, posicion.X - 10, posicion.Y - 10, lado, lado);
        }
        
        public void movimiento(Direccion d)
        {
            if (estado == Estado.Movimiento)
            {
                if (d == Cuadro.Direccion.izquierda)
                {
                    this.posicion.X--;
                }
                if (d == Cuadro.Direccion.arriba)
                {
                    this.posicion.Y--;
                }
                if (d == Cuadro.Direccion.derecha)
                {
                    this.posicion.X++;
                }
                if (d == Cuadro.Direccion.abajo)
                {
                    this.posicion.Y++;
                }
                if (d == Cuadro.Direccion.ninguna)
                { }
            }
            else { }
        }
      }

    public class Obstaculo : Elemento
    {
        int altura;
        public Obstaculo(Point p, int l, int al, Pen c, Color f)
            : base(p, l, c, f)
        {
            this.altura = al;
        }
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(contorno, posicion.X - 10, posicion.Y - 10, lado,altura);
        }
        public void Colicion(Cuadro cuadro)
        {
            if (cuadro.posicion.X >= this.posicion.X && cuadro.posicion.X <= (this.posicion.X + lado) &&
               cuadro.posicion.Y >= this.posicion.Y && cuadro.posicion.Y <= (this.posicion.Y + altura))
            {
         
                cuadro.estado = Cuadro.Estado.Estatico;
                cuadro.direccion = Cuadro.Direccion.ninguna;
                
            }
            else
            { };
 
        }

        
    }

}

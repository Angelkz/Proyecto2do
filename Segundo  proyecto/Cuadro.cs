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
        public enum Estado { Estatico, Movimiento,Ganar,Perder};
        public enum Direccion {arriba,abajo,derecha,izquierda,ninguna}
        public Estado estado;
        public Direccion direccion;
        
        public Cuadro(Point p, int l, Pen c, Color f, Estado e, Direccion d):base (p,l,c,f)
        {
            this.estado = e; this.direccion = d;
        }

        public void Draw(PaintEventArgs e)
        {
            //Image n=Image.FromFile("C:/Documents and Settings/ruben/Mis documentos/Mis imágenes/PiezaAzul.png");
            //e.Graphics.DrawImage(n, posicion.X, posicion.Y, lado+30, lado+30);
            //e.Graphics.DrawRectangle(contorno, posicion.X, posicion.Y, lado, lado);
            e.Graphics.FillRectangle(new SolidBrush(fondo), posicion.X, posicion.Y, lado, lado);
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
            //e.Graphics.DrawRectangle(contorno, posicion.X, posicion.Y, lado,altura);
            e.Graphics.FillRectangle(new SolidBrush(fondo), posicion.X, posicion.Y, lado, altura);
        }
        public void Colicion(Cuadro cuadro)
        {
            if (cuadro.posicion.X>=this.posicion.X && ((cuadro.posicion.X)+cuadro.lado) <= (this.posicion.X + lado) && (cuadro.posicion.Y+cuadro.lado)==this.posicion.Y) 
            {
                cuadro.estado = Cuadro.Estado.Estatico;
                cuadro.direccion = Cuadro.Direccion.ninguna;
                cuadro.posicion.Y--;       
            }
            if (cuadro.posicion.Y >= this.posicion.Y && (cuadro.posicion.Y + cuadro.lado) <= (this.posicion.Y + altura) && (cuadro.posicion.X + cuadro.lado) == this.posicion.X)
            {
                cuadro.estado = Cuadro.Estado.Estatico;
                cuadro.direccion = Cuadro.Direccion.ninguna;
                cuadro.posicion.X--; 
            }
            if (cuadro.posicion.Y >= this.posicion.Y && (cuadro.posicion.Y + cuadro.lado) <= (this.posicion.Y + altura) && cuadro.posicion.X == (this.posicion.X + lado))
            {
                cuadro.estado = Cuadro.Estado.Estatico;
                cuadro.direccion = Cuadro.Direccion.ninguna;
                cuadro.posicion.X++;
            }
            if (cuadro.posicion.X >= this.posicion.X && ((cuadro.posicion.X) + cuadro.lado) <= (this.posicion.X + lado) && cuadro.posicion.Y == (this.posicion.Y + altura))
            {
                cuadro.estado = Cuadro.Estado.Estatico;
                cuadro.direccion = Cuadro.Direccion.ninguna;
                cuadro.posicion.Y++;
            }
            else
            { }; 
 
        }
       

        
    }
    public class Meta : Elemento
    {
        int altura;
        public Meta(Point p, int l, int al, Pen c, Color f)
            : base(p, l, c, f)
        {
            this.altura = al;
        }
        public void Draw(PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(contorno, posicion.X, posicion.Y, lado,altura);
            e.Graphics.FillRectangle(new SolidBrush(fondo), posicion.X, posicion.Y, lado, altura);
        }
        public void End(Cuadro cuadro)
        {
            if (cuadro.posicion.X >= this.posicion.X && ((cuadro.posicion.X) + cuadro.lado) <= (this.posicion.X + lado) && 
                cuadro.posicion.Y >= this.posicion.Y && ((cuadro.posicion.Y) + cuadro.lado) <= (this.posicion.Y + lado))
            {
                cuadro.estado = Cuadro.Estado.Ganar;
                cuadro.posicion.X = this.posicion.X+5;
                cuadro.posicion.Y = this.posicion.Y + 5;
                
            }
        }
    }
    public class Escenario : Elemento
    {
        int altura;
        public Escenario(Point p, int l, int al, Pen c, Color f)
            : base(p, l, c, f)
        {
            this.altura = al;
        }
        public void Draw(PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(contorno, posicion.X, posicion.Y, lado,altura);
            e.Graphics.FillRectangle(new SolidBrush(fondo), posicion.X, posicion.Y, lado, altura);
        }
        public void Dead(Cuadro cuadro)
        {
            //if (cuadro.posicion.X <= this.posicion.X && ((cuadro.posicion.X) + cuadro.lado) >= (this.posicion.X + lado) &&
              //  cuadro.posicion.Y <= this.posicion.Y && ((cuadro.posicion.Y) + cuadro.lado) >= (this.posicion.Y + lado))
            
                //if (cuadro.posicion.X>this.posicion.X ||(cuadro.posicion.X+cuadro.lado)<this.posicion.X ||cuadro.posicion.Y>this.posicion.Y ||(cuadro.posicion.Y+cuadro.lado)<this.posicion.Y) 
            if (cuadro.posicion.X >= this.posicion.X && ((cuadro.posicion.X) + cuadro.lado) <= (this.posicion.X + lado) &&
                cuadro.posicion.Y >= this.posicion.Y && ((cuadro.posicion.Y) + cuadro.lado) <= (this.posicion.Y + lado))
            {


            }
            else { cuadro.estado = Cuadro.Estado.Perder; }            

            
        }
    }
}

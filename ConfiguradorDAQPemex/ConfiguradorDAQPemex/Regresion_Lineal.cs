using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfiguradorDAQPemex
{
    class Regresion_Lineal
    {
        //Y = mX + b

        // m = [n SUM(X,Y) - SUM(X) * SUM (Y)]/ [n SUM(x°2) - SUM(X)°2]

        // b = [SUM (Y) - m SUM(X)]/ n

        // n = numero de datos

        private double sum_X, sum_Y, sum_XY, sum_Xcuadrado;
        private double m, b;
        private int n;

        public Regresion_Lineal()
        {
            sum_X = sum_Y = sum_XY = sum_Xcuadrado = m = b = 0;
            n = 0;
        }

        public void addTermino(double punto_X, double punto_Y)
        {
            sum_X += punto_X;
            sum_Y += punto_Y;
            sum_XY += (punto_X + punto_Y);
            sum_Xcuadrado +=  (punto_X * punto_X);
            n ++;
        }



        private double pendiente()
        {
            double pendiente = 0;
            pendiente = ((n * sum_XY) - (sum_X * sum_Y)) / ((n * sum_Xcuadrado) - (sum_X * sum_X));
            return pendiente;
        }
        private double ordenada()
        {
            // Es necesario tener el valor de la pendiente para que la ordenada sea calculada
            double ordenada = 0;
            ordenada = (sum_Y - (m * sum_X)) / n;
            return ordenada;
        }

        public void calcularRegresionLineal()
        {
            m = pendiente();
            b = ordenada();
        }

        public double obtieneCoordenada(double punto_X)
        {
            double temp;
            temp = (m * punto_X) + b;
            return temp;
        }

        public void borrar()
        {
            sum_X = 0;
            sum_Y = 0;
            sum_XY = 0;
            sum_Xcuadrado = 0;
            n = 0;
        }
    }
}

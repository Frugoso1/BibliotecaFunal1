﻿using System;

namespace Biblioteca
{
    public static class Variables
    {

        //Arreglo global de x filas y cuatro columnas, cada columna representa una categoria del producto
        //Para usarlo: Variables.items[0,0] o  Variables.ventas[0,0]
        public static string[,] items = new string[10000, 4];
        public static string[,] ventas = new string[10000, 4];
        public static int valor = 0;
    }

    public static class MetodosAuxiliares
    {

        //Método que verifica si un código existe en el arreglo de items.
        public static int VerificarCodigo(string a)
        {
            for (int i = 0; i < Variables.items.GetLongLength(0); i++)
            {
                if (a == Variables.items[i, 0])
                {
                    return 1;
                }

            }
            return 0;
        }

        //Método que verifica si un código es válido, revisa que el primer carácter sea una p y que los otros cinco sean números
        public static int VerificarCodigoValido(string codigo)
        {
            bool a = false, b = false, c = false, d = false, e = false, f = false;

            if (codigo.Length == 6)
            {
                if (codigo[0] == 'P' || codigo[0] == 'p') { a = true; }
                if (int.TryParse(codigo[1].ToString(), out int num))
                {
                    b = true;
                }
                if (int.TryParse(codigo[2].ToString(), out int num1))
                {
                    c = true;
                }
                if (int.TryParse(codigo[3].ToString(), out int num2))
                {
                    d = true;
                }
                if (int.TryParse(codigo[4].ToString(), out int num3))
                {
                    e = true;
                }
                if (int.TryParse(codigo[5].ToString(), out int num4))
                {
                    f = true;
                }
            }

            if (a && b && c && d && e && f)
            {
                return 1;
            }

            return 0;

        }
        public static int verificarCodigoNoRepitente(string cadena, int numeroDeOrden)
        {
            for (int i = 0; i < numeroDeOrden; i++)
            {
                if (cadena == Variables.items[i, 0])
                {
                    Console.WriteLine("Codigo repitente");
                    return 0;
                }
            }
            return 1;
        }
        public static int verificarNombreNoRepitente(string cadena, int numeroDeOrden)
        {
            for (int i = 0; i < numeroDeOrden; i++)
            {
                if (cadena == Variables.items[i, 1])
                {
                    Console.WriteLine("Nombre repitente");
                    return 0;
                }
            }
            return 1;
        }
    }
}

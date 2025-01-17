﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
   
        public class productos
        {
            public int menu()
            {
                
                int op;
                Console.WriteLine(" ----------------------------------------------------------");
                Console.WriteLine("|                                                         |");
                Console.Write("|      "); Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Sistema de ventas en una tienda que SI vende"); Console.ResetColor(); Console.Write("       |\n");
                Console.WriteLine("|                                                         |");
                Console.WriteLine(" ---------------------------------------------------------");
                Console.WriteLine("|        =========== MENÚ DE OPCIONES ===========         |");
                Console.WriteLine("|                                                         |");
                Console.WriteLine("|                1 -> Registrar Producto                  |");
                Console.WriteLine("|                2 -> Editar Producto                     |");
                Console.WriteLine("|                3 -> Eliminar Producto                   |");
                Console.WriteLine("|                4 -> Registrar Venta                     |");
                Console.WriteLine("|                5 -> Listar Producto                     |");
                Console.WriteLine("|                6 -> Listar Ventas                       |");
                Console.WriteLine("|                7 -> SALIR DEL MENÚ                      |");
                Console.WriteLine("|                                                         |");
                Console.WriteLine(" ---------------------------------------------------------\n");

                Console.SetCursorPosition(11, 17); Console.Write("Ingrese una opción [1-7] ->  ");
                while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out op) || op > 7 || op < 1)
                {
                    
                Console.ForegroundColor = ConsoleColor.DarkRed;        
                Console.SetCursorPosition(11, 17);
                Console.ResetColor();
                Console.Write("Ingrese una opción válida [1-7] -> ");
                }
            return op;
            }

            public void Registrar(int opcion)
            {
                Console.Clear();
                int verificarCodigo1, verificarCodigo2, verificarStock, verificarPrecio, verificarCodigo3, verificarNombre;
                char continuar = 'o';

                Console.WriteLine("REGISTRO DE PRODUCTOS\n");


                for (int i = 1; ; i++)
                {
                    do
                    {
                        do
                        {
                            Console.WriteLine($"\nProducto {i}");
                            Console.Write("-> Código (ejemplo:\"P00000\"): ");
                            Variables.items[Variables.valor + i, 0] = Console.ReadLine();
                            verificarCodigo1 = MetodosAuxiliares.VerificarCodigo(Variables.items[Variables.valor + i, 0]);
                            verificarCodigo2 = MetodosAuxiliares.VerificarCodigoValido(Variables.items[Variables.valor + i, 0]);
                            verificarCodigo3 = MetodosAuxiliares.verificarCodigoNoRepitente(Variables.items[Variables.valor + i, 0], i);
                        }
                        while (verificarCodigo1 == 0 || verificarCodigo2 == 0 || verificarCodigo3 == 0);


                        do
                        {
                            Console.Write("-> Nombre: ");
                            Variables.items[Variables.valor + i, 1] = Console.ReadLine();

                            if (Variables.items[Variables.valor + i, 1].Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("[Error] ");
                                Console.ResetColor();
                                Console.Write("Cantidad de caracteres muy bajo para corresponder a la de un nombre.\n");
                            }
                            verificarNombre = MetodosAuxiliares.verificarNombreNoRepitente(Variables.items[Variables.valor + i, 1], i);

                        }
                        while (Variables.items[Variables.valor + i, 1].Length < 3 || verificarNombre == 0);


                        if (Variables.items[Variables.valor + i, 0] != Variables.items[Variables.valor + i, 1])
                        {
                            do
                            {
                                Console.Write("-> Stock: ");
                                Variables.items[Variables.valor + i, 2] = Console.ReadLine();
                                verificarStock = verificarStock1(i);
                            }
                            while (verificarStock != 1);

                            do
                            {
                                Console.Write("-> Precio: ");
                                Variables.items[Variables.valor + i, 3] = Console.ReadLine();
                                verificarPrecio = verificarPrecio1(i);
                            }
                            while (verificarPrecio != 1);
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nEl código y el nombre del producto no pueden ser iguales. "); Console.ResetColor();
                        }
                    }
                    while (Variables.items[Variables.valor + i, 0] == Variables.items[Variables.valor + i, 1]);
                    Variables.valor++;
                    Console.Write("\n¿Desea continuar registrando? [S/N] -> ");
                    continuar = char.ToUpper(Console.ReadKey().KeyChar);
                    if (continuar == 'N')
                    {
                        break;
                    }
                }
            }

            public int verificarStock1(int i)
            {
                int stock;

                while (!int.TryParse(Variables.items[Variables.valor + i, 2], out stock) || stock < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERROR ");
                    Console.ResetColor();
                    Console.Write("Ingrese un stock válido: ");
                    return 0;
                }
                return 1;
            }

            public int verificarPrecio1(int i)
            {
                double precio;

                while (!double.TryParse(Variables.items[Variables.valor + i, 3], out precio) || precio < 0)
                {
                    Console.WriteLine("ERROR. Ingrese un precio válido: ");
                    return 0;
                }
                return 1;
            }


            public void MostrarProductos()
            {
                Console.Clear();
                Console.WriteLine(" -------------------------------------------------------------------------");
                Console.Write("|                      "); 
                Console.ForegroundColor = ConsoleColor.DarkBlue; 
                Console.Write("LISTA DE PRODUCTOS REGISTRADOS"); 
                Console.ResetColor(); 
                Console.Write("                     |\n");
                Console.Write(" -------------------------------------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(2, 3); 
                Console.Write("CODIGO");
                Console.SetCursorPosition(12, 3); 
                Console.Write("NOMBRE");
                Console.SetCursorPosition(52, 3); 
                Console.Write("STOCK");
                Console.SetCursorPosition(62, 3); 
                Console.Write("PRECIO");
                Console.ResetColor();

                Console.WriteLine();


                for (int i = 0; i < Variables.items.GetLongLength(0); i++) //GetLongLength(0) recupera el tamaño de filas y si pongo 1 seria tamaño de las columnas.
                {
                    if (Variables.items[i, 0] != null) // Verifica si la fila contiene datos, para asi evitar que se muestren los datos vacios
                    {
                            Console.SetCursorPosition(2, 3 + i); 
                            Console.Write(Variables.items[i, 0]);
                            Console.SetCursorPosition(12, 3 + i); 
                            Console.Write(Variables.items[i, 1]);
                            Console.SetCursorPosition(52, 3 + i); 
                            Console.Write(Variables.items[i, 2]);
                            Console.SetCursorPosition(62, 3 + i); 
                            Console.Write(Variables.items[i, 3]);
                    }
                }
                Console.Write("\n ------------------------------------------------------------------------\n");
            }

            public void buscarEimprimir(string codi)
            {
                bool encontrado = false;
                for (int i = 0; i < Variables.items.GetLength(0); i++) // Recorre las filas
                {
                    if (Variables.items[i, 0] != null && Variables.items[i, 0] == codi) // Verifica que el código coincida
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Green; Console.WriteLine("Producto encontrado"); Console.ResetColor();
                        Console.SetCursorPosition(0, 2); Console.Write("CODIGO");
                        Console.SetCursorPosition(0, 3); Console.WriteLine(Variables.items[i, 0]);
                        Console.SetCursorPosition(10, 2); Console.Write("NOMBRE");
                        Console.SetCursorPosition(10, 3); Console.WriteLine(Variables.items[i, 1]);
                        Console.SetCursorPosition(50, 2); Console.Write("STOCK");
                        Console.SetCursorPosition(50, 3); Console.WriteLine(Variables.items[i, 2]);
                        Console.SetCursorPosition(65, 2); Console.Write("PRECIO\n");
                        Console.SetCursorPosition(65, 3); Console.WriteLine(Variables.items[i, 3]);

                        encontrado = true;
                        break;
                    }
                }

                if (encontrado == false)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("El producto con el código ingresado no existe.");
                    Console.ResetColor();
                }
            }
            public int buscar(string cod)
            {
                for (int i = 0; i < Variables.items.GetLength(0); i++) // Recorre las filas
                {
                    if (Variables.items[i, 0] != null && Variables.items[i, 0] == cod)
                    {
                        return i; // Retorna el índice de la fila donde se encuentra el código
                    }
                }
                return -1; // Retorna -1 si no encuentra el código
            }
            public void Modificar()
            {
                productos R = new productos();
                string code;
                Console.Write("\nIngrese el código del producto a modificar (ejemplo:\"P99999\") -> "); code = Console.ReadLine();
                R.buscar(code);
                bool encontrado = false;
                string COD, NOM, STO, PRE;
                for (int i = 0; i < Variables.items.GetLength(0); i++) // Recorre las filas
                {
                    if (Variables.items[i, 0] != null && Variables.items[i, 0] == code) // Verifica que el código coincida
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Green; Console.WriteLine("Producto encontrado"); Console.ResetColor();
                        byte opc;
                        Console.Write("\n1.- Código" + "\n2.- Nombre del Producto" + "\n3.- Stock" + "\n4.- Precio" + "\n\n¿Que opcion desea modificar? -> ");
                        while (!byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out opc) || opc > 4) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("\n[ERROR]"); Console.Write("Ingrese un valor válido  -> "); }
                        switch (opc)
                        {

                            case 1:
                                Console.Write("\nIngrese código modificado: ");
                                COD = Console.ReadLine();
                                Variables.items[i, 0] = COD;
                                break;

                            case 2:
                                Console.Write("\nIngrese nombre del producto modificado: ");
                                NOM = Console.ReadLine();
                                Variables.items[i, 1] = NOM;
                                break;

                            case 3:
                                Console.Write("\nIngrese stock del producto modificado: ");
                                STO = Console.ReadLine();
                                Variables.items[i, 2] = STO;
                                break;

                            case 4:
                                Console.Write("\nIngrese precio modificado: ");
                                PRE = Console.ReadLine();
                                Variables.items[i, 3] = PRE;
                                break;

                        }
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El producto con el código ingresado no existe.");
                    Console.ResetColor();
                }



            }
            public void EliminarProducto()
            {
                Console.Write("Ingrese código del producto a eliminar: ");
                string cod = Console.ReadLine().Trim();

                int indice = buscar(cod); // Guardamos el índice del producto

                if (indice != -1)
                {
                    for (int i = indice; i < Variables.items.GetLength(0) - 1; i++)
                    {
                        for (int j = 0; j < Variables.items.GetLength(1); j++)
                        {
                            Variables.items[i, j] = Variables.items[i + 1, j];
                        }
                    }

                    for (int j = 0; j < Variables.items.GetLength(1); j++)
                    {
                        Variables.items[Variables.items.GetLength(0) - 1, j] = null;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEl producto ha sido eliminado correctamente!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEl producto no se puede eliminar porque no existe!");
                    Console.ResetColor();
                }
            }
        }
    
}

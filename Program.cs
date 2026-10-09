using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ejercicio1parrte2
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("Sistema de Gestión de Notas");
        }
        static public void registrar_estudiante()
        {
            Console.WriteLine("*** REGISTRAR ESTUDIANTE ***");

            if (contador >= max)
            {
                Console.WriteLine("Se alcanzó la capacidad máxima.");
                return;
            }

            string nombre;
            bool IsNullOrWhiteSpace;
            do
            {
                Console.Write("Ingresar nombre del estudiante: ");
                nombre = Console.ReadLine();
                IsNullOrWhiteSpace = string.IsNullOrWhiteSpace(nombre);
                if (IsNullOrWhiteSpace)
                {
                    Console.WriteLine("Error. El nombre no puede estar vacío.");
                }

            } while (IsNullOrWhiteSpace);

            double nota;

            while (true)
            {
                Console.Write("Ingresar nota [0-20]: ");
                if (double.TryParse(Console.ReadLine(), out nota) &&
                    nota >= 0 &&
                    nota <= 20)
                {
                    break;
                }

                Console.WriteLine("Error. Ingrese una nota entre 0 y 20.");
            }

            nombres[contador] = nombre.Trim();
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Registro con éxito...!!");
        }

        static public void buscar_estudiante()
        {
            Console.WriteLine("** BUSCAR ESTUDIANTE ****");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().Trim().ToLower();

            bool encontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("Estudiante encontrado:");
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }

        static public void Modificar_Nota()
        {
            Console.WriteLine("*** MODIFICAR NOTA ****");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.Write("Ingresar nombre del estudiante: ");
            string nom_buscar = Console.ReadLine().Trim().ToLower();

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);

                    double nueva_nota;

                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota [0-20]: ");

                        if (double.TryParse(Console.ReadLine(), out nueva_nota) &&
                            nueva_nota >= 0 &&
                            nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;

                            Console.WriteLine("Nota modificada correctamente.");
                            return;
                        }

                        Console.WriteLine("Nota fuera de rango [0-20].");
                    }
                }
            }

            Console.WriteLine("Estudiante no encontrado.");
        }

        static public void Mostrar()
        {
            Console.WriteLine("** LISTADO DE ESTUDIANTES ****");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.WriteLine("NOMBRE\t\tNOTA");

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine(nombres[i] + "\t\t" + notas[i]);
            }
        }

        static public void Burbuja()
        {
            Console.WriteLine("*** ORDENAMIENTO ASCENDENTE ****");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            double temp_nota;
            string temp_nombre;

            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - 1 - i; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;

                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }

            Console.WriteLine("Estudiantes ordenados de menor a mayor.");
            Mostrar();
        }

        static public void Seleccion()
        {
            Console.WriteLine("*** ORDENAMIENTO DESCENDENTE ***");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            for (int i = 0; i < contador - 1; i++)
            {
                int Mayor = i;

                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[Mayor])
                    {
                        Mayor = j;
                    }
                }

                if (Mayor != i)
                {
                    double temp_nota = notas[i];
                    notas[i] = notas[Mayor];
                    notas[Mayor] = temp_nota;

                    string temp_nombre = nombres[i];
                    nombres[i] = nombres[Mayor];
                    nombres[Mayor] = temp_nombre;
                }
            }

            Console.WriteLine("Estudiantes ordenados de mayor a menor.");
            Mostrar();
        }

        static public void nota_max_prom()
        {
            Console.WriteLine("*** NOTA MAXIMA Y PROMEDIO ****");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            double suma = 0;
            double nota_maxima = notas[0];
            string estudiante_maximo = nombres[0];

            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];

                if (notas[i] > nota_maxima)
                {
                    nota_maxima = notas[i];
                    estudiante_maximo = nombres[i];
                }
            }

            double promedio = suma / contador;

            Console.WriteLine("Nota máxima: " + nota_maxima);
            Console.WriteLine("Estudiante con mayor nota: " + estudiante_maximo);
            Console.WriteLine("Promedio general: " + promedio.ToString("F2"));
        }

        static void Main(string[] args)
        {
            int opc = 0;

            while (opc != 8)
            {
                Console.Clear();

                Titulo();

                Console.WriteLine();
                Console.WriteLine("***********");
                Console.WriteLine("       MENU PRINCIPAL");
                Console.WriteLine("***********");
                Console.WriteLine("[1] Registrar Estudiante");
                Console.WriteLine("[2] Buscar Estudiante");
                Console.WriteLine("[3] Modificar Nota");
                Console.WriteLine("[4] Mostrar lista");
                Console.WriteLine("[5] Ordenar con Burbuja");
                Console.WriteLine("[6] Ordenar con Seleccion");
                Console.WriteLine("[7] Nota maxima y promedio");
                Console.WriteLine("[8] Salir");
                Console.Write("Ingresar Opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Opcion incorrecta.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();

                switch (opc)
                {
                    case 1:
                        registrar_estudiante();
                        break;

                    case 2:
                        buscar_estudiante();
                        break;

                    case 3:
                        Modificar_Nota();
                        break;

                    case 4:
                        Mostrar();
                        break;

                    case 5:
                        Burbuja();
                        break;

                    case 6:
                        Seleccion();
                        break;

                    case 7:
                        nota_max_prom();
                        break;

                    case 8:
                        Console.WriteLine("Gracias por usar el Sistema.");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }

                if (opc != 8)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
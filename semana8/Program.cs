using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CASO_SEMA7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Sistema de gestion de notas");
            Console.WriteLine("******************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a la capacidad máxima");
                return;
            }
            Console.WriteLine("Ingresar nombre del estudiante: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota [0-20]: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error, Volver a ingresar la nota[0-20]");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }
        static public void Buscar_estudiante()
        {
            Console.WriteLine("******BUSCAR ESTUDIANTE******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("Estudiante encontrado:");
                    Console.WriteLine(nombres[i] + "tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado...");
        }
        static public void Modificar_nota()
        {
            Console.WriteLine("******MODIFICAR NOTA******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiante registrados");
                return;
            }
            Console.Write("Ingresar nombre del estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + "tiene" + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada correctamente");
                            return;
                        }
                        Console.WriteLine("Nota fuera de rango[0-20]");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado...");
        }
        static public void Mostrar()
        {
            Console.WriteLine("******LISTADO ORIGINAL******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("\tNOMBRE \t\tNOTAS");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("\t" + nombres[i] + "\t\t" + notas[i]);
            }
        }
        static public void burbuja()
        {
            Console.WriteLine("******ORDENAMIENTO ASCENDENTE******");
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
        }
        static public void Seleccion()
        {
            Console.WriteLine("******ORDENAMIENTO DESCENDENTE******");
            for (int i = 0; i < contador - 1; i++)
            {
                int mayor = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[mayor])
                    {
                        mayor = j;
                    }
                }
                if (mayor != i)
                {
                    double temp_nota = notas[i];
                    notas[i] = notas[mayor];
                    notas[mayor] = temp_nota;


                    string temp_nombre = nombres[i];
                    nombres[i] = nombres[mayor];
                    nombres[mayor] = temp_nombre;
                }
            }
            Console.WriteLine("Estudiantes ordenados de mayor a menor");
        }
        static public void nota_max_prom()
        {
            Console.WriteLine("******NOTA MAXIMA Y PROMEDIO******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            double nota_maxima = notas[0];
            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                if (notas[i] > nota_maxima)
                {
                    nota_maxima = notas[i];
                }
                suma += notas[i];
            }
            double promedio = suma / contador;
            Console.WriteLine("Nota maxima:" + nota_maxima);
            Console.WriteLine("Estudiante con la nota maxima:");
            for (int i = 0; i < contador; i++)
            {
                if (notas[i] == nota_maxima)
                {
                    Console.WriteLine("- " + nombres[i]);
                }
            }
            Console.WriteLine("Promedio final:" + promedio.ToString("F2"));
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 8)
            {
                Console.WriteLine("************************************");
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("************************************");
                Console.WriteLine("[1]Registrar estudiante");
                Console.WriteLine("[2]Buscar estudiante");
                Console.WriteLine("[3]Modificar nota");
                Console.WriteLine("[4]Mostrar lista sin ordenar");
                Console.WriteLine("[5]Ordenar con Burbuja");
                Console.WriteLine("[6]Ordenar con Seleccion Descendente");
                Console.WriteLine("[7]Nota maxima y promedio");
                Console.WriteLine("[8]Salir");
                Console.WriteLine("Ingresar opcion: ");
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Opcion no valida, ingresa un numero");
                    opc = 0;
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        Buscar_estudiante();
                        break;
                    case 3:
                        Modificar_nota();
                        break;
                    case 4:
                        Mostrar();
                        break;
                    case 5:
                        burbuja();
                        Mostrar();
                        break;
                    case 6:
                        Seleccion();
                        Mostrar();
                        break;
                    case 7:
                        nota_max_prom();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta..!!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}

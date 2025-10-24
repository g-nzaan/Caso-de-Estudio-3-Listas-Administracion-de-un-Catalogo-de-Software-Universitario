using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoDeSoftware
{
    class Programa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }

        public Programa(int id, string nombre, string version)
        {
            Id = id;
            Nombre = nombre;
            Version = version;
        }

        public override string ToString()
        {
            return $"ID: {Id:000} | Nombre: {Nombre} | Versión: {Version}";
        }
    }

    class Program
    {
        static void Main()
        {
            List<Programa> catalogo = new List<Programa>
            {
                new Programa(1, "Visual Studio", "2022"),
                new Programa(2, "SQL Server", "2019"),
                new Programa(3, "AutoCAD", "2023")
            };
            int opcion;

            do
            {
                Console.WriteLine("\n--- CATÁLOGO DE SOFTWARE UNIVERSITARIO ---");
                Console.WriteLine("1. Agregar programa");
                Console.WriteLine("2. Eliminar programa");
                Console.WriteLine("3. Buscar programa por nombre");
                Console.WriteLine("4. Mostrar todos los programas");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Debe ingresar un número entre 1 y 5.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarPrograma(catalogo);
                        break;
                    case 2:
                        EliminarPrograma(catalogo);
                        break;
                    case 3:
                        BuscarPrograma(catalogo);
                        break;
                    case 4:
                        MostrarCatalogo(catalogo);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción fuera de rango. Intente de nuevo.");
                        break;
                }

            } while (opcion != 5);
        }

        static void AgregarPrograma(List<Programa> catalogo)
        {
            int id;
            string nombre, version;

            // El ID se genera automáticamente como el siguiente número consecutivo, formateado a 3 dígitos
            if (catalogo.Count == 0)
            {
                id = 4; // Inicia desde 004
            }
            else
            {
                id = catalogo.Max(p => p.Id) + 1;
            }
            Console.WriteLine($"ID asignado automáticamente: {id:000}");

            do
            {
                Console.Write("Ingrese el nombre del programa: ");
                nombre = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(nombre))
                    Console.WriteLine("El nombre no puede estar vacío.");
            } while (string.IsNullOrEmpty(nombre));

            do
            {
                Console.Write("Ingrese la versión del programa: ");
                version = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(version))
                    Console.WriteLine("La versión no puede estar vacía.");
            } while (string.IsNullOrEmpty(version));

            catalogo.Add(new Programa(id, nombre, version));
            Console.WriteLine("Programa agregado correctamente.");
        }

        static void EliminarPrograma(List<Programa> catalogo)
        {
            if (catalogo.Count == 0)
            {
                Console.WriteLine("No hay programas para eliminar.");
                return;
            }

            Console.Write("Ingrese el ID del programa a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Programa programa = catalogo.Find(p => p.Id == id);

                if (programa != null)
                {
                    catalogo.Remove(programa);
                    Console.WriteLine("Programa eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró un programa con ese ID.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debe ingresar un número entero.");
            }
        }

        static void BuscarPrograma(List<Programa> catalogo)
        {
            if (catalogo.Count == 0)
            {
                Console.WriteLine("No hay programas registrados.");
                return;
            }

            Console.Write("Ingrese el nombre del programa a buscar: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            List<Programa> resultados = catalogo.FindAll(p => p.Nombre.ToLower().Contains(nombre.ToLower()));

            if (resultados.Count > 0)
            {
                Console.WriteLine("\nResultados de búsqueda:");
                foreach (var programa in resultados)
                {
                    Console.WriteLine(programa);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron programas con ese nombre.");
            }
        }

        static void MostrarCatalogo(List<Programa> catalogo)
        {
            if (catalogo.Count == 0)
            {
                Console.WriteLine("El catálogo está vacío.");
            }
            else
            {
                Console.WriteLine("\n--- LISTA DE PROGRAMAS REGISTRADOS ---");
                foreach (var programa in catalogo)
                {
                    Console.WriteLine(programa);
                }
            }
        }
    }
}
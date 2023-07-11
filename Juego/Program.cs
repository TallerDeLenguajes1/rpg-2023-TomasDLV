using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using clasePokemon;
using claseMoves;
using Personajes;
using Pantalla;


class Program
{
    static void Main(string[] args)
    {
        EntrenadoresJson listaDeEntrenadores = new EntrenadoresJson();
        listaDeEntrenadores.LeerEntrenadores();
        Entrenador player = new Entrenador();

        string opcion;
        do
        {
            pantallaInicio.MostrarMenuDeInicio();

            Console.Write("Selecciona una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Has seleccionado la opción de cargar entrenador.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    // Aquí llamo a la función correspondiente para cargar entrenador
                    pantallaInicio.MostrarMenuDeCarga();
                    player = listaDeEntrenadores.SeleccionarEntrenador();
                    if (player != null)
                    {
                        //jugar
                    }else
                    {
                        Console.WriteLine("VOLVIENDO AL INICIO...");
                        Thread.Sleep(2000);
                    }
                    break;
                case "2":
                    Console.WriteLine("Has seleccionado la opción de nuevo entrenador.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    // Aquí llamo a la función correspondiente para crear un nuevo entrenador
                    Entrenador nuevo = new Entrenador();
                    nuevo = CrearEntrenador.CrearEntrenadorPlayer();
                    Thread.Sleep(4000);
                    listaDeEntrenadores.GuardarEntrenador(nuevo);
                    break;
                case "3":
                    Console.WriteLine("Gracias por jugar a Pokemon Battle Console. ¡Hasta luego!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, selecciona una opción válida.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }

            Console.WriteLine();

        } while (opcion != "3");


    }
}


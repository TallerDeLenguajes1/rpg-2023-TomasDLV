using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using clasePokemon;
using claseMoves;
using Personajes;
using claseJugar;
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
                        Console.WriteLine("¡Bienvenido, " + player.Apodo + "!");
                        Thread.Sleep(2000);
                        if (Jugar(player) == 1)
                        {
                            Console.WriteLine("Guardando partida...");
                            Thread.Sleep(2000);
                            listaDeEntrenadores.GuardarEntrenador(player);
                            Console.WriteLine("Partida guardada exitosamente.");
                            Thread.Sleep(2000);
                            Console.WriteLine("Volviendo atrás...");
                        }
                        else
                        {
                            Console.WriteLine("Volviendo atrás...");
                            Thread.Sleep(2000);
                        }

                    }
                    else
                    {
                        Console.WriteLine("VOLVIENDO AL INICIO...");
                        Thread.Sleep(2000);
                    }

                    break;
                case "2":
                    Console.WriteLine("Has seleccionado la opción de nuevo entrenador.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    pantallaInicio.MostrarTitulo();
                    Console.WriteLine();
                    // Aquí llamo a la función correspondiente para crear un nuevo entrenador
                    Entrenador nuevo = new Entrenador();
                    nuevo = CrearEntrenador.CrearEntrenadorPlayer();
                    Thread.Sleep(8000);
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
    static int Jugar(Entrenador player)
    {
        string opcion;
        do
        {
            pantallaInicio.MostrarMenuDeJuego();

            Console.Write("Selecciona una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Has seleccionado la opción de iniciar batalla.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    // Aquí puedes implementar la lógica de las batallas
                    // y cualquier otra funcionalidad relacionada con las batallas
                    if (player.Pokemon.Salud == 100)
                    {
                        Batalla.Empezar(player);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine($"{player.Pokemon.Nombre} se encuentra herido, debes llevarlo al Centro Pokemon antes de entrar a la batalla");
                    }
                    Thread.Sleep(2000);
                    break;
                case "2":
                    Console.WriteLine("Has seleccionado la opción de ver estadísticas.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    player.MostrarInformacion();
                    Thread.Sleep(2000);
                    break;
                case "3":
                    string curar;
                    do
                    {
                        pantallaInicio.MostrarTitulo();
                        Console.WriteLine($"¡BIENVENIDO ENTRENADOR {player.Apodo} AL CENTRO POKEMON !");
                        Console.WriteLine($"{player.Pokemon.Nombre} tiene {player.Pokemon.Salud} puntos de Salud");
                        Thread.Sleep(1000);
                        Console.WriteLine("¿Quieres curar a tu Pokemon?");
                        Console.WriteLine("1. Si");
                        Console.WriteLine("2. No");
                        curar = Console.ReadLine().ToLower();

                    } while (curar != "1" && curar != "2");

                    if (curar == "1")
                    {
                        player.Pokemon.Salud = 100;
                        Console.WriteLine("");
                        Console.WriteLine($"{player.Pokemon.Nombre} Ha recibido atención médica");
                        Console.WriteLine("¡Tu Pokemon ha sido curado!");
                        Thread.Sleep(3000);
                    }
                    break;

                case "4":
                    return 1;
                case "5":
                    return 0;
                default:
                    Console.WriteLine("Opción inválida. Por favor, selecciona una opción válida.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
        } while (opcion != "5" || opcion != "4");
        return 0;
    }
}


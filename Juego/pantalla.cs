namespace pantalla
{
    class pantallaInicio{
        static void MostrarMenuDeSeleccion(){
            string opcion;

            Console.Clear();
            Console.WriteLine("*********************");
            Console.WriteLine("Pokemon Battle Console");
            Console.WriteLine("*********************");
            Console.WriteLine();
            Console.WriteLine("1. Cargar entrenador");
            Console.WriteLine("2. Nuevo entrenador");
            Console.WriteLine("3. Salir del juego");
            do
            {
                Console.Write("Selecciona una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Has seleccionado la opción de cargar entrenador.");
                        // Aquí puedes llamar a la función correspondiente para cargar entrenador
                        break;
                    case "2":
                        Console.WriteLine("Has seleccionado la opción de nuevo entrenador.");
                        // Aquí puedes llamar a la función correspondiente para crear un nuevo entrenador
                        break;
                    case "3":
                        Console.WriteLine("Gracias por jugar a Pokemon Battle Console. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, selecciona una opción válida.");
                        break;
                }

                Console.WriteLine();

            } while (opcion != "3");
        }
        static void MostrarMenuDeJuego(){

        }
    }
}
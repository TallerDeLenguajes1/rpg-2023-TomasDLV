namespace Pantalla
{
    public class pantallaInicio
    {
        public static void MostrarTitulo()
        {
            Console.Clear();
            Console.WriteLine("*********************");
            Console.WriteLine("Pokemon Battle Console");
            Console.WriteLine("*********************");
            Console.WriteLine();
            
        }
        public static void MostrarMenuDeInicio()
        {
            MostrarTitulo();
            Console.WriteLine("1. Cargar entrenador");
            Console.WriteLine("2. Nuevo entrenador");
            Console.WriteLine("3. Salir del juego");
        }
        public static void MostrarMenuDeCarga()
        {
            MostrarTitulo();
            Console.WriteLine("0. Volver atras");
            Console.WriteLine("");
        }
        public static void MostrarMenuDeJuego()
        {
            MostrarTitulo();
            Console.WriteLine("----- MENU DE JUEGO -----");
            Console.WriteLine("1. Iniciar batalla");
            Console.WriteLine("2. Ver estadísticas");
            Console.WriteLine("3. Ir al Centro Pokemon");
            Console.WriteLine("4. Guardar y Salir");
            Console.WriteLine("5. Volver atrás");
            Console.WriteLine("-------------------------");
        }
    }
}
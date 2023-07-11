using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using clasePokemon;
using claseMoves;
namespace Personajes
{
    public enum listaCiudades
    {
        PuebloPaleta,
        CiudadVerde,
        CiudadPlateada,
        CiudadCeleste,
        CiudadCarmin,
        PuebloLavanda,
        CiudadAzulona,
        CiudadFucsia,
        CiudadAzafran,
        IslaCanela
    }

    public enum listaPokemonInicio
    {
        squirtle,
        charmander,
        bulbasaur,
        pikachu
    }

    public enum listaEntrenadores
    {
        LasGemelas,
        PokeChica,
        ElPayaso,
        ElPescador,
        ElMecanico,
        Brock,
        Misty,
        ElTenienteSurge,
        Erika,
        Agatha,
        Norman,
        Roco,
        Lino,
        Lotto
    }
    class Entrenador
    {
        private string apodo;
        private int edad;
        private string ciudad;
        private DateTime fechaNac;
        private PokemonInfo pokemon;
        private int victorias;
        private int derrotas;

        public string Apodo { get => apodo; set => apodo = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        internal PokemonInfo Pokemon { get => pokemon; set => pokemon = value; }
        public int Victorias { get => victorias; set => victorias = value; }
        public int Derrotas { get => derrotas; set => derrotas = value; }
        public void MostrarInformacion()
        {
            Console.WriteLine("Información del Entrenador:");
            Console.WriteLine("Apodo: " + Apodo);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Ciudad: " + Ciudad);
            Console.WriteLine("Fecha de Nacimiento: " + FechaNac.ToString("yyyy-MM-dd"));

            Console.WriteLine("Información del Pokémon:");
            pokemon.MostrarDatosPokemon();
        }
    }
    class PokemonInfo
    {
        private int id;
        private string nombre;
        private string tipo;
        private int velocidad;//1 a 10
        private int destreza;//1 a 5
        private int fuerza;//1 a 10
        private int nivel;//1 a 10
        private int armadura;//1 a 10
        private int salud;//100
        private List<string> movimientosPosibles;
        private List<string> movimientosActuales;


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
        public List<string> MovimientosPosibles { get => movimientosPosibles; set => movimientosPosibles = value; }
        public List<string> MovimientosActuales { get => movimientosActuales; set => movimientosActuales = value; }
        public void MostrarDatosPokemon()
        {
            Console.WriteLine("---Detalles del Pokémon---");
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nivel: " + Nivel);
            Console.WriteLine("Velocidad: " + Velocidad);
            Console.WriteLine("Destreza: " + Destreza);
            Console.WriteLine("Fuerza: " + Fuerza);
            Console.WriteLine("Armadura: " + Armadura);
            Console.WriteLine("Salud: " + Salud);

            Console.WriteLine("Movimientos Actuales:");
            foreach (var movimiento in MovimientosActuales)
            {
                Console.WriteLine(movimiento);
            }
        }
    }
    class EntrenadoresJson
    {
        private List<Entrenador> listEntrenadores;
        public string NombreArchivo = "entrenadores.json";

        internal List<Entrenador> ListEntrenadores { get => listEntrenadores; set => listEntrenadores = value; }

        public void LeerEntrenadores()
        {
            ListEntrenadores = new List<Entrenador>();
            if (File.Exists(NombreArchivo) && new FileInfo(NombreArchivo).Length > 0)
            {
                string json = File.ReadAllText(NombreArchivo);
                ListEntrenadores = JsonSerializer.Deserialize<List<Entrenador>>(json);
            }
        }
        public void GuardarEntrenador(Entrenador entrenador)
        {
            // Primero, quitamos el entrenador existente de la lista
            ListEntrenadores.RemoveAll(e => e.Apodo == entrenador.Apodo);

            // Luego, actualizamos los datos del entrenador en la lista
            ListEntrenadores.Add(entrenador);

            // Finalmente, guardamos la lista actualizada en el archivo JSON
            string contenido = JsonSerializer.Serialize(ListEntrenadores);
            File.WriteAllText(NombreArchivo, contenido);
        }
        public Entrenador SeleccionarEntrenador()
        {
            Console.WriteLine("Entrenadores disponibles:");
            int posicion = 1;
            foreach (var entrenador in ListEntrenadores)
            {
                Console.WriteLine($"#{posicion} - Entrenador: {entrenador.Apodo}");
                Console.WriteLine($"    Pokemon: {entrenador.Pokemon.Nombre}");
                Console.WriteLine($"    Nivel: {entrenador.Pokemon.Nivel}");
                Console.WriteLine();
                posicion++;
            }

            while (true)
            {
                Console.Write("Seleccione un entrenador (número): ");
                if (int.TryParse(Console.ReadLine(), out int seleccion))
                {
                    if (seleccion == 0)
                    {
                        return null; // Retorna null para indicar "Volver atrás"
                    }

                    if (seleccion >= 1 && seleccion <= ListEntrenadores.Count)
                    {
                        return ListEntrenadores[seleccion - 1];
                    }
                }

                Console.WriteLine("Selección inválida. Intente nuevamente.");
            }
        }
    }
    class CrearEntrenador
    {
        Random rand = new Random();

        public Entrenador CrearEntrenadorRival(Entrenador player)
        {
            var PJ = new Entrenador();
            PJ.Apodo = Enum.GetName(typeof(listaEntrenadores), rand.Next(1, Enum.GetNames(typeof(listaEntrenadores)).Length));
            PJ.FechaNac = ObtenerFechaNacimientoAleatoria();
            PJ.Edad = DateTime.Today.Year - PJ.FechaNac.Year;
            PJ.Ciudad = Enum.GetName(typeof(listaCiudades), rand.Next(1, Enum.GetNames(typeof(listaCiudades)).Length));
            PJ.Pokemon = CrearPokemon.CrearPokemonAleatorio(player.Pokemon);
            PJ.Victorias = rand.Next(5, 55);
            PJ.Derrotas = rand.Next(5, 55);
            return PJ;
        }
        public static Entrenador CrearEntrenadorPlayer()
        {
            var PJ = new Entrenador();

            Console.Write("Ingrese el apodo del entrenador: ");
            PJ.Apodo = Console.ReadLine();

            Console.Write("Ingrese la ciudad del entrenador: ");
            PJ.Ciudad = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del entrenador (yyyy-MM-dd): ");
            DateTime fechaNac;

            do
            {
                if (!DateTime.TryParse(Console.ReadLine(), out fechaNac))
                {
                    Console.WriteLine("Fecha inválida. Intente nuevamente.");
                }
            } while (fechaNac == default(DateTime));

            PJ.FechaNac = fechaNac;
            PJ.Edad = DateTime.Today.Year - PJ.FechaNac.Year;
            PJ.Victorias = 0;
            PJ.Derrotas = 0;

            PJ.Pokemon = CrearPokemon.CrearPokemonInicio();

            return PJ;
        }
        public DateTime ObtenerFechaNacimientoAleatoria()
        {
            DateTime fechaMin = new DateTime(1970, 1, 1);
            int rango = (DateTime.Today - fechaMin).Days;
            return fechaMin.AddDays(rand.Next(rango));
        }

    }
    class CrearPokemon
    {
        Random rand = new Random();



        public static PokemonInfo CrearPokemonAleatorio(PokemonInfo pokemonPlayer)
        {
            Random rand = new Random();
            var pokeApi = new PokemonApi();
            pokeApi = GetPokemon((rand.Next(1, 151)).ToString());
            var pokemon = new PokemonInfo();
            pokemon.Nombre = pokeApi.Name;
            pokemon.Id = pokeApi.Id;
            pokemon.Velocidad = CalcularValorAleatorio(pokemonPlayer.Velocidad);
            pokemon.Destreza = CalcularValorAleatorio(pokemonPlayer.Destreza);
            pokemon.Fuerza = CalcularValorAleatorio(pokemonPlayer.Fuerza);
            pokemon.Nivel = CalcularValorAleatorio(pokemonPlayer.Nivel);
            pokemon.Armadura = CalcularValorAleatorio(pokemonPlayer.Armadura);
            pokemon.Salud = 100;

            var movesActuales = new List<Move>();
            movesActuales = pokeApi.Moves.OrderBy(x => Guid.NewGuid()).Take(4).ToList();

            var listaMoves = new List<string>();
            foreach (var move in pokeApi.Moves)
            {
                listaMoves.Add(move.MoveInfo.Name);
            }
            var listaMovActuales = new List<string>();
            foreach (var move in movesActuales)
            {
                listaMovActuales.Add(move.MoveInfo.Name);
            }
            pokemon.MovimientosPosibles = listaMoves;
            pokemon.MovimientosActuales = listaMovActuales;
            return pokemon;
        }
        private static int CalcularValorAleatorio(int valorBase)
        {
            Random rand = new Random();
            double rangoMin = valorBase * 0.85; // Rango mínimo = 85% del valor base
            double rangoMax = valorBase * 1.15; // Rango máximo = 115% del valor base

            return rand.Next((int)rangoMin, (int)rangoMax + 1);
        }
        public static PokemonInfo CrearPokemonInicio()
        {
            Random rand = new Random();

            var pokeApi = new PokemonApi();
            pokeApi = GetPokemon(Enum.GetName(typeof(listaPokemonInicio), rand.Next(1, Enum.GetNames(typeof(listaPokemonInicio)).Length)));
            var pokemon = new PokemonInfo();
            pokemon.Nombre = pokeApi.Name;
            pokemon.Id = pokeApi.Id;
            pokemon.Velocidad = rand.Next(1, 10);
            pokemon.Destreza = rand.Next(1, 5);
            pokemon.Fuerza = rand.Next(1, 10);
            pokemon.Nivel = 1;
            pokemon.Armadura = rand.Next(1, 10);
            pokemon.Salud = 100;


            var movesActuales = new List<Move>();
            movesActuales = pokeApi.Moves.OrderBy(x => Guid.NewGuid()).Take(4).ToList();

            var listaMoves = new List<string>();
            foreach (var move in pokeApi.Moves)
            {
                listaMoves.Add(move.MoveInfo.Name);
            }
            var listaMovActuales = new List<string>();
            foreach (var move in movesActuales)
            {
                listaMovActuales.Add(move.MoveInfo.Name);
            }
            pokemon.MovimientosPosibles = listaMoves;
            pokemon.MovimientosActuales = listaMovActuales;

            Console.WriteLine("¡Se ha abierto la Pokébola!");
            Console.WriteLine("Has obtenido un Pokémon:");
            pokemon.MostrarDatosPokemon();

            return pokemon;
        }
        public static PokemonApi GetPokemon(string name)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{name}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        return JsonSerializer.Deserialize<PokemonApi>(responseBody);
                    }
                }
            }
        }
        public static MoveApi GetMove(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        return JsonSerializer.Deserialize<MoveApi>(responseBody);
                    }
                }
            }
        }
    }


}
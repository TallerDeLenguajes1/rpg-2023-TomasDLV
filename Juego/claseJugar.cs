using clasePokemon;
using claseMoves;
using Personajes;
using Pantalla;
namespace claseJugar
{

    class Batalla
    {
        public static void Empezar(Entrenador player)
        {
            Entrenador rival = new Entrenador();
            rival = CrearEntrenador.CrearEntrenadorRival(player);
            int bandera = 0;

            PokemonInfo pPlayer = player.Pokemon;
            PokemonInfo pRival = rival.Pokemon;

            ComentariosDeBatalla.ComentarInicio(player, rival);

            while (pPlayer.Salud > 0 && pRival.Salud > 0)
            {

                Batalla.Atacar(pPlayer, pRival);

                if (pRival.Salud > 0)
                {
                    Batalla.Atacar(pRival, pPlayer);

                    if (pPlayer.Salud <= 0)
                    {
                        Console.WriteLine($"Ganador... {pRival.Nombre} !!");
                        bandera = 0;
                    }
                }
                else
                {
                    Console.WriteLine($"Ganador... {pPlayer.Nombre} !!");
                    bandera = 1;
                }
            }
            if (bandera == 1)
            {
                Console.WriteLine($"Enhorabuena Entrenador {player.Apodo}!!");
                Console.WriteLine($"Has ganado la Batalla contra el entrenador {rival.Apodo}");
                player.Pokemon.Salud = player.Pokemon.SaludMax;
                player.Victorias++;
                player.Pokemon.XpActual += 25;
                Console.WriteLine($"{player.Pokemon.Nombre} ha recibido 25 puntos de Experiencia y su Salud se ha reestablecido");

            }
            else
            {
                Console.WriteLine($"La proxima Batalla sera tuya Entrenador {player.Apodo}!!");
                player.Derrotas++;
                player.Pokemon.XpActual += 10;
                Console.WriteLine($"{player.Pokemon.Nombre} ha recibido 10 puntos de Experiencia");
                Console.WriteLine($"{player.Pokemon.Nombre} se encuentra herido");
                Console.WriteLine($"Recuerda llevar a {player.Pokemon.Nombre} al Centro Pokemon");


            }
            player.Pokemon.BonificarNivel();
            pantallaInicio.PresionarParaContinuar();
        }
        public static void Atacar(PokemonInfo atacante, PokemonInfo defensor)
        {
            Random rand = new Random();
            int efectividad = rand.Next(1, 100);
            int ataque = atacante.Destreza * atacante.Fuerza ;//* atacante.Nivel;
            int defensa = defensor.Armadura * defensor.Velocidad;

            double Ajuste = (double)defensor.SaludMax/(ataque*100-defensa);
            int dañoProvocado = (int)(((ataque * efectividad) - defensa) * (Ajuste));

            if (dañoProvocado < 0)
            {
                dañoProvocado = 0;
            }

            defensor.Salud -= dañoProvocado;

            if (defensor.Salud < 0)
            {
                defensor.Salud = 0;
            }


            ComentariosDeBatalla.ComentarAtaque(atacante, dañoProvocado);


        }
        public static class ComentariosDeBatalla
        {
            private static List<string> comentariosAtaque = new List<string>()
        {
            "¡{0} ha realizado un ataque {1} causando {2} de daño!",
            "{0} utilizó su ataque {1} y causó {2} de daño.",
            "¡El ataque {1} de {0} fue exitoso! Causó {2} de daño.",
            "¡{0} ha lanzado un poderoso ataque {1}! {2} puntos de daño causados."
        };

            private static Random rand = new Random();

            public static void ComentarAtaque(PokemonInfo atacante, int daño)
            {
                string comentario = comentariosAtaque[rand.Next(comentariosAtaque.Count)];
                string movimientoUtilizado = atacante.MovimientosActuales[rand.Next(atacante.MovimientosActuales.Count)];
                Console.WriteLine("");
                Console.WriteLine(string.Format(comentario, atacante.Nombre, movimientoUtilizado, daño));
                Console.WriteLine("");
                Thread.Sleep(3000);
            }
            public static void ComentarInicio(Entrenador atacante, Entrenador defensor)
            {
                pantallaInicio.MostrarTitulo();
                Console.WriteLine("¡La batalla está por comenzar!");
                Console.WriteLine($"{atacante.Apodo} se enfrentará a {defensor.Apodo}.");

                Console.WriteLine("");
                Console.WriteLine($"{atacante.Apodo} tiene un Pokémon poderoso: {atacante.Pokemon.Nombre}");
                Console.WriteLine($"Nivel: {atacante.Pokemon.Nivel}");
                Console.WriteLine($"Victorias: {atacante.Victorias}");
                Console.WriteLine($"Derrotas: {atacante.Derrotas}");

                Console.WriteLine("");
                Console.WriteLine($"{defensor.Apodo} ha preparado a su Pokémon: {defensor.Pokemon.Nombre}");
                Console.WriteLine($"Nivel: {defensor.Pokemon.Nivel}");
                Console.WriteLine($"Victorias: {defensor.Victorias}");
                Console.WriteLine($"Derrotas: {defensor.Derrotas}");

                Console.WriteLine("");
                Console.WriteLine("¡Que comience la batalla!");

                pantallaInicio.PresionarParaContinuar();
            }
        }

    }



}
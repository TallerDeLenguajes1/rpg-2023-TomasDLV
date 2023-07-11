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
            PokemonInfo pRival = player.Pokemon;
            while (pPlayer.Salud > 0 && pRival.Salud > 0)
            {

                pPlayer.Atacar(pRival);
                if (pRival.Salud > 0)
                {
                    pRival.Atacar(pPlayer);
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
                player.Pokemon.Salud = 100;
                player.Victorias++;
                Console.WriteLine($"{player.Pokemon.Nombre} ha recibido experiencia y su Salud se ha reestablecido");
            }else
            {
                Console.WriteLine($"La proxima Batalla sera tuya Entrenador {player.Apodo}!!");
                Console.WriteLine($"{player.Pokemon.Nombre} se encuentra herido");
                Console.WriteLine($"Recuerda llevar a {player.Pokemon.Nombre} al Centro Pokemon");
                player.Derrotas++;
                
            }
        }
    }

}
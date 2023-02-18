using RPG_Game.Services;
using System;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var gameService = new GamesService();
            var game = new Game(gameService);

            game.Run();
        }
    }
}

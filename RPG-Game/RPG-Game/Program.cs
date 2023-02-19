using RPG_Game.Services;
using System;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var db = new ApplicationDbContext();
            var gameService = new GamesService(db);
            var game = new Game(gameService);
            game.Run();
        }
    }
}

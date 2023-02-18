using RPG_Game.Models;
using RPG_Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Game
    {
        private readonly IGamesService gamesService;

        public Game(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public void Run()
        {

            this.gamesService.PrintWelcomeMessage();

            var character = this.gamesService.SelectCharacter();

            this.gamesService.BuffCharacter(character);

        }
    }
}

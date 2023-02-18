using RPG_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Services
{
    public interface IGamesService
    {
        public void PrintWelcomeMessage();

        public Character SelectCharacter();

        public void BuffCharacter(Character character);

    }
}

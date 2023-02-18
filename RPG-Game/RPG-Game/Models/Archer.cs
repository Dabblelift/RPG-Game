using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public class Archer : Character
    {
        public Archer()
        {
            this.Race = Enums.Race.Archer;
            this.Strength = 2;
            this.Agility = 4;
            this.Intelligence = 0;
            this.Range = 2;
            this.FieldSymbol = '#';
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public class Mage : Character
    {
        public Mage() : base()
        {
            this.Race = Enums.Race.Mage;
            this.Strength = 2;
            this.Agility = 1;
            this.Intelligence = 3;
            this.Range = 3;
            this.FieldSymbol = '*';
        }
    }
}

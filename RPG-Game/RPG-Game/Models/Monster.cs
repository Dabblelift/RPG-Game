using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public class Monster : Character
    {
        public Monster()
        {
            var random = new Random(); 
            this.Race = Enums.Race.Monster;
            this.Strength = random.Next(1, 4);
            this.Agility = random.Next(1, 4);
            this.Intelligence = random.Next(1, 4);
            this.Range = 1;
            this.FieldSymbol = '◙';
            this.Setup();
        }
    }
}

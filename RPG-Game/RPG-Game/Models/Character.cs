using RPG_Game.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public abstract class Character
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Race Race { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public char FieldSymbol { get; set; }

        [NotMapped]
        public int CoordinateX { get; set; }
        [NotMapped]
        public int CoordinateY { get; set; }

        public Character()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.Now;
        }
        public void Setup() 
        {
            this.Health = this.Strength * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }


    }
}

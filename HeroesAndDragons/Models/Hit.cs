using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class Hit
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Power { get; set; }
        public Hero Hero { get; set; }
        public Dragon Dragon { get; set; }

        public Hit()
        {
            Power = Hero.Weapon + new Random().Next(1, 3);
        }
    }
}

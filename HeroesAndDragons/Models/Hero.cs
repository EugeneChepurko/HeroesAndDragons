using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class Hero
    {
        private static Random random = new Random();

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Weapon { get; set; }
        public DateTime Date { get; set; }

        public Hero()
        {
            Date = DateTime.Now;
            Weapon = random.Next(1, 6);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace HeroesAndDragons.Models
{
    public class Dragon
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Имя не указано.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Длина имени должна быть от 4 до 20 символов.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int HitPoint { get; set; }
        public DateTime Date { get; set; }

        public Dragon()
        {
            HitPoint = new Random().Next(80, 100);
        }
    }
}

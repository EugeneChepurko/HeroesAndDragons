using HeroesAndDragons.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class Hero /*: IValidatableObject*/
    {
        private static Random random = new Random();

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Имя не указано.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Длина имени должна быть от 4 до 20 символов.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int Weapon { get; set; }
        public DateTime Date { get; set; }

        public Hero()
        {
            Date = DateTime.Now;
            Weapon = random.Next(1, 6);
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> errors = new List<ValidationResult>();
        //    if (this.Name || this.Age > 120)
        //    {
        //        errors.Add(new ValidationResult("Недопустимый возраст!"));
        //    }

        //    return errors;
        //}
    }  
}

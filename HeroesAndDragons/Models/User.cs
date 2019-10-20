using Microsoft.AspNetCore.Identity;
using System;

namespace HeroesAndDragons.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
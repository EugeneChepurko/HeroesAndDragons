﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class User : IdentityUser
    {
        //public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
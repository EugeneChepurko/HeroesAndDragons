﻿using HeroesAndDragons.Controllers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class HeroNameValidator : IUserValidator<Hero>
    {
        private readonly DataContext db;
        public HeroNameValidator(DataContext db)
        {
            this.db = db;
        }

        public Task<IdentityResult> ValidateAsync(UserManager<Hero> manager, Hero hero)
        {
            var errors = new List<IdentityError>();
            var findHero = db.Heroes.FirstOrDefault(n => n.Name == hero.Name);

            if (hero.Name.StartsWith(" ") || hero.Name.EndsWith(" "))
            {
                errors.Add(new IdentityError
                {
                    Description = "Имя не может начинаться или заканчиваться пробелом."
                });
            }

            if (hero.Name == findHero.Name)
            {
                errors.Add(new IdentityError
                {
                    Description = "Такое имя уже существует."
                });
            }

            return Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}

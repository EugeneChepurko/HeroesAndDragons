using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Models
{
    public class UserNameValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            string findUser = manager?.FindByNameAsync(user.UserName)?.Result?.UserName;
            var errors = new List<IdentityError>();
            if(user.UserName.StartsWith(" ") || user.UserName.EndsWith(" "))
            {
                errors.Add(new IdentityError
                {
                    Description = "Имя не может начинаться или заканчиваться пробелом."
                });
            }

            if(user.UserName == findUser)
            {
                errors.Add(new IdentityError
                {
                    Description = "Такое имя уже существует."
                });
            }

            if(user.UserName.Contains("admin"))
            {
                errors.Add(new IdentityError
                {
                    Description = $"Имя не может содержать - 'admin'"
                });
            }

            if(user.Email.Contains("admin"))
            {
                errors.Add(new IdentityError
                {
                    Description = $"Email не может содержать - 'admin'"
                });
            }
            return Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}

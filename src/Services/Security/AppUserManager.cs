using Data.EF.Context;
using Domain.Acessos.Entitites;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security
{
    public class AppUserManager :
        UserManager<UsuarioEntity, string>
    {
        public UserStore<UsuarioEntity> _userStore;

        public AppUserManager()
            : base(new UserStore<UsuarioEntity>(new IdentityContext()))
        {
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
        }
    }
}

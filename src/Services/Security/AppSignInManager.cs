using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Domain.Acessos.Entitites;

namespace Services.Security
{
    public class AppSignInManager : SignInManager<UsuarioEntity, string>
    {
        public AppSignInManager(IAuthenticationManager authenticationManager)
            : base(new AppUserManager(), authenticationManager)
        {}
    }
}

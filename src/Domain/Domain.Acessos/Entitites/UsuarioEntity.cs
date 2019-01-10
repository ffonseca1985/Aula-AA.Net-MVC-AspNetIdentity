using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Acessos.Entitites
{
    public class UsuarioEntity 
        : IdentityUser
    {
        //Colocar mais propriedades
        public bool Ativo { get; set; }
    }
}

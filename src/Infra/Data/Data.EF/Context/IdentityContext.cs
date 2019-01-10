using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Domain.Acessos.Entitites;

namespace Data.EF.Context
{
    public class IdentityContext 
        : IdentityDbContext<UsuarioEntity>
    {
        public IdentityContext()
            : base("DbIdentity1"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioEntity>()
                .ToTable("Usuarios");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UsuariosExternos");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UsuariosRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("Claims");
        }
    }
}

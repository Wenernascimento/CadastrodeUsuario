using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastrodeUsuario.Models;

namespace CadastrodeUsuario.Data
{
    public class CadastrodeUsuarioContext : DbContext
    {
        public CadastrodeUsuarioContext (DbContextOptions<CadastrodeUsuarioContext> options)
            : base(options)
        {
        }

        public DbSet<CadastrodeUsuario.Models.Usuario> Usuario { get; set; } = default!;
    }
}

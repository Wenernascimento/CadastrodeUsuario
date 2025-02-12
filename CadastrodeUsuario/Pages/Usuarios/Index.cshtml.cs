using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CadastrodeUsuario.Data;
using CadastrodeUsuario.Models;

namespace CadastrodeUsuario.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly CadastrodeUsuario.Data.CadastrodeUsuarioContext _context;

        public IndexModel(CadastrodeUsuario.Data.CadastrodeUsuarioContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuario = await _context.Usuario.ToListAsync();
        }
    }
}

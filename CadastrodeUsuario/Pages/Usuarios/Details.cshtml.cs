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
    public class DetailsModel : PageModel
    {
        private readonly CadastrodeUsuario.Data.CadastrodeUsuarioContext _context;

        public DetailsModel(CadastrodeUsuario.Data.CadastrodeUsuarioContext context)
        {
            _context = context;
        }

        public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                Usuario = usuario;
            }
            return Page();
        }
    }
}

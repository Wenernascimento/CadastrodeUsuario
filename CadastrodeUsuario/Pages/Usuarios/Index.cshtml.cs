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

        public IList<Usuario> Usuario { get; set; } = default!;
        public string SearchTerm { get; set; } = string.Empty;  // Para armazenar o termo de pesquisa

        public async Task OnGetAsync(string searchTerm)
        {
            SearchTerm = searchTerm ?? string.Empty;

            // Verifica se há um termo de pesquisa e faz a comparação sem distinguir maiúsculas/minúsculas
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Usuario = await _context.Usuario
                    .Where(u => EF.Functions.Like(u.Name.ToLower(), "%" + SearchTerm.ToLower() + "%"))  // Realiza a comparação ignorando maiúsculas/minúsculas
                    .ToListAsync();
            }
            else
            {
                // Caso contrário, traz todos os usuários
                Usuario = await _context.Usuario.ToListAsync();
            }
        }

    }
}

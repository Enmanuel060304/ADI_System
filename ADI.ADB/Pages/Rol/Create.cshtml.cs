using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.modelos;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Pages.Rol
{
    public class CreateModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public CreateModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public modelos.Rol Rol { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var existingRole = await _context.Rols
                .FirstOrDefaultAsync(r => r.Nombre == Rol.Nombre);

            if (existingRole != null)
            {
                // Si el rol ya existe, agregar un error al ModelState y volver a la página
                ModelState.AddModelError("Rol.Nombre", "Ya existe un rol con este nombre.");
                return Page();
            }

            _context.Rols.Add(Rol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.Migrations;
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
        public Migrations.Rol Rol { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Rols.Add(Rol);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Error al agregar el rol. Ya existe un rol con este nombre.");
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}

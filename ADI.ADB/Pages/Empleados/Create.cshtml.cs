using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.Migrations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Pages.Empleados
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
        ViewData["rol_id"] = new SelectList(_context.Rols, "id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("Empleado.rol_id"))
            {
                return Page();
            }
            try
            {
                _context.Empleados.Add(Empleado);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601) // Número de error para clave duplicada
            {
                ModelState.AddModelError(string.Empty, "Ya existe un empleado con este nombre y otros datos.");
                return Page();
            }

        }
    }
}

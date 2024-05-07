using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Ventas
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
        ViewData["Cliente_id"] = new SelectList(_context.Clientes, "id", "id");
        ViewData["Empleado_id"] = new SelectList(_context.Empleados, "id", "Apellido");
            return Page();
        }

        [BindProperty]
        public ventas ventas { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.venta.Add(ventas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

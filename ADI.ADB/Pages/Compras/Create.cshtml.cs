using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.modelos;

namespace ADI.ADB.Pages.Compras
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
        ViewData["Empleado_id"] = new SelectList(_context.Empleados, "id", "id");
        ViewData["Proveedor_id"] = new SelectList(_context.Proveedors, "id", "id");
            return Page();
        }

        [BindProperty]
        public Compra Compra { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Compras.Add(Compra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

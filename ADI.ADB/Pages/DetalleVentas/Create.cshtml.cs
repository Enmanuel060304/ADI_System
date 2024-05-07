using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.DetalleVentas
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
        ViewData["Producto_id"] = new SelectList(_context.Productos, "id", "id");
        ViewData["Venta_id"] = new SelectList(_context.venta, "id", "id");
            return Page();
        }

        [BindProperty]
        public Migrations.DetalleVentas DetalleVentas { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DetalleVenta.Add(DetalleVentas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

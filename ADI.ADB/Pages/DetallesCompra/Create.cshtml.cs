using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.modelos;

namespace ADI.ADB.Pages.DetallesCompra
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
        ViewData["Compra_id"] = new SelectList(_context.Compras, "id", "id");
        ViewData["Producto_id"] = new SelectList(_context.Productos, "id", "Nombre");
            return Page();
        }

        [BindProperty]
        public DetalleCompra DetalleCompra { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("DetalleCompra.Compra_id"))
            {
                return Page();
            }
            
            if (ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("DetalleCompra.Producto_id"))
            {
                return Page();
            }
            

            _context.DetalleCompras.Add(DetalleCompra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

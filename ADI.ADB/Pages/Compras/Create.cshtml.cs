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
            ViewData["Empleado_id"] = new SelectList(_context.Empleados, "id", "Nombre");
            ViewData["Proveedor_id"] = new SelectList(_context.Proveedors, "id", "Nombre");
            Productos = _context.Productos.ToList();
            return Page();
        }

        
        
        [BindProperty]
        public Compra Compra { get; set; } = default!;
        
        [BindProperty]
       public List<modelos.Producto> Productos { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("Compra.Proveedor_id")
                || ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("Compra.Empleado_id"))
            {
                return Page();
            }
            _context.Compras.Add(Compra);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

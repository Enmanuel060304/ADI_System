using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.modelos;

namespace ADI.ADB.Pages.DetallesCompra
{
    public class EditModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public EditModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetalleCompra DetalleCompra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallecompra =  await _context.DetalleCompras.FirstOrDefaultAsync(m => m.id == id);
            if (detallecompra == null)
            {
                return NotFound();
            }
            DetalleCompra = detallecompra;
           ViewData["Compra_id"] = new SelectList(_context.Compras, "id", "id");
           ViewData["Producto_id"] = new SelectList(_context.Productos, "id", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DetalleCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCompraExists(DetalleCompra.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DetalleCompraExists(Guid id)
        {
            return _context.DetalleCompras.Any(e => e.id == id);
        }
    }
}

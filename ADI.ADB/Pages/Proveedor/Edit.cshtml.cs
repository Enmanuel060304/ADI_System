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

namespace ADI.ADB.Pages.Proveedor
{
    public class EditModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public EditModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public modelos.Proveedor Proveedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor =  await _context.Proveedors.FirstOrDefaultAsync(m => m.id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            Proveedor = proveedor;
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

            _context.Attach(Proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(Proveedor.id))
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

        private bool ProveedorExists(Guid id)
        {
            return _context.Proveedors.Any(e => e.id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.DetalleVentas
{
    public class DeleteModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DeleteModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Migrations.DetalleVentas DetalleVentas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventas = await _context.DetalleVenta.FirstOrDefaultAsync(m => m.id == id);

            if (detalleventas == null)
            {
                return NotFound();
            }
            else
            {
                DetalleVentas = detalleventas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventas = await _context.DetalleVenta.FindAsync(id);
            if (detalleventas != null)
            {
                DetalleVentas = detalleventas;
                _context.DetalleVenta.Remove(DetalleVentas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

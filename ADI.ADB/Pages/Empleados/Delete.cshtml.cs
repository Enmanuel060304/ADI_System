using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.modelos;

namespace ADI.ADB.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DeleteModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.id == id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                Empleado = empleado;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                Empleado = empleado;
                _context.Empleados.Remove(Empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

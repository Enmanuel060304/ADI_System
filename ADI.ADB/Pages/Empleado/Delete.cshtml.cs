using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Empleado
{
    public class DeleteModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DeleteModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EMPLEADO EMPLEADO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.EMPLEADOs.FirstOrDefaultAsync(m => m.ID == id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                EMPLEADO = empleado;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.EMPLEADOs.FindAsync(id);
            if (empleado != null)
            {
                EMPLEADO = empleado;
                _context.EMPLEADOs.Remove(EMPLEADO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

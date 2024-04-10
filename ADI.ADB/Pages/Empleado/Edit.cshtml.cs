using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Empleado
{
    public class EditModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public EditModel(ADI.ADB.Context.MyDbContext context)
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

            var empleado =  await _context.EMPLEADOs.FirstOrDefaultAsync(m => m.ID == id);
            if (empleado == null)
            {
                return NotFound();
            }
            EMPLEADO = empleado;
           ViewData["ID_ROLE"] = new SelectList(_context.ROLEs, "ID", "ID");
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

            _context.Attach(EMPLEADO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADOExists(EMPLEADO.ID))
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

        private bool EMPLEADOExists(int id)
        {
            return _context.EMPLEADOs.Any(e => e.ID == id);
        }
    }
}

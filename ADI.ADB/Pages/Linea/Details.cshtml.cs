using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Linea
{
    public class DetailsModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DetailsModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public Migrations.Linea Linea { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Lineas.FirstOrDefaultAsync(m => m.id == id);
            if (linea == null)
            {
                return NotFound();
            }
            else
            {
                Linea = linea;
            }
            return Page();
        }
    }
}

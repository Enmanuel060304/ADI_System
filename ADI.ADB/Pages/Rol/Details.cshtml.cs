using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Rol
{
    public class DetailsModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DetailsModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public Migrations.Rol Rol { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Rols.FirstOrDefaultAsync(m => m.id == id);
            if (rol == null)
            {
                return NotFound();
            }
            else
            {
                Rol = rol;
            }
            return Page();
        }
    }
}

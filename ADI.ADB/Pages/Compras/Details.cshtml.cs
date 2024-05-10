using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.modelos;

namespace ADI.ADB.Pages.Compras
{
    public class DetailsModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DetailsModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public Compra Compra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FirstOrDefaultAsync(m => m.id == id);
            if (compra == null)
            {
                return NotFound();
            }
            else
            {
                Compra = compra;
            }
            return Page();
        }
    }
}

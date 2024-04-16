using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Line
{
    public class DeleteModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public DeleteModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Migrations.Line Line { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines.FirstOrDefaultAsync(m => m.id == id);

            if (line == null)
            {
                return NotFound();
            }
            else
            {
                Line = line;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines.FindAsync(id);
            if (line != null)
            {
                Line = line;
                _context.Lines.Remove(Line);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

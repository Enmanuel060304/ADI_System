using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.VENTAS
{
    public class CreateModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public CreateModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ID_CLIENTE"] = new SelectList(_context.CLIENTEs, "ID", "ID");
        ViewData["ID_EMPLEADO"] = new SelectList(_context.EMPLEADOs, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public VENTum VENTum { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VENTAs.Add(VENTum);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

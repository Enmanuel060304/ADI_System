using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Employee
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
        ViewData["rol_id"] = new SelectList(_context.Rols, "id", "id");
            return Page();
        }

        [BindProperty]
        public Migrations.Employee Employee { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

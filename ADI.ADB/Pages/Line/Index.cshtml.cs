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
    public class IndexModel : PageModel
    {
        private readonly MyDbContext _context;

        public IndexModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<Migrations.Line> Line { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Line = await _context.Lines.ToListAsync();
        }
    }
}

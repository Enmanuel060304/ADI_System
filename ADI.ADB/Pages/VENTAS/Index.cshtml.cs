using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.VENTAS
{
    public class IndexModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public IndexModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<VENTum> VENTum { get;set; } = default!;

        public async Task OnGetAsync()
        {
            VENTum = await _context.VENTAs
                .Include(v => v.ID_CLIENTENavigation)
                .Include(v => v.ID_EMPLEADONavigation).ToListAsync();
        }
    }
}

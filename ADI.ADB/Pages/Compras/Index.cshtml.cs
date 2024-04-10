using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Compras
{
    public class IndexModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public IndexModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<COMPRA> COMPRA { get;set; } = default!;

        public async Task OnGetAsync()
        {
            COMPRA = await _context.COMPRAs
                .Include(c => c.ID_PROVEEDORNavigation)
                .Include(c => c.Id_EMPLEADONavigation).ToListAsync();
        }
    }
}

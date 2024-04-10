using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.Empleado
{
    public class IndexModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public IndexModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<EMPLEADO> EMPLEADO { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EMPLEADO = await _context.EMPLEADOs
                .Include(e => e.ID_ROLENavigation).ToListAsync();
        }
    }
}

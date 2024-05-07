using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADI.ADB.Context;
using ADI.ADB.Migrations;

namespace ADI.ADB.Pages.DetalleCompra
{
    public class IndexModel : PageModel
    {
        private readonly ADI.ADB.Context.MyDbContext _context;

        public IndexModel(ADI.ADB.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<Migrations.DetalleCompra> DetalleCompra { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DetalleCompra = await _context.DetalleCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto).ToListAsync();
        }
    }
}

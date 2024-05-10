using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADI.ADB.Context;
using ADI.ADB.modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Pages.Producto
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
        ViewData["Categoria_id"] = new SelectList(_context.Categoria, "id", "Nombre");
        ViewData["Linea_id"] = new SelectList(_context.Lineas, "id", "Nombre");
            return Page();
        }

        [BindProperty]
        public modelos.Producto Producto { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("Producto.Linea_id"))
            {
                return Page();
            }
            
            if (ModelState is { IsValid: false, Count: not 1 } && !ModelState.ContainsKey("Producto.Categoria_id"))
            {
                return Page();
            }

            _context.Productos.Add(Producto);
            if (Producto.Nombre == null)
            {
                // Si el nombre del producto es NULL, agregar un error al ModelState y volver a la página
                ModelState.AddModelError("Producto.Nombre", "El nombre del producto es obligatorio.");
                ViewData["Categoria_id"] = new SelectList(_context.Categoria, "id", "Nombre");
                ViewData["Linea_id"] = new SelectList(_context.Lineas, "id", "Nombre");
                return Page();
            }
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    // Si el producto ya existe, agregar un error al ModelState y volver a la página
                    ModelState.AddModelError("Producto.Nombre", "Ya existe un producto con este nombre.");
                    ViewData["Categoria_id"] = new SelectList(_context.Categoria, "id", "Nombre");
                    ViewData["Linea_id"] = new SelectList(_context.Lineas, "id", "Nombre");
                    return Page();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

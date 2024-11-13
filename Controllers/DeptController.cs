using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;

namespace web.Controllers
{
    public class DeptController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        // Exemple d'action pour lister les depts
        public async Task<IActionResult> Index()
        {
            var depts = await _context.Depts.ToListAsync();
            return View(depts);
        }
        
        // Exemple d'action pour ajouter un dept
        [HttpPost]
        public async Task<IActionResult> Create(Dept dept)
        {
            if (ModelState.IsValid)
            {
                _context.Depts.Add(dept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }
    }
}

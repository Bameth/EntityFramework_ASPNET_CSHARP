using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;

namespace web.Controllers
{
    public class DetailController : Controller
    {
        private readonly AppDbContext _context;

        public DetailController(AppDbContext context)
        {
            _context = context;
        }

        // Exemple d'action pour lister les details
        public async Task<IActionResult> Index()
        {
            var details = await _context.Details.ToListAsync();
            return View(details);
        }

        // Exemple d'action pour ajouter un detail
        [HttpPost]
        public async Task<IActionResult> Create(Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Details.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }
    }
}

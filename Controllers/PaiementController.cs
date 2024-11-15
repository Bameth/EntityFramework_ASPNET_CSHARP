using Microsoft.AspNetCore.Mvc;
using web.data;
using web.entities;

namespace web.Controllers
{
    public class PaiementController : Controller
    {
        private readonly AppDbContext _context;

        public PaiementController(AppDbContext context)
        {
            _context = context;
        }

        // Action pour effectuer un paiement
        [HttpPost]
        public async Task<IActionResult> PaiementAsync(Paiement Paiement)
        {
            if (ModelState.IsValid)
            {
                _context.Paiements.Add(Paiement);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "  Paiement effectuer avec succès.";

                return RedirectToAction(nameof(Index));
            }
            return View(Paiement);
        }
        // Action pour afficher la liste des paiements
        public IActionResult Index()
        {
            return View(_context.Paiements.ToList());
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;

namespace web.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        // Exemple d'action pour lister les clients
        public IActionResult Index()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
        }

        // Action GET pour afficher le formulaire de création
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Client());
        }


        // Action POST pour soumettre le formulaire de création
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

    }
}

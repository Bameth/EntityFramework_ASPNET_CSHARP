using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;
using web.Models;
using web.services;

namespace web.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IClientService _clientService;
        private const int PageSize = 4;

        public ClientController(AppDbContext context, IClientService clientService)
        {
            _clientService = clientService;
            _context = context;

        }


        public IActionResult Index(int page = 1)
        {
            var totalClients = _context.Clients.Count();  
            var totalPages = (int)Math.Ceiling((double)totalClients / PageSize); 

            var clients = _context.Clients
                .OrderBy(c => c.Id)  
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var model = new ClientPaginationViewModel
            {
                Clients = clients,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        public IActionResult Show(int id)
        {
            var client = _context.Clients
                                 .Include(c => c.Depts)
                                 .FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
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
                await _clientService.Create(client);
                TempData["SuccessMessage"] = "Client ajouté avec succès.";
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }
    }
}

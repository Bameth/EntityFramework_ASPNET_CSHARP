using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;
using web.enums;

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

        // Exemple d'action pour ajouter un client
        [HttpPost]
        public async Task<IActionResult> Create(Client client, string name, string login, string password, bool toggleUser)
        {
            if (ModelState.IsValid)
            {
                if (toggleUser)
                {
                    var user = new User
                    {
                        Name = name,
                        Password = password,
                        Login = login,
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    client.UserId = user.Id;
                }

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        public IActionResult Create()
        {
            return View(new Client());
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;

namespace web.Controllers
{
    public class DeptController : Controller
    {
        private readonly AppDbContext _context;

        public DeptController(AppDbContext context)
        {
            _context = context;
        }

        // Exemple d'action pour lister les depts
        public async Task<IActionResult> Index()
        {
            var depts = await _context.Depts.ToListAsync();
            return View(depts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clients = await _context.Clients.ToListAsync();
            var articles = await _context.Articles.ToListAsync();  
            ViewBag.Clients = clients;
            ViewBag.Articles = articles;  
            return View(new Dept());
        }

        // Action POST pour soumettre le formulaire de création
        [HttpPost]
        public async Task<IActionResult> Create(Dept dept, List<int> selectedArticleIds, List<int> quantities)
        {
            if (ModelState.IsValid)
            {
                double totalAmount = 0;
                for (int i = 0; i < selectedArticleIds.Count; i++)
                {
                    var article = await _context.Articles.FindAsync(selectedArticleIds[i]);
                    if (article != null)
                    {
                        double articlePrice = article.Prix;  
                        int quantity = quantities[i];
                        totalAmount += articlePrice * quantity;

                        dept.Details.Add(new Detail
                        {
                            ArticlesId = article.Id,
                            Qte = quantity,
                            Articles = article
                        });

                        article.QteStock -= quantity;
                        _context.Articles.Update(article);
                    }
                }

                dept.Montant = totalAmount;

                var client = await _context.Clients.FindAsync(dept.Client);
                if (client != null)
                {
                    dept.Client = client;
                }

                _context.Depts.Add(dept);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Dette ajoutée avec succès.";
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;
namespace web.services.impl;

public class PaiementService : IPaiementService
{
    private readonly AppDbContext _context;

    public PaiementService(AppDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId)
    {
        return await _context.Paiements.Where(paiement => paiement.Dept.Id == detteId).ToListAsync();
    }
}
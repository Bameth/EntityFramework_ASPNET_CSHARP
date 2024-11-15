using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;

namespace web.services.impl;

public class DetteService : IDetteService
{

    private readonly AppDbContext _context;

    public DetteService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Dept>> GetDettesClientAsync(int clientId)
    {
        return await _context.Depts
        .Where(dette => dette.Client.Id == clientId)
        .ToListAsync();
    }
}
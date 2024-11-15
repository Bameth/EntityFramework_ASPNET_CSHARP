
using Microsoft.EntityFrameworkCore;
using web.data;
using web.entities;
using web.services;

namespace web.services.impl;

public class ClientService : IClientService
{
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client> Create(Client client)
    {
        
        _context.Clients.Add(client);
        
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }
}
using web.entities;

namespace web.services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> Create(Client client);
}
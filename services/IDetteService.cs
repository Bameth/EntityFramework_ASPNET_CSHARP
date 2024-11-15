using web.entities;

namespace web.services;
public interface IDetteService
{
    Task<IEnumerable<Dept>> GetDettesClientAsync(int clientId);
}
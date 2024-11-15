using web.entities;

namespace web.services;

public interface IPaiementService
{
    Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId);
}
using web.entities;
namespace web.Models
{
    public class ClientPaginationViewModel
    {
        public List<Client>? Clients { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

}
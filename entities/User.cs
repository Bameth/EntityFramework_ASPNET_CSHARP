using web.enums;

namespace web.entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public TypeEtat TypeEtat { get; set; }
        public Client? Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"User {Id} : {Name} - {Login} - {Role} - {TypeEtat}";
        }
    }
}

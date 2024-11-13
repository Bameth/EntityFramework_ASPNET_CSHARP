namespace web.entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<Dept>? Depts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Client()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }


        public override string ToString()
        {
            if (User == null)
            {
                return $"Client {Id} : {Surname} - {Phone} - {Address} - Aucun utilisateur associé";
            }

            return $"Client {Id} : {Surname} - {Phone} - {Address} - {User.Name}";
        }
    }
}
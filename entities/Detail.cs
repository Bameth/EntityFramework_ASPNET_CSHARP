namespace web.entities
{
    public class Detail
    {
        public int Id { get; set; }
        public int Qte { get; set; }
        public int ArticlesId { get; set; }
        public Articles Articles { get; set; }
        public int DeptId { get; set; }
        public Dept Dept { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Detail()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Detail {Id} : {Qte} - {Articles.Libelle} - {Dept} - CreatedAt: {CreatedAt} - UpdatedAt: {UpdatedAt}";
        }
    }
}

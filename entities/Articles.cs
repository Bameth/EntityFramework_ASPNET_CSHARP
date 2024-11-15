namespace web.entities
{
    public class Articles
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public double Prix { get; set; }
        public int QteStock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Articles()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            GenerateReference();
        }

        public void GenerateReference()
        {
            Reference = GenerateNumero(Id, "ART");
        }

        public static string GenerateNumero(int nbre, string format)
        {
            int size = nbre.ToString().Length;
            return format + new string('0', (4 - size) < 0 ? 0 : 4 - size) + nbre;
        }

        public override string ToString()
        {
            return $"Article {Id} : {Reference} - {Libelle} - {Prix} - {QteStock}";
        }
    }
}

namespace web.entities
{
    public class Paiement
    {
        public int Id { get; set; }
        public double Montant { get; set; }
        public DateTime DatePaiement { get; set; }
        public Dept Dept { get; set; }
        public Paiement()
        {
            DatePaiement = DateTime.UtcNow;
        }
        public override string ToString()
        {
            return $"Paiement {Id} : {Montant} - {DatePaiement}  - {Dept}";
        }
    }
}
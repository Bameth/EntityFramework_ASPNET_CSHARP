using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web.enums;

namespace web.entities
{
    public class Dept
    {
        public int Id { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Montant doit être positif.")]
        public double Montant { get; set; }

        public double MontantVerser { get; set; } = 0;
        public double MontantRestant => Montant - MontantVerser;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public EtatDette Etat { get; set; }
        public TypeDette TypeDette { get; set; }
        public List<Detail> Details { get; set; } = new();
        public Client Client { get; set; }
        public List<Paiement> Paiement { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Dept()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            TypeDette = TypeDette.ENCOURS;
            UpdateEtat();
        }

        public void UpdateEtat()
        {
            Etat = MontantRestant > 0 ? EtatDette.NONSOLDEES : EtatDette.SOLDEES;
        }
        public double MontantTotal
        {
            get
            {
                double total = 0;
                foreach (var detail in Details)
                {
                    total += detail.Qte * detail.Articles.Prix;
                }
                return total;
            }
        }
        public override string ToString()
        {
            string detailsStr = Details.Count > 0 ? string.Join(", ", Details) : "Aucun détail";
            return $"Dept {Id} : {Montant} - {Date} - {Etat} - {detailsStr} - {TypeDette}";
        }
    }
}

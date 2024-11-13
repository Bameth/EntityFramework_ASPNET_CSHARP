using System;
using System.Collections.Generic;
using web.enums;

namespace web.entities
{
    public class Dept
    {
        public int Id { get; set; }
        public double Montant { get; set; }
        public double MontantVerser { get; set; } = 0;
        public double MontantRestant => Montant - MontantVerser;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public EtatDette Etat { get; set; }
        public TypeDette TypeDette { get; set; } = TypeDette.ENCOURS;

        public List<Detail> Details { get; set; } = new();
        public Client Client { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Dept()
        {
            UpdateEtat(); 
        }

        public void UpdateEtat()
        {
            Etat = MontantRestant > 0 ? EtatDette.NONSOLDEES : EtatDette.SOLDEES;
        }

        public override string ToString()
        {
            string detailsStr = Details.Count > 0 ? string.Join(", ", Details) : "Aucun détail";
            return $"Dept {Id} : {Montant} - {Date} - {Etat} - {detailsStr} - {TypeDette} - CreatedAt: {CreatedAt} - UpdatedAt: {UpdatedAt}";
        }
    }
}

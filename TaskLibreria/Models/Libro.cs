using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibreria.Models
{
    internal class Libro
    {
        public int Id { get; set; }

        public string? Titolo { get; set; }

        public DateTime AnnoDiPubblicazione { get; set; } 

        public bool IsDisponibile { get; set; }


        public Libro() { }
        public Libro( int id,string? titolo, DateTime annoDiPubblicazione, bool isDisponibile)
        {
            Id = id;
            Titolo = titolo;
            AnnoDiPubblicazione = annoDiPubblicazione;
            IsDisponibile = isDisponibile;
        }
        public Libro( string? titolo, DateTime annoDiPubblicazione, bool isDisponibile)
        {
            
            Titolo = titolo;
            AnnoDiPubblicazione = annoDiPubblicazione;
            IsDisponibile = isDisponibile;
        }

        public override string ToString()
        {
            string disponibilita = IsDisponibile ? "è disponibile" : "non è disponibile";
            return $"{Titolo} {AnnoDiPubblicazione.ToString("d")} {disponibilita}";
        }
    }
}

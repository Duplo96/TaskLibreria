using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibreria.Models
{
    internal class Utente
    {
        public int Id { get; set; }

        public string? Nome { get; set; }
        public string? Cognome { get; set;}
        public string? Email { get; set; }


        public Utente() { }
        public Utente(int id, string? nome, string? cognome,string? email)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
        
        }
        public Utente(string?nome,string?cognome,string?email)
        {
            Nome = nome;
            Cognome = cognome;
            Email = email;  
        }
    }
}

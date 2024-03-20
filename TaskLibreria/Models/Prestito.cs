using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibreria.Models
{
    internal class Prestito
    {
        public int Id { get; set; }

        public DateTime DataDiPrestito { get; set; }

        public DateTime DataDiRitorno { get; set; }

        public int LibroRIF {  get; set; }

        public int UtenteRIF {  get; set; } 



        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibreria.Models;

namespace TaskLibreria.DAL
{
    internal class UtenteDAL : IDal<Utente>
    {

        private static UtenteDAL? istanza;
        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();
            return istanza;
        }
        public bool Delete(Utente t)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Utente t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Utente t)
        {
            throw new NotImplementedException();
        }
    }
}

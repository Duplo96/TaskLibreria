using TaskLibreria.DAL;
using TaskLibreria.Models;

namespace TaskLibreria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro lib = new Libro()
            {
                
                Titolo="Il Mercante",
                AnnoDiPubblicazione=new(2023,04,18),
                IsDisponibile=true
            };
            #region Inserisci Libro
            //Console.WriteLine(LibroDAL.getIstanza().Insert(lib));
            #endregion
            #region Eliminazione Libri

            //Console.WriteLine(LibroDAL.getIstanza().Delete(lib));
            #endregion
            #region Stampa tutti i libri
            //Tiriamo fuori tutti i libri
            foreach (Libro l in LibroDAL.getIstanza().GetAll())
            {
                Console.WriteLine(l);
            }
            #endregion
        }
    }
}

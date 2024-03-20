using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibreria.Models;
using TaskLibreria.Utilities;

namespace TaskLibreria.DAL
{
    internal class LibroDAL : IDal<Libro>
    {
        private static LibroDAL? istanza;
        public static LibroDAL getIstanza()
        {
            if (istanza == null)
                istanza = new LibroDAL();
            return istanza;
        }


        private List<Libro> elencoLibri = new List<Libro>();
        public bool Delete(Libro t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Libro WHERE libroID = @valLibro";
                cmd.Parameters.AddWithValue("@valLibro", t.Id);
                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        risultato = true;
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return risultato;
            }
        }

        public List<Libro> GetAll()
            {

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroID, titolo,annoDiPubblicazione,IsDisponibile FROM Libro";


                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elencoLibri.Add(new Libro
                        {
                            Id = Convert.ToInt32(reader["libroID"]),
                            Titolo = reader["titolo"].ToString(),
                            AnnoDiPubblicazione = Convert.ToDateTime(reader["annoDiPubblicazione"]),
                            IsDisponibile = Convert.ToBoolean(reader["isDisponibile"])
                        });
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }
                return elencoLibri;
            }
            
            }

        public Libro? GetById(int id)
        {
            Libro? libro = null;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT libroID, titolo, annoDiPubblicazione, IsDisponibile FROM Libro WHERE libroID = @valId";
                cmd.Parameters.AddWithValue("@valId", id);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        libro = new Libro
                        {
                            Id = Convert.ToInt32(reader["libroID"]),
                            Titolo = reader["titolo"].ToString(),
                            AnnoDiPubblicazione = Convert.ToDateTime(reader["annoDiPubblicazione"]),
                            IsDisponibile = Convert.ToBoolean(reader["IsDisponibile"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return libro;
        }


        public bool Insert(Libro t)
            {
                bool risultato = false;
                using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Libro(titolo, annoDiPubblicazione, IsDisponibile) " +
                                      "VALUES(@valTit, @valAnno, @valIsDisp)";
                    cmd.Parameters.AddWithValue("@valTit", t.Titolo);
                    cmd.Parameters.AddWithValue("@valAnno", t.AnnoDiPubblicazione);
                    cmd.Parameters.AddWithValue("@valIsDisp", t.IsDisponibile);

                    try
                    {
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                            risultato = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    return risultato;
                }
            }

            public bool Update(Libro t)
            {

            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Libro SET titolo = @valTitolo,annoDiPubblicazione = @valAnno,IsDisponibile= @valDisp WHERE libroID = @valId";
                cmd.Parameters.AddWithValue("@valTitolo", t.Titolo);
                cmd.Parameters.AddWithValue("@valAnno", t.AnnoDiPubblicazione);
                cmd.Parameters.AddWithValue("@valDisp", t.IsDisponibile);
                cmd.Parameters.AddWithValue("@valId", t.Id);
                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return risultato;
            }

        }

       public List<Libro> TrovaLibriDisponibili()
        {
            List<Libro> libri = GetAll();
            return libri.FindAll(libro => libro.IsDisponibile);
        }

    }

}

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
    internal class UtenteDAL : IDal<Utente>
    {

        private static UtenteDAL? istanza;

        private List<Utente> elencoUtenti = new List<Utente>();
        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new UtenteDAL();
            return istanza;
        }




        public bool Delete(Utente t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Utente WHERE utenteID = @valUtente";
                cmd.Parameters.AddWithValue("@valUtente", t.Id);
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

        public List<Utente> GetAll()
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
                        elencoUtenti.Add(new Utente
                        {
                            Id = Convert.ToInt32(reader["utenteID"]),
                            Nome = reader["nome"].ToString(),
                            Cognome = reader["cognome"].ToString(),
                            Email = reader["email"].ToString()
                        });
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }
                return elencoUtenti;
            }
        }

        public Utente? GetById(int id)
        {
            Utente? utente = null;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT utenteID, nome, cognome,email FROM Utente WHERE utenteID = @valId";
                cmd.Parameters.AddWithValue("@valId", id);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        utente = new Utente
                        {
                            Id = Convert.ToInt32(reader["utenteID"]),
                            Nome = reader["nome"].ToString(),
                            Cognome = reader["cognome"].ToString(),
                            Email = reader["email"].ToString()

                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return utente;
        }

        public bool Insert(Utente t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Libro(nome,cognome,email) " +
                                  "VALUES(@valNom, @valCogn, @valEmail)";
                cmd.Parameters.AddWithValue("@valNom", t.Nome);
                cmd.Parameters.AddWithValue("@valCogn", t.Cognome);
                cmd.Parameters.AddWithValue("@valEmail", t.Email);

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

        public bool Update(Utente t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Utente SET nome = @valNom,cognome = @valCogn, email= @valEmail WHERE utenteID = @valId";
                cmd.Parameters.AddWithValue("@valNom", t.Nome);
                cmd.Parameters.AddWithValue("@valCogn", t.Cognome);
                cmd.Parameters.AddWithValue("@valEmail", t.Email);
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


    }
}

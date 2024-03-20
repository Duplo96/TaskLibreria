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
    internal class PrestitoDAL : IDal<Prestito>
    {

        private static PrestitoDAL? istanza;
        public static PrestitoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new PrestitoDAL();
            return istanza;
        }


        private List<Prestito> elencoPrestiti = new List<Prestito>();
        public bool Delete(Prestito t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Prestito WHERE libroRIF = @valLibro AND utenteRIF=@valUtente";
                cmd.Parameters.AddWithValue("@valLibro", t.Id);
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

        public List<Prestito> GetAll()
        {
            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID,dataDiPrestito,dataDiRitorno,libroRIF,utenteRIF FROM Prestito";


                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        elencoPrestiti.Add(new Prestito
                        {
                            Id = Convert.ToInt32(reader["prestitoID"]),
                            DataDiPrestito = Convert.ToDateTime(reader["dataDiPrestito"]),
                            DataDiRitorno = Convert.ToDateTime(reader["dataDiRitorno"]),
                            LibroRIF = Convert.ToInt32(reader["libroRIF"]),
                            UtenteRIF = Convert.ToInt32(reader["utenteRIF"])
                            
                        });
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }
                return elencoPrestiti;
            }
        }

        public Prestito? GetById(int id)
        {
            Prestito? prestito= null;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT prestitoID,dataDiPrestito,dataDiRitorno,libroRIF,utenteRIF FROM Prestito WHERE prestitoID = @valId";
                cmd.Parameters.AddWithValue("@valId", id);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        prestito = new Prestito
                        {
                            Id = Convert.ToInt32(reader["prestitoID"]),
                            DataDiPrestito = Convert.ToDateTime(reader["dataDiPrestito"]),
                            DataDiRitorno = Convert.ToDateTime(reader["dataDiRitorno"]),
                            LibroRIF = Convert.ToInt32(reader["libroRIF"]),
                            UtenteRIF = Convert.ToInt32(reader["utenteRIF"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return prestito;
        }

        public bool Insert(Prestito t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Prestito t)
        {
            throw new NotImplementedException();
        }
    }
}

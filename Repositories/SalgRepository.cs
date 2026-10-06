using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories.Interfaces;

namespace ProjektReolmarked.Repositories
{
    internal class SalgRepository : ISalgRepository
    {
        private readonly string _connectionString;

        public SalgRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = config.GetConnectionString("DefaultConnection") ?? "";
        }

        public void SaveSalg(Salg inputSalg)
        {
            string query = "INSERT INTO Salg (Dato, Belob, Bemaerkning) VALUES (@Dato, @Belob, @Bemaerkning)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Dato", inputSalg.Dato);
                command.Parameters.AddWithValue("@Belob", inputSalg.Belob);
                command.Parameters.AddWithValue("@Bemaerkning", inputSalg.Bemaerkning ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Salg GetSalgById(int salgId)
        {
            Salg salg = null;

            string query = "SELECT * FROM Salg WHERE SalgId = @SalgId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SalgId", salgId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        salg = new Salg
                        {
                            SalgId = (int)reader["SalgId"],
                            Dato = (DateTime)reader["Dato"],
                            Belob = (decimal)reader["Belob"],
                            Bemaerkning = reader["Bemaerkning"] as string
                        };
                    }
                }
            }

            return salg;
        }

        public Salg[] GetAllSalg()
        {
            List<Salg> salgListe = new List<Salg>();

            string query = "SELECT * FROM Salg";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salgListe.Add(new Salg
                        {
                            SalgId = (int)reader["SalgId"],
                            Dato = (DateTime)reader["Dato"],
                            Belob = (decimal)reader["Belob"],
                            Bemaerkning = reader["Bemaerkning"] as string
                        });
                    }
                }
            }

            return salgListe.ToArray();
        }
    }
}

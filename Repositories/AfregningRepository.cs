using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories
{
    internal class AfregningRepository : IAfregningRepository
    {
        private readonly string _connectionString;
        public AfregningRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? ConnectionString = config.GetConnectionString("DefaultConnection");
            _connectionString = ConnectionString;
        }

        public IEnumerable<Afregning> GetAll()
        {
            var semesters = new List<Afregning>();
            string query = "SELECT * FROM AFREGNING";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        semesters.Add(new Afregning
                        {
                            AfregningID = (int)reader["AfregningId"],
                            Aar = (int)reader["Aar"],
                            Maaned = (int)reader["Maaned"],
                            SamletSalg  = (decimal)reader["SamletSalg"],
                            KommissionProcent = (decimal)reader["KommissionProcent"],
                            KommissionBeloeb = (decimal)reader["KommissionBeloeb"],
                            LejeBeloeb = (decimal)reader["LejeBeloeb"],
                            BeloebTilUdbetaling = (decimal)reader["BeloebTilUdbetaling"],
                            Status = (bool)reader["Status"]
                        });
                    }
                }
            }

            return semesters;
        }

        public Afregning GetAfregningById(int afregningId)
        {
            Afregning afregning = null;
            string query = "SELECT * FROM AFREGNING WHERE AfregningId = @AfregningId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AfregningId", afregningId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        afregning = new Afregning
                        {
                            AfregningID = (int)reader["AfregningId"],
                            Aar = (int)reader["Aar"],
                            Maaned = (int)reader["Maaned"],
                            SamletSalg = (decimal)reader["SamletSalg"],
                            LejeBeloeb = (decimal)reader["LejeBeloeb"],
                            KommissionProcent = (decimal)reader["KommissionProcent"],
                            KommissionBeloeb = (decimal)reader["KommissionBeloeb"],
                            BeloebTilUdbetaling = (decimal)reader["BeloebTilUdbetaling"],
                            Status = (bool)reader["Status"]

                        };
                    }
                }
            }
            return afregning;
        }


        //Add = Save
        public void SaveAfregning(Afregning inputAfregning)
        {
            string query = "INSERT INTO Afregning (Aar, Maaned, SamletSalg, KommissionProcent, KommissionBeloeb, LejeBeloeb,BeloebTilUdbetaling, Status) VALUES (@Aar, @Maaned, @SamletSalg, @KommissionProcent, @KommissionBeloeb, @LejeBeloeb,@BeloebTilUdbetaling, @Status)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Aar", inputAfregning.Aar);
                command.Parameters.AddWithValue("@Maaned", inputAfregning.Maaned);
                command.Parameters.AddWithValue("@SamletSalg", inputAfregning.SamletSalg);
                command.Parameters.AddWithValue("@KommissionProcent", (inputAfregning.KommissionProcent*100));
                command.Parameters.AddWithValue("@KommissionBeloeb", inputAfregning.KommissionBeloeb);
                command.Parameters.AddWithValue("@LejeBeloeb", inputAfregning.LejeBeloeb);
                command.Parameters.AddWithValue("@BeloebTilUdbetaling", inputAfregning.BeloebTilUdbetaling);
                command.Parameters.AddWithValue("@Status", inputAfregning.Status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

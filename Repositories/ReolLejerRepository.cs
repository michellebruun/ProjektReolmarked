using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektReolmarked.Repositories
{
    internal class ReolLejerRepository : IReolLejerRepository
    {
        private readonly string _connectionString;
        public ReolLejerRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = config.GetConnectionString("DefaultConnection") ?? "";
        }

        public IEnumerable<ReolLejer> GetAll()
        {
            var reolLejere = new List<ReolLejer>();
            string query = "SELECT * FROM ReolLejer";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reolLejere.Add(new ReolLejer
                        {
                            ReolLejerId = (int)reader["ReolLejerId"],
                            Navn = (string)reader["Navn"],
                            Telefon = (string)reader["Telefon"],
                            Email = (string)reader["Email"]
                        });
                    }
                }
            }

            return reolLejere;
        }

        public ReolLejer? GetReolLejerById(int reolLejerId)
        {
            ReolLejer? reolLejer = null;
            string query = "SELECT * FROM ReolLejer WHERE ReolLejerId = @ReolLejerId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReolLejerId", reolLejerId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reolLejer = new ReolLejer
                        {
                            ReolLejerId = (int)reader["ReolLejerId"],
                            Navn = (string)reader["Navn"],
                            Telefon = (string)reader["Telefon"],
                            Email = (string)reader["Email"]
                        };
                    }
                }
            }
            return reolLejer;
        }

        //Add = Save
        public void SaveReolLejer(ReolLejer inputReolLejer)
        {
            string query = "INSERT INTO ReolLejer (Navn, Telefon, Email) VALUES (@Navn, @Telefon, @Email)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Navn", inputReolLejer.Navn);
                command.Parameters.AddWithValue("@Telefon", inputReolLejer.Telefon);
                command.Parameters.AddWithValue("@Email", inputReolLejer.Email);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateReolLejer(ReolLejer inputReolLejer)
        {
            string query = "UPDATE ReolLejer SET Navn = @Navn, Telefon = @Telefon, Email = @Email WHERE ReolLejerId = @ReolLejerId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReolLejerId", inputReolLejer.ReolLejerId);
                command.Parameters.AddWithValue("@Navn", inputReolLejer.Navn);
                command.Parameters.AddWithValue("@Telefon", inputReolLejer.Telefon);
                command.Parameters.AddWithValue("@Email", inputReolLejer.Email);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReolLejer(int reolLejerId)
        {
            string query = "DELETE FROM ReolLejer WHERE ReolLejerId = @ReolLejerId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReolLejerId", reolLejerId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

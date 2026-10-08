using Microsoft.Data.SqlClient;
using ProjektReolmarked.Models;
using ProjektReolmarked.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjektReolmarked.Repositories
{
    internal class ReolRepository : IReolRepository
    {
        private readonly string _connectionString =
            "Server=localhost;Database=ProjektReolmarked;Trusted_Connection=True;TrustServerCertificate=True;";

        public void SaveReol(Reol inputReol)
        {
        }

        public void UpdateReol(Reol reol)
        {
            string query = @"
        UPDATE dbo.Reol
        SET
            Status = @Status,
            ReolLejerId = @ReolLejerId,
            Type = @Type
        WHERE ReolId = @ReolId";

            using SqlConnection connection = new SqlConnection(_connectionString);

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReolId", reol.ReolId);
            command.Parameters.AddWithValue("@Status", reol.Status);
            command.Parameters.AddWithValue("@ReolLejerId", reol.ReolLejerId);
            command.Parameters.AddWithValue("@Type", reol.Type);

            connection.Open();

            command.ExecuteNonQuery();
        }

        public Reol GetReolById(int reolId)
        {
            return null;
        }

        public Reol[] GetAllReoler()
        {
            List<Reol> reoler = new List<Reol>();

            using SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = @"
                SELECT
                    ReolId,
                    Placering,
                    Status,
                    ReolLejerId,
                    Type
                FROM dbo.Reol
                ORDER BY ReolId";

            using SqlCommand command = new SqlCommand(query, connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Reol reol = new Reol
                {
                    ReolId = (int)reader["ReolId"],
                    Placering = (int)reader["Placering"],
                    Status = (bool)reader["Status"],
                    ReolLejerId = reader["ReolLejerId"] == DBNull.Value
                        ? null
                        : (int)reader["ReolLejerId"],
                    Type = reader["Type"] == DBNull.Value
                        ? null
                        : (string)reader["Type"]
                };

                reoler.Add(reol);
            }

            return reoler.ToArray();
        }
    }
}
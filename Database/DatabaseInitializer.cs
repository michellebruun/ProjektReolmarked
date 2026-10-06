using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProjektReolmarked.Database
{
    internal class DatabaseInitializer
    {
        private readonly string _masterConnectionString;
        private readonly string _connectionString;

        public DatabaseInitializer()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _masterConnectionString =
                config.GetConnectionString("MasterConnection")
                ?? throw new InvalidOperationException(
                    "MasterConnection was not found in appsettings.json.");

            _connectionString =
                config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "DefaultConnection was not found in appsettings.json.");
        }

        public void Initialize()
        {
            CreateDatabase();
            CreateTables();
        }

        private void CreateDatabase()
        {
            using SqlConnection connection =
                new SqlConnection(_masterConnectionString);

            connection.Open();

            string query = @"
                IF DB_ID('ProjektReolmarked') IS NULL
                BEGIN
                    CREATE DATABASE ProjektReolmarked;
                END";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.ExecuteNonQuery();
        }

        private void CreateTables()
        {
            using SqlConnection connection =
                new SqlConnection(_connectionString);

            connection.Open();

            string query = @"
                IF OBJECT_ID('dbo.Afregning', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Afregning
                    (
                        AfregningId INT IDENTITY(1,1) NOT NULL,
                        Aar INT NOT NULL,
                        Maaned INT NOT NULL,
                        SamletSalg DECIMAL NOT NULL,
                        KomminsionProcent DECIMAL NOT NULL,
                        KomminsionBeloeb DECIMAL NOT NULL,
                        LejeBeloeb DECIMAL NOT NULL,
                        BeloebTilUdbetaling DECIMAL NOT NULL,
                        Status BIT NOT NULL,

                        CONSTRAINT PK_Afregning
                            PRIMARY KEY (AfregningId)
                    );
                END;

                IF OBJECT_ID('dbo.ReolLejer', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.ReolLejer
                    (
                        ReolLejerId INT IDENTITY(1,1) NOT NULL,
                        Navn NVARCHAR(100) NOT NULL,
                        Telefon NVARCHAR(20) NOT NULL,
                        Email NVARCHAR(254) NOT NULL,

                        CONSTRAINT PK_ReolLejer
                            PRIMARY KEY (ReolLejerId),

                        CONSTRAINT UQ_ReolLejer_Email
                            UNIQUE (Email),

                        CONSTRAINT CK_ReolLejer_Navn
                            CHECK (LEN(Navn) > 0),

                        CONSTRAINT CK_ReolLejer_Telefon
                            CHECK (LEN(Telefon) >= 8),

                        CONSTRAINT CK_ReolLejer_Email
                            CHECK (Email LIKE '%_@_%._%')
                    );
                END;

                IF OBJECT_ID('dbo.Salg', 'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Salg
                    (
                        SalgId INT IDENTITY(1,1) NOT NULL,
                        Dato DATETIME NOT NULL,
                        Belob DECIMAL(18,2) NOT NULL,
                        Bemaerkning NVARCHAR(255) NULL,

                        CONSTRAINT PK_Salg
                            PRIMARY KEY (SalgId)
                    );
                END;
            ";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.ExecuteNonQuery();
        }
    }
}
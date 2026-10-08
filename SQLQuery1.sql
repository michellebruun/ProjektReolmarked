IF OBJECT_ID('dbo.Afregning', 'U') IS NOT NULL
    DROP TABLE dbo.Afregning;
GO

CREATE TABLE dbo.Afregning
(
    -- INT IDENTITY(1,1) --> ID starts from 1 and adds up by 1 for every new afregning.
    AfregningId INT IDENTITY(1,1) NOT NULL,
    Aar INT NOT NULL,
    Maaned INT NOT NULL,
    SamletSalg DECIMAL NOT NULL,
    KomminsionProcent DECIMAL NOT NULL,
    KomminsionBeloeb DECIMAL NOT NULL,
    LejeBeloeb DECIMAL NOT NULL,
    BeloebTilUdbetaling DECIMAL NOT NULL,
    Status BIT NOT NULL,

    CONSTRAINT PK_Afregning PRIMARY KEY (AfregningId)
);
GO

IF OBJECT_ID('dbo.ReolLejer', 'U') IS NOT NULL
    DROP TABLE dbo.ReolLejer;
GO

CREATE TABLE dbo.ReolLejer
(
    -- INT IDENTITY(1,1) --> ID starts from 1 and adds up by 1 for every new reollejer.
    ReolLejerId INT IDENTITY(1,1) NOT NULL,
    Navn NVARCHAR(100) NOT NULL,
    Telefon NVARCHAR(20) NOT NULL,
    Email NVARCHAR(254) NOT NULL,

    CONSTRAINT PK_ReolLejer PRIMARY KEY (ReolLejerId),
    -- Two reollejer cannot have the same email
    CONSTRAINT UQ_ReolLejer_Email UNIQUE (Email),
    CONSTRAINT CK_ReolLejer_Navn CHECK (LEN(Navn) > 0),
    CONSTRAINT CK_ReolLejer_Telefon CHECK (LEN(Telefon) >= 8),
    CONSTRAINT CK_ReolLejer_Email CHECK (Email LIKE '%_@_%._%')
);
GO

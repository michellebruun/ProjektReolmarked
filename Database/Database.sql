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

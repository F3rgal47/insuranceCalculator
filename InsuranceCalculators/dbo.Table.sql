CREATE TABLE [dbo].[Table]
(
	[DriverId] INT NOT NULL PRIMARY KEY, 
    [Forename] TEXT NULL, 
    [Surname] TEXT NULL, 
    [DOB] DATE NULL, 
    [Occupation] TEXT NULL, 
    [ClaimKey] INT NOT NULL, 
    [QuoteKey] INT NOT NULL
)

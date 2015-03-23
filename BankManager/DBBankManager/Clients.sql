CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ClientContactNumber] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [Deposit] BIT NOT NULL, 
    [StatusID] INT NOT NULL, 
    CONSTRAINT [FK_Clients_ToTable] FOREIGN KEY ([StatusID]) REFERENCES [Clients]([StatusID])
)

CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Login] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(200) NOT NULL, 
    [PasswordSalt] NVARCHAR(MAX) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Address] NCHAR(10) NOT NULL
)

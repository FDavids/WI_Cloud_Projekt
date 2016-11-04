CREATE TABLE [dbo].[User] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [LastName]    NVARCHAR (50) NULL,
    [FirstName]   NVARCHAR (50) NULL,
    [EmailAdress] NVARCHAR (50) NOT NULL,
    [Password]    NVARCHAR (50) NOT NULL,
    [UserName]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);
















GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User]
    ON [dbo].[User]([UserName] ASC);


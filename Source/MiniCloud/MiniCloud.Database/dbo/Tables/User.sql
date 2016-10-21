CREATE TABLE [dbo].[User] (
    [Id]       INT           NOT NULL,
    [UserName] NVARCHAR (50) NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [Password] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);














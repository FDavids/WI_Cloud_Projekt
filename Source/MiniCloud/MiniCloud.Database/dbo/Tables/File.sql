CREATE TABLE [dbo].[File] (
    [FileName]       NVARCHAR (MAX) NOT NULL,
    [ContentType]    NVARCHAR (50)  NOT NULL,
    [FileSizeInByte] NVARCHAR (50)  NOT NULL,
    [CreationDate]   DATETIME       NOT NULL,
    [FileOwnerId]    INT            NOT NULL,
    [Uri]            NVARCHAR (MAX) NOT NULL,
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_File_User] FOREIGN KEY ([FileOwnerId]) REFERENCES [dbo].[User] ([Id])
);


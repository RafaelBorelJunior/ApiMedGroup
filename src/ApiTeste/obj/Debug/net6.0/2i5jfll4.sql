IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Contatos] (
    [Id] uniqueidentifier NOT NULL,
    [NomeContato] nvarchar(max) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Sexo] nvarchar(max) NULL,
    [IsAtivo] bit NOT NULL,
    CONSTRAINT [PK_Contatos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221215181244_start', N'6.0.12');
GO

COMMIT;
GO


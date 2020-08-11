IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200109153317_Initial')
BEGIN
    CREATE TABLE [Receita] (
        [ReceitaId] int NOT NULL IDENTITY,
        [Descricao] varchar(300) NOT NULL,
        [Valor] decimal(14, 2) NOT NULL,
        [Recebido] bit NULL,
        [DataRecebido] datetime NULL,
        [Recorrente] bit NOT NULL DEFAULT 0,
        CONSTRAINT [PK_Receita] PRIMARY KEY ([ReceitaId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200109153317_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200109153317_Initial', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200109161521_Alterando_Coluna')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receita]') AND [c].[name] = N'Recebido');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Receita] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Receita] ALTER COLUMN [Recebido] bit NULL;
    ALTER TABLE [Receita] ADD DEFAULT (0) FOR [Recebido];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200109161521_Alterando_Coluna')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200109161521_Alterando_Coluna', N'2.1.14-servicing-32113');
END;

GO


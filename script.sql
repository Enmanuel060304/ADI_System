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

ALTER TABLE [User] DROP CONSTRAINT [PK_User];
GO

ALTER TABLE [Producto] DROP CONSTRAINT [PK_Producto];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Producto]') AND [c].[name] = N'nombre');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Producto] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Producto] DROP COLUMN [nombre];
GO

EXEC sp_rename N'[User]', N'Users', 'OBJECT';
GO

EXEC sp_rename N'[Producto]', N'Productos', 'OBJECT';
GO

ALTER TABLE [Productos] ADD [Name] nvarchar(450) NOT NULL DEFAULT N'';
GO

ALTER TABLE [Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Productos] ADD CONSTRAINT [PK_Productos] PRIMARY KEY ([Id]);
GO

CREATE TABLE [Clients] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [Address] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Line] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Line] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Providers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [email] nvarchar(100) NOT NULL,
    [phone] nvarchar(20) NOT NULL,
    [address] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Providers] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Productos_Name] ON [Productos] ([Name]);
GO

CREATE UNIQUE INDEX [IX_Clients_Name] ON [Clients] ([Name], [LastName], [Email], [Phone]);
GO

CREATE UNIQUE INDEX [IX_Lines_Name] ON [Line] ([Name]);
GO

CREATE UNIQUE INDEX [IX_Providers_Name] ON [Providers] ([Name], [email], [phone]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240409164625_Initial', N'9.0.0-preview.2.24128.4');
GO

COMMIT;
GO


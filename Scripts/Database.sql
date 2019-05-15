IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Owners] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [CPF] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [Gender] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Services] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Value] real NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Cars] (
    [Id] uniqueidentifier NOT NULL,
    [Plate] nvarchar(max) NULL,
    [Brand] nvarchar(max) NULL,
    [Model] nvarchar(max) NULL,
    [Color] nvarchar(max) NULL,
    [Year] int NOT NULL,
    [OwnerId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cars_Owners_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Owners] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ServiceOrders] (
    [Id] uniqueidentifier NOT NULL,
    [VehicleId] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [Quantity] int NOT NULL,
    [CarId] uniqueidentifier NULL,
    CONSTRAINT [PK_ServiceOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ServiceOrders_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ServiceOrders_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Cars_OwnerId] ON [Cars] ([OwnerId]);

GO

CREATE INDEX [IX_ServiceOrders_CarId] ON [ServiceOrders] ([CarId]);

GO

CREATE INDEX [IX_ServiceOrders_ServiceId] ON [ServiceOrders] ([ServiceId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190515162912_Initial', N'2.2.4-servicing-10062');

GO


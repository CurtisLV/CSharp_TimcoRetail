CREATE TABLE [dbo].[Product] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [ProductName]     NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [RetailPrice]     MONEY          NOT NULL,
    [QuantityInStock] INT            DEFAULT 1 NOT NULL,
    [CreateDate]      DATETIME2 (7)  DEFAULT getutcdate() NOT NULL,
    [LastModified]    DATETIME2 (7)  DEFAULT getutcdate() NOT NULL,
    [IsTaxable]       BIT            DEFAULT 1 NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


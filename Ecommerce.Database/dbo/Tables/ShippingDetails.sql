CREATE TABLE [dbo].[ShippingDetails] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [ShippingType] NVARCHAR (MAX) NULL,
    [ShippingAdd1] NVARCHAR (200) NULL,
    [ShippingAdd2] NVARCHAR (200) NULL,
    [City]         NVARCHAR (200) NULL,
    [State]        NVARCHAR (200) NULL,
    [Zip]          NVARCHAR (10)  NULL,
    [OrderId]      INT            NOT NULL,
    CONSTRAINT [PK_ShippingDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ShippingDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ShippingDetails_OrderId]
    ON [dbo].[ShippingDetails]([OrderId] ASC);


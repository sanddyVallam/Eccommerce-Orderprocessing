CREATE TABLE [dbo].[Payments] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [paymentmethod]       NVARCHAR (MAX) NULL,
    [Paymentdate]         NVARCHAR (MAX) NULL,
    [PaymentConfirmation] NVARCHAR (MAX) NULL,
    [BillingAdd1]         NVARCHAR (200) NULL,
    [BillingAdd2]         NVARCHAR (200) NULL,
    [City]                NVARCHAR (200) NULL,
    [State]               NVARCHAR (200) NULL,
    [Zip]                 NVARCHAR (10)  NULL,
    [OrderId]             INT            NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Payments_OrderId]
    ON [dbo].[Payments]([OrderId] ASC);


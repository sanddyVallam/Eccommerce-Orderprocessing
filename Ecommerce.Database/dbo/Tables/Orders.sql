CREATE TABLE [dbo].[Orders] (
    [Id]              INT                IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100)     NOT NULL,
    [Status]          NVARCHAR (MAX)     NOT NULL,
    [CustomerId]      INT                NOT NULL,
    [Quantity]        INT                NOT NULL,
    [Subtotal]        DECIMAL (18, 2)    NOT NULL,
    [Tax]             DECIMAL (18, 2)    NOT NULL,
    [ShippingCharges] DECIMAL (18, 2)    NOT NULL,
    [Total]           DECIMAL (18, 2)    NOT NULL,
    [CreatedDate]     DATETIMEOFFSET (7) NOT NULL,
    [ModifiedDate]    DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);


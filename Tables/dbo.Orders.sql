CREATE TABLE [dbo].[Orders]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Orders_ID] DEFAULT (newid()),
[Member_ID] [uniqueidentifier] NOT NULL,
[Customer_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[Salesman_ID] [uniqueidentifier] NULL,
[Shipping_ID] [uniqueidentifier] NOT NULL,
[Billing_ID] [uniqueidentifier] NOT NULL,
[Order_Payment_ID] [uniqueidentifier] NOT NULL,
[SubTotal] [money] NULL,
[TaxTotal] [money] NULL,
[OrderTotal] [money] NULL,
[Charges_Completed] [bit] NOT NULL CONSTRAINT [DF_Orders_PaymentCompleted] DEFAULT ((0)),
[Partial_Fulfillment] [bit] NOT NULL CONSTRAINT [DF_Orders_Partial_Fulfillment] DEFAULT ((0)),
[Fulfilled] [bit] NOT NULL CONSTRAINT [DF_Orders_Fulfilled] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Orders_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Orders_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_Order_Payment_Information] FOREIGN KEY ([Order_Payment_ID]) REFERENCES [dbo].[Order_Payment_Information] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PURCHASES_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Orders', NULL, NULL
GO

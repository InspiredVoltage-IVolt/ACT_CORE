CREATE TABLE [dbo].[Order_Line_Items]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Order_Line_Items_ID] DEFAULT (newid()),
[Order_ID] [uniqueidentifier] NOT NULL,
[Product_ID] [uniqueidentifier] NULL,
[Coupon_ID] [uniqueidentifier] NULL,
[ShippingAddress_ID] [uniqueidentifier] NULL,
[Quantity] [int] NOT NULL CONSTRAINT [DF_Order_Line_Items_Quantity] DEFAULT ((1)),
[SubTotal] [money] NULL,
[TaxTotal] [money] NULL,
[OrderTotal] [money] NULL,
[Charges_Completed] [bit] NOT NULL CONSTRAINT [DF_Order_Line_Items_Charges_Completed] DEFAULT ((0)),
[Partial_Fulfillment] [bit] NOT NULL CONSTRAINT [DF_Order_Line_Items_Partial_Fulfillment] DEFAULT ((0)),
[Fulfilled] [bit] NOT NULL CONSTRAINT [DF_Order_Line_Items_Fulfilled] DEFAULT ((0)),
[Deliver_To_EmailAddress] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Additional_Information] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Order_Line_Items_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Order_Line_Items_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order_Line_Items] ADD CONSTRAINT [PK_Order_Line_Items] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order_Line_Items] ADD CONSTRAINT [FK_Order_Line_Items_Order_ID_TO_Orders_ID] FOREIGN KEY ([Order_ID]) REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Order_Line_Items] ADD CONSTRAINT [FK_Order_Line_Items_Product_ID_TO_Products_ID] FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Order_Line_Items] ADD CONSTRAINT [FK_Order_Line_Items_ShippingAddress_ID_TO_Common_Address_Data_ID] FOREIGN KEY ([ShippingAddress_ID]) REFERENCES [dbo].[Common_Address_Data] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PURCHASES_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Order_Line_Items', NULL, NULL
GO

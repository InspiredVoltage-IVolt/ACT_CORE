CREATE TABLE [dbo].[Order_Payment_Information]
(
[ID] [uniqueidentifier] NOT NULL,
[Payment_Method_ID] [int] NOT NULL,
[Payment_Info_JSON] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Order_Payment_Information_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Order_Payment_Information_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order_Payment_Information] ADD CONSTRAINT [PK_Order_Payment_Information] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order_Payment_Information] ADD CONSTRAINT [FK_Order_Payment_Information_Order_Payment_Information] FOREIGN KEY ([ID]) REFERENCES [dbo].[Order_Payment_Information] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PURCHASES_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Order_Payment_Information', NULL, NULL
GO

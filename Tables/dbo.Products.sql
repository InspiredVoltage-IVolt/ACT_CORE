CREATE TABLE [dbo].[Products]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Products_ID] DEFAULT (newid()),
[Parent_ID] [uniqueidentifier] NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MSRPPrice] [money] NOT NULL,
[ShortDescription] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Products_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Products_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_ID_Products] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [FK_Products_Products] FOREIGN KEY ([Parent_ID]) REFERENCES [dbo].[Products] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PURCHASES_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Products', NULL, NULL
GO

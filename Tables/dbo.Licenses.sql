CREATE TABLE [dbo].[Licenses]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Licenses_ID] DEFAULT (newid()),
[Product_ID] [uniqueidentifier] NOT NULL,
[Order_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[Company_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Sales_Employee_ID] [uniqueidentifier] NULL,
[LicenseKey] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Production_Server_Count] [int] NOT NULL CONSTRAINT [DF_Licenses_Production_Server_Count] DEFAULT ((0)),
[Development_Server_Count] [int] NOT NULL CONSTRAINT [DF_Licenses_Development_Server_Count] DEFAULT ((0)),
[Developer_Count] [int] NOT NULL CONSTRAINT [DF_Licenses_Developer_Count] DEFAULT ((0)),
[ExpiresOn] [datetime] NOT NULL CONSTRAINT [DF_Licenses_ExpiresOn] DEFAULT (dateadd(year,(1),getdate())),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Licenses_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Licenses_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Licenses] ADD CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Licenses] ADD CONSTRAINT [FK_Licenses_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Licenses] ADD CONSTRAINT [FK_Licenses_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PURCHASES_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Licenses', NULL, NULL
GO

CREATE TABLE [dbo].[Company_Clients]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Company_Clients_ID] DEFAULT (newid()),
[Company_ID] [uniqueidentifier] NOT NULL,
[Client_ID] [uniqueidentifier] NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Company_Clients_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Company_Clients_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company_Clients] ADD CONSTRAINT [PK_Company_Clients] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company_Clients] ADD CONSTRAINT [FK_Company_Clients_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Company_Clients] ADD CONSTRAINT [FK_Company_Clients_Companies] FOREIGN KEY ([Company_ID]) REFERENCES [dbo].[Companies] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'COMPANY_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Company_Clients', NULL, NULL
GO

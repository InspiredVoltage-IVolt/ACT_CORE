CREATE TABLE [dbo].[Company_Keys]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Company_Keys_ID] DEFAULT (newid()),
[Company_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[EncryptionKey] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateTimeImplemented] [datetime] NOT NULL,
[ExpirationDate] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Company_Keys_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Company_Keys_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company_Keys] ADD CONSTRAINT [PK_Company_Keys] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company_Keys] ADD CONSTRAINT [FK_Company_Keys_Application_ID_TO_Applications_ID] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Company_Keys] ADD CONSTRAINT [FK_Company_Keys_Company_ID_TO_Companies_ID] FOREIGN KEY ([Company_ID]) REFERENCES [dbo].[Companies] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'COMPANY_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Company_Keys', NULL, NULL
GO

CREATE TABLE [dbo].[Application_To_Company]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Company_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[ConfirmationCode] [uniqueidentifier] NOT NULL,
[Banned] [bit] NOT NULL,
[Approved] [bit] NOT NULL,
[WebService_Token] [uniqueidentifier] NULL,
[WebService_TokenTimeStamp] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Application_To_Company_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Application_To_Company_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_To_Company] ADD CONSTRAINT [PK_ID_Application_To_Company] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_To_Company] ADD CONSTRAINT [FK_Application_To_Company_ApplicationID] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Application_To_Company] ADD CONSTRAINT [FK_Application_To_Company_CompanyID] FOREIGN KEY ([Company_ID]) REFERENCES [dbo].[Companies] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_To_Company', NULL, NULL
GO

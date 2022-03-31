CREATE TABLE [dbo].[Application_To_Client]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Client_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[ConfirmationCode] [uniqueidentifier] NOT NULL,
[Banned] [bit] NOT NULL CONSTRAINT [DF__Applicati__Banne__2739D489] DEFAULT ((0)),
[Approved] [bit] NOT NULL CONSTRAINT [DF__Applicati__Appro__282DF8C2] DEFAULT ((1)),
[WebService_Token] [uniqueidentifier] NULL,
[WebService_TokenTimeStamp] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF__Applicati__DateA__29221CFB] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF__Applicati__DateM__2A164134] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_To_Client] ADD CONSTRAINT [PK_ID_Application_To_Client] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_To_Client] ADD CONSTRAINT [FK_Application_To_Client_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Application_To_Client] ADD CONSTRAINT [FK_Application_To_Client_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_To_Client', NULL, NULL
GO

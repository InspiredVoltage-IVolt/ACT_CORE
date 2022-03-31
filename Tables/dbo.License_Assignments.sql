CREATE TABLE [dbo].[License_Assignments]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_License_Assignments_ID] DEFAULT (newid()),
[Client_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[License_Details] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ValidUntil] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_License_Assignments_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_License_Assignments_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[License_Assignments] ADD CONSTRAINT [PK_License_Assignments] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[License_Assignments] ADD CONSTRAINT [FK_License_Assignments_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[License_Assignments] ADD CONSTRAINT [FK_License_Assignments_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[License_Assignments] ADD CONSTRAINT [FK_License_Assignments_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PURCHASES_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'License_Assignments', NULL, NULL
GO

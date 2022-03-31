CREATE TABLE [dbo].[Application_Members_WebService_Permissions]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Application_Members_WebService_Permissions_ID] DEFAULT (newid()),
[Member_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[WebService_Action_ID] [int] NOT NULL,
[CanRead] [bit] NOT NULL,
[CanWrite] [bit] NOT NULL,
[CanModify] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Application_Members_WebService_Permissions_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Application_Members_WebService_Permissions_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Members_WebService_Permissions] ADD CONSTRAINT [PK_ID_Application_Members_WebService_Permissions] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Members_WebService_Permissions] ADD CONSTRAINT [FK_Application_Members_WebService_Permissions_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Application_Members_WebService_Permissions] ADD CONSTRAINT [FK_Application_Members_WebService_Permissions_DATA_WebService_Actions] FOREIGN KEY ([WebService_Action_ID]) REFERENCES [dbo].[DATA_WebService_Actions] ([ID])
GO
ALTER TABLE [dbo].[Application_Members_WebService_Permissions] ADD CONSTRAINT [FK_Application_Members_WebService_Permissions_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_Members_WebService_Permissions', NULL, NULL
GO

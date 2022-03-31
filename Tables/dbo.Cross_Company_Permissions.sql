CREATE TABLE [dbo].[Cross_Company_Permissions]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Company_ID] [uniqueidentifier] NULL,
[Company_B_ID] [uniqueidentifier] NULL,
[Decline_Cross_Members] [bit] NOT NULL CONSTRAINT [DF_Cross_Customer_Permissions_Decline_Cross_Members] DEFAULT ((0)),
[Monitor_Cross_Members] [bit] NOT NULL CONSTRAINT [DF_Cross_Customer_Permissions_Monitor_Cross_Members] DEFAULT ((0)),
[Decline_Members_ManyClients] [bit] NOT NULL,
[Monitor_Members_ManyClients] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Cross_Customer_Permissions_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Cross_Customer_Permissions_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cross_Company_Permissions] ADD CONSTRAINT [PK_Cross_Customer_Permissions] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cross_Company_Permissions] ADD CONSTRAINT [FK_Cross_Company_Permissions_Company_B_ID_TO_Companies_ID] FOREIGN KEY ([Company_B_ID]) REFERENCES [dbo].[Companies] ([ID])
GO
ALTER TABLE [dbo].[Cross_Company_Permissions] ADD CONSTRAINT [FK_Cross_Company_Permissions_Company_ID_TO_Companies_ID] FOREIGN KEY ([Company_ID]) REFERENCES [dbo].[Companies] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'COMPANY_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Cross_Company_Permissions', NULL, NULL
GO

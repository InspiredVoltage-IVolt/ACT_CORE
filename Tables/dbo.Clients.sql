CREATE TABLE [dbo].[Clients]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Clients_ID] DEFAULT (newid()),
[Creator_Member_ID] [uniqueidentifier] NOT NULL,
[Company_Name] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Company_URL] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MasterAccount_UserName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MasterAccount_Password] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MasterAccount_Email] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Industry_ID] [int] NULL,
[API_Code] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[API_Secret] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Approved] [bit] NOT NULL CONSTRAINT [DF_Clients_Approved] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Clients_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Clients_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clients] ADD CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clients] ADD CONSTRAINT [FK_Clients_DATA_Industries] FOREIGN KEY ([Industry_ID]) REFERENCES [dbo].[DATA_Industries] ([ID])
GO
ALTER TABLE [dbo].[Clients] ADD CONSTRAINT [FK_Clients_Members] FOREIGN KEY ([Creator_Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Clients', NULL, NULL
GO

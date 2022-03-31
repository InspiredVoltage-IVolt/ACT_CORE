CREATE TABLE [dbo].[SYSTEM_MEMBER_ONLINE_STATUS]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Priority] [int] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_Priority] DEFAULT ((1)),
[Online] [bit] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_Online] DEFAULT ((1)),
[Online_Hidden] [bit] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_Online_Hidden] DEFAULT ((0)),
[Online_Inactive] [bit] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_Online_Inactive] DEFAULT ((0)),
[Offline] [bit] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_Offline] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_MEMBER_ONLINE_STATUS_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_MEMBER_ONLINE_STATUS] ADD CONSTRAINT [PK_SYSTEM_MEMBER_ONLINE_STATUS] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_MEMBER_ONLINE_STATUS', NULL, NULL
GO

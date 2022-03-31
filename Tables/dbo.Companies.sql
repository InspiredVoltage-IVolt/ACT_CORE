CREATE TABLE [dbo].[Companies]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Companies_ID] DEFAULT (newid()),
[Member_ID] [uniqueidentifier] NULL,
[CompanyName] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CompanyURL] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PhoneNumber] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Industry] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[APICode] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Approved] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Companies] ADD CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Companies] ADD CONSTRAINT [FK_Companies_Member_ID_TO_Members_ID] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'COMPANY_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Companies', NULL, NULL
GO

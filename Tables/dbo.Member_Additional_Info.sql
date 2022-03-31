CREATE TABLE [dbo].[Member_Additional_Info]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Member_Additional_Info_ID] DEFAULT ('newid()'),
[Member_ID] [uniqueidentifier] NOT NULL,
[FieldName] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FieldValue] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member_Additional_Info] ADD CONSTRAINT [PK_ID_Member_Additional_Info] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member_Additional_Info] ADD CONSTRAINT [FK_Member_Additional_Info_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'MEMBER_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Member_Additional_Info', NULL, NULL
GO

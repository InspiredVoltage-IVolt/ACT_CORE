CREATE TABLE [dbo].[DATA_Common_Lookups]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[IDValue] [int] NULL,
[Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TextValue] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GroupName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TableName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FieldName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsFlagBased] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Common_Lookups] ADD CONSTRAINT [PK_ID_DATA_Common_Lookups] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Common_Lookups', NULL, NULL
GO

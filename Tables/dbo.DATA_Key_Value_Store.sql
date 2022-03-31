CREATE TABLE [dbo].[DATA_Key_Value_Store]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Value] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GroupName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Key_Value_Store] ADD CONSTRAINT [PK_ID_DATA_Key_Value_Store] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Key_Value_Store', NULL, NULL
GO

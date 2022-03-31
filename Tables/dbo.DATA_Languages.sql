CREATE TABLE [dbo].[DATA_Languages]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Icon_File_ID] [uniqueidentifier] NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Languages] ADD CONSTRAINT [PK_ID_DATA_Languages] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Languages', NULL, NULL
GO

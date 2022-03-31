CREATE TABLE [dbo].[DATA_Industries]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Industry] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Approved] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Industries] ADD CONSTRAINT [PK_ID_DATA_Industries] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Industries', NULL, NULL
GO

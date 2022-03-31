CREATE TABLE [dbo].[DATA_MIME_Types]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Suffix] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MediaType] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Approved] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_MIME_Types] ADD CONSTRAINT [PK_ID_DATA_MIME_Types] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_MIME_Types', NULL, NULL
GO

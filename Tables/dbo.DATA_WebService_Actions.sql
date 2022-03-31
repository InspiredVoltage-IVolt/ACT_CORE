CREATE TABLE [dbo].[DATA_WebService_Actions]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[URLPath] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_WebService_Actions] ADD CONSTRAINT [PK_ID_DATA_WebService_Actions] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_WebService_Actions', NULL, NULL
GO

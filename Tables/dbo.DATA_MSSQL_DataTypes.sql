CREATE TABLE [dbo].[DATA_MSSQL_DataTypes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (400) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_MSSQL_DataTypes] ADD CONSTRAINT [PK_ID_DATA_MSSQL_DataTypes] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_MSSQL_DataTypes', NULL, NULL
GO

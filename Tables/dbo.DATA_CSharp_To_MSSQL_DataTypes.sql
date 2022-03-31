CREATE TABLE [dbo].[DATA_CSharp_To_MSSQL_DataTypes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[MSSQL_DataType_ID] [int] NOT NULL,
[CSharp_DataType_ID] [int] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_CSharp_To_MSSQL_DataTypes] ADD CONSTRAINT [PK_ID_DATA_CSharp_To_MSSQL_DataTypes] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_CSharp_To_MSSQL_DataTypes] ADD CONSTRAINT [FK_DATA_CSharp_To_MSSQL_DataTypes_DATA_CSharp_DataTypes] FOREIGN KEY ([CSharp_DataType_ID]) REFERENCES [dbo].[DATA_CSharp_DataTypes] ([ID])
GO
ALTER TABLE [dbo].[DATA_CSharp_To_MSSQL_DataTypes] ADD CONSTRAINT [FK_DATA_CSharp_To_MSSQL_DataTypes_DATA_MSSQL_DataTypes] FOREIGN KEY ([MSSQL_DataType_ID]) REFERENCES [dbo].[DATA_MSSQL_DataTypes] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_CSharp_To_MSSQL_DataTypes', NULL, NULL
GO

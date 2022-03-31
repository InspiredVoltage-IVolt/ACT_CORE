CREATE TABLE [dbo].[SYSTEM_LOCALIZATION]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Language_ID] [int] NOT NULL,
[Identifier] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Text] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_LOCALIZATION] ADD CONSTRAINT [PK_ID_SYSTEM_LOCALIZATION] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_LOCALIZATION] ADD CONSTRAINT [FK_SYSTEM_LOCALIZATION_DATA_Languages] FOREIGN KEY ([Language_ID]) REFERENCES [dbo].[DATA_Languages] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_LOCALIZATION', NULL, NULL
GO

CREATE TABLE [dbo].[DATA_Counties]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[State_ID] [int] NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FIPS] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Counties] ADD CONSTRAINT [PK_ID_DATA_Counties] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Counties] ADD CONSTRAINT [FK_DATA_Counties_DATA_States] FOREIGN KEY ([State_ID]) REFERENCES [dbo].[DATA_States] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Counties', NULL, NULL
GO

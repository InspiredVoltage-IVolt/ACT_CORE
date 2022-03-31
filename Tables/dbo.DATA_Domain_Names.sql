CREATE TABLE [dbo].[DATA_Domain_Names]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_DATA_Domain_Names_ID] DEFAULT (newid()),
[Application_ID] [uniqueidentifier] NULL,
[DomainName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Verified] [bit] NOT NULL,
[DateModified] [datetime] NOT NULL,
[DateAdded] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Domain_Names] ADD CONSTRAINT [PK_ID_DATA_Domain_Names] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Domain_Names] ADD CONSTRAINT [FK_DATA_Domain_Names_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Domain_Names', NULL, NULL
GO

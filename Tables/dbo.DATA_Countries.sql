CREATE TABLE [dbo].[DATA_Countries]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Abbr] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Display_Order] [int] NOT NULL CONSTRAINT [DF_DATA_Countries_Display_Order] DEFAULT ((10000)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_DATA_Countries_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_DATA_Countries_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Countries] ADD CONSTRAINT [PK_DATA_Countries] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Countries', NULL, NULL
GO

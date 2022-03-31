CREATE TABLE [dbo].[DATA_ZipCodes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ZIPCode] [int] NOT NULL,
[ZIPType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CityName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CityType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CountyName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CountyFIPS] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StateName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StateAbbr] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StateFIPS] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MSACode] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaCode] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TimeZone] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UTC] [float] NULL,
[DST] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Latitude] [float] NULL,
[Longitude] [float] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_ZipCodes] ADD CONSTRAINT [PK_ID_DATA_ZipCodes] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_ZipCodes', NULL, NULL
GO

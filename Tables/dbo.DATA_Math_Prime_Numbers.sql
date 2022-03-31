CREATE TABLE [dbo].[DATA_Math_Prime_Numbers]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[PrimeBase10] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PrimeBase2] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Math_Prime_Numbers] ADD CONSTRAINT [PK_ID_DATA_Math_Prime_Numbers] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Math_Prime_Numbers', NULL, NULL
GO

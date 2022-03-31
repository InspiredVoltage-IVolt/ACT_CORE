CREATE TABLE [dbo].[DATA_County_SSA_FIPS_Crosstalk]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[County_ID] [int] NULL,
[State_ID] [int] NULL,
[County] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[State] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SSA_CODE] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FIPS_CODE] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CBSA] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CBSA_NAME] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Year] [int] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_County_SSA_FIPS_Crosstalk] ADD CONSTRAINT [PK_ID_DATA_County_SSA_FIPS_Crosstalk] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_County_SSA_FIPS_Crosstalk] ADD CONSTRAINT [FK_DATA_County_SSA_FIPS_Crosstalk_DATA_Counties] FOREIGN KEY ([County_ID]) REFERENCES [dbo].[DATA_Counties] ([ID])
GO
ALTER TABLE [dbo].[DATA_County_SSA_FIPS_Crosstalk] ADD CONSTRAINT [FK_DATA_County_SSA_FIPS_Crosstalk_DATA_States] FOREIGN KEY ([State_ID]) REFERENCES [dbo].[DATA_States] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_County_SSA_FIPS_Crosstalk', NULL, NULL
GO

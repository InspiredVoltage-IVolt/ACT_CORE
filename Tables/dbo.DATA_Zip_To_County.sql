CREATE TABLE [dbo].[DATA_Zip_To_County]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[County_ID] [int] NULL,
[ZipCode_ID] [int] NULL,
[ZipCode] [int] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Zip_To_County] ADD CONSTRAINT [PK_ID_DATA_Zip_To_County] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_Zip_To_County] ADD CONSTRAINT [FK_DATA_Zip_To_County_DATA_Counties] FOREIGN KEY ([County_ID]) REFERENCES [dbo].[DATA_Counties] ([ID])
GO
ALTER TABLE [dbo].[DATA_Zip_To_County] ADD CONSTRAINT [FK_DATA_Zip_To_County_DATA_ZipCodes] FOREIGN KEY ([ZipCode_ID]) REFERENCES [dbo].[DATA_ZipCodes] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_Zip_To_County', NULL, NULL
GO

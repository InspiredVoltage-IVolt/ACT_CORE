CREATE TABLE [dbo].[SQLTreeo_Backup]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[JSONData] [dbo].[JSON] NOT NULL,
[BackupDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SQLTreeo_Backup] ADD CONSTRAINT [PK_SQLTreeo_Backup] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO

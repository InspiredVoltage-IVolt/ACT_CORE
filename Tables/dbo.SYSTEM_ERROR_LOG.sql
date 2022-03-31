CREATE TABLE [dbo].[SYSTEM_ERROR_LOG]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Application_ID] [uniqueidentifier] NULL,
[FeatureName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Feature_ID] [int] NULL,
[ClassName] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ErrorTitle] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[AdditionalInfo] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UserInfo] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Exception] [varbinary] (max) NULL,
[StackTrace] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SYSTEM_GENERATED] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModifed] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_ERROR_LOG] ADD CONSTRAINT [PK_ID_SYSTEM_ERROR_LOG] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_ERROR_LOG', NULL, NULL
GO

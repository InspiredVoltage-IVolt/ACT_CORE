CREATE TABLE [dbo].[SYSTEM_CORE_CODE_LOG]
(
[ID] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_CORE_CODE_LOG_ID] DEFAULT (newid()),
[entered_date] [datetime] NULL CONSTRAINT [DF_CORE_CODE_LOG_entered_date] DEFAULT (getdate()),
[log_application] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_date] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_level] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_logger] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_message] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_machine_name] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_user_name] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_call_site] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_thread] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_exception] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[log_stacktrace] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_CORE_CODE_LOG] ADD CONSTRAINT [PK_CORE_CODE_LOG] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_CORE_CODE_LOG', NULL, NULL
GO

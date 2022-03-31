CREATE TABLE [dbo].[Client_Additional_Info]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Client_ID] [uniqueidentifier] NOT NULL,
[FieldName] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FieldValue] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Additional_Info] ADD CONSTRAINT [PK__Client_A__3214EC2754C6CE49] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Additional_Info] ADD CONSTRAINT [FK_Client_Additional_Info_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Client_Additional_Info', NULL, NULL
GO

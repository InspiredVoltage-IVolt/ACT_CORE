CREATE TABLE [dbo].[Environment_Keys]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Environment_Keys_ID] DEFAULT (newid()),
[Member_ID] [uniqueidentifier] NOT NULL,
[Environment_ID] [uniqueidentifier] NOT NULL,
[EncryptionKey] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateTimeImplemented] [datetime] NOT NULL,
[ExpirationDate] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Environment_Keys_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Environment_Keys_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Environment_Keys] ADD CONSTRAINT [PK_Environment_Keys] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO

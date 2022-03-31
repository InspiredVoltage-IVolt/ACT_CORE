CREATE TABLE [dbo].[DATA_PaymentTypes]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ISCC] [bit] NOT NULL CONSTRAINT [DF_DATA_PaymentTypes_ISCC] DEFAULT ((1)),
[Processor_Plugin_ID] [uniqueidentifier] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_DATA_PaymentTypes_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_DATA_PaymentTypes_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DATA_PaymentTypes] ADD CONSTRAINT [PK_DATA_PaymentTypes] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DATA_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'DATA_PaymentTypes', NULL, NULL
GO

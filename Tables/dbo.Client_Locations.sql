CREATE TABLE [dbo].[Client_Locations]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Client_Locations_ID] DEFAULT (newid()),
[Client_ID] [uniqueidentifier] NOT NULL,
[FirstName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DBA] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address1] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address2] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[City] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[State_ID] [int] NOT NULL,
[PostalCode] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[BillingPhone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ShippingPhone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ContactPhone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LogoURL] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LogoImage] [varbinary] (max) NULL,
[EncryptionKey] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CertificateData] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Information_Confirmed] [bit] NOT NULL,
[IsPrimaryBilling] [bit] NOT NULL,
[IsPrimaryShipping] [bit] NOT NULL,
[IsPrimaryContact] [bit] NOT NULL,
[IsPrimaryTechContact] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Locations] ADD CONSTRAINT [PK_ID_Client_Locations] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Locations] ADD CONSTRAINT [FK_Client_Locations_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Client_Locations', NULL, NULL
GO

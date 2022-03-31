CREATE TABLE [dbo].[Common_Address_Data]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Common_Address_Data_ID] DEFAULT (newid()),
[Company_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[Employee_ID] [uniqueidentifier] NULL,
[Delivery_EmailAddress] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Attention_Line] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsPrimaryShipping] [bit] NOT NULL,
[IsPrimaryBilling] [bit] NOT NULL,
[Address1] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Common_Address_Data_Address1] DEFAULT (''),
[Address2] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address3] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[State_Province_District] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Postal_Code] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Country_ID] [int] NOT NULL,
[Additional_Information] [dbo].[JSON] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Common_Address_Data_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Common_Address_Data_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Common_Address_Data] ADD CONSTRAINT [PK_Common_Address_Data] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Common_Address_Data] ADD CONSTRAINT [FK_Common_Address_Data_Client_ID_TO_Clients_ID] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Common_Address_Data] ADD CONSTRAINT [FK_Common_Address_Data_Company_ID_TO_Companies_ID] FOREIGN KEY ([Company_ID]) REFERENCES [dbo].[Companies] ([ID])
GO
ALTER TABLE [dbo].[Common_Address_Data] ADD CONSTRAINT [FK_Common_Address_Data_Country_ID_TO_DATA_Countries_ID] FOREIGN KEY ([Country_ID]) REFERENCES [dbo].[DATA_Countries] ([ID])
GO
ALTER TABLE [dbo].[Common_Address_Data] ADD CONSTRAINT [FK_Common_Address_Data_Members_ID_TO_Members_ID] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO

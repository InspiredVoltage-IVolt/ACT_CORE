﻿USE [###DATABASENAME###]
GO

/****** Object:  UserDefinedDataType [dbo].[JSON(ARRAY)]    Script Date: 4/1/2022 9:58:21 AM ******/
IF EXISTS (SELECT * FROM Sys.Types WHERE name = 'JSON(ARRAY)')
	BEGIN
		DROP TYPE [JSON(ARRAY)]
	END

CREATE TYPE [dbo].[JSON(ARRAY)] FROM [NVARCHAR](MAX) NULL
GO

/****** Object:  UserDefinedDataType [dbo].[JSON(ARRAY)]    Script Date: 4/1/2022 9:58:21 AM ******/
IF EXISTS (SELECT * FROM Sys.Types WHERE name = 'JSON(OBJECT)')
	BEGIN
		DROP TYPE [JSON(OBJECT)]
	END

CREATE TYPE [dbo].[JSON(OBJECT)] FROM [NVARCHAR](MAX) NULL
GO

/****** Object:  UserDefinedDataType [dbo].[JSON(ARRAY)]    Script Date: 4/1/2022 9:58:21 AM ******/
IF EXISTS (SELECT * FROM Sys.Types WHERE name = 'JSON(OBJECTARRAY)')
	BEGIN
		DROP TYPE [JSON(OBJECTARRAY)]
	END

CREATE TYPE [dbo].[JSON(OBJECTARRAY)] FROM [NVARCHAR](MAX) NULL
GO
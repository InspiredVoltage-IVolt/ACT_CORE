﻿IF EXISTS (SELECT * FROM Sys.Types WHERE name = 'JSON(CHANGE)')
	BEGIN
		DROP TYPE [JSON(CHANGE)]
	END

CREATE TYPE [dbo].[JSON(CHANGE)] FROM [NVARCHAR](MAX) NULL
GO
﻿IF EXISTS (SELECT * FROM Sys.Types WHERE name = 'JSON')
	BEGIN
		DROP TYPE [JSON]
	END

CREATE TYPE [dbo].[JSON] FROM [NVARCHAR](MAX) NULL
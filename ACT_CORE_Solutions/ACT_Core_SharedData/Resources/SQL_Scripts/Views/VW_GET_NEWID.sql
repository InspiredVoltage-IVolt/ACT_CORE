/****** Object:  View [dbo].[VW_GET_NEWID]    Script Date: 4/16/2022 8:28:16 AM ******/
DROP VIEW [dbo].[VW_GET_NEWID]
GO

/****** Object:  View [dbo].[VW_GET_NEWID]    Script Date: 4/16/2022 8:28:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/*
Used to Create a Guid In a Function.
*/
CREATE VIEW [dbo].[VW_GET_NEWID]
AS
	SELECT NEWID() AS GeneratedID
GO



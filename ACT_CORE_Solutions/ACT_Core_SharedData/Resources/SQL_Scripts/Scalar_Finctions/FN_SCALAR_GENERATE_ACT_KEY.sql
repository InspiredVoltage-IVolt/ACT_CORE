DROP FUNCTION [dbo].[FN_SCALAR_GENERATE_ACT_KEY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark ALicz
-- Create date: 2-2022
-- Description:	Generates A New ACT KEY
-- Print dbo.FN_SCALAR_GENERATE_ACT_KEY()
-- =============================================
CREATE FUNCTION [dbo].[FN_SCALAR_GENERATE_ACT_KEY]
(
)
RETURNS NVARCHAR(30)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tmpReturn AS NVARCHAR(30)

	SET @tmpReturn = REPLACE(SUBSTRING(CAST((SELECT GeneratedID FROM dbo.VW_GET_NEWID) AS NVARCHAR(50)),1,4)+
						SUBSTRING(CAST((SELECT GeneratedID FROM dbo.VW_GET_NEWID) AS NVARCHAR(50)),2,4)+
						SUBSTRING(CAST((SELECT GeneratedID FROM dbo.VW_GET_NEWID) AS NVARCHAR(50)),9,4)+
						SUBSTRING(CAST((SELECT GeneratedID FROM dbo.VW_GET_NEWID) AS NVARCHAR(50)),11,4),'-','')

	-- Return the result of the function
	RETURN @tmpReturn

END
GO



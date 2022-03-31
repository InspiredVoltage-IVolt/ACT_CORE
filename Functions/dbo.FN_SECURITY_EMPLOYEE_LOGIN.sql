SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	Employee ADMIN Login
-- =============================================
CREATE FUNCTION [dbo].[FN_SECURITY_EMPLOYEE_LOGIN]
(
	@EmailAddress AS NVARCHAR(100),
	@Password AS NVARCHAR(100)
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tmpReturn AS UNIQUEIDENTIFIER
	
	-- Add the T-SQL statements to compute the return value here
	SET @tmpReturn = (SELECT ID FROM dbo.Employees WHERE Email = @EmailAddress AND Password = @Password AND Employment_Status = 1)

	-- Return the result of the function
	RETURN @tmpReturn

END
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_EMPLOYEES', 'SCHEMA', N'dbo', 'FUNCTION', N'FN_SECURITY_EMPLOYEE_LOGIN', NULL, NULL
GO

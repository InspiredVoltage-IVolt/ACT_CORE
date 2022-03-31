SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	Get Employee Name
-- =============================================
CREATE FUNCTION [dbo].[FUNC_EMPLOYEE_INFO_FULL_NAME_BY_ID]
(
	@EmployeeID AS UNIQUEIDENTIFIER
)
RETURNS NVARCHAR(200)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tmpReturn AS NVARCHAR(200)

	-- Add the T-SQL statements to compute the return value here
	SET @tmpReturn = (SELECT FirstName + ' ' + LastName FROM dbo.Employees WHERE ID = @EmployeeID)

	-- Return the result of the function
	RETURN @tmpReturn

END
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_EMPLOYEES', 'SCHEMA', N'dbo', 'FUNCTION', N'FUNC_EMPLOYEE_INFO_FULL_NAME_BY_ID', NULL, NULL
GO

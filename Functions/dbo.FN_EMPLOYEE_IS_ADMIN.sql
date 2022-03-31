SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 3-28-22
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[FN_EMPLOYEE_IS_ADMIN]
(
	@EmployeeID AS UNIQUEIDENTIFIER NULL
)
RETURNS BIT
AS
BEGIN
	DECLARE @tmpReturn AS BIT = 0

	IF @EmployeeID IS NOT NULL
		BEGIN
			IF EXISTS(SELECT ID FROM EMPLOYEES WHERE AdminAccount = 1 AND ID = @EmployeeID)
				SET @tmpReturn = 1
			ELSE
				SET @tmpReturn = 0
		END

	RETURN @tmpReturn
END
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_EMPLOYEES', 'SCHEMA', N'dbo', 'FUNCTION', N'FN_EMPLOYEE_IS_ADMIN', NULL, NULL
GO

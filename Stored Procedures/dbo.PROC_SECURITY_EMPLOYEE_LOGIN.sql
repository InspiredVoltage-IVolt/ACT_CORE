SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 10-7-2021
-- Description:	PROC - Security Employee Login
-- =============================================
CREATE PROCEDURE [dbo].[PROC_SECURITY_EMPLOYEE_LOGIN]
	@EmployeeEmail AS NVARCHAR(200),
	@EmployeePassword AS NVARCHAR(200),
	@RequireAdmin AS BIT    
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @EmployeeID AS UNIQUEIDENTIFIER
    -- Insert statements for procedure here
	IF @RequireAdmin = 1
		SET @EmployeeID = dbo.FN_SECURITY_EMPLOYEE_ADMIN_LOGIN(@EmployeeEmail, @EmployeePassword)
	ELSE
		SET @EmployeeID = dbo.FN_SECURITY_EMPLOYEE_LOGIN(@EmployeeEmail, @EmployeePassword)

	IF @EmployeeID IS NULL
		BEGIN
			SELECT '' AS EmployeeID WHERE 1 = 2
		END

	SELECT @EmployeeID AS EmployeeID
END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SECURITY', 'SCHEMA', N'dbo', 'PROCEDURE', N'PROC_SECURITY_EMPLOYEE_LOGIN', NULL, NULL
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	Get Dashboard Line Items For Employee
-- PROC_EMPLOYEE_ADMIN_DASHBOARD_SUMMARY_INFO 'A3C003F5-2342-41E2-9E57-3E359F7C0FA6'
-- =============================================
CREATE PROCEDURE [dbo].[PROC_EMPLOYEE_ADMIN_DASHBOARD_SUMMARY_INFO] 
	@EmployeeID AS UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	   
	DECLARE @EmpName AS NVARCHAR(200)
	SET @EmpName = dbo.FUNC_EMPLOYEE_INFO_FULL_NAME_BY_ID(@EmployeeID)
	DECLARE @tmpDataTable AS TABLE(Info nvarchar(1000), OrderOfDisplay int)

	INSERT INTO @tmpDataTable ( Info, OrderOfDisplay )
		SELECT 'Employee: ' + @EmpName AS Info, 1 AS OrderOfDisplay
    
	INSERT INTO @tmpDataTable ( Info, OrderOfDisplay )
		SELECT 'Employee Managed Companies' AS Info, 2 AS OrderOfDisplay
	
	INSERT INTO @tmpDataTable ( Info, OrderOfDisplay )
		SELECT '  Company Name: ' + CompanyName AS Info, 3 AS OrderOfDisplay FROM dbo.Companies WHERE Member_ID IN (SELECT Member_ID FROM dbo.VIEW_EMPLOYEES_ADMIN_MEMBER_RECORDS WHERE EmployeeID = @EmployeeID)
	
	INSERT INTO @tmpDataTable ( Info, OrderOfDisplay )
		SELECT 'Employee Managed Members' AS Info, 4 AS OrderOfDisplay
	
	INSERT INTO @tmpDataTable ( Info, OrderOfDisplay )
		SELECT '  [' + CAST(MemberID AS NVARCHAR(50)) + '] - [' + MemberFirstName + ' ' + MemberLastName + '] - ' + '[' + MemberEmail + ']', 5 AS OrderOfDisplay
		FROM dbo.VIEW_EMPLOYEES_ADMIN_MEMBER_RECORDS WHERE EmployeeID = @EmployeeID

	SELECT * FROM @tmpDataTable ORDER BY OrderOfDisplay ASC
	DELETE FROM @tmpDataTable
END
GO

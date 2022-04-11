SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 3-28-2022
-- Description:	Get Menu Items
-- =============================================
CREATE   PROCEDURE [dbo].[PROC_SYSTEM_MENUS_GETITEMS]
	@Parent_ID AS UNIQUEIDENTIFIER,
	@PAGE_ID AS nvarchar(100),
	@EmployeeID AS UNIQUEIDENTIFIER NULL,
	@MemberID AS UNIQUEIDENTIFIER NULL,
	@ClientID AS UNIQUEIDENTIFIER NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @EmployeeISAdmin AS BIT = dbo.FN_EMPLOYEE_IS_ADMIN(@EmployeeID)

	

    SELECT * FROM dbo.SYSTEM_MENUS SM 
		LEFT JOIN System_Menus SM2 ON ((SM2.ID = SM.Parent_ID AND SM.Parent_ID IS NOT NULL) AND (@EmployeeID IS NOT NULL AND (SM2.SystemAdminOnly = 1 AND @EmployeeISAdmin = 1)))
		WHERE SM.Page_ID = @PAGE_ID AND (SM.SystemAdminOnly = 1 AND @EmployeeISAdmin = 1)
			

END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM', 'SCHEMA', N'dbo', 'PROCEDURE', N'PROC_SYSTEM_MENUS_GETITEMS', NULL, NULL
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[PROC_LICENSE_CHECK] 
	@LicenseID AS UNIQUEIDENTIFIER,
	@LicenseProductName AS NVARCHAR(200),
	@LicenseProductionServerCount AS INT,
	@LicenseDevelopmentServerCount AS INT,
	@LicenseDeveloperCount AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @tmpGuid AS UNIQUEIDENTIFIER
	SET @tmpGuid = (SELECT ID FROM Products WHERE Name = @LicenseProductName)
    -- Insert statements for procedure here
	SELECT * FROM dbo.Licenses WHERE ID = @LicenseID AND Product_ID = @tmpGuid AND Production_Server_Count = @LicenseProductionServerCount AND
		Development_Server_Count = @LicenseDevelopmentServerCount AND Developer_Count = @LicenseDeveloperCount
		AND GETDATE() > ExpiresOn


END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'LICENSE_MANAGEMENT', 'SCHEMA', N'dbo', 'PROCEDURE', N'PROC_LICENSE_CHECK', NULL, NULL
GO

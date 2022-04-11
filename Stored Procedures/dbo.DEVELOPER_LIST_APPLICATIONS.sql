SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	<Description,,>
-- DEVELOPER_LIST_APPLICATIONS 'cb8af51d-7a81-46be-97d6-700cba7d0aa1', 1
-- =============================================
CREATE PROCEDURE [dbo].[DEVELOPER_LIST_APPLICATIONS]
	@MemberID AS UNIQUEIDENTIFIER,
	@ShowOrganizationApps AS BIT  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @tmpMemID AS UNIQUEIDENTIFIER
	DECLARE @tmpCompanyID AS TABLE (CompanyID UNIQUEIDENTIFIER)
	DECLARE @tmpClientID AS TABLE (ClientID UNIQUEIDENTIFIER)

	SET @tmpMemID = dbo.FN_SECURITY_ENSURE_MEMBER_ISVALID(@MemberID)
	INSERT Into @tmpCompanyID (CompanyID) 
		SELECT CompanyID From dbo.TBLFN_MEMBER_GET_COMPANYIDS(@MemberID)

	INSERT INTO @tmpClientID (ClientID)
		SELECT ClientID FROM dbo.TBLFN_MEMBER_GET_CLIENTIDS(@MemberID)

	IF @tmpMemID IS NULL
		BEGIN
			SELECT NULL AS APPID, NULL AS COMPANYID, NULL AS CLIENTID, 'Member Validity Did Not Pass' AS APPNAME
			RETURN
		END
    
	
		BEGIN			
			IF @ShowOrganizationApps = 1
				BEGIN
					SELECT ID, Company_ID, Client_ID, Name FROM Applications WHERE Client_ID IN (SELECT ClientID FROM @tmpClientID) OR Company_ID IN (SELECT Company_ID FROM @tmpCompanyID)
                    UNION					
					SELECT ID, Company_ID, Client_ID, Name FROM Applications WHERE Member_ID = @MemberID 
				END
			ELSE
				BEGIN
					SELECT ID, Company_ID, Client_ID, Name FROM Applications WHERE Member_ID = @MemberID 
                    RETURN
				END
		END

	
END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATIONS', 'SCHEMA', N'dbo', 'PROCEDURE', N'DEVELOPER_LIST_APPLICATIONS', NULL, NULL
GO

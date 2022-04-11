SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: <Create Date,,>
-- Description:	Quick Login For Rapid Application Access - Additional calls to Population Permissions Happen ASYNC
/*

declare @tmpMemOut as uniqueidentifier

exec [PROC_MEMBER_LOGIN_QUICK] 'malicz@ivolt.io','5FF333A205A520A13CFBB987B3F004F987878694A3DF6F25C7EB7992CBBD45B73CF443D3703D91F6A52A703DBD98F492520BD251F9BD102B5E05A9857B8AEAF5',1, @tmpMemOut OUTPUT

print @tmpMemOut

*/
-- =============================================
CREATE PROCEDURE [dbo].[PROC_MEMBER_LOGIN_QUICK]
	@EmailAddress AS NVARCHAR(500),
	@Password AS NVARCHAR(1000),
	@SelectData AS BIT ,
	@MemberID AS UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--PRINT 'here'
	--PRINT @EmailAddress
	--PRINT @Password
	SET @MemberID = (SELECT ID FROM Members WHERE Email_Address = @EmailAddress AND [Password] = @Password AND Deleted = 0 AND ConfirmationCode IS NULL)

	DECLARE @SuccessTmp AS BIT

    IF @MemberID IS NULL 
		SET @SuccessTmp = 0
	ELSE
		SET @SuccessTmp = 1


	--INSERT INTO dbo.SYSTEM_MEMBER_LOGIN_ATTEMPTS (UN,PW,Success,DateAdded)
	--	VALUES(@EmailAddress,@Password,@SuccessTmp,GETDATE())
	IF @SelectData = 1
		BEGIN
			IF @SuccessTmp = 1
				SELECT * FROM Members WHERE ID = @MemberID
			ELSE
				SELECT * FROM Members WHERE 1 = 2
		END

	RETURN
END
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SECURITY', 'SCHEMA', N'dbo', 'PROCEDURE', N'PROC_MEMBER_LOGIN_QUICK', NULL, NULL
GO

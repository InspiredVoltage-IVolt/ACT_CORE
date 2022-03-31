SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	<Description, ,>
-- print dbo.FN_SECURITY_LOGIN_MEMBER('malicz@ivolt.io','5FF333A205A520A13CFBB987B3F004F987878694A3DF6F25C7EB7992CBBD45B73CF443D3703D91F6A52A703DBD98F492520BD251F9BD102B5E05A9857B8AEAF5')
-- =============================================
CREATE FUNCTION [dbo].[FN_SECURITY_LOGIN_MEMBER]
(
	@MemberEmail AS NVARCHAR(500),
	@Pasword AS NVARCHAR(500)
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tmpReturn AS UNIQUEIDENTIFIER

	-- Add the T-SQL statements to compute the return value here
	SELECT @tmpReturn = ID FROM Members WHERE Email = @MemberEmail AND Password = @Pasword
			AND Deleted = 0 AND ConfirmationCode IS NULL AND Account_Status_ID = (SELECT ID FROM dbo.SYSTEM_MEMBER_ACCOUNT_STATUS WHERE AllOK = 1)


	-- Return the result of the function
	RETURN @tmpReturn

END


GO

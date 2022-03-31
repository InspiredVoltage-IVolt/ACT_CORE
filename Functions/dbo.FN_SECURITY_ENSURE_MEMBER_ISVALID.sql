SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[FN_SECURITY_ENSURE_MEMBER_ISVALID]
(
	@MemberID AS UNIQUEIDENTIFIER
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tmpReturn AS UNIQUEIDENTIFIER

	-- Add the T-SQL statements to compute the return value here
	SELECT @tmpReturn = ID FROM Members WHERE ID = @MemberID
			AND Deleted = 0 AND ConfirmationCode IS NULL AND Account_Status_ID = (SELECT ID FROM dbo.SYSTEM_MEMBER_ACCOUNT_STATUS WHERE AllOK = 1)

	-- Return the result of the function
	RETURN @tmpReturn

END
GO

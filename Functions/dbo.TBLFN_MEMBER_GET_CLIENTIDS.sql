SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[TBLFN_MEMBER_GET_CLIENTIDS] 
(	
	@MemberID AS UNIQUEIDENTIFIER
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
		SELECT C.ID AS ClientID FROM dbo.Application_To_Member A INNER JOIN dbo.Applications B ON A.Application_ID = B.ID
		INNER JOIN dbo.Companies C ON B.Client_ID = C.ID WHERE A.Member_ID = @MemberID
	UNION
		SELECT A.Client_ID AS ClientID FROM dbo.Applications A WHERE A.Member_ID = @MemberID AND A.Client_ID IS NOT NULL
)
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: <Create Date,,>
-- Description:	Quick Login For Rapid Application Access - Additional calls to Population Permissions Happen ASYNC
-- =============================================
CREATE PROCEDURE [dbo].[PROC_MEMBER_LOGIN_QUICK]
	@EmailAddress AS NVARCHAR(500),
	@Password AS NVARCHAR(1000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Members WHERE Email = @EmailAddress AND [Password] = @Password
END
GO

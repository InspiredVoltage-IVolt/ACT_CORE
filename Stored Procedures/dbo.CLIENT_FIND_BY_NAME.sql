SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CLIENT_FIND_BY_NAME] 
	-- Add the parameters for the stored procedure here
	@ClientName AS NVARCHAR(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Clients WHERE Company_Name = @ClientName
END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENTS', 'SCHEMA', N'dbo', 'PROCEDURE', N'CLIENT_FIND_BY_NAME', NULL, NULL
GO

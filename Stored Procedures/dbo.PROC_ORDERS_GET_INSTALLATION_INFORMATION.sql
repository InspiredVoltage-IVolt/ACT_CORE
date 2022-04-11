SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_ORDERS_GET_INSTALLATION_INFORMATION] 
	@OrderID AS UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'ORDERS', 'SCHEMA', N'dbo', 'PROCEDURE', N'PROC_ORDERS_GET_INSTALLATION_INFORMATION', NULL, NULL
GO

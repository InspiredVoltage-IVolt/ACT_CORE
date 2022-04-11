SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_PLUGINS_CREATE_PLUGIN]
	@Application_ID AS UNIQUEIDENTIFIER,
	@Application_Environment_ID AS UNIQUEIDENTIFIER,
	@System_Interface_ID AS UNIQUEIDENTIFIER,
	@Dependancy_ID AS UNIQUEIDENTIFIER,
	@Member_ID AS UNIQUEIDENTIFIER,
	@Client_ID AS UNIQUEIDENTIFIER,
	@Company_ID AS UNIQUEIDENTIFIER,
	@IsCoreEncryption BIT,
	@DataHasBeenEncrypted AS BIT,
	@Full_Class_Name AS nvarchar(500),
	@Is_Default AS BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @Application_ID IS NULL

	INSERT INTO dbo.Application_Plugins
		( Application_ID, Application_Environment_ID, System_Interface_ID, Dependancy_ID, Member_ID, Client_ID, Company_ID, IsCoreEncryption,
	    DataHasBeenEncrypted, Full_Class_Name, Is_Default)
	VALUES
		(@Application_ID,	@Application_Environment_ID,	@System_Interface_ID,	@Dependancy_ID,	@Member_ID,	@Client_ID ,	@Company_ID,	@IsCoreEncryption, 
		@DataHasBeenEncrypted,	@Full_Class_Name,	@Is_Default )


END

GO
EXEC sp_addextendedproperty N'VirtualFolder', N'PLUGINS', 'SCHEMA', N'dbo', 'PROCEDURE', N'PROC_PLUGINS_CREATE_PLUGIN', NULL, NULL
GO

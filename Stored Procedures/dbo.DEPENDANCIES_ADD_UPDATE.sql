SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DEPENDANCIES_ADD_UPDATE]
	-- Add the parameters for the stored procedure here
	@FileName AS NVARCHAR(200),
	@FileVersion AS NVARCHAR(10),
	@Source AS NVARCHAR(400),
	@UpdateSource AS NVARCHAR(500),
	@CoreRequired AS BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @TmpReturn AS UNIQUEIDENTIFIER
	DECLARE @ExistingVersion AS INT

	SET @TmpReturn = NEWID()

	IF EXISTS(SELECT * FROM dbo.SYSTEM_DEPENDENCIES WHERE FileName = @FileName)
		BEGIN
			SET @ExistingVersion = (SELECT TOP 1 DBVersion FROM dbo.SYSTEM_DEPENDENCIES WHERE @FileName = @FileName ORDER BY DBVersion DESC)
			SET @ExistingVersion = @ExistingVersion + 1			
		 END

	INSERT INTO [dbo].SYSTEM_DEPENDENCIES ([ID],[FileName],[FileVersion],[Source],[UpdateSource],[CoreRequired],DBVersion,[DateAdded]) 
	VALUES (@TmpReturn, @FileName, @FileVersion, @Source, @UpdateSource, @CoreRequired, @ExistingVersion, GETDATE())

	SELECT @TmpReturn


END
GO

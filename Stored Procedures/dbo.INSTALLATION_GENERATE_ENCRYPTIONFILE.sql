SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 2021
-- Description:	Checks Login Info - Generates Key
-- exec INSTALLATION_GENERATE_ENCRYPTIONFILE N'mark@ivolt.io', N'5FF333A205A520A13CFBB987B3F004F987878694A3DF6F25C7EB7992CBBD45B73CF443D3703D91F6A52A703DBD98F492520BD251F9BD102B5E05A9857B8AEAF5','FF19B7EF-859D-434D-BD8E-6EA994BF0115','1BDD7C3D-3798-4340-A7D1-3BE3134796B6','11F4589E-F816-44FB-A02D-30E400DFD170'
-- =============================================

CREATE PROCEDURE [dbo].[INSTALLATION_GENERATE_ENCRYPTIONFILE] 
	@EmployeeEmail AS NVARCHAR(200),
	@EmployeePassword AS NVARCHAR(200),
	@ClientID AS UNIQUEIDENTIFIER,
	@LicenseID AS UNIQUEIDENTIFIER,
	@ApplicationID AS UNIQUEIDENTIFIER
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	DECLARE @EmployeeID UNIQUEIDENTIFIER
	DECLARE @tmpKey nvarchar(MAX)

	SET @EmployeeID = dbo.FN_SECURITY_EMPLOYEE_ADMIN_LOGIN(@EmployeeEmail, @EmployeePassword)
	
	IF @EmployeeID IS NULL
		BEGIN
			SELECT '' AS EmployeeID, '' AS EncryptionKey WHERE 1 = 2
		END

	IF NOT EXISTS(SELECT ID FROM Licenses WHERE Client_ID = @ClientID AND ID = @LicenseID)
		BEGIN
			SELECT '' AS EmployeeID, '' AS EncryptionKey WHERE 1 = 2
		END

	IF NOT EXISTS(SELECT ID FROM Applications WHERE dbo.Applications.Approved = 1 AND ID = @ApplicationID)
		BEGIN
			SELECT '' AS EmployeeID, '' AS EncryptionKey WHERE 1 = 2
		END

	SET @tmpKey = (SELECT EncryptionKey FROM dbo.Client_Keys 
	WHERE DateTimeImplemented < GETDATE() AND ExpirationDate > GETDATE() 
			  AND Client_ID = @ClientID AND Application_ID = @ApplicationID)

	SELECT @EmployeeID AS EmployeeID, @tmpKey AS EncryptionKey
END
GO

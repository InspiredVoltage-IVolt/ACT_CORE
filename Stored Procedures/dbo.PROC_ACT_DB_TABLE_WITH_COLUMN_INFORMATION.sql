SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_ACT_DB_TABLE_WITH_COLUMN_INFORMATION] 	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT t.name AS TableName, c.name AS ColumnName, c.column_id AS ColumnID, c.system_type_id AS SystemTypeID, c.max_length AS 'MaxLength', 
	c.object_id AS ObjectID, c.precision AS 'Precision', c.is_identity AS 'IS_IDENTITY', c.is_nullable AS 'IS NULLABLE', p.name AS UserTypeName 
	FROM sys.tables t 
	INNER JOIN sys.columns c ON t.object_id = c.object_id
	INNER JOIN sys.types p ON p.user_type_id = c.user_type_id
END
GO

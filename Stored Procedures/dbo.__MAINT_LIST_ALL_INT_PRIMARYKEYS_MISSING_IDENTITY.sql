SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz
-- Create date: 5-26/2021
-- Description:	ADDS PRIMARY KEYS TO TABLES MISSING THEM
-- =============================================
CREATE PROCEDURE [dbo].[__MAINT_LIST_ALL_INT_PRIMARYKEYS_MISSING_IDENTITY]
AS
BEGIN
	SELECT  i.name AS IndexName ,
        OBJECT_NAME(ic.OBJECT_ID) AS TableName ,
        COL_NAME(ic.OBJECT_ID, ic.column_id) AS ColumnName ,
        ( SELECT    is_identity
          FROM      sys.columns c
                    INNER JOIN sys.tables t ON c.object_id = t.object_id
          WHERE     c.name = COL_NAME(ic.OBJECT_ID, ic.column_id)
                    AND t.name = OBJECT_NAME(ic.OBJECT_ID)
        ) AS 'identity'
FROM    sys.indexes AS i
        INNER JOIN sys.index_columns AS ic ON i.OBJECT_ID = ic.OBJECT_ID
                                              AND i.index_id = ic.index_id
		INNER JOIN sys.columns ON columns.column_id = ic.column_id AND columns.object_id = ic.object_id
WHERE   i.is_primary_key = 1 AND sys.columns.system_type_id != 36
ORDER BY OBJECT_NAME(ic.OBJECT_ID)
END
GO

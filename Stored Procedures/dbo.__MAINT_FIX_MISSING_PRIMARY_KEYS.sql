SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mark Alicz-IVolt
-- Create date: 2021
-- Description:	ADDS PRIMARY KEYS TO TABLES MISSING THEM  (SUPPORTS  INTEGERS and UNIQUEIDENTIFIERS)
-- Parameters: @AutoExecute -- Try and Execute the SQL Statements After they have been Identified.
-- =============================================
CREATE PROCEDURE [dbo].[__MAINT_FIX_MISSING_PRIMARY_KEYS]
	@AutoExecute AS BIT = 0
AS
BEGIN
	
SET NOCOUNT ON

	DECLARE @TableData AS TABLE(TableName NVARCHAR(100), ColumnName NVARCHAR(100), IsGUID BIT, MissingPK BIT, CREATEPKSQL NVARCHAR(MAX), CREATEDEFAULTSQL NVARCHAR(MAX))
	DECLARE @tmpGoodTables AS TABLE(oid INT)

	INSERT INTO @tmpGoodTables ( oid )
		SELECT Distinct tab.object_id FROM sys.tables tab
			INNER JOIN sys.columns col ON tab.object_id = col.object_id
			INNER Join sys.indexes pk on tab.object_id = pk.object_id and pk.is_primary_key = 1
	
	DECLARE BadTblCursor CURSOR FAST_FORWARD READ_ONLY FOR SELECT object_id FROM sys.tables WHERE object_id NOT IN (SELECT oid FROM @tmpGoodTables)
	DECLARE @tmpNeededTblID AS INT

	OPEN BadTblCursor
	FETCH NEXT FROM BadTblCursor INTO @tmpNeededTblID

	WHILE @@FETCH_STATUS = 0   -- Sys Types INT = 56  GUID = 36
		BEGIN
			DECLARE @tmpTableName AS NVARCHAR(200)
			DECLARE @tmpColumnName AS NVARCHAR(200)
			DECLARE @tmpColumnType AS INT
			DECLARE @tmpExecSQL AS NVARCHAR(500)
			DECLARE @tmpExecSQL_Default AS NVARCHAR(500)
		
			SET @tmpTableName = (SELECT tab.name FROM sys.tables tab WHERE tab.object_id = @tmpNeededTblID)
			SET @tmpColumnName = (SELECT TOP 1 col.name FROM sys.columns col WHERE col.object_id = @tmpNeededTblID ORDER BY column_id ASC)		
			SET @tmpColumnType = (SELECT system_type_id FROM sys.columns WHERE object_id = @tmpNeededTblID AND name = @tmpColumnName)

			SET @tmpExecSQL =  N'ALTER TABLE [' + @tmpTableName + '] ADD CONSTRAINT PK_' + @tmpColumnName + '_' + @tmpTableName + ' PRIMARY KEY (' + @tmpColumnName + ');'

			IF @tmpColumnType = 36
				BEGIN
					SET @tmpExecSQL_Default = N'ALTER TABLE [' + @tmpTableName  + '] ADD CONSTRAINT DF_' + @tmpTableName + '_' + @tmpColumnName + ' DEFAULT ''newid()'' FOR ' + @tmpColumnName
				END
			ELSE
				BEGIN
					SET @tmpExecSQL_Default = N'ALTER TABLE [' + @tmpTableName  + '] ADD [' + @tmpColumnName + '] INT IDENTITY(1,1)'
				END

			INSERT INTO @TableData ( TableName, ColumnName, IsGUID, MissingPK,CREATEPKSQL, CREATEDEFAULTSQL )
				VALUES (@tmpTableName, @tmpColumnName, CASE WHEN @tmpColumnType = 56 THEN 0 ELSE 1 END, 1, @tmpExecSQL, @tmpExecSQL_Default)

			FETCH NEXT FROM BadTblCursor INTO @tmpNeededTblID
		END

	CLOSE BadTblCursor
	DEALLOCATE BadTblCursor

	-- CLEANUP MY DATA
	DELETE From @tmpGoodTables

	IF @AutoExecute = 1
		BEGIN
			SET @tmpExecSQL = NULL 
			SET @tmpExecSQL_Default = NULL

			DECLARE execCursor CURSOR FAST_FORWARD READ_ONLY FOR SELECT CREATEPKSQL, CREATEDEFAULTSQL FROM @TableData	
			OPEN execCursor

			FETCH NEXT FROM execCursor INTO @tmpExecSQL, @tmpExecSQL_Default

			WHILE @@FETCH_STATUS = 0
				BEGIN
					BEGIN TRY
						IF @tmpExecSQL IS NOT NULL
							BEGIN
								EXECUTE sp_executesql @tmpExecSQL
								SET @tmpExecSQL = NULL 
							END
					END TRY
					BEGIN CATCH
						PRINT 'Error Executing: ' + @tmpExecSQL
					END CATCH

					BEGIN TRY
						IF @tmpExecSQL_Default IS NOT NULL
							BEGIN
								EXECUTE sp_executesql @tmpExecSQL_Default
								SET @tmpExecSQL_Default = NULL
							END
					END TRY
					BEGIN CATCH
						PRINT 'Error Executing: ' + @tmpExecSQL_Default
					END CATCH
				
					FETCH NEXT FROM execCursor INTO @tmpExecSQL, @tmpExecSQL_Default
				END

			CLOSE execCursor
			DEALLOCATE execCursor

		END


END
GO

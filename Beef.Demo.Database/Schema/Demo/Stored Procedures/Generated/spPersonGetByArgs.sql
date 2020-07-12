CREATE PROCEDURE [Demo].[spPersonGetByArgs]
   @FirstName AS NVARCHAR(100) NULL = NULL
  ,@LastName AS NVARCHAR(100) NULL = NULL
  ,@GenderCodes AS [dbo].[udtnvarcharlist] READONLY
  ,@PagingSkip AS INT = 0
  ,@PagingTake AS INT = 250
  ,@PagingCount AS BIT = NULL
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost. 
   */
 
  SET NOCOUNT ON;

  -- Check list counts.
  DECLARE @GenderCodesCount AS INT
  SET @GenderCodesCount = (SELECT COUNT(*) FROM @GenderCodes)

  -- Select the requested data.
  SELECT
        [p].[PersonId]
       ,[p].[FirstName]
       ,[p].[LastName]
       ,[p].[GenderCode]
       ,[p].[Birthday]
       ,[p].[RowVersion]
       ,[p].[CreatedBy]
       ,[p].[CreatedDate]
       ,[p].[UpdatedBy]
       ,[p].[UpdatedDate]
    FROM [Demo].[Person] AS [p]
    WHERE (@FirstName IS NULL OR [p].[FirstName] LIKE @FirstName)
      AND (@LastName IS NULL OR [p].[LastName] LIKE @LastName)
      AND (@GenderCodesCount = 0 OR [p].[GenderCode] IN (SELECT [Value] FROM @GenderCodes))
    ORDER BY [p].[LastName], [p].[FirstName]
      OFFSET @PagingSkip ROWS FETCH NEXT @PagingTake ROWS ONLY

  -- Return the full (all pages) row count.
  IF (@PagingCount IS NOT NULL AND @PagingCount = 1)
  BEGIN
    RETURN (SELECT COUNT(*)
      FROM [Demo].[Person] AS [p]
      WHERE (@FirstName IS NULL OR [p].[FirstName] LIKE @FirstName)
        AND (@LastName IS NULL OR [p].[LastName] LIKE @LastName)
        AND (@GenderCodesCount = 0 OR [p].[GenderCode] IN (SELECT [Value] FROM @GenderCodes)))
  END
END
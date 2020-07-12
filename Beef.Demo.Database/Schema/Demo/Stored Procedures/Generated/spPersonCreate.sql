CREATE PROCEDURE [Demo].[spPersonCreate]
   @PersonId AS UNIQUEIDENTIFIER = NULL OUTPUT
  ,@FirstName AS NVARCHAR(100) NULL = NULL
  ,@LastName AS NVARCHAR(100) NULL = NULL
  ,@GenderCode AS NVARCHAR(50) NULL = NULL
  ,@Birthday AS DATE NULL = NULL
  ,@CreatedBy AS NVARCHAR(250) NULL = NULL
  ,@CreatedDate AS DATETIME2 NULL = NULL
  ,@ReselectRecord AS BIT = 0
AS
BEGIN
  /*
   * This file is automatically generated; any changes will be lost. 
   */
 
  SET NOCOUNT ON;
  
  BEGIN TRY
    -- Wrap in a transaction.
    BEGIN TRANSACTION

    -- Set audit details.
    EXEC @CreatedDate = fnGetTimestamp @CreatedDate
    EXEC @CreatedBy = fnGetUsername @CreatedBy

    DECLARE @InsertedIdentity TABLE([PersonId] UNIQUEIDENTIFIER)

    -- Create the record.
    INSERT INTO [Demo].[Person] (
        [FirstName]
       ,[LastName]
       ,[GenderCode]
       ,[Birthday]
       ,[CreatedBy]
       ,[CreatedDate]
    )
    OUTPUT inserted.PersonId INTO @InsertedIdentity
    VALUES (
        @FirstName
       ,@LastName
       ,@GenderCode
       ,@Birthday
       ,@CreatedBy
       ,@CreatedDate
    )

    -- Get the inserted identity.
    SELECT @PersonId = [PersonId] FROM @InsertedIdentity

    -- Commit the transaction.
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    -- Rollback transaction and rethrow error.
    IF @@TRANCOUNT > 0
      ROLLBACK TRANSACTION;

    THROW;
  END CATCH
  
  -- Reselect record.
  IF @ReselectRecord = 1
  BEGIN
    EXEC [Demo].[spPersonGet] @PersonId
  END
END
CREATE PROCEDURE [Demo].[spPersonGet]
   @PersonId AS UNIQUEIDENTIFIER
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost. 
   */
 
  SET NOCOUNT ON;

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
    WHERE [p].[PersonId] = @PersonId
END
CREATE PROCEDURE [Demo].[spCompanyGet]
   @CompanyId AS UNIQUEIDENTIFIER
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost. 
   */
 
  SET NOCOUNT ON;

  SELECT
        [c].[CompanyId]
       ,[c].[Name]
       ,[c].[Address]
       ,[c].[Phone]
       ,[c].[RowVersion]
       ,[c].[CreatedBy]
       ,[c].[CreatedDate]
       ,[c].[UpdatedBy]
       ,[c].[UpdatedDate]
    FROM [Demo].[Company] AS [c]
    WHERE [c].[CompanyId] = @CompanyId
END
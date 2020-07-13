CREATE PROCEDURE [Demo].[spCompanyGetAll]
AS
BEGIN
 
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
    ORDER BY [c].[Name]
END
CREATE PROCEDURE [dbo].[spProduct_GetById] @Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.Id
		,p.ProductName
		,p.[Description]
		,p.RetailPrice
		,p.QuantityInStock
		,p.IsTaxable
	FROM dbo.Product p
	WHERE Id = @Id;
END


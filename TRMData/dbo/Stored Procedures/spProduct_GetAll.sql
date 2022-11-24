CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	set nocount on;

	SELECT p.id
		,p.ProductName
		,p.[Description]
		,p.RetailPrice
		,p.QuantityInStock
	FROM dbo.Product p
	ORDER BY ProductName;
END
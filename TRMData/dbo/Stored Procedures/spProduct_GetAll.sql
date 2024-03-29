﻿CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	set nocount on;

	SELECT p.Id
		,p.ProductName
		,p.[Description]
		,p.RetailPrice
		,p.QuantityInStock
		,p.IsTaxable
	FROM dbo.Product p
	ORDER BY ProductName;
END
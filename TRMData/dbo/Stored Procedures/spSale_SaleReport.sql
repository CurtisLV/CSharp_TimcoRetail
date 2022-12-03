CREATE PROCEDURE [dbo].[spSale_SaleReport]
	@param1 int = 0,
	@param2 int
AS
BEGIN
	SET NOCOUNT ON;

	select  [s].[SaleDate], [s].[SubTotal], [s].[Tax], [s].[Total], u.FirstName, u.LastName, u.EmailAddress
	from dbo.Sale s 
	inner join dbo.[User] u on s.CashierId = u.Id;
END

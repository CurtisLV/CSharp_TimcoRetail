CREATE PROCEDURE [dbo].[spInventory_GetAll]

AS
Begin
	set nocount on;
	select [ProductId], [Quantity], [PurchasePrice], [PurchaseDate]
	from dbo.Inventory
End
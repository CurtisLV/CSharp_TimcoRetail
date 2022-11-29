CREATE PROCEDURE [dbo].[spSaleDetail_Insert] 
	@SaleId INT
	,@ProductId INT
	,@Quantity INT
	,@PurchasePrice MONEY
	,@Tax MONEY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	INSERT INTO dbo.SaleDetail (SaleId, ProductId, Quantity, PurchasePrice, Tax)
	VALUES (@SaleId, @ProductId, @Quantity, @PurchasePrice, @Tax);
END

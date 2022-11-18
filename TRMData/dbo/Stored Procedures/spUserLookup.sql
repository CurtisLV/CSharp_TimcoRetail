CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)

AS

BEGIN
	SET NOCOUNT ON;

	SELECT FirstName, LastName, LastName
	FROM [dbo].[User]
	WHERE Id = @Id;
END
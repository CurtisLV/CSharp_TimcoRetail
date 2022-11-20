CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)

AS

BEGIN
	SET NOCOUNT ON;

	SELECT u.Id, u.FirstName, u.LastName, u.LastName, u.EmailAddress, u.CreatedDate
	FROM [dbo].[User] u
	WHERE u.Id = @Id;
END
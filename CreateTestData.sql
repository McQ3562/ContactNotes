USE ContactNotes

EXEC sp_ADD_Contact
	@FirstName =
	@LastName =
	@Gender =
	@BirthDate =
	@VirtualParty =
	@VirtualPartyWho =,
	@InPerson =
	@InPersonWho =
	@Referal =
	@ReferalWho =
	@DirectSalesWebsite =
	@Other =
	@OtherWhere =

EXEC sp_ADD_Note @NoteTilte='Test Title 1', @Note='Test Note 1'
EXEC sp_ADD_Note @NoteTilte='Test Title 2', @Note='Test Note 2'
EXEC sp_ADD_Note @NoteTilte='Test Title 3', @Note='Test Note 3'
EXEC sp_ADD_Note @NoteTilte='Test Title 4', @Note='Test Note 4'
EXEC sp_ADD_Note @NoteTilte='Test Title 5', @Note='Test Note 5'
EXEC sp_ADD_Note @NoteTilte='Test Title 6', @Note='Test Note 6'

EXEC sp_GET_Note_List
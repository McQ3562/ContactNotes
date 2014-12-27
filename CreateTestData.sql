USE ContactNotes

EXEC sp_ADD_Contact
	@FirstName = 'AFirstName'
	,@LastName = 'ZLastName'
	,@Gender = 'M'
	,@BirthDate = '5/29/1972'
	,@StatusID = 'Prospect'
	,@PotentualID = 'No'
	,@EmailAddress = 'SomeOne@SomeWhere.net'
	,@VirtualParty = 'Y'
	,@VirtualPartyWho = 'Bob'
	,@InPerson = 'N'
	,@InPersonWho = 'InPersonWho'
	,@Referal = 'N'
	,@ReferalWho = 'ReferalWho'
	,@DirectSalesWebsite = 'N'
	,@Other ='N'
	,@OtherWhere ='OtherWhere'
	,@IsActive = 'Active'
EXEC sp_ADD_Address
	 @ContactID = 1
	,@ContactAddress = 'Address 1'
	,@ContactCity = 'City'
	,@ContactState = 'State'
	,@ContactZip = 'ZipCode'
	, @IsPrimary='Y'
EXEC sp_ADD_Phone
	@ContactID = 1
	,@ContactPhoneNumber = '(206) 555-1212'
	,@ContactPhoneTypeID = 2
	, @IsPrimary='Y'

EXEC sp_ADD_Note @ContactID = 1, @NoteTilte='Test Title 1', @Note='Test Note 1'
EXEC sp_ADD_Note @ContactID = 1, @NoteTilte='Test Title 2', @Note='Test Note 2'
EXEC sp_ADD_Note @ContactID = 1, @NoteTilte='Test Title 3', @Note='Test Note 3'
EXEC sp_ADD_Note @ContactID = 1, @NoteTilte='Test Title 4', @Note='Test Note 4'
EXEC sp_ADD_Note @ContactID = 1, @NoteTilte='Test Title 5', @Note='Test Note 5'
EXEC sp_ADD_Note @ContactID = 1, @NoteTilte='Test Title 6', @Note='Test Note 6'

EXEC sp_ADD_Contact @FirstName = 'BFirstName',@LastName = 'YLastName',@Gender = 'M',@BirthDate = '5/29/1972', @StatusID = 'Prospect', @PotentualID = 'No', @EmailAddress = 'SomeOne@SomeWhere.net', @VirtualParty = 'Y',@VirtualPartyWho = 'Bob',@InPerson = 'N',@InPersonWho = '',@Referal = 'N',@ReferalWho = '',@DirectSalesWebsite = 'N',@Other ='N',@OtherWhere ='',@IsActive = 'Active'
EXEC sp_ADD_Address @ContactID = 2 ,@ContactAddress = 'Address 1', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode', @IsPrimary='Y'
EXEC sp_ADD_Phone @ContactID = 2, @ContactPhoneNumber = '(206) 555-1111', @ContactPhoneTypeID = 2, @IsPrimary='Y'
EXEC sp_ADD_Address @ContactID = 2 ,@ContactAddress = 'Address 2', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode'
EXEC sp_ADD_Phone @ContactID = 2, @ContactPhoneNumber = '(206) 555-2222', @ContactPhoneTypeID = 2

EXEC sp_ADD_Contact @FirstName = 'CFirstName',@LastName = 'XLastName',@Gender = 'M',@BirthDate = '5/29/1972',@StatusID = 'Prospect', @PotentualID = 'No', @EmailAddress = 'SomeOne@SomeWhere.net', @VirtualParty = 'Y',@VirtualPartyWho = 'Bob',@InPerson = 'N',@InPersonWho = '',@Referal = 'N',@ReferalWho = '',@DirectSalesWebsite = 'N',@Other ='N',@OtherWhere ='',@IsActive = 'Active'
EXEC sp_ADD_Address @ContactID = 3 ,@ContactAddress = 'Address 1', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode', @IsPrimary='Y'
EXEC sp_ADD_Phone @ContactID = 3, @ContactPhoneNumber = '(206) 555-1111', @ContactPhoneTypeID = 2, @IsPrimary='Y'
EXEC sp_ADD_Address @ContactID = 3 ,@ContactAddress = 'Address 2', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode'
EXEC sp_ADD_Phone @ContactID = 3, @ContactPhoneNumber = '(206) 555-2222', @ContactPhoneTypeID = 2

EXEC sp_ADD_Contact @FirstName = 'DFirstName',@LastName = 'WLastName',@Gender = 'M',@BirthDate = '5/29/1972',@StatusID = 'Prospect', @PotentualID = 'No', @EmailAddress = 'SomeOne@SomeWhere.net', @VirtualParty = 'Y',@VirtualPartyWho = 'Bob',@InPerson = 'N',@InPersonWho = '',@Referal = 'N',@ReferalWho = '',@DirectSalesWebsite = 'N',@Other ='N',@OtherWhere ='',@IsActive = 'Active'
EXEC sp_ADD_Address @ContactID = 4 ,@ContactAddress = 'Address 1', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode', @IsPrimary='Y'
EXEC sp_ADD_Phone @ContactID = 4, @ContactPhoneNumber = '(206) 555-1111', @ContactPhoneTypeID = 2, @IsPrimary='Y'
EXEC sp_ADD_Address @ContactID = 4 ,@ContactAddress = 'Address 2', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode'
EXEC sp_ADD_Phone @ContactID = 4, @ContactPhoneNumber = '(206) 555-2222', @ContactPhoneTypeID = 2

EXEC sp_ADD_Contact @FirstName = 'EFirstName',@LastName = 'VLastName',@Gender = 'M',@BirthDate = '5/29/1972',@StatusID = 'Prospect', @PotentualID = 'No', @EmailAddress = 'SomeOne@SomeWhere.net', @VirtualParty = 'Y',@VirtualPartyWho = 'Bob',@InPerson = 'N',@InPersonWho = '',@Referal = 'N',@ReferalWho = '',@DirectSalesWebsite = 'N',@Other ='N',@OtherWhere ='',@IsActive = 'Active'
EXEC sp_ADD_Address @ContactID = 5 ,@ContactAddress = 'Address 1', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode', @IsPrimary='Y'
EXEC sp_ADD_Phone @ContactID = 5, @ContactPhoneNumber = '(206) 555-1111', @ContactPhoneTypeID = 2, @IsPrimary='Y'
EXEC sp_ADD_Address @ContactID = 5 ,@ContactAddress = 'Address 2', @ContactCity = 'City', @ContactState = 'State', @ContactZip = 'ZipCode'
EXEC sp_ADD_Phone @ContactID = 5, @ContactPhoneNumber = '(206) 555-2222', @ContactPhoneTypeID = 2
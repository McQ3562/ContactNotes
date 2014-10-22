USE ContactNotes
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_ADD_Note'))
	DROP PROCEDURE sp_ADD_Note
GO
CREATE PROCEDURE sp_ADD_Note
	@ContactID AS INT,
	@NoteTilte AS VARCHAR(1000),
	@Note AS VARCHAR(MAX)
AS
DECLARE @CurrentDate DATETIME
SET @CurrentDate = GETDATE()

INSERT INTO Notes (ContactID, NoteTitle, Note, IsActive, NoteCreated, NoteEdited)
VALUES (@ContactID, @NoteTilte, @Note, 'Active', @CurrentDate, @CurrentDate)

SELECT @@IDENTITY;

GO

IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_Note'))
	DROP PROCEDURE sp_GET_Note
GO
CREATE PROCEDURE sp_GET_Note
	@NoteID AS INT
AS
SELECT 
	NoteID,
	NoteTitle,
	Note,
	--IsActive,
	NoteCreated,
	NoteEdited
FROM Notes
WHERE NoteID=@NoteID
GO

IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_NoteID_List'))
	DROP PROCEDURE sp_GET_NoteID_List
GO
CREATE PROCEDURE sp_GET_NoteID_List
AS
SELECT 
	NoteID
	--,NoteTitle
	--,Note
	--,NoteCreated
	--,NoteEdited
FROM Notes
WHERE IsActive = 'Active'
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_ADD_Contact'))
	DROP PROCEDURE sp_ADD_Contact
GO
CREATE PROCEDURE sp_ADD_Contact
	@FirstName VARCHAR(500),
	@LastName VARCHAR(500),
	@Gender VARCHAR(10),
	@BirthDate DATETIME,
	@VirtualParty VARCHAR(1),
	@VirtualPartyWho VARCHAR(100),
	@InPerson VARCHAR(1),
	@InPersonWho VARCHAR(100),
	@Referal VARCHAR(1),
	@ReferalWho VARCHAR(100),
	@DirectSalesWebsite VARCHAR(1),
	@Other VARCHAR(1),
	@OtherWhere VARCHAR(100),
	@IsActive VARCHAR(10)
AS

INSERT INTO Contacts (FirstName, LastName, Gender, BirthDate, VirtualParty, VirtualPartyWho, InPerson, InPersonWho, Referal, ReferalWho, DirectSalesWebsite, Other, OtherWhere, IsActive)
VALUES(@FirstName, @LastName, @Gender, @BirthDate, @VirtualParty, @VirtualPartyWho, @InPerson, @InPersonWho, @Referal, @ReferalWho, @DirectSalesWebsite, @Other, @OtherWhere, @IsActive)

SELECT SCOPE_IDENTITY()
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_ADD_Address'))
	DROP PROCEDURE sp_ADD_Address
GO
CREATE PROCEDURE sp_ADD_Address
	 @ContactID INT
	,@ContactAddress VARCHAR(500)
	,@ContactCity VARCHAR(100)
	,@ContactState VARCHAR(100)
	,@ContactZip VARCHAR(100)
AS
INSERT INTO ContactAddress (ContactID, ContactAddress, ContactCity, ContactState, ContactZip)
VALUES (@ContactID, @ContactAddress, @ContactCity, @ContactState, @ContactZip)

SELECT SCOPE_IDENTITY()
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_ADD_Phone'))
	DROP PROCEDURE sp_ADD_Phone
GO
CREATE PROCEDURE sp_ADD_Phone
	@ContactID INT,
	@ContactPhoneNumber VARCHAR(20),
	@ContactPhoneTypeID INT
AS
INSERT INTO ContactPhone (ContactID, ContactPhoneNumber, ContactPhoneTypeID)
VALUES (@ContactID, @ContactPhoneNumber, @ContactPhoneTypeID)

SELECT SCOPE_IDENTITY()
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_Contact'))
	DROP PROCEDURE sp_GET_Contact
GO
CREATE PROCEDURE sp_GET_Contact
	@ContactID INT
AS
SELECT 
	ContactID,
	FirstName,
	LastName,
	Gender,
	BirthDate,
	VirtualParty,
	VirtualPartyWho,
	InPerson,
	InPersonWho,
	Referal,
	ReferalWho,
	DirectSalesWebsite,
	Other,
	OtherWhere
FROM Contacts
WHERE ContactID=@ContactID
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_Contact_List'))
	DROP PROCEDURE sp_GET_Contact_List
GO
CREATE PROCEDURE sp_GET_Contact_List
	@FirstLastBoth VARCHAR(50) = 'Both',
	@SearchString VARCHAR(50) = ''
AS
IF((@SearchString = '')OR(@SearchString IS NULL))
BEGIN
SELECT 
	ContactID,
	FirstName,
	LastName
FROM Contacts
END
ELSE IF(@FirstLastBoth='First')
BEGIN
SELECT 
	ContactID,
	FirstName,
	LastName
FROM Contacts
WHERE FirstName LIKE '%'+@SearchString+'%'
END
ELSE IF(@FirstLastBoth='Last')
BEGIN
SELECT 
	ContactID,
	FirstName,
	LastName
FROM Contacts
WHERE LastName LIKE '%'+@SearchString+'%'
END
ELSE IF(@FirstLastBoth='Both')
BEGIN
SELECT 
	ContactID,
	FirstName,
	LastName
FROM Contacts
WHERE FirstName LIKE '%'+@SearchString+'%' OR LastName LIKE '%'+@SearchString+'%'
END
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_ContactID_List'))
	DROP PROCEDURE sp_GET_ContactID_List
GO
CREATE PROCEDURE sp_GET_ContactID_List
AS
SELECT 
	ContactID
	--,NoteTitle
	--,Note
	--,NoteCreated
	--,NoteEdited
FROM Contacts
WHERE IsActive = 'Active'
GO
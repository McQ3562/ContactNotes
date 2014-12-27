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
	@ContactID INT
AS
SELECT 
	NoteID
	--,NoteTitle
	--,Note
	--,NoteCreated
	--,NoteEdited
FROM Notes
WHERE IsActive = 'Active'
AND
ContactID = @ContactID
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_ADD_Contact'))
	DROP PROCEDURE sp_ADD_Contact
GO
CREATE PROCEDURE sp_ADD_Contact
	@FirstName VARCHAR(500),
	@LastName VARCHAR(500),
	@Gender VARCHAR(10),
	@BirthDate DATETIME,
	@StatusID VARCHAR(50),
	@PotentualID VARCHAR(50),
	@EmailAddress VARCHAR(1000),
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

INSERT INTO Contacts (FirstName, LastName, Gender, BirthDate, StatusID, PotentualID, VirtualParty, VirtualPartyWho, InPerson, InPersonWho, Referal, ReferalWho, DirectSalesWebsite, Other, OtherWhere, IsActive)
VALUES(@FirstName, @LastName, @Gender, @BirthDate, @StatusID, @PotentualID, @VirtualParty, @VirtualPartyWho, @InPerson, @InPersonWho, @Referal, @ReferalWho, @DirectSalesWebsite, @Other, @OtherWhere, @IsActive)

DECLARE @ContactID INT;
SET @ContactID = SCOPE_IDENTITY()

INSERT INTO EmailAddress (EmailAddress, ContactID)
VALUES (@EmailAddress, @ContactID)
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
	,@IsPrimary CHAR(1) = 'N'
AS
INSERT INTO ContactAddress (ContactID, ContactAddress, ContactCity, ContactState, ContactZip, IsPrimary)
VALUES (@ContactID, @ContactAddress, @ContactCity, @ContactState, @ContactZip, @IsPrimary)

SELECT SCOPE_IDENTITY()
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_ADD_Phone'))
	DROP PROCEDURE sp_ADD_Phone
GO
CREATE PROCEDURE sp_ADD_Phone
	@ContactID INT,
	@ContactPhoneNumber VARCHAR(20),
	@ContactPhoneTypeID INT,
	@IsPrimary CHAR(1) = 'N'
AS
INSERT INTO ContactPhone (ContactID, ContactPhoneNumber, ContactPhoneTypeID, IsPrimary)
VALUES (@ContactID, @ContactPhoneNumber, @ContactPhoneTypeID, @IsPrimary)

SELECT SCOPE_IDENTITY()
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_Contact'))
	DROP PROCEDURE sp_GET_Contact
GO
CREATE PROCEDURE sp_GET_Contact
	@ContactID INT
AS
SELECT 
	C.ContactID,
	FirstName,
	LastName,
	Gender,
	BirthDate,
	StatusID,
	PotentualID,
	StatusUpdateDate,
	EA.EmailAddress,
	VirtualParty,
	VirtualPartyWho,
	InPerson,
	InPersonWho,
	Referal,
	ReferalWho,
	DirectSalesWebsite,
	Other,
	OtherWhere,
	IsActive
FROM 
Contacts C
	LEFT JOIN
EmailAddress EA
		ON C.ContactID=EA.ContactID
WHERE C.ContactID=@ContactID
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_SET_Contact'))
	DROP PROCEDURE sp_SET_Contact
GO
CREATE PROCEDURE sp_SET_Contact
	@ContactID VARCHAR(50),
	@FirstName VARCHAR(500),
	@LastName VARCHAR(500),
	@Gender VARCHAR(10),
	@BirthDate DATETIME,
	@StatusID VARCHAR(50),
	@PotentualID VARCHAR(50),
	@EmailAddress VARCHAR(1000),
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
	UPDATE Contacts 
	SET FirstName = @FirstName
	,LastName = @LastName
	,Gender = @Gender
	,BirthDate=@BirthDate
	,StatusID=@StatusID
	,PotentualID=@PotentualID
	,VirtualParty=@VirtualParty
	,VirtualPartyWho=@VirtualPartyWho
	,InPerson=@InPerson
	,InPersonWho=@InPersonWho
	,Referal=@Referal
	,ReferalWho=@ReferalWho
	,DirectSalesWebsite=@DirectSalesWebsite
	,Other=@Other
	,OtherWhere=@OtherWhere
	,IsActive=@IsActive
	WHERE ContactID = @ContactID
	
	UPDATE EmailAddress
	SET EmailAddress=@EmailAddress
	WHERE ContactID=@ContactID
	AND
	EmailAddressType = 'Primary'
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
FROM Contacts
WHERE IsActive = 'Active'
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_AddressID_List'))
	DROP PROCEDURE sp_GET_AddressID_List
GO
CREATE PROCEDURE sp_GET_AddressID_List
	@ContactID INT
AS
SELECT 
	ContactAddressID
FROM ContactAddress
WHERE ContactID = @ContactID
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_Address'))
	DROP PROCEDURE sp_GET_Address
GO
CREATE PROCEDURE sp_GET_Address
	@ContactAddressID INT
AS
SELECT 
	ContactAddress,
	ContactCity,
	ContactState,
	ContactZip,
	IsPrimary
FROM ContactAddress
WHERE ContactAddressID = @ContactAddressID
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_PhoneID_List'))
	DROP PROCEDURE sp_GET_PhoneID_List
GO
CREATE PROCEDURE sp_GET_PhoneID_List
	@ContactID INT
AS
SELECT 
	ContactPhoneID
FROM ContactPhone
WHERE ContactID = @ContactID
GO
IF(EXISTS(SELECT 1 FROM sys.procedures WHERE name='sp_GET_Phone'))
	DROP PROCEDURE sp_GET_Phone
GO
CREATE PROCEDURE sp_GET_Phone
	@ContactPhoneID INT
AS
SELECT 
	ContactID,
	ContactPhoneNumber,
	ContactPhoneTypeID,
	IsPrimary
FROM ContactPhone
WHERE ContactPhoneID = @ContactPhoneID
GO
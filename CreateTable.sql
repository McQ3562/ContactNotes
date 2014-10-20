--CREATE DATABASE ContactNotes
USE ContactNotes
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='Notes'))
	DROP TABLE Notes
GO
CREATE TABLE Notes (
	NoteID INT IDENTITY(1,1) PRIMARY KEY,
	ContactID INT,
	NoteTitle VARCHAR(1000),
	Note VARCHAR(MAX),
	IsActive VARCHAR(10),
	NoteCreated DATETIME,
	NoteEdited DATETIME
)

IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='Contacts'))
	DROP TABLE Contacts
GO
CREATE TABLE Contacts (
	ContactID INT PRIMARY KEY,
	FirstName VARCHAR(500),
	LastName VARCHAR(500),
	Gender VARCHAR(10),
	BirthDate DATETIME,
	VirtualParty VARCHAR(1),
	VirtualPartyWho VARCHAR(100),
	InPerson VARCHAR(1),
	InPersonWho VARCHAR(100),
	Referal VARCHAR(1),
	ReferalWho VARCHAR(100),
	DirectSalesWebsite VARCHAR(1),
	Other VARCHAR(1),
	OtherWhere VARCHAR(100)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='ContactAddress'))
	DROP TABLE ContactAddress
GO
CREATE TABLE ContactAddress (
	ContactAddressID INT PRIMARY KEY,
	ContactID INT,
	ContactAddress VARCHAR(500),
	ContactCity VARCHAR(100),
	ContactState VARCHAR(100),
	ContactZip VARCHAR(100),
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='ContactPhone'))
	DROP TABLE ContactPhone
GO
CREATE TABLE ContactPhone (
	ContactPhoneID INT PRIMARY KEY,
	ContactID INT,
	ContactPhoneNumber VARCHAR(20),
	ContactPhoneTypeID INT,
)
GO
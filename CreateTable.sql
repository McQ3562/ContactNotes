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
	ContactID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(500),
	LastName VARCHAR(500),
	Gender VARCHAR(10),
	BirthDate DATETIME,
	StatusID VARCHAR(50),
	PotentualID VARCHAR(50),
	StatusUpdateDate DATETIME DEFAULT(GETDATE()),
	VirtualParty VARCHAR(1),
	VirtualPartyWho VARCHAR(100),
	InPerson VARCHAR(1),
	InPersonWho VARCHAR(100),
	Referal VARCHAR(1),
	ReferalWho VARCHAR(100),
	DirectSalesWebsite VARCHAR(1),
	Other VARCHAR(1),
	OtherWhere VARCHAR(100),
	IsActive VARCHAR(10)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='ContactAddress'))
	DROP TABLE ContactAddress
GO
CREATE TABLE ContactAddress (
	ContactAddressID INT IDENTITY(1,1) PRIMARY KEY,
	ContactID INT,
	ContactAddress VARCHAR(500),
	ContactCity VARCHAR(100),
	ContactState VARCHAR(100),
	ContactZip VARCHAR(100),
	IsPrimary CHAR(1)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='ContactPhone'))
	DROP TABLE ContactPhone
GO
CREATE TABLE ContactPhone (
	ContactPhoneID INT IDENTITY(1,1) PRIMARY KEY,
	ContactID INT,
	ContactPhoneNumber VARCHAR(20),
	ContactPhoneTypeID INT,
	IsPrimary CHAR(1)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_PhoneType'))
	DROP TABLE lk_PhoneType
GO
CREATE TABLE lk_PhoneType (
	PhoneTypeID INT,
	PhoneTypeName VARCHAR(50)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_Status'))
	DROP TABLE lk_Status
GO
CREATE TABLE lk_Status (
	StatusID VARCHAR(50),
	StatusDiscription VARCHAR(500)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_Potentual'))
	DROP TABLE lk_Potentual
GO
CREATE TABLE lk_Potentual (
	PotentualID VARCHAR(50),
	PotentualDiscription VARCHAR(500)
)

INSERT INTO lk_PhoneType (PhoneTypeID, PhoneTypeName) VALUES (1, 'Cell')
INSERT INTO lk_PhoneType (PhoneTypeID, PhoneTypeName) VALUES (2, 'Home')
INSERT INTO lk_PhoneType (PhoneTypeID, PhoneTypeName) VALUES (3, 'Office')
INSERT INTO lk_PhoneType (PhoneTypeID, PhoneTypeName) VALUES (4, 'Other')

INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Prospect', '')
INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Customer', '')
INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Host', '')
INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Presenter', '')
INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Customer / Host', '')
INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Customer / Presenter', '')
INSERT INTO lk_Status (StatusID, StatusDiscription) VALUES ('Host / Presenter', '')

INSERT INTO lk_Potentual (PotentualID, PotentualDiscription) VALUES ('Yes', '')
INSERT INTO lk_Potentual (PotentualID, PotentualDiscription) VALUES ('Maybe', '')
INSERT INTO lk_Potentual (PotentualID, PotentualDiscription) VALUES ('No', '')
GO

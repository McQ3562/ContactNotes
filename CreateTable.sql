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
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='EmailAddress'))
	DROP TABLE EmailAddress
GO
CREATE TABLE EmailAddress (
	EmailAddressID INT IDENTITY(1,1) PRIMARY KEY,
	ContactID INT,
	EmailAddressType VARCHAR(50),
	EmailAddress VARCHAR(1000)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_PhoneType'))
	DROP TABLE lk_PhoneType
GO
CREATE TABLE lk_PhoneType (
	PhoneTypeID INT IDENTITY(1,1) PRIMARY KEY,
	PhoneTypeName VARCHAR(50),
	PhoneTypeDiscription VARCHAR(500)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_Status'))
	DROP TABLE lk_Status
GO
CREATE TABLE lk_Status (
	StatusID INT IDENTITY(1,1) PRIMARY KEY,
	StatusName VARCHAR(100),
	StatusDiscription VARCHAR(500)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_Potentual'))
	DROP TABLE lk_Potentual
GO
CREATE TABLE lk_Potentual (
	PotentualID INT IDENTITY(1,1) PRIMARY KEY,
	PotentualName VARCHAR(100),
	PotentualDiscription VARCHAR(500)
)
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_EmailType'))
	DROP TABLE lk_EmailType
GO
CREATE TABLE lk_EmailType (
	EmailTypeID INT IDENTITY(1,1) PRIMARY KEY,
	EmailTypeName VARCHAR(100),
	EmailTypeDiscription VARCHAR(500)
)

INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Cell', '')
INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Home', '')
INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Office', '')
INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Other', '')

INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Prospect', '')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Customer', '')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Host', '')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Presenter', '')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Customer / Host', '')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Customer / Presenter', '')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Host / Presenter', '')

INSERT INTO lk_Potentual (PotentualName, PotentualDiscription) VALUES ('Yes', '')
INSERT INTO lk_Potentual (PotentualName, PotentualDiscription) VALUES ('Maybe', '')
INSERT INTO lk_Potentual (PotentualName, PotentualDiscription) VALUES ('No', '')

INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Primary', '')
INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Personal', '')
INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Business', '')
INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Other', '')
GO

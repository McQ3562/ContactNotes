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
GO
IF(EXISTS(SELECT 1 FROM sys.tables WHERE name='lk_State'))
	DROP TABLE lk_State
GO
CREATE TABLE lk_State (
	StateID INT IDENTITY(1,1) PRIMARY KEY
	,StateName VARCHAR(50)
	,StateAbbreviation VARCHAR(3)
)

INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Cell', 'Mobile Phone')
INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Home', 'Phone for non-working hours')
INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Office', 'Phone for working hours')
INSERT INTO lk_PhoneType (PhoneTypeName, PhoneTypeDiscription) VALUES ('Other', 'Alternate contact phone')

INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Prospect', 'No comitment')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Customer', 'Contact is a customer')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Host', 'Contact hosts partys')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Presenter', 'Contact presents at partys')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Customer / Host', 'Customer who also hosts partys')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Customer / Presenter', 'Customer who presents at partys')
INSERT INTO lk_Status (StatusName, StatusDiscription) VALUES ('Host / Presenter', 'Contact who Hosts partys and Presents at partys')

INSERT INTO lk_Potentual (PotentualName, PotentualDiscription) VALUES ('Yes', 'Yes means Yes')
INSERT INTO lk_Potentual (PotentualName, PotentualDiscription) VALUES ('Maybe', 'Undecided or a Yes waiting to happen')
INSERT INTO lk_Potentual (PotentualName, PotentualDiscription) VALUES ('No', 'No means No')

INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Primary', 'Primary email address')
INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Personal', 'Personal email address')
INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Business', 'Business email address')
INSERT INTO lk_EmailType (EmailTypeName, EmailTypeDiscription) VALUES ('Other', 'Other email address')

INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Alabama','AL')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Alaska','AK')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Arizona','AZ')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Arkansas','AR')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('California','CA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Colorado','CO')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Connecticut','CT')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Delaware','DE')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Florida','FL')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Georgia','GA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Hawaii','HI')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Idaho','ID')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Illinois','IL')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Indiana','IN')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Iowa','IA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Kansas','KS')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Kentucky','KY')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Louisiana','LA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Maine','ME')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Maryland','MD')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Massachusetts','MA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Michigan','MI')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Minnesota','MN')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Mississippi','MS')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Missouri','MO')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Montana','MT')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Nebraska','NE')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Nevada','NV')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('New Hampshire','NH')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('New Jersey','NJ')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('New Mexico','NM')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('New York','NY')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('North Carolina','NC')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('North Dakota','ND')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Ohio','OH')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Oklahoma','OK')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Oregon','OR')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Pennsylvania','PA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Rhode Island','RI')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('South Carolina','SC')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('South Dakota','SD')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Tennessee','TN')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Texas','TX')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Utah','UT')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Vermont','VT')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Virginia','VA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Washington','WA')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('West Virginia','WV')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Wisconsin','WI')
INSERT INTO lk_state (StateName,StateAbbreviation) VALUES ('Wyoming','WY')
GO

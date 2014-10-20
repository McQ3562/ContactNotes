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
	@OtherWhere VARCHAR(100)
AS
INSERT INTO Contacts (FirstName, LastName, Gender, BirthDate, VirtualParty, VirtualPartyWho, InPerson, InPersonWho, Referal, ReferalWho, DirectSalesWebsite, Other, OtherWhere)
VALUES(@FirstName, @LastName, @Gender, @BirthDate, @VirtualParty, @VirtualPartyWho, @Referal, @ReferalWho, @DirectSalesWebsite, @Other, @OtherWhere )

SELECT @@IDENTITY

GO

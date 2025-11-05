CREATE DATABASE insurance_database

USE insurance_database


CREATE TABLE Partner
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(255) NOT NULL CHECK (LEN(FirstName) >= 2),
	LastName VARCHAR(255) NOT NULL CHECK (LEN(LastName) >= 2),
	Address VARCHAR(50),
    PartnerNumber NUMERIC(20, 0),
	CroatianPIN VARCHAR(11),
	PartnerTypeId TINYINT NOT NULL,
	CreatedAtUtc DATETIME DEFAULT GETUTCDATE(),
	CreateByUser VARCHAR(255) NOT NULL,
	IsForeign BIT NOT NULL,
	ExternalCode VARCHAR(20) UNIQUE CHECK (LEN(ExternalCode) >= 10),
	GenderTypeId INT NOT NULL,
)


CREATE TABLE InsurancePolicy
(
	Id INT PRIMARY KEY IDENTITY (1,1),
	PolicyNumber VARCHAR(15) NOT NULL CHECK (LEN(PolicyNumber) >= 10),
	PolicyPrice DECIMAL NOT NULL,
	PartnerId INT FOREIGN KEY REFERENCES Partner(Id)
)

CREATE PROCEDURE AddPartner
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @Address VARCHAR(50),
    @PartnerNumber DECIMAL(20,0),
    @CroatianPIN VARCHAR(11),
    @PartnerTypeId INT,
    @CreateByUser VARCHAR(255),
    @IsForeign BIT,
    @ExternalCode VARCHAR(20),
    @GenderTypeId INT
AS
BEGIN
    INSERT INTO Partner
    (
        FirstName,
        LastName,
        Address,
        PartnerNumber,
        CroatianPIN,
        PartnerTypeId,
        CreateByUser,
        IsForeign,
        ExternalCode,
        GenderTypeId
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @Address,
        @PartnerNumber,
        @CroatianPIN,
        @PartnerTypeId,
        @CreateByUser,
        @IsForeign,
        @ExternalCode,
        @GenderTypeId
    )
END

CREATE PROCEDURE AddPolicy
    @PolicyNumber VARCHAR(15),
    @PolicyPrice DECIMAL(18,2),
    @PartnerId INT
AS
BEGIN
    INSERT INTO InsurancePolicy
    (
        PolicyNumber,
        PolicyPrice,
        PartnerId
    )
    VALUES
    (
        @PolicyNumber,
        @PolicyPrice,
        @PartnerId
    )
END

CREATE PROCEDURE GetAllPartners
AS 
BEGIN
    SELECT 
        P.*,
        ISNULL(COUNT(IP.Id), 0) AS PolicyCount,
        ISNULL(SUM(IP.PolicyPrice), 0) AS TotalPolicyAmount
    FROM 
        Partner AS P
    LEFT JOIN 
        InsurancePolicy AS IP ON P.Id = IP.PartnerId
    GROUP BY 
        P.Id, P.FirstName, P.LastName, P.GenderTypeId,
        P.Address, P.PartnerNumber, P.CroatianPIN,
        P.PartnerTypeId, P.CreatedAtUtc, P.CreateByUser,
        P.IsForeign, P.ExternalCode
    ORDER BY 
        P.CreatedAtUtc DESC;
END


CREATE PROCEDURE DeletePartnerById
    @Id INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM InsurancePolicy WHERE PartnerId = @Id)
    BEGIN
        DELETE FROM Partner WHERE Id = @Id
    END
    ELSE
    BEGIN
        DELETE FROM InsurancePolicy WHERE PartnerId = @Id;
        DELETE FROM Partner WHERE Id = @Id;
    END
END

CREATE PROCEDURE GetPoliciesByPartner
    @PartnerId INT
AS
BEGIN
    SELECT 
        IP.Id AS PolicyId,
        IP.PolicyNumber,
        IP.PolicyPrice,
        P.Id AS PartnerId,
        P.FirstName,
        P.LastName,
        P.GenderTypeId
    FROM InsurancePolicy AS IP
    JOIN Partner AS P ON IP.PartnerId = P.Id
    WHERE P.Id = @PartnerId;
END

CREATE PROCEDURE GetPoliciesCountByPartner
    @PartnerId INT
AS
BEGIN
    SELECT 
        P.Id AS PartnerId,
        P.FirstName,
        P.LastName,
        P.Address,
        P.PartnerNumber,
        P.CroatianPIN,
        P.PartnerTypeId,
        P.CreatedAtUtc,
        P.CreateByUser,
        P.IsForeign,
        P.ExternalCode,
        P.GenderTypeId,
        COUNT(IP.Id) AS PolicyCount
    FROM 
        Partner AS P
    LEFT JOIN 
        InsurancePolicy AS IP ON P.Id = IP.PartnerId
    WHERE 
        P.Id = @PartnerId
    GROUP BY 
        P.Id, P.FirstName, P.LastName, P.Address, P.PartnerNumber, P.CroatianPIN, P.PartnerTypeId, P.CreatedAtUtc, P.CreateByUser, P.IsForeign, P.ExternalCode, P.GenderTypeId
END


CREATE PROCEDURE PartnerUpdate
    @Id INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @Address VARCHAR(50),
    @PartnerNumber DECIMAL(20,0),
    @CroatianPIN VARCHAR(11),
    @PartnerTypeId INT,
    @CreateByUser VARCHAR(255),
    @IsForeign BIT,
    @ExternalCode VARCHAR(20),
    @GenderTypeId INT
AS
BEGIN
    UPDATE Partner
    SET
        FirstName = @FirstName,
        LastName = @LastName,
        Address = @Address,
        PartnerNumber = @PartnerNumber,
        CroatianPIN = @CroatianPIN,
        PartnerTypeId = @PartnerTypeId,
        CreateByUser = @CreateByUser,
        IsForeign = @IsForeign,
        ExternalCode = @ExternalCode,
        GenderTypeId = @GenderTypeId
    WHERE 
        Id = @Id
END


CREATE PROCEDURE GetPartnerById
    @Id INT
AS
BEGIN
    SELECT * FROM Partner WHERE Id = @Id
END

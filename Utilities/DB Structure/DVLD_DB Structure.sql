

--CREATE DATABASE DVLD_DB;
USE DVLD_DB;


-- People & Countries --

CREATE TABLE Countries(
		
		-- Columns --
	CountryID int PRIMARY KEY IDENTITY,
	CountryName nvarchar(60) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_Countries_CountryName UNIQUE (CountryName)
);

CREATE TABLE People(

		-- Columns --
	PersonID int PRIMARY KEY IDENTITY,
	NationalNo nvarchar(100) NOT NULL,
	FirstName nvarchar(25) NOT NULL,
	SecondName nvarchar(25) NULL,
	ThirdName nvarchar(25) NULL,
	LastName nvarchar(25) NOT NULL,
	Gender char(1) NOT NULL,
	BirthDate DateTime NOT NULL,
	Phone nvarchar(20) NOT NULL,
	Email nvarchar(150) NOT NULL,
	Address nvarchar(Max) NOT NULL,
	CountryID int REFERENCES Countries(CountryID) NOT NULL,
	ImagePath nvarchar(Max) NULL,
	IsMarkedToDelete bit NOT NULL DEFAULT 0,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL
	
		-- Constraints --
	CONSTRAINT UQ_People_NationalNo UNIQUE (NationalNo),
	CONSTRAINT UQ_People_Phone UNIQUE (Phone),
    CONSTRAINT UQ_People_Email UNIQUE (Email),
	CONSTRAINT CHK_People_Gender CHECK (Gender IN ('M', 'F')),
	CONSTRAINT CHK_People_BirthDate CHECK ( ( BirthDate <= DATEADD(YEAR, -18, GETDATE()) ) AND ( BirthDate >= DATEADD(YEAR, -60, GETDATE()) ) ),
    CONSTRAINT CHK_People_Email CHECK (Email LIKE '%_@__%.__%')
);

-- Users & LoginRegister --

CREATE TABLE Users(

		-- Columns -- 
    UserID int PRIMARY KEY IDENTITY,
    PersonID int REFERENCES People(PersonID) NOT NULL,
    UserName nvarchar(100) NOT NULL,
    Password nvarchar(255) NOT NULL,
    Status int NOT NULL default(1),
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,

		-- Constraints --
    CONSTRAINT UQ_Users_PersonID UNIQUE (PersonID),
    CONSTRAINT UQ_Users_UserName UNIQUE (UserName),
	CONSTRAINT CHK_Users_Status CHECK (Status IN (1, 2, 3))  -- Enums used ! --
);

CREATE TABLE LoginRegister (

		-- Columns --
    LoginRegisterID int PRIMARY KEY IDENTITY,
    UserID int REFERENCES Users(UserID) NOT NULL,
    LoginTime smallDateTime NOT NULL DEFAULT GETDATE(),
    LogoutTime smallDateTime NULL,

		-- Constraints --
	CONSTRAINT CHK_LoginRegister_LogoutTime CHECK ((LogoutTime IS NULL) OR (LoginTime <= LogoutTime)),

		-- Indexes -- 
	INDEX IX_LoginRegister_UserID NONCLUSTERED (UserID)
);

-- Applications & ApplicationTypes -- 

CREATE TABLE ApplicationTypes(

		-- Columns --
	ApplicationTypeID int PRIMARY KEY IDENTITY,
	ApplicationTypeName nvarchar(75) NOT NULL,
	ApplicationTypeFees decimal(10,4) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_ApplicationTypes_ApplicationTypeName UNIQUE (ApplicationTypeName),
	CONSTRAINT CHK_ApplicationTypes_ApplicationTypeFees CHECK (ApplicationTypeFees > 0)
);

CREATE TABLE Applications(

		-- Columns --
	ApplicationID int PRIMARY KEY IDENTITY,
	ApplicantPersonID int REFERENCES People(PersonID) NOT NULL,
	ApplicationTypeID int REFERENCES ApplicationTypes(ApplicationTypeID) NOT NULL,
	ApplicationDate DateTime NOT NULL DEFAULT GETDATE(),
	ApplicationStatus int NOT NULL DEFAULT 1,
	StatusModificationDate DateTime NULL,
	PaidFees decimal(10,4) NOT NULL,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,

		-- Constraints --
	CONSTRAINT CHK_Applications_ApplicationStatus CHECK (ApplicationStatus IN (1, 2, 3)),
	CONSTRAINT CHK_Applications_ApplicationDate CHECK (ApplicationDate <= GETDATE()),
	CONSTRAINT CHK_Applications_StatusModificationDate CHECK ( (StatusModificationDate IS NULL) OR (StatusModificationDate >= ApplicationDate) ),
	CONSTRAINT CHK_Applications_PaidFees CHECK (PaidFees > 0),

		-- Indexes -- 
	INDEX IX_Applications_ApplicantPersonID NONCLUSTERED (ApplicantPersonID)
);

-- LocalLicensesApplications & LicenseClasses --

CREATE TABLE LicenseClasses(
		
		-- Columns --
	LicenseClassID int PRIMARY KEY IDENTITY,
	LicenseClassName nvarchar(75) NOT NULL,
	ClassDescription nvarchar(300) NOT NULL,
	MinimumAgeAllowed int NOT NULL DEFAULT 18,
	DefaultValidityLength int NOT NULL,
	ClassFees decimal(10, 4) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_LicenseClasses_LicenseClassName UNIQUE (LicenseClassName),
	CONSTRAINT CHK_LicenseClasses_MinimumAgeAllowed CHECK (MinimumAgeAllowed >= 18),
	CONSTRAINT CHK_LicenseClasses_ClassFees CHECK (ClassFees > 0)
);

CREATE TABLE LocalLicensesApplications(
	
		-- Columns --
	LocalLicenseApplicationID int PRIMARY KEY IDENTITY,
	ApplicationID int REFERENCES Applications(ApplicationID) NOT NULL,
	LicenseClassID int REFERENCES LicenseClasses(LicenseClassID) NOT NULL,
	PassedTests int NOT NULL DEFAULT 0,                                                   --Added to save Time and Work

		-- Constraints -- 
	CONSTRAINT UQ_LocalLicensesApplications_ApplicationID UNIQUE (ApplicationID),
	CONSTRAINT CHK_LocalLicensesApplications_PassedTests CHECK (PassedTests IN (1, 2, 3)) --Added to save Time and work
);

-- TestTypes & TestAppointements & Tests --

CREATE TABLE TestTypes(
	
		-- Columns --
	TestTypeID int PRIMARY KEY IDENTITY,
	TestTypeName nvarchar(75) NOT NULL,
	TestTypeDescription nvarchar(300) NOT NULL,
	TestTypeFees decimal(10,4) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_TestTypes_TestTypeName UNIQUE (TestTypeName),
	CONSTRAINT CHK_TestTypes_TestTypeFees CHECK (TestTypeFees > 0)
);

CREATE TABLE TestAppointments(
		
		-- Columns --
	TestAppointmentID int PRIMARY KEY IDENTITY,
	TestTypeID int REFERENCES TestTypes (TestTypeID) NOT NULL,
	LocalLicenseApplicationID int REFERENCES LocalLicensesApplications (LocalLicenseApplicationID) NOT NULL,
	TestAppointmentDate DateTime NOT NULL DEFAULT GETDATE(),
	PaidFees decimal(10,4) NOT NULL,
	IsLocked bit NOT NULL DEFAULT 0,
	RetakeTestApplicationID int REFERENCES Applications (ApplicationID) NULL,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_TestAppointments_RetakeTestApplicationID UNIQUE (RetakeTestApplicationID),
	CONSTRAINT CHK_TestAppointments_PaidFees CHECK (PaidFees > 0),

		-- Indexes --
	INDEX IX_TestAppointments_LocalLicenseApplicationID NONCLUSTERED (LocalLicenseApplicationID)
);

CREATE TABLE Tests(

		-- Columns --
	TestID int PRIMARY KEY IDENTITY,
	TestAppointmentID int REFERENCES TestAppointments(TestAppointmentID) NOT NULL,
	TestResult bit NOT NULL,
	Notes nvarchar(Max) NULL,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,

		-- Indexes --
	INDEX IX_Tests_TestAppointmentID NONCLUSTERED (TestAppointmentID)
);


-- Licenses & Drivers & InternationalLicenses -- 

CREATE TABLE Drivers(
	
		-- Columns --
	DriverID int PRIMARY KEY IDENTITY,
	PersonID int REFERENCES People(PersonID) NOT NULL,
	CreatedDate DateTime NOT NULL DEFAULT GETDATE(),
	IsMarkedToDelete bit NOT NULL DEFAULT 0,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_Drivers_PersonID UNIQUE (PersonID),
	CONSTRAINT CHK_Drivers_CreatedDate CHECK (CreatedDate <= GETDATE())
);

CREATE TABLE Licenses(

		-- Columns --
	LicenseID int PRIMARY KEY IDENTITY,
	LicenseClassID int REFERENCES LicenseClasses (LicenseClassID) NOT NULL,
	ApplicationID int REFERENCES Applications(ApplicationID) NOT NULL,
	DriverID int REFERENCES Drivers(DriverID) NOT NULL,
	IssueDate DateTime NOT NULL DEFAULT GETDATE(),
	ExpirationDate DateTime NOT NULL,
	PaidFees decimal(10,4) NOT NULL,
	IssueReason int NOT NULL,
	Notes nvarchar(Max) NULL,
	IsActive bit NOT NULL DEFAULT 1,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,
	
		-- Constraints --
	CONSTRAINT UQ_Licenses_ApplicationID UNIQUE (ApplicationID),
	CONSTRAINT CHK_Licenses_IssueDate CHECK (IssueDate <= GETDATE()),
	CONSTRAINT CHK_Licenses_ExpirationDate CHECK (ExpirationDate > IssueDate),
	CONSTRAINT CHK_Licenses_PaidFees CHECK (PaidFees > 0),
	CONSTRAINT CHK_Licenses_IssueReason CHECK (IssueReason IN (1, 2, 3, 4)),

		-- Indexes --
	INDEX IX_Licenses_LicenseClassID NONCLUSTERED (LicenseClassID),
	INDEX IX_Licenses_DriverID NONCLUSTERED (DriverID)
);

CREATE TABLE InternationalLicenses(

		-- Columns --
	InternationalLicenseID int PRIMARY KEY IDENTITY,
	LicenseID int REFERENCES Licenses (LicenseID) NOT NULL,
	DriverID int REFERENCES Drivers(DriverID) NOT NULL,
	ApplicationID int REFERENCES Applications(ApplicationID) NOT NULL,
	IssueDate DateTime NOT NULL DEFAULT GETDATE(),
	ExpirationDate DateTime NOT NULL,
	IsActive bit NOT NULL DEFAULT 1,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,

		-- Constraints --
	CONSTRAINT UQ_InternationalLicenses_ApplicationID UNIQUE (ApplicationID),
	CONSTRAINT CHK_InternationalLicenses_IssueDate CHECK (IssueDate <= GETDATE()),
	CONSTRAINT CHK_InternationalLicenses_ExpirationDate CHECK (ExpirationDate > IssueDate),

		-- Indexes --
	INDEX IX_InternationalLicenses_LicenseID NONCLUSTERED (LicenseID),
	INDEX IX_InternationalLicenses_DriverID NONCLUSTERED (DriverID)
);

-- DetainedLicenses -- 

CREATE TABLE DetainedLicenses(

		-- Columns --
	DetainedLicenseID int PRIMARY KEY IDENTITY,
	LicenseID int REFERENCES Licenses (LicenseID) NOT NULL,
	DetainDate DateTime NOT NULL DEFAULT GETDATE(),
	FineFees decimal(10,4) NOT NULL,
	CreatedByUserID int REFERENCES Users(UserID) NOT NULL,
	IsReleased bit NOT NULL DEFAULT 0,
	ReleaseDate DateTime NULL,
	ReleaseLicenseApplicationID int REFERENCES Applications(ApplicationID) NULL,
	ReleasedByUserID int REFERENCES Users(UserID) NULL,

		-- Constraints --
	CONSTRAINT UQ_DetainedLicenses_ReleaseLicenseApplicationID UNIQUE (ReleaseLicenseApplicationID),
	CONSTRAINT CHK_DetainedLicenses_DetainDate CHECK (DetainDate <= GETDATE()),
	CONSTRAINT CHK_DetainedLicenses_FineFees CHECK (FineFees > 0),
	CONSTRAINT CHK_DetainedLicenses_ReleaseDate CHECK ( (ReleaseDate IS NULL) OR (ReleaseDate >= DetainDate) ),

		-- Indexes --
	INDEX IX_DetainedLicenses_LicenseID NONCLUSTERED (LicenseID)
);



-- Inserting the records to the fixed look up tables in the DB --

INSERT INTO ApplicationTypes (ApplicationTypeName, ApplicationTypeFees)
VALUES 
('New Local Driving License Service', 15.0000),
('Renew Driving License Service', 5.0000),
('Replacement for a Lost Driving License', 10.0000),
('Replacement for a Damaged Driving License', 5.0000),
('Release Detained Driving License', 15.0000),
('New International License', 51.0000),
('Retake Test', 5.0000);


INSERT INTO TestTypes (TestTypeName, TestTypeDescription, TestTypeFees)
VALUES 
('Vision Test', 'This assesses the applicant''s visual acuity to ensure they have sufficient vision to drive safely.', 10.0000),
('Written (Theory) Test', 'This test assesses the applicant''s knowledge of traffic rules, road signs, and driving regulations. It typically consists of multiple choice questions.', 20.0000),
('Practical (Street) Test', 'This test evaluates the applicant''s driving skills and ability to operate a motor vehicle safely on public roads. A licensed examiner accompanies the applicant.', 30.0000);


INSERT INTO LicenseClasses 
    (LicenseClassName, ClassDescription, MinimumAgeAllowed, DefaultValidityLength, ClassFees)
VALUES 
('Class 1 - Small Motorcycle', 'It allows the driver to drive small motorcycles, It is suitable for beginners.', 18, 5, 15.00),
('Class 2 - Heavy Motorcycle License', 'Heavy Motorcycle License (Large Motorcycle License).', 21, 5, 30.00),
('Class 3 - Ordinary driving license', 'Ordinary driving license (car licence)', 18, 10, 20.00),
('Class 4 - Commercial', 'Commercial driving license (taxi/limousine)', 21, 10, 200.00),
('Class 5 - Agricultural', 'Agricultural and work vehicles used in farming or construction.', 21, 10, 50.00),
('Class 6 - Small and medium bus', 'Small and medium bus license', 21, 10, 250.00),
('Class 7 - Truck and heavy vehicle', 'Truck and heavy vehicle license', 21, 10, 300.00);


INSERT INTO Countries (CountryName) VALUES
('Afghanistan'),
('Albania'),
('Algeria'),
('Andorra'),
('Angola'),
('Antigua and Barbuda'),
('Argentina'),
('Armenia'),
('Australia'),
('Austria'),
('Azerbaijan'),
('Bahamas'),
('Bahrain'),
('Bangladesh'),
('Barbados'),
('Belarus'),
('Belgium'),
('Belize'),
('Benin'),
('Bhutan'),
('Bolivia'),
('Bosnia and Herzegovina'),
('Botswana'),
('Brazil'),
('Brunei'),
('Bulgaria'),
('Burkina Faso'),
('Burundi'),
('Cabo Verde'),
('Cambodia'),
('Cameroon'),
('Canada'),
('Central African Republic'),
('Chad'),
('Chile'),
('China'),
('Colombia'),
('Comoros'),
('Congo (Congo-Brazzaville)'),
('Costa Rica'),
('Croatia'),
('Cuba'),
('Cyprus'),
('Czechia (Czech Republic)'),
('Democratic Republic of the Congo'),
('Denmark'),
('Djibouti'),
('Dominica'),
('Dominican Republic'),
('Ecuador'),
('Egypt'),
('El Salvador'),
('Equatorial Guinea'),
('Eritrea'),
('Estonia'),
('Eswatini'),
('Ethiopia'),
('Fiji'),
('Finland'),
('France'),
('Gabon'),
('Gambia'),
('Georgia'),
('Germany'),
('Ghana'),
('Greece'),
('Grenada'),
('Guatemala'),
('Guinea'),
('Guinea-Bissau'),
('Guyana'),
('Haiti'),
('Honduras'),
('Hungary'),
('Iceland'),
('India'),
('Indonesia'),
('Iran'),
('Iraq'),
('Ireland'),
('Israel'),
('Italy'),
('Jamaica'),
('Japan'),
('Jordan'),
('Kazakhstan'),
('Kenya'),
('Kiribati'),
('Kuwait'),
('Kyrgyzstan'),
('Laos'),
('Latvia'),
('Lebanon'),
('Lesotho'),
('Liberia'),
('Libya'),
('Liechtenstein'),
('Lithuania'),
('Luxembourg'),
('Madagascar'),
('Malawi'),
('Malaysia'),
('Maldives'),
('Mali'),
('Malta'),
('Marshall Islands'),
('Mauritania'),
('Mauritius'),
('Mexico'),
('Micronesia'),
('Moldova'),
('Monaco'),
('Mongolia'),
('Montenegro'),
('Morocco'),
('Mozambique'),
('Myanmar (Burma)'),
('Namibia'),
('Nauru'),
('Nepal'),
('Netherlands'),
('New Zealand'),
('Nicaragua'),
('Niger'),
('Nigeria'),
('North Korea'),
('North Macedonia'),
('Norway'),
('Oman'),
('Pakistan'),
('Palau'),
('Palestine'),
('Panama'),
('Papua New Guinea'),
('Paraguay'),
('Peru'),
('Philippines'),
('Poland'),
('Portugal'),
('Qatar'),
('Romania'),
('Russia'),
('Rwanda'),
('Saint Kitts and Nevis'),
('Saint Lucia'),
('Saint Vincent and the Grenadines'),
('Samoa'),
('San Marino'),
('Sao Tome and Principe'),
('Saudi Arabia'),
('Senegal'),
('Serbia'),
('Seychelles'),
('Sierra Leone'),
('Singapore'),
('Slovakia'),
('Slovenia'),
('Solomon Islands'),
('Somalia'),
('South Africa'),
('South Korea'),
('South Sudan'),
('Spain'),
('Sri Lanka'),
('Sudan'),
('Suriname'),
('Sweden'),
('Switzerland'),
('Syria'),
('Tajikistan'),
('Tanzania'),
('Thailand'),
('Timor-Leste'),
('Togo'),
('Tonga'),
('Trinidad and Tobago'),
('Tunisia'),
('Turkey'),
('Turkmenistan'),
('Tuvalu'),
('Uganda'),
('Ukraine'),
('United Arab Emirates'),
('United Kingdom'),
('United States of America'),
('Uruguay'),
('Uzbekistan'),
('Vanuatu'),
('Vatican City'),
('Venezuela'),
('Vietnam'),
('Yemen'),
('Zambia'),
('Zimbabwe');


DELETE FROM Users;

INSERT INTO Users(PersonID, UserName, Password, Status)
VALUES 
(14, 'User3', '123456', 3),
(23, 'User4', '123456', 3),
(39, 'User2', '123456', 2),
(40, 'User1', '123456', 2),
(41, 'Ahmed2', '123456', 1),
(13, 'Admin', '123456', 1)
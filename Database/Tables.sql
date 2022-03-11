CREATE TABLE COUNTRIES
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE USER_TYPES
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE USERS
(
	Code varchar(20) primary key not null,
	FullName nvarchar(254),
	Username varchar(40),
	Password varchar(500),
	UserType varchar(20),
	Auth nvarchar(max),
	AvatarPath nvarchar(max),
	Status varchar(1),
	LastLogin datetime,
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE [dbo].[USER_LOGIN] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL
);


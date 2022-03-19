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
	Email varchar(254),
	Username varchar(40),
	Password varchar(500),
	UserType varchar(20),
	Auth nvarchar(max),
	PhotoPath nvarchar(max),
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
GO

CREATE TABLE MOVIE_GENRES
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE MOVIE_ROLES
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE ACTORS
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	DOB datetime,
	PlaceOBirth nvarchar(254),
	Height varchar(6),
	Couple nvarchar(254),
	Children nvarchar(254),
	Prize nvarchar(254),
	Descriptions nvarchar(max),
	RoleCode varchar(20),
	PhotoPath varchar(max),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE DIRECTORS
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	DOB datetime,
	PlaceOBirth nvarchar(254),
	Height varchar(6),
	Couple nvarchar(254),
	Children nvarchar(254),
	Prize nvarchar(254),
	Descriptions nvarchar(max),
	RoleCode varchar(20),
	PhotoPath varchar(max),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE SUBTITLES
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	TimeCreated datetime,
	TimeUpdated datetime
)
GO

CREATE TABLE MOVIES_INFO
(
	Code varchar(20) primary key not null,
	Name nvarchar(254),
	DirectorsCode ntext,
	ActorsCode ntext,
	GenresCode ntext,
	SubtitlesCode ntext,
	CountryCode varchar(20),
	ReleaseTime int,
	MovieTime int,
	IMDbScrore decimal(1,1),
	PhotoPath nvarchar(max),
	TimeCreated datetime,
	TimeUpdated datetime
)

CREATE TABLE MOVIE_TRAILERS
(
	Code varchar(20) primary key not null,
	MovieCode varchar(20),
	Name nvarchar(254),
	Path nvarchar(max),
	TimeCreated datetime,
	TimeUpdated datetime
)

CREATE TABLE MOVIE_LIKES
(
	Code varchar(20) primary key not null,
	MovieCode varchar(20),
	Username varchar(40),
	LikeNum int,
	TimeCreated datetime,
	TimeUpdated datetime
)

CREATE TABLE MOVIE_COMMENTS
(
	Code varchar(20) primary key not null,
	MovieCode varchar(20),
	Username varchar(40),
	Comments nvarchar(max),
	TimeCreated datetime,
	TimeUpdated datetime
)
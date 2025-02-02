USE [master]
GO
/****** Object:  Database [CivilRegistry]    Script Date: 9/26/2020 11:54:05 AM ******/
CREATE DATABASE [CivilRegistry]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CivilRegistry', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CivilRegistry.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CivilRegistry_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CivilRegistry_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CivilRegistry] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CivilRegistry].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CivilRegistry] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CivilRegistry] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CivilRegistry] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CivilRegistry] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CivilRegistry] SET ARITHABORT OFF 
GO
ALTER DATABASE [CivilRegistry] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CivilRegistry] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CivilRegistry] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CivilRegistry] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CivilRegistry] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CivilRegistry] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CivilRegistry] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CivilRegistry] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CivilRegistry] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CivilRegistry] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CivilRegistry] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CivilRegistry] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CivilRegistry] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CivilRegistry] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CivilRegistry] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CivilRegistry] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CivilRegistry] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CivilRegistry] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CivilRegistry] SET  MULTI_USER 
GO
ALTER DATABASE [CivilRegistry] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CivilRegistry] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CivilRegistry] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CivilRegistry] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CivilRegistry] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CivilRegistry] SET QUERY_STORE = OFF
GO
USE [CivilRegistry]
GO
/****** Object:  User [granit.krasniqi]    Script Date: 9/26/2020 11:54:06 AM ******/
CREATE USER [granit.krasniqi] FOR LOGIN [granit.krasniqi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[BirthCertificates]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirthCertificates](
	[BirthCertificateID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[CivilStatus] [varchar](50) NOT NULL,
	[PersonID] [int] NULL,
	[FatherID] [int] NULL,
	[MotherID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BirthCertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeathCertificates]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeathCertificates](
	[DeathCertificatesID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[DeathDate] [date] NOT NULL,
	[PersonID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DeathCertificatesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyCertificates]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyCertificates](
	[FamilyCertificatesID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[FamilyMembers] [varchar](max) NULL,
	[PersonID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FamilyCertificatesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityCards]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityCards](
	[IdentityCardID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[PersonID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentityCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarriageCertificates]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarriageCertificates](
	[MarriageCertificateID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[MarriageDate] [date] NOT NULL,
	[Partner1ID] [int] NULL,
	[Partner2ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MarriageCertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passports]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passports](
	[PassportID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[EyeColor] [varchar](50) NOT NULL,
	[MigrationPlace] [varchar](50) NOT NULL,
	[PersonID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[PersonalNumber] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[BirthPlace] [varchar](50) NOT NULL,
	[Municipality] [varchar](50) NOT NULL,
	[Nationality] [varchar](50) NOT NULL,
	[EmploymentStatus] [varchar](50) NOT NULL,
	[Qualification] [varchar](50) NOT NULL,
	[HealthCondition] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BirthCertificates] ON 

INSERT [dbo].[BirthCertificates] ([BirthCertificateID], [RegistrationDate], [ExpirationDate], [CivilStatus], [PersonID], [FatherID], [MotherID]) VALUES (1, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'Single', 1, 2, 3)
INSERT [dbo].[BirthCertificates] ([BirthCertificateID], [RegistrationDate], [ExpirationDate], [CivilStatus], [PersonID], [FatherID], [MotherID]) VALUES (2, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'Married', 4, 7, 6)
INSERT [dbo].[BirthCertificates] ([BirthCertificateID], [RegistrationDate], [ExpirationDate], [CivilStatus], [PersonID], [FatherID], [MotherID]) VALUES (3, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'Single', 3, 4, 5)
INSERT [dbo].[BirthCertificates] ([BirthCertificateID], [RegistrationDate], [ExpirationDate], [CivilStatus], [PersonID], [FatherID], [MotherID]) VALUES (4, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'Married', 6, 7, 8)
INSERT [dbo].[BirthCertificates] ([BirthCertificateID], [RegistrationDate], [ExpirationDate], [CivilStatus], [PersonID], [FatherID], [MotherID]) VALUES (5, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'Single', 8, 9, 6)
SET IDENTITY_INSERT [dbo].[BirthCertificates] OFF
SET IDENTITY_INSERT [dbo].[DeathCertificates] ON 

INSERT [dbo].[DeathCertificates] ([DeathCertificatesID], [RegistrationDate], [ExpirationDate], [DeathDate], [PersonID]) VALUES (1, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), CAST(N'2002-12-15' AS Date), 7)
INSERT [dbo].[DeathCertificates] ([DeathCertificatesID], [RegistrationDate], [ExpirationDate], [DeathDate], [PersonID]) VALUES (2, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), CAST(N'2008-12-19' AS Date), 9)
SET IDENTITY_INSERT [dbo].[DeathCertificates] OFF
SET IDENTITY_INSERT [dbo].[FamilyCertificates] ON 

INSERT [dbo].[FamilyCertificates] ([FamilyCertificatesID], [RegistrationDate], [ExpirationDate], [FamilyMembers], [PersonID]) VALUES (1, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'1000000002,1000000003,1000000004', 1)
INSERT [dbo].[FamilyCertificates] ([FamilyCertificatesID], [RegistrationDate], [ExpirationDate], [FamilyMembers], [PersonID]) VALUES (2, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'1000000003,1000000004,1000000006,1000000005', 2)
INSERT [dbo].[FamilyCertificates] ([FamilyCertificatesID], [RegistrationDate], [ExpirationDate], [FamilyMembers], [PersonID]) VALUES (3, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'1000000007,1000000008', 4)
INSERT [dbo].[FamilyCertificates] ([FamilyCertificatesID], [RegistrationDate], [ExpirationDate], [FamilyMembers], [PersonID]) VALUES (4, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'1000000008,1000000003,1000000004,1000000006', 5)
INSERT [dbo].[FamilyCertificates] ([FamilyCertificatesID], [RegistrationDate], [ExpirationDate], [FamilyMembers], [PersonID]) VALUES (5, CAST(N'2020-09-26' AS Date), CAST(N'2021-03-26' AS Date), N'1000000009,1000000010', 8)
SET IDENTITY_INSERT [dbo].[FamilyCertificates] OFF
SET IDENTITY_INSERT [dbo].[IdentityCards] ON 

INSERT [dbo].[IdentityCards] ([IdentityCardID], [RegistrationDate], [ExpirationDate], [PersonID]) VALUES (1, CAST(N'2020-09-26' AS Date), CAST(N'2026-09-26' AS Date), 1)
INSERT [dbo].[IdentityCards] ([IdentityCardID], [RegistrationDate], [ExpirationDate], [PersonID]) VALUES (2, CAST(N'2020-09-26' AS Date), CAST(N'2026-09-26' AS Date), 2)
INSERT [dbo].[IdentityCards] ([IdentityCardID], [RegistrationDate], [ExpirationDate], [PersonID]) VALUES (3, CAST(N'2020-09-26' AS Date), CAST(N'2026-09-26' AS Date), 3)
INSERT [dbo].[IdentityCards] ([IdentityCardID], [RegistrationDate], [ExpirationDate], [PersonID]) VALUES (4, CAST(N'2020-09-26' AS Date), CAST(N'2026-09-26' AS Date), 4)
INSERT [dbo].[IdentityCards] ([IdentityCardID], [RegistrationDate], [ExpirationDate], [PersonID]) VALUES (5, CAST(N'2020-09-26' AS Date), CAST(N'2026-09-26' AS Date), 5)
SET IDENTITY_INSERT [dbo].[IdentityCards] OFF
SET IDENTITY_INSERT [dbo].[Passports] ON 

INSERT [dbo].[Passports] ([PassportID], [RegistrationDate], [ExpirationDate], [EyeColor], [MigrationPlace], [PersonID]) VALUES (1, CAST(N'2020-09-26' AS Date), CAST(N'2030-09-26' AS Date), N'Gjelber', N'Gjermani', 1)
INSERT [dbo].[Passports] ([PassportID], [RegistrationDate], [ExpirationDate], [EyeColor], [MigrationPlace], [PersonID]) VALUES (2, CAST(N'2020-09-26' AS Date), CAST(N'2030-09-26' AS Date), N'Zi', N'Angli', 4)
INSERT [dbo].[Passports] ([PassportID], [RegistrationDate], [ExpirationDate], [EyeColor], [MigrationPlace], [PersonID]) VALUES (3, CAST(N'2020-09-26' AS Date), CAST(N'2030-09-26' AS Date), N'Kalter', N'Austri', 7)
INSERT [dbo].[Passports] ([PassportID], [RegistrationDate], [ExpirationDate], [EyeColor], [MigrationPlace], [PersonID]) VALUES (4, CAST(N'2020-09-26' AS Date), CAST(N'2030-09-26' AS Date), N'Kafte', N'Suedi', 9)
INSERT [dbo].[Passports] ([PassportID], [RegistrationDate], [ExpirationDate], [EyeColor], [MigrationPlace], [PersonID]) VALUES (5, CAST(N'2020-09-26' AS Date), CAST(N'2030-09-26' AS Date), N'Gjelber', N'Sloveni', 5)
SET IDENTITY_INSERT [dbo].[Passports] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (1, N'1000000001', N'Granit', N'Krasniqi', CAST(N'1995-04-16' AS Date), N'Male', N'g@k.com', N'Negroc/Drenas', N'Negroc', N'Drenas', N'Shqiptar', N'Unemployed', N'Bachelor', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (2, N'1000000002', N'Bedri', N'Krasniqi', CAST(N'1972-06-01' AS Date), N'Male', N'b@k.com', N'Negroc/Drenas', N'Negroc', N'Drenas', N'Shqiptar', N'Employed', N'ProfesionalTraining', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (3, N'1000000003', N'Fazile', N'Krasniqi', CAST(N'1972-06-06' AS Date), N'Male', N'f@k.com', N'Negroc/Drenas', N'Llapushnik', N'Drenas', N'Shqiptar', N'Employed', N'Bachelor', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (4, N'1000000004', N'Endrit', N'Krasniqi', CAST(N'2018-04-17' AS Date), N'Male', N'e@k.com', N'Negroc/Drenas', N'Negroc', N'Drenas', N'Shqiptar', N'Unemployed', N'Other', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (5, N'1000000005', N'Gresa', N'Krasniqi', CAST(N'2007-02-14' AS Date), N'Female', N'g@k.com', N'Negroc/Drenas', N'Negroc', N'Drenas', N'Shqiptar', N'Unemployed', N'Other', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (6, N'1000000006', N'Diellza', N'Berisha', CAST(N'1998-12-04' AS Date), N'Female', N'd@b.com', N'Zhur/Prizren', N'Zhur', N'Prizren', N'Shqiptar', N'Employed', N'Bachelor', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (7, N'1000000007', N'Veton', N'berisha', CAST(N'1983-09-03' AS Date), N'Male', N'v@b.com', N'FK/Prishtine', N'FusheKosove', N'FusheKosove', N'Egjiptian', N'Employed', N'Bachelor', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (8, N'1000000008', N'Egzona', N'Gashi', CAST(N'2001-02-28' AS Date), N'Female', N'e@g.com', N'Fshat/Gjilan', N'Fshat', N'Gjilan', N'Shqiptar', N'Employed', N'Bachelor', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (9, N'1000000009', N'Blerim', N'Hoxha', CAST(N'1993-08-16' AS Date), N'Male', N'b@h.com', N'Fshat/Suhareke', N'Fshat', N'Suhareke', N'Shqiptar', N'Employed', N'ProfesionalTraining', N'Positive')
INSERT [dbo].[People] ([PersonID], [PersonalNumber], [FirstName], [LastName], [Birthday], [Gender], [Email], [Address], [BirthPlace], [Municipality], [Nationality], [EmploymentStatus], [Qualification], [HealthCondition]) VALUES (10, N'1000000010', N'Elmi', N'Shala', CAST(N'2005-01-01' AS Date), N'Male', N'e@sh.com', N'Fshat/Mitrovice', N'Fshat', N'Mitrovice', N'Shqiptar', N'Employed', N'Bachelor', N'Positive')
SET IDENTITY_INSERT [dbo].[People] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__People__AC2CC42EDCB7FCAA]    Script Date: 9/26/2020 11:54:06 AM ******/
ALTER TABLE [dbo].[People] ADD UNIQUE NONCLUSTERED 
(
	[PersonalNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BirthCertificates]  WITH CHECK ADD FOREIGN KEY([FatherID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[BirthCertificates]  WITH CHECK ADD FOREIGN KEY([MotherID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[BirthCertificates]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[DeathCertificates]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[FamilyCertificates]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[IdentityCards]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[MarriageCertificates]  WITH CHECK ADD FOREIGN KEY([Partner1ID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[MarriageCertificates]  WITH CHECK ADD FOREIGN KEY([Partner2ID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Passports]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
/****** Object:  StoredProcedure [dbo].[usp_BirthNumber]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[usp_BirthNumber]
AS
	SELECT count(PersonID) as number from People
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[usp_DeathNumber]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[usp_DeathNumber]
AS
	SELECT count(DeathCertificatesID) as number from DeathCertificates
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[usp_MarriageNumber]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[usp_MarriageNumber]
AS
	SELECT count(MarriageCertificateID) as number from MarriageCertificates
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[usp_MigrationNumber]    Script Date: 9/26/2020 11:54:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[usp_MigrationNumber]
AS
	SELECT count(PassportID) as number from Passports
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [CivilRegistry] SET  READ_WRITE 
GO

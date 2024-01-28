USE [master]
GO
/****** Object:  Database [BallastLane]    Script Date: 14/12/2016 05:20:46 ******/
CREATE DATABASE [BallastLane]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BallastLane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BallastLane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BallastLane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BallastLane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BallastLane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BallastLane] SET ARITHABORT OFF 
GO
ALTER DATABASE [BallastLane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BallastLane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BallastLane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BallastLane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BallastLane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BallastLane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BallastLane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BallastLane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BallastLane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BallastLane] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BallastLane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BallastLane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BallastLane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BallastLane] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [BallastLane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BallastLane] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BallastLane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BallastLane] SET RECOVERY FULL 
GO
ALTER DATABASE [BallastLane] SET  MULTI_USER 
GO
ALTER DATABASE [BallastLane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BallastLane] SET DB_CHAINING OFF 
GO



USE [BallastLane]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredEvent]    Script Date: 1/27/2024 11:22:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredEvent](
	[Id] [uniqueidentifier] NOT NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[Data] [nvarchar](max) NULL,
	[Action] [varchar](100) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[User] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

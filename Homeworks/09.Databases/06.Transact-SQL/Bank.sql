USE [master]
GO
/****** Object:  Database [Bank]    Script Date: 22.2.2015 г. 23:25:00 ******/
CREATE DATABASE [Bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Bank.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Bank_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bank] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bank] SET RECOVERY FULL 
GO
ALTER DATABASE [Bank] SET  MULTI_USER 
GO
ALTER DATABASE [Bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bank] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Bank] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bank', N'ON'
GO
USE [Bank]
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_CalculateInterest]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_CalculateInterest](@sum MONEY, @interest REAL, @months FLOAT) RETURNS DECIMAL(18, 2)
BEGIN
	DECLARE @result MONEY;
	SET @result = @sum * (1 + (@interest / 100) * (@months / 12));
	RETURN @result;
END

GO
/****** Object:  UserDefinedFunction [dbo].[ufn_GetBalanceById]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_GetBalanceById] (@AccountId INT) RETURNS MONEY
BEGIN
	RETURN (
		SELECT Balance
		FROM Accounts
		WHERE Id = @AccountId
	)
END

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[OldSum] [money] NOT NULL,
	[NewSum] [money] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (1, 67, 79403.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (2, 76, 61949.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (3, 59, 65215.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (4, 76, 66196.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (5, 90, 42652.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (6, 73, 31864.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (7, 5, 88420.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (8, 55, 58098.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (9, 54, 33647.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (10, 72, 10837.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (11, 96, 62211.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (12, 73, 46340.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (13, 3, 58155.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (14, 40, 12828.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (15, 91, 92233.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (16, 91, 63473.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (17, 44, 85451.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (18, 91, 79073.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (19, 15, 56755.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (20, 18, 51821.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (21, 21, 11994.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (22, 55, 37309.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (23, 49, 62844.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (24, 87, 80442.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (25, 98, 17801.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (26, 80, 48571.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (27, 25, 51961.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (28, 68, 57547.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (29, 38, 85268.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (30, 97, 89865.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (31, 49, 36709.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (32, 48, 39697.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (33, 90, 26647.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (34, 45, 65149.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (35, 71, 6446.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (36, 99, 27054.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (37, 16, 42513.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (38, 57, 33179.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (39, 88, 93112.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (40, 88, 32308.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (41, 45, 87118.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (42, 42, 36005.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (43, 96, 90248.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (44, 15, 95803.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (45, 66, 16838.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (46, 24, 39308.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (47, 18, 35003.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (48, 52, 89909.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (49, 12, 23086.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (50, 63, 64210.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (51, 57, 67590.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (52, 14, 57800.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (53, 97, 30124.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (54, 21, 24597.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (55, 23, 41606.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (56, 17, 88306.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (57, 90, 72359.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (58, 91, 2037.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (59, 67, 90596.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (60, 60, 85366.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (61, 8, 20940.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (62, 10, 75521.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (63, 42, 83198.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (64, 90, 30007.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (65, 94, 17324.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (66, 71, 9329.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (67, 66, 15850.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (68, 13, 21896.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (69, 13, 32742.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (70, 49, 61475.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (71, 82, 36515.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (72, 92, 99024.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (73, 27, 40511.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (74, 60, 93911.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (75, 45, 72363.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (76, 7, 85229.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (77, 69, 95740.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (78, 66, 75698.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (79, 20, 4865.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (80, 57, 55582.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (81, 94, 41684.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (82, 58, 83086.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (83, 7, 12058.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (84, 13, 46418.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (85, 31, 44018.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (86, 93, 18363.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (87, 37, 32061.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (88, 91, 10662.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (89, 78, 59225.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (90, 78, 84134.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (91, 63, 98864.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (92, 91, 13515.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (93, 72, 33389.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (94, 53, 90118.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (95, 3, 640.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (96, 13, 5593.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (97, 61, 31367.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (98, 17, 45780.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (99, 79, 10263.0000)
GO
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (100, 9, 28249.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (2, N'Oprah', N'Gabriel', N'346532893323807')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (3, N'Felicia', N'Ryder', N'376617621553133')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (4, N'Veronica', N'Bert', N'5453339451062496')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (5, N'Sade', N'Amery', N'348283887832890')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (6, N'Lydia', N'Kasimir', N'4267299929494035')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (7, N'Lavinia', N'Kibo', N'371089247994593')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (8, N'Nina', N'Lee', N'343072814039429')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (9, N'Tamekah', N'Herrod', N'371123385914608')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (10, N'Jaden', N'Fulton', N'4482392141083257')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (11, N'Yuri', N'Vladimir', N'5171822974951930')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (12, N'Amy', N'Kenyon', N'376463381274600')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (13, N'Neve', N'Julian', N'5243233992145396')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (14, N'Cheryl', N'Rogan', N'5134319122685110')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (15, N'Bo', N'Damon', N'344915848316152')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (16, N'Briar', N'Callum', N'5327137613869275')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (17, N'Evelyn', N'Samuel', N'5163809792371464')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (18, N'Sade', N'Camden', N'372990685696241')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (19, N'Lavinia', N'Uriah', N'343230521856804')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (20, N'Alexandra', N'Tate', N'4481417629588391')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (21, N'Alika', N'Jeremy', N'4799716134462506')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (22, N'Allegra', N'Ryan', N'5148918030667118')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (23, N'Vera', N'Caleb', N'371258036138959')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (24, N'Shelby', N'Lawrence', N'5450408371314409')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (25, N'Whoopi', N'Perry', N'4920269523188478')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (26, N'Nora', N'Tanner', N'345303575983273')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (27, N'Chanda', N'Beck', N'346300098837815')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (28, N'Julie', N'Omar', N'4346692473534498')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (29, N'Harriet', N'Drew', N'5418101091897113')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (30, N'Medge', N'Dorian', N'5288089648145257')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (31, N'Hadassah', N'Asher', N'5140607161903756')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (32, N'Yetta', N'Emery', N'5154936531390997')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (33, N'Mollie', N'Cole', N'5153418581383308')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (34, N'Quintessa', N'David', N'379678337743500')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (35, N'Hanna', N'Lyle', N'349827598249534')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (36, N'Shelley', N'Travis', N'4362574597122140')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (37, N'Sierra', N'Emmanuel', N'4235133704263718')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (38, N'Fiona', N'Samuel', N'4991684624413029')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (39, N'Jolene', N'Donovan', N'5156985600106414')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (40, N'Aubrey', N'Thane', N'5124747229572381')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (41, N'Iona', N'Castor', N'5347407676549623')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (42, N'Stella', N'Carson', N'5128808575058359')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (43, N'Kendall', N'Callum', N'347938104231847')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (44, N'Alexis', N'Malcolm', N'4806416686950250')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (45, N'Lee', N'Devin', N'5153127697743471')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (46, N'Olympia', N'Wayne', N'4285395254800091')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (47, N'Tatiana', N'Martin', N'349777928256428')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (48, N'Raven', N'Cameron', N'5116937490156859')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (49, N'Quincy', N'Kenneth', N'4484463824424894')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (50, N'Linda', N'Valentine', N'5130084501132365')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (51, N'Cally', N'Orson', N'375507925311564')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (52, N'Deirdre', N'Ross', N'4284179958887399')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (53, N'Madeline', N'Brenden', N'4690025317994877')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (54, N'Renee', N'Lev', N'345765961450523')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (55, N'Libby', N'Jason', N'5368826367245050')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (56, N'Alfreda', N'Deacon', N'5161029484118331')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (57, N'Casey', N'Carter', N'5210695374379863')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (58, N'Astra', N'Sylvester', N'5331827355623245')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (59, N'Caryn', N'Nolan', N'348569873147178')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (60, N'Ann', N'Lee', N'5118796466276982')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (61, N'Kelly', N'Keefe', N'371991700376848')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (62, N'Avye', N'Gage', N'4263058933755387')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (63, N'Wynter', N'Emery', N'4637329977098850')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (64, N'Charissa', N'Ulric', N'346333558519375')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (65, N'Alexa', N'Ryder', N'4230892708525068')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (66, N'Audrey', N'Paki', N'346200898020527')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (67, N'Natalie', N'Mark', N'4895930449059235')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (68, N'Nomlanga', N'Malik', N'5136602641278877')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (69, N'Jaime', N'Hop', N'5161177442646586')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (70, N'Leila', N'Myles', N'5346578645054258')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (71, N'Whilemina', N'Jerome', N'5351349870851267')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (72, N'Kalia', N'Leroy', N'4985851191962130')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (73, N'Inga', N'Amery', N'376538722011266')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (74, N'Rama', N'Abbot', N'5130730913169680')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (75, N'Olivia', N'Victor', N'5179226787891232')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (76, N'Taylor', N'Valentine', N'5118514917897999')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (77, N'Faith', N'Emery', N'344927043864965')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (78, N'Ann', N'Gray', N'5377006070455539')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (79, N'Shea', N'Ahmed', N'5125452408054849')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (80, N'Daryl', N'Rooney', N'5187716821092189')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (81, N'Guinevere', N'Hall', N'379709057158799')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (82, N'Blythe', N'Yardley', N'5170531661170533')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (83, N'Victoria', N'Damon', N'5116134817022830')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (84, N'Cheryl', N'Odysseus', N'5166093103387391')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (85, N'Pascale', N'Orson', N'5128191275675784')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (86, N'Leigh', N'Dane', N'5174961184267880')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (87, N'Sheila', N'Nero', N'4271225875057280')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (88, N'Kimberly', N'Ferdinand', N'4288866500556462')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (89, N'Macy', N'Kane', N'349678853989118')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (90, N'Jillian', N'Hammett', N'371282131897752')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (91, N'Eugenia', N'Alden', N'343768311637454')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (92, N'Kai', N'Ira', N'4167055437015360')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (93, N'Shelly', N'Drew', N'5129127212394965')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (94, N'Elaine', N'Scott', N'349141611408444')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (95, N'Rosalyn', N'Jakeem', N'5170041128895243')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (96, N'Chiquita', N'Price', N'374221648324743')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (97, N'Cameran', N'Amery', N'4534250942897053')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (98, N'Judith', N'Mark', N'5359634173801160')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (99, N'Jena', N'Denton', N'376881912452633')
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (100, N'Irma', N'Raymond', N'4146025369362906')
GO
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (101, N'Althea', N'Ian', N'379621281885543')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
/****** Object:  StoredProcedure [dbo].[usp_DepositMoney]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_DepositMoney] (@AccountId INT, @amount MONEY)
AS
	IF (@amount <= 0 OR @amount IS NULL)
		RAISERROR ('Deposit amount must number greater then zero.', 16, 1);
	ELSE
		UPDATE Accounts
		SET Balance = dbo.ufn_GetBalanceById(@AccountId) + @amount
		WHERE Id = @AccountId;

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllWithBalanceMoreThan]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_GetAllWithBalanceMoreThan](@balance MONEY)
AS
SELECT p.FirstName, p.LastName, a.Balance
FROM Persons p
JOIN Accounts a
ON p.Id = a.PersonId AND a.Balance > @balance

GO
/****** Object:  StoredProcedure [dbo].[usp_GetClientInterest]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetClientInterest](@AccountId INT, @interest REAL)
AS
	DECLARE @currentBalance MONEY;
	SET @currentBalance = (
	SELECT Balance FROM Accounts a
	WHERE a.Id = @AccountId
	);

	UPDATE Accounts
	SET  Balance = dbo.ufn_CalculateInterest(@currentBalance, @interest, 1)
	WHERE Id = @AccountId

GO
/****** Object:  StoredProcedure [dbo].[usp_GetFullName]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetFullName]
AS
	SELECT FirstName + ' ' + LastName
	AS [Full Name]
	FROM Persons

GO
/****** Object:  StoredProcedure [dbo].[usp_WithdrawMoney]    Script Date: 22.2.2015 г. 23:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_WithdrawMoney] (@AccountId INT, @amount MONEY)
AS
	IF (@amount <= 0 OR @amount IS NULL)
		RAISERROR ('Withdraw amount must number greater then zero.', 16, 1);
	ELSE
		UPDATE Accounts
		SET Balance = dbo.ufn_GetBalanceById(@AccountId) - @amount
		WHERE Id = @AccountId;

GO
USE [master]
GO
ALTER DATABASE [Bank] SET  READ_WRITE 
GO

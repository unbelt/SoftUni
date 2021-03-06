USE [School]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 10.2.2015 г. 23:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Classes](
	[Name] [varchar](50) NOT NULL,
	[MaxStudents] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 10.2.2015 г. 23:16:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[Name] [varchar](50) NOT NULL,
	[Age] [tinyint] NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Classes] ([Name], [MaxStudents]) VALUES (N'C# Fundamentals', 500)
INSERT [dbo].[Classes] ([Name], [MaxStudents]) VALUES (N'PHP Basics', 300)
INSERT [dbo].[Classes] ([Name], [MaxStudents]) VALUES (N'HTML / CSS', 250)
INSERT [dbo].[Students] ([Name], [Age], [PhoneNumber]) VALUES (N'Pesho', 23, N'0881231233')
INSERT [dbo].[Students] ([Name], [Age], [PhoneNumber]) VALUES (N'Gosho', 24, N'0883213211')
INSERT [dbo].[Students] ([Name], [Age], [PhoneNumber]) VALUES (N'John', 33, N'+44 556 654 123')
INSERT [dbo].[Students] ([Name], [Age], [PhoneNumber]) VALUES (N'Peter', 23, N'(+359) 881 233 212')
INSERT [dbo].[Students] ([Name], [Age], [PhoneNumber]) VALUES (N'Ivo', 44, N'none')

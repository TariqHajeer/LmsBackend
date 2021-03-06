USE [master]
GO
/****** Object:  Database [Lms]    Script Date: 6/12/2021 8:40:40 PM ******/
CREATE DATABASE [Lms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lms', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Lms.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Lms_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Lms_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Lms] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lms] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lms] SET RECOVERY FULL 
GO
ALTER DATABASE [Lms] SET  MULTI_USER 
GO
ALTER DATABASE [Lms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lms] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Lms] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Lms', N'ON'
GO
USE [Lms]
GO
/****** Object:  Table [dbo].[Ads]    Script Date: 6/12/2021 8:40:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[CreateDate] [date] NOT NULL,
 CONSTRAINT [PK_Ads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 6/12/2021 8:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Pwassowrd] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeWork]    Script Date: 6/12/2021 8:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeWork](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[Path] [nvarchar](max) NULL,
 CONSTRAINT [PK_HomeWork] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 6/12/2021 8:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[Choise1] [nvarchar](max) NOT NULL,
	[Choise2] [nvarchar](max) NOT NULL,
	[Choise3] [nvarchar](max) NOT NULL,
	[Choise4] [nvarchar](max) NOT NULL,
	[Correct] [nvarchar](max) NOT NULL,
	[Time] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAnswers]    Script Date: 6/12/2021 8:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAnswers](
	[StudentId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Student_Answers] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/12/2021 8:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Exam] ON 

INSERT [dbo].[Exam] ([Id], [Title], [Date], [Pwassowrd]) VALUES (14, N'اخبار تجريبي', CAST(N'2021-06-12T16:00:00.000' AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[Exam] OFF
SET IDENTITY_INSERT [dbo].[HomeWork] ON 

INSERT [dbo].[HomeWork] ([Id], [Note], [UserId], [Path]) VALUES (16, N'sjdaflos l;ksa fdsa;l sad', 2, N'16.pdf')
SET IDENTITY_INSERT [dbo].[HomeWork] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([Id], [ExamId], [Question], [Choise1], [Choise2], [Choise3], [Choise4], [Correct], [Time]) VALUES (22, 14, N'سؤال', N'منشستي', N'سمنتيشسيشسي', N'شسنمتيسشيلل', N'لاتبت', N'سمنتيشسيشسي', 1)
INSERT [dbo].[Questions] ([Id], [ExamId], [Question], [Choise1], [Choise2], [Choise3], [Choise4], [Correct], [Time]) VALUES (23, 14, N'مسنيتسشمنتي', N'منتسشينمتشسيشس', N'سنمتيسشيتشستي', N'سشنمتيسشنت', N'منشتسي', N'سنمتيسشيتشستي', 1)
INSERT [dbo].[Questions] ([Id], [ExamId], [Question], [Choise1], [Choise2], [Choise3], [Choise4], [Correct], [Time]) VALUES (24, 14, N'سؤال 3', N'c1', N'c2', N'c3', N'c4', N'c1', 1)
INSERT [dbo].[Questions] ([Id], [ExamId], [Question], [Choise1], [Choise2], [Choise3], [Choise4], [Correct], [Time]) VALUES (25, 14, N'سؤال4', N'c1', N'c2', N'c3', N'c4', N'c2', 1)
INSERT [dbo].[Questions] ([Id], [ExamId], [Question], [Choise1], [Choise2], [Choise3], [Choise4], [Correct], [Time]) VALUES (26, 14, N'سؤال5', N'c1', N'c2', N'c3', N'c4', N'c4', 1)
INSERT [dbo].[Questions] ([Id], [ExamId], [Question], [Choise1], [Choise2], [Choise3], [Choise4], [Correct], [Time]) VALUES (27, 14, N'سؤال6', N'c1', N'c2', N'c3', N'c4', N'c3', 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (2, 22, N'منشستي')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (2, 23, N'سنمتيسشيتشستي')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (2, 24, N'c2')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (2, 25, N'c2')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (2, 26, N'c2')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (2, 27, N'c2')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (3, 22, N'متشسي')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (3, 24, N'c2')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (3, 25, N'c3')
INSERT [dbo].[StudentAnswers] ([StudentId], [QuestionId], [Answer]) VALUES (3, 26, N'c4')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [IsAdmin]) VALUES (1, N'سعد محسن', N'SaidMohsen', N'SaidMohsen123', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [IsAdmin]) VALUES (2, N'طالب1', N'student1', N'123', 0)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [IsAdmin]) VALUES (3, N'طالب2', N'studnet2', N'123', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[HomeWork]  WITH CHECK ADD  CONSTRAINT [FK_HomeWork_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HomeWork] CHECK CONSTRAINT [FK_HomeWork_User]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Exam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Exam]
GO
ALTER TABLE [dbo].[StudentAnswers]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswers_Questions1] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[StudentAnswers] CHECK CONSTRAINT [FK_StudentAnswers_Questions1]
GO
ALTER TABLE [dbo].[StudentAnswers]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswers_User] FOREIGN KEY([StudentId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StudentAnswers] CHECK CONSTRAINT [FK_StudentAnswers_User]
GO
USE [master]
GO
ALTER DATABASE [Lms] SET  READ_WRITE 
GO

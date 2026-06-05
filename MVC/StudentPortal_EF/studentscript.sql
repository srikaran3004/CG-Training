USE [master]
GO
/****** Object:  Database [StudentPortalDb]    Script Date: 02-03-2026 11:44:53 ******/
CREATE DATABASE [StudentPortalDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentPortalDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StudentPortalDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentPortalDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StudentPortalDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
 ---------------------
USE [StudentPortalDb]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 02-03-2026 11:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[DurationDays] [int] NOT NULL,
	[Fee] [decimal](10, 2) NOT NULL,
	[Level] [nvarchar](30) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 02-03-2026 11:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrollDate] [date] NOT NULL,
	[PaymentStatus] [nvarchar](20) NOT NULL,
	[PaidAmount] [decimal](10, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED 
(
	[EnrollmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 02-03-2026 11:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](120) NOT NULL,
	[Email] [nvarchar](180) NOT NULL,
	[Phone] [nvarchar](30) NULL,
	[Status] [nvarchar](20) NOT NULL,
	[JoinDate] [date] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLog]    Script Date: 02-03-2026 11:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLog](
	[StudentId] [int] NOT NULL,
	[LogId] [int] NOT NULL,
	[Info] [varchar](2000) NULL,
 CONSTRAINT [PK_tblLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [Title], [DurationDays], [Fee], [Level], [IsActive], [CreatedAt]) VALUES (1, N'ASP.NET MVC Fundamentals', 20, CAST(7999.00 AS Decimal(10, 2)), N'Beginner', 1, CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Courses] ([CourseId], [Title], [DurationDays], [Fee], [Level], [IsActive], [CreatedAt]) VALUES (2, N'Entity Framework (DB First + Code First)', 15, CAST(6999.00 AS Decimal(10, 2)), N'Intermediate', 1, CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Courses] ([CourseId], [Title], [DurationDays], [Fee], [Level], [IsActive], [CreatedAt]) VALUES (3, N'Deployment with IIS + CI/CD Basics', 10, CAST(4999.00 AS Decimal(10, 2)), N'Advanced', 1, CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollments] ON 

INSERT [dbo].[Enrollments] ([EnrollmentId], [StudentId], [CourseId], [EnrollDate], [PaymentStatus], [PaidAmount], [CreatedAt]) VALUES (1, 1, 1, CAST(N'2026-02-05' AS Date), N'Paid', CAST(7999.00 AS Decimal(10, 2)), CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Enrollments] ([EnrollmentId], [StudentId], [CourseId], [EnrollDate], [PaymentStatus], [PaidAmount], [CreatedAt]) VALUES (2, 2, 1, CAST(N'2026-02-12' AS Date), N'Pending', CAST(0.00 AS Decimal(10, 2)), CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Enrollments] ([EnrollmentId], [StudentId], [CourseId], [EnrollDate], [PaymentStatus], [PaidAmount], [CreatedAt]) VALUES (3, 2, 2, CAST(N'2026-02-14' AS Date), N'Paid', CAST(6999.00 AS Decimal(10, 2)), CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Enrollments] ([EnrollmentId], [StudentId], [CourseId], [EnrollDate], [PaymentStatus], [PaidAmount], [CreatedAt]) VALUES (4, 4, 1, CAST(N'2026-03-02' AS Date), N'Pending', CAST(0.00 AS Decimal(10, 2)), CAST(N'2026-03-02T00:25:39.6537202' AS DateTime2))
INSERT [dbo].[Enrollments] ([EnrollmentId], [StudentId], [CourseId], [EnrollDate], [PaymentStatus], [PaidAmount], [CreatedAt]) VALUES (5, 1, 3, CAST(N'2026-03-02' AS Date), N'Pending', CAST(0.00 AS Decimal(10, 2)), CAST(N'2026-03-02T00:25:51.1832907' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Enrollments] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [Phone], [Status], [JoinDate], [CreatedAt]) VALUES (1, N'Asha Sharma', N'asha@example.com', N'9876543210', N'Active', CAST(N'2026-02-01' AS Date), CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [Phone], [Status], [JoinDate], [CreatedAt]) VALUES (2, N'Ravi Kumar', N'ravi@example.com', N'9876543211', N'Active', CAST(N'2026-02-10' AS Date), CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [Phone], [Status], [JoinDate], [CreatedAt]) VALUES (3, N'Neha Singh', N'neha@example.com', N'9876543212', N'Inactive', CAST(N'2026-01-15' AS Date), CAST(N'2026-03-01T23:32:56.5034546' AS DateTime2))
INSERT [dbo].[Students] ([StudentId], [FullName], [Email], [Phone], [Status], [JoinDate], [CreatedAt]) VALUES (4, N'Gopi Suresh', N'osgopinath@gmail.com', N'07019742115', N'Active', CAST(N'2026-01-01' AS Date), CAST(N'2026-03-01T18:39:20.6655940' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Courses_Title]    Script Date: 02-03-2026 11:44:53 ******/
CREATE NONCLUSTERED INDEX [IX_Courses_Title] ON [dbo].[Courses]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Enrollments_StudentCourse]    Script Date: 02-03-2026 11:44:53 ******/
ALTER TABLE [dbo].[Enrollments] ADD  CONSTRAINT [UQ_Enrollments_StudentCourse] UNIQUE NONCLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_CourseId]    Script Date: 02-03-2026 11:44:53 ******/
CREATE NONCLUSTERED INDEX [IX_Enrollments_CourseId] ON [dbo].[Enrollments]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_StudentId]    Script Date: 02-03-2026 11:44:53 ******/
CREATE NONCLUSTERED INDEX [IX_Enrollments_StudentId] ON [dbo].[Enrollments]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Students_Email]    Script Date: 02-03-2026 11:44:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Students_Email] ON [dbo].[Students]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_CreatedAt]  DEFAULT (sysdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Enrollments] ADD  CONSTRAINT [DF_Enrollments_PaymentStatus]  DEFAULT ('Pending') FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[Enrollments] ADD  CONSTRAINT [DF_Enrollments_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[Enrollments] ADD  CONSTRAINT [DF_Enrollments_CreatedAt]  DEFAULT (sysdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Students_Status]  DEFAULT ('Active') FOR [Status]
GO
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Students_CreatedAt]  DEFAULT (sysdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Courses]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Students]
GO
ALTER TABLE [dbo].[tblLog]  WITH CHECK ADD  CONSTRAINT [FK_tblLog_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[tblLog] CHECK CONSTRAINT [FK_tblLog_Students]
GO
USE [master]
GO
ALTER DATABASE [StudentPortalDb] SET  READ_WRITE 
GO

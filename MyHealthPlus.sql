USE [MyHealthPlus]
GO
/****** Object:  Schema [Manage]    Script Date: 12/14/2021 6:53:41 AM ******/
CREATE SCHEMA [Manage]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserNotes] [varchar](max) NULL,
	[CheckUpTypeId] [int] NULL,
	[AppointmentDate] [datetime] NOT NULL,
	[TimeRangeId] [int] NULL,
	[DoctorNotes] [varchar](max) NULL,
	[StatusId] [int] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[DateUpdated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[Level] [varchar](max) NOT NULL,
	[CallSite] [varchar](max) NOT NULL,
	[Type] [varchar](max) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[StackTrace] [varchar](max) NOT NULL,
	[InnerException] [varchar](max) NOT NULL,
	[AdditionalInfo] [varchar](max) NOT NULL,
	[LoggedOnDate] [datetime] NOT NULL,
 CONSTRAINT [pk_logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](256) NULL,
	[Password] [varchar](256) NULL,
	[LastName] [varchar](256) NULL,
	[FirstName] [varchar](256) NOT NULL,
	[MiddleName] [varchar](256) NULL,
	[Extension] [varchar](256) NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[DateUpdated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Manage].[CheckUpTypes]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Manage].[CheckUpTypes](
	[CheckUpTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[DateUpdated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CheckUpTypes] PRIMARY KEY CLUSTERED 
(
	[CheckUpTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Manage].[Roles]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Manage].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[DateUpdated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Manage].[Status]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Manage].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[DateUpdated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Manage].[TimeRangeList]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Manage].[TimeRangeList](
	[TimeRangeId] [int] IDENTITY(1,1) NOT NULL,
	[Period] [varchar](2) NOT NULL,
	[StartRange] [time](7) NULL,
	[EndRange] [time](7) NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[DateUpdated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TimeRangeList] PRIMARY KEY CLUSTERED 
(
	[TimeRangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password], [LastName], [FirstName], [MiddleName], [Extension], [RoleId], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (1, N'jdelacruz', N'OS05Lgnt2DGnnm7LN2yF8w2', N'Dela Cruz', N'Juan', N'Cruz', NULL, 4, N'User', CAST(N'2021-12-10T17:31:32.860' AS DateTime), N'jdelacruz', CAST(N'2021-12-14T03:41:43.203' AS DateTime), 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [LastName], [FirstName], [MiddleName], [Extension], [RoleId], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (2, N'Doctor', N'sLYc3IR9UwM1', N'Doctor', N'Doctor', N'Doctor', NULL, 2, N'User', CAST(N'2021-12-14T04:59:13.007' AS DateTime), N'', CAST(N'2021-12-14T04:59:13.007' AS DateTime), 1)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [LastName], [FirstName], [MiddleName], [Extension], [RoleId], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (3, N'Staff', N'jRC9odTuUZw1', N'Staff', N'Staff', N'Staff', NULL, 3, N'User', CAST(N'2021-12-14T04:59:41.593' AS DateTime), N'', CAST(N'2021-12-14T04:59:41.593' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [Manage].[CheckUpTypes] ON 

INSERT [Manage].[CheckUpTypes] ([CheckUpTypeId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (1, N'General Check-ups', N'', N'kmaghirang', CAST(N'2021-12-13T08:22:31.700' AS DateTime), N'', CAST(N'2021-12-13T08:22:31.700' AS DateTime), 1)
INSERT [Manage].[CheckUpTypes] ([CheckUpTypeId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (2, N'Skin Cancer Appointment', N'', N'kmaghirang', CAST(N'2021-12-13T08:22:39.017' AS DateTime), N'', CAST(N'2021-12-13T08:22:39.017' AS DateTime), 1)
SET IDENTITY_INSERT [Manage].[CheckUpTypes] OFF
GO
SET IDENTITY_INSERT [Manage].[Roles] ON 

INSERT [Manage].[Roles] ([RoleId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (1, N'Super Admin', N'', N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), 0)
INSERT [Manage].[Roles] ([RoleId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (2, N'Doctor', N'', N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), 1)
INSERT [Manage].[Roles] ([RoleId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (3, N'Staff', N'', N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), 1)
INSERT [Manage].[Roles] ([RoleId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (4, N'User', N'', N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), N'kmaghirang', CAST(N'2021-12-10T17:07:09.360' AS DateTime), 1)
SET IDENTITY_INSERT [Manage].[Roles] OFF
GO
SET IDENTITY_INSERT [Manage].[Status] ON 

INSERT [Manage].[Status] ([StatusId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (1, N'Scheduled', N'', N'kmaghirang', CAST(N'2021-12-13T08:24:07.083' AS DateTime), N'', CAST(N'2021-12-13T08:24:07.083' AS DateTime), 1)
INSERT [Manage].[Status] ([StatusId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (2, N'Done', N'', N'kmaghirang', CAST(N'2021-12-13T08:24:27.757' AS DateTime), N'', CAST(N'2021-12-13T08:24:27.757' AS DateTime), 1)
INSERT [Manage].[Status] ([StatusId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (3, N'Rescheduled', N'', N'kmaghirang', CAST(N'2021-12-13T08:24:42.193' AS DateTime), N'', CAST(N'2021-12-13T08:24:42.193' AS DateTime), 1)
INSERT [Manage].[Status] ([StatusId], [Name], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (4, N'Cancelled', N'', N'kmaghirang', CAST(N'2021-12-13T08:24:53.240' AS DateTime), N'', CAST(N'2021-12-13T08:24:53.240' AS DateTime), 1)
SET IDENTITY_INSERT [Manage].[Status] OFF
GO
SET IDENTITY_INSERT [Manage].[TimeRangeList] ON 

INSERT [Manage].[TimeRangeList] ([TimeRangeId], [Period], [StartRange], [EndRange], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (1, N'PM', CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'', N'kmaghirang', CAST(N'2021-12-13T08:20:30.543' AS DateTime), N'', CAST(N'2021-12-13T08:20:30.543' AS DateTime), 1)
INSERT [Manage].[TimeRangeList] ([TimeRangeId], [Period], [StartRange], [EndRange], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (2, N'PM', CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'', N'kmaghirang', CAST(N'2021-12-13T08:20:38.230' AS DateTime), N'', CAST(N'2021-12-13T08:20:38.230' AS DateTime), 1)
INSERT [Manage].[TimeRangeList] ([TimeRangeId], [Period], [StartRange], [EndRange], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (3, N'PM', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'', N'kmaghirang', CAST(N'2021-12-13T08:20:44.067' AS DateTime), N'', CAST(N'2021-12-13T08:20:44.067' AS DateTime), 1)
INSERT [Manage].[TimeRangeList] ([TimeRangeId], [Period], [StartRange], [EndRange], [Description], [CreatedBy], [DateCreated], [UpdatedBy], [DateUpdated], [IsActive]) VALUES (4, N'PM', CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time), N'', N'kmaghirang', CAST(N'2021-12-13T08:20:44.067' AS DateTime), N'', CAST(N'2021-12-13T08:20:44.067' AS DateTime), 1)
SET IDENTITY_INSERT [Manage].[TimeRangeList] OFF
GO
ALTER TABLE [dbo].[ErrorLogs] ADD  CONSTRAINT [df_logs_loggedondate]  DEFAULT (getutcdate()) FOR [LoggedOnDate]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_CheckUpTypes] FOREIGN KEY([CheckUpTypeId])
REFERENCES [Manage].[CheckUpTypes] ([CheckUpTypeId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_CheckUpTypes]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Status] FOREIGN KEY([StatusId])
REFERENCES [Manage].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Status]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_TimeRangeList] FOREIGN KEY([TimeRangeId])
REFERENCES [Manage].[TimeRangeList] ([TimeRangeId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_TimeRangeList]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [Manage].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[Insert_ErrorLog]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[Insert_ErrorLog] 
(
	@level varchar(max),
	@callSite varchar(max),
	@type varchar(max),
	@message varchar(max),
	@stackTrace varchar(max),
	@innerException varchar(max),
	@additionalInfo varchar(max)
)
as

insert into dbo.ErrorLogs
(
	[Level],
	CallSite,
	[Type],
	[Message],
	StackTrace,
	InnerException,
	AdditionalInfo
)
values
(
	@level,
	@callSite,
	@type,
	@message,
	@stackTrace,
	@innerException,
	@additionalInfo
)

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAvailableTimeRange]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Maghirang
-- Create date: 12/13/2021
-- Description:	Get the available timerange for the specific date
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAvailableTimeRange]
	-- Add the parameters for the stored procedure here
	@date varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DROP TABLE IF EXISTS #tempTable

	SELECT
	* 
	INTO #tempTable
	FROM dbo.Appointments
	WHERE CONVERT(date, AppointmentDate) = CONVERT(date,@date) 
	AND IsActive = 'true'

	SELECT
	* 
	FROM Manage.TimeRangeList
	WHERE TimeRangeId NOT IN (SELECT TimeRangeId FROM #tempTable)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMySchedule]    Script Date: 12/14/2021 6:53:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kevin Maghirang
-- Create date: 12/13/2021
-- Description:	Get the doctor schedule for the specific day
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetMySchedule]
	-- Add the parameters for the stored procedure here
	@date varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT 
		appt.AppointmentId,
		usr.LastName + ', ' + usr.FirstName + ' ' + usr.MiddleName AS FullName,
		cut.Name AS CheckUpType, 
		appt.AppointmentDate AS AppointmentDateDateFrmt,
		trl.StartRange,
		trl.EndRange,
		stat.Name AS Status,
		appt.StatusId
	FROM dbo.Appointments AS appt
	LEFT JOIN dbo.Users AS usr
	ON appt.UserId = usr.UserId
	LEFT JOIN Manage.CheckUpTypes as cut
	ON appt.CheckUpTypeId = cut.CheckUpTypeId
	LEFT JOIN Manage.TimeRangeList as trl
	ON appt.TimeRangeId = trl.TimeRangeId
	LEFT JOIN Manage.Status as stat
	ON appt.StatusId = stat.StatusId
	WHERE CONVERT(date, appt.AppointmentDate) = CONVERT(date,@date) 
	AND appt.IsActive = 'true'
END
GO

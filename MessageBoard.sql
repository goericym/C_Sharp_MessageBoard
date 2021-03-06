USE [MessageBoard]
GO
/****** Object:  Table [dbo].[login]    Script Date: 2016/4/18 下午 02:50:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[login](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](255) NULL,
	[Passwd] [varchar](600) NULL,
	[UserName] [varchar](255) NULL,
	[CreateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[message]    Script Date: 2016/4/18 下午 02:50:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [text] NULL,
	[Account] [varchar](255) NULL DEFAULT (NULL),
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReMessage]    Script Date: 2016/4/18 下午 02:50:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReMessage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Re_Id] [int] NOT NULL,
	[Account] [varchar](255) NOT NULL,
	[Message] [varchar](255) NOT NULL,
	[UpdateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[login] ADD  DEFAULT (NULL) FOR [Account]
GO
ALTER TABLE [dbo].[login] ADD  DEFAULT (NULL) FOR [Passwd]
GO
ALTER TABLE [dbo].[login] ADD  DEFAULT (NULL) FOR [UserName]
GO
ALTER TABLE [dbo].[login] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[ReMessage] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO

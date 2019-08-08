USE [DbEjemplos]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 8/08/2019 2:30:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[EmailId] [varchar](150) NULL,
	[City] [varchar](100) NULL,
	[PhoneNo] [varchar](15) NULL,
	[PinCode] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserDetails] ON 
GO
INSERT [dbo].[UserDetails] ([Id], [Name], [EmailId], [City], [PhoneNo], [PinCode]) VALUES (7, N'mario cobo', N'mariocc@gmail.com', N'cali', N'0987654321', N'0987')
GO
INSERT [dbo].[UserDetails] ([Id], [Name], [EmailId], [City], [PhoneNo], [PinCode]) VALUES (9, N'william', N'wifagoco@gmail.com', N'bogota', N'1234567', N'1234')
GO
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
GO
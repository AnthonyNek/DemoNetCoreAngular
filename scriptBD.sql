USE [BDInventario]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 17/07/2020 19:40:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Precio] [decimal](5, 2) NULL,
	[Tipo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 17/07/2020 19:40:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](max) NULL,
	[Clave] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (7, N'Fanta', CAST(12.40 AS Decimal(5, 2)), N'Gaseosa')
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (11, N'Concordia', CAST(2.20 AS Decimal(5, 2)), N'Gaseosa')
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (13, N'hola', CAST(34.00 AS Decimal(5, 2)), N'sdsd')
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (15, N'as', CAST(23.00 AS Decimal(5, 2)), N'as')
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (17, N'as', CAST(23.00 AS Decimal(5, 2)), N'sd')
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (19, N'sd', CAST(343.00 AS Decimal(5, 2)), N'sd')
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Tipo]) VALUES (20, N'dorito', CAST(34.00 AS Decimal(5, 2)), N'golosina')
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Clave], [Token]) VALUES (1, N'aportilla', N'12345', N'')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

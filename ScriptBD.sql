USE [DbPrueba]
GO
/****** Object:  Table [dbo].[tblInventario]    Script Date: 10/09/2022 11:11:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInventario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidadEntrada] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[codigo] [nvarchar](100) NOT NULL,
	[precio] [decimal](18, 0) NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[cantidad] [int] NOT NULL,
	[documento] [varbinary](max) NULL,
	[creadoPor] [nvarchar](50) NULL,
	[modificadoPor] [nvarchar](50) NULL,
	[fechaCreacion] [datetime2](7) NULL,
	[fechaModificacion] [datetime2](7) NULL,
	[nombreDocumento] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblInventario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProducto]    Script Date: 10/09/2022 11:11:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[cantidadMinAlerta] [int] NOT NULL,
	[creadoPor] [nvarchar](50) NULL,
	[modificadoPor] [nvarchar](50) NULL,
	[fechaCreacion] [datetime2](7) NULL,
	[fechaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_tblProducto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuario]    Script Date: 10/09/2022 11:11:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[correo] [nvarchar](100) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[creadoPor] [nvarchar](50) NULL,
	[modificadoPor] [nvarchar](50) NULL,
	[fechaCreacion] [datetime2](7) NULL,
	[fechaModificacion] [datetime2](7) NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_tblUsuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUsuario] ADD  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[tblInventario]  WITH CHECK ADD  CONSTRAINT [fk_inventario_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[tblProducto] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblInventario] CHECK CONSTRAINT [fk_inventario_producto]
GO

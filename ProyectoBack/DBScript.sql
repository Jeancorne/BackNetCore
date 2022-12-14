USE [DbPrueba]
GO
/****** Object:  Table [dbo].[tblPersona]    Script Date: 24/03/2022 2:37:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[numIdentificacion] [varchar](20) NULL,
	[idTipoIdentificacion] [int] NULL,
	[fechaCreacion] [datetime] NULL,
	[columnaCalculadaNum] [varchar](100) NULL,
	[columnaCalculadaNom] [varchar](100) NULL,
	[fechaModificacion] [datetime] NULL,
	[email] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoDocumento]    Script Date: 24/03/2022 2:37:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoDocumento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuario]    Script Date: 24/03/2022 2:37:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](100) NULL,
	[password] [varchar](max) NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblPersona]  WITH CHECK ADD  CONSTRAINT [fk_idTipoIdentificacion] FOREIGN KEY([idTipoIdentificacion])
REFERENCES [dbo].[tblTipoDocumento] ([id])
GO
ALTER TABLE [dbo].[tblPersona] CHECK CONSTRAINT [fk_idTipoIdentificacion]
GO
/****** Object:  StoredProcedure [dbo].[prc_obtenerUsuario]    Script Date: 24/03/2022 2:37:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[prc_obtenerUsuario]
as
select 
per.*,
tipo.nombre as nombreDocumento
from tblPersona as per
left join tblTipoDocumento as tipo
on per.IdTipoIdentificacion = tipo.id
GO

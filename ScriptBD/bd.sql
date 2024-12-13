USE [VentasSoft]
GO
/****** Object:  UserDefinedTableType [dbo].[compradetalles]    Script Date: 13/12/2024 13:49:00 ******/
CREATE TYPE [dbo].[compradetalles] AS TABLE(
	[IdCompra] [int] NULL,
	[IdProducto] [int] NULL,
	[CodProducto] [int] NULL,
	[Impuesto] [int] NULL,
	[Cantidad] [int] NULL,
	[Costo] [decimal](10, 2) NULL,
	[Precio] [decimal](10, 2) NULL,
	[SubTotal] [decimal](10, 2) NULL,
	[Total] [decimal](10, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[ventasdetalles]    Script Date: 13/12/2024 13:49:01 ******/
CREATE TYPE [dbo].[ventasdetalles] AS TABLE(
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[CodProducto] [varchar](100) NULL,
	[Cantidad] [int] NULL,
	[Precio] [decimal](10, 2) NULL,
	[Descuento] [int] NULL,
	[Impuesto] [int] NULL,
	[Subtotal] [decimal](10, 2) NULL,
	[Total] [decimal](10, 2) NULL
)
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Categoria] [varchar](30) NULL,
	[Descripcion] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Telefono] [varchar](25) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compras]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdSuplidor] [int] NOT NULL,
	[IdEmpresa] [int] NULL,
	[NroComprobante] [varchar](40) NULL,
	[MetodoPago] [varchar](50) NOT NULL,
	[TipoTarjeta] [varchar](40) NULL,
	[EstadoCompra] [varchar](30) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[NroTarjeta] [varchar](90) NULL,
	[TarjetaHabiente] [varchar](40) NULL,
	[Efectivo] [decimal](10, 2) NULL,
	[MontoDebitado] [decimal](10, 2) NULL,
	[Transferencia] [decimal](10, 2) NULL,
	[Pago] [decimal](10, 2) NULL,
	[Total] [decimal](10, 2) NULL,
	[Debe] [decimal](10, 2) NULL,
	[Devuelta] [decimal](10, 2) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_compra] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comprasdetalles]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comprasdetalles](
	[IdCompraDetalles] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[CodProducto] [int] NULL,
	[Impuesto] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[Costo] [decimal](10, 2) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_comprasdetalles] PRIMARY KEY CLUSTERED 
(
	[IdCompraDetalles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empresa]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresa](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nombre] [varchar](70) NOT NULL,
	[Telefono] [varchar](25) NOT NULL,
	[RNC] [varchar](60) NULL,
	[Direccion] [varchar](100) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estados]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estados](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Estado] [varchar](20) NULL,
	[Descripcion] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estadod] [varchar](20) NULL,
 CONSTRAINT [PK_estados] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[laboratorios]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[laboratorios](
	[IdLaboratorio] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[Direccion] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](15) NULL,
 CONSTRAINT [PK_laboratorios] PRIMARY KEY CLUSTERED 
(
	[IdLaboratorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[modulos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pagos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pagos](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdCompra] [int] NULL,
	[IdUsuario] [int] NOT NULL,
	[MetodoPago] [varchar](50) NULL,
	[TipoTarjeta] [varchar](40) NULL,
	[Descripcion] [varchar](100) NULL,
	[NroTarjeta] [varchar](90) NULL,
	[TarjetaHabiente] [varchar](40) NULL,
	[Efectivo] [decimal](10, 2) NULL,
	[MontoDebitado] [decimal](10, 2) NULL,
	[Transferencia] [decimal](10, 2) NULL,
	[Pago] [decimal](10, 2) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_pagos] PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permisos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Permiso] [varchar](50) NULL,
	[IdModulo] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[CodProducto] [varchar](25) NULL,
	[Producto] [varchar](30) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[IdCategoria] [int] NULL,
	[Imagen] [varbinary](max) NULL,
	[IdUbicacion] [int] NULL,
	[IdSeccion] [int] NULL,
	[IdLaboratorio] [int] NULL,
	[AplicaImpuesto] [varchar](10) NOT NULL,
	[Impuesto] [int] NULL,
	[Stock] [int] NULL,
	[Costo] [decimal](10, 2) NULL,
	[Precio] [decimal](10, 2) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
 CONSTRAINT [table_1_idproducto_primary] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](25) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolPermisos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolPermisos](
	[IdRolPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdPermisos] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_RolPermisos] PRIMARY KEY CLUSTERED 
(
	[IdRolPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[secciones]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[secciones](
	[IdSeccion] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombre] [varchar](20) NULL,
	[Descripcion] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](15) NULL,
 CONSTRAINT [PK_secciones] PRIMARY KEY CLUSTERED 
(
	[IdSeccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[suplidores]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suplidores](
	[IdSuplidor] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](40) NOT NULL,
	[ManejaComprobantes] [varchar](5) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_suplidores] PRIMARY KEY CLUSTERED 
(
	[IdSuplidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tiposcomprobantes]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tiposcomprobantes](
	[IdTipoComprobante] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[TipoComprobante] [varchar](40) NOT NULL,
	[Prefijo] [varchar](10) NULL,
	[CorreoLativo] [varchar](35) NOT NULL,
	[Desde] [varchar](35) NULL,
	[Hasta] [varchar](35) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_tiposcomprobantes] PRIMARY KEY CLUSTERED 
(
	[IdTipoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ubicaciones]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ubicaciones](
	[IdUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Ubicacion] [varchar](25) NULL,
	[Descripcion] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_ubicaciones] PRIMARY KEY CLUSTERED 
(
	[IdUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellidos] [varchar](30) NULL,
	[IdRol] [int] NOT NULL,
	[Imagen] [varchar](max) NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[IdEmpresa] [int] NULL,
	[IdTipoComprobante] [int] NULL,
	[NroComprobante] [varchar](70) NULL,
	[EstadoVenta] [varchar](25) NOT NULL,
	[MetodoPago] [varchar](25) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[TipoTarjeta] [varchar](30) NULL,
	[NroTarjeta] [varchar](90) NULL,
	[TarjetaHabiente] [varchar](40) NULL,
	[Efectivo] [decimal](10, 2) NULL,
	[MontoDebitado] [decimal](10, 2) NULL,
	[Transferencia] [decimal](10, 2) NULL,
	[Pago] [decimal](10, 2) NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[Debe] [decimal](10, 2) NOT NULL,
	[Devuelta] [decimal](10, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventasdetalles]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventasdetalles](
	[IdVentaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[CodProducto] [varchar](50) NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Impuesto] [int] NOT NULL,
	[Descuento] [int] NULL,
	[SubTotal] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[Estado] [varchar](20) NULL,
 CONSTRAINT [PK_ventasdetalles_1] PRIMARY KEY CLUSTERED 
(
	[IdVentaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[categorias] ADD  CONSTRAINT [DF_categorias_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF_clientes_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[compras] ADD  CONSTRAINT [DF_compra_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[comprasdetalles] ADD  CONSTRAINT [DF_comprasdetalles_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[estados] ADD  CONSTRAINT [DF_estados_Estadod]  DEFAULT ('Disponible') FOR [Estadod]
GO
ALTER TABLE [dbo].[laboratorios] ADD  CONSTRAINT [DF_laboratorios_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[modulos] ADD  CONSTRAINT [DF_modulos_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[pagos] ADD  CONSTRAINT [DF_pagos_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_Costo]  DEFAULT ((0.00)) FOR [Costo]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_Precio]  DEFAULT ((0.00)) FOR [Precio]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[RolPermisos] ADD  CONSTRAINT [DF_RolPermisos_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[secciones] ADD  CONSTRAINT [DF_secciones_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[suplidores] ADD  CONSTRAINT [DF_suplidores_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[tiposcomprobantes] ADD  CONSTRAINT [DF_tiposcomprobantes_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[ubicaciones] ADD  CONSTRAINT [DF_ubicaciones_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[usuarios] ADD  CONSTRAINT [DF_usuarios_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[ventas] ADD  CONSTRAINT [DF_ventas_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[ventasdetalles] ADD  CONSTRAINT [DF_ventasdetalles_Estado]  DEFAULT ('Disponible') FOR [Estado]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[empresa] ([IdEmpresa])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_empresa]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_suplidores] FOREIGN KEY([IdSuplidor])
REFERENCES [dbo].[suplidores] ([IdSuplidor])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_suplidores]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_usuarios]
GO
ALTER TABLE [dbo].[comprasdetalles]  WITH CHECK ADD  CONSTRAINT [FK_comprasdetalles_compras] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[compras] ([IdCompra])
GO
ALTER TABLE [dbo].[comprasdetalles] CHECK CONSTRAINT [FK_comprasdetalles_compras]
GO
ALTER TABLE [dbo].[comprasdetalles]  WITH CHECK ADD  CONSTRAINT [FK_comprasdetalles_productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[productos] ([IdProducto])
GO
ALTER TABLE [dbo].[comprasdetalles] CHECK CONSTRAINT [FK_comprasdetalles_productos]
GO
ALTER TABLE [dbo].[pagos]  WITH CHECK ADD  CONSTRAINT [FK_pagos_compras] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[compras] ([IdCompra])
GO
ALTER TABLE [dbo].[pagos] CHECK CONSTRAINT [FK_pagos_compras]
GO
ALTER TABLE [dbo].[pagos]  WITH CHECK ADD  CONSTRAINT [FK_pagos_ventas] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[pagos] CHECK CONSTRAINT [FK_pagos_ventas]
GO
ALTER TABLE [dbo].[permisos]  WITH CHECK ADD  CONSTRAINT [FK_permisos_modulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[modulos] ([IdModulo])
GO
ALTER TABLE [dbo].[permisos] CHECK CONSTRAINT [FK_permisos_modulos]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_categorias]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_secciones] FOREIGN KEY([IdSeccion])
REFERENCES [dbo].[secciones] ([IdSeccion])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_secciones]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_ubicaciones] FOREIGN KEY([IdUbicacion])
REFERENCES [dbo].[ubicaciones] ([IdUbicacion])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_ubicaciones]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_usuarios]
GO
ALTER TABLE [dbo].[RolPermisos]  WITH CHECK ADD  CONSTRAINT [FK_RolPermisos_permisos] FOREIGN KEY([IdPermisos])
REFERENCES [dbo].[permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[RolPermisos] CHECK CONSTRAINT [FK_RolPermisos_permisos]
GO
ALTER TABLE [dbo].[RolPermisos]  WITH CHECK ADD  CONSTRAINT [FK_RolPermisos_roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[roles] ([IdRol])
GO
ALTER TABLE [dbo].[RolPermisos] CHECK CONSTRAINT [FK_RolPermisos_roles]
GO
ALTER TABLE [dbo].[tiposcomprobantes]  WITH CHECK ADD  CONSTRAINT [FK_tiposcomprobantes_usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[tiposcomprobantes] CHECK CONSTRAINT [FK_tiposcomprobantes_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[roles] ([IdRol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_roles]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_clientes]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[empresa] ([IdEmpresa])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_empresa]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_tiposcomprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[tiposcomprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_tiposcomprobantes]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_usuarios]
GO
ALTER TABLE [dbo].[ventasdetalles]  WITH CHECK ADD  CONSTRAINT [FK_ventasdetalles_productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ventasdetalles] CHECK CONSTRAINT [FK_ventasdetalles_productos]
GO
ALTER TABLE [dbo].[ventasdetalles]  WITH CHECK ADD  CONSTRAINT [FK_ventasdetalles_ventas] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[ventas] ([IdVenta])
GO
ALTER TABLE [dbo].[ventasdetalles] CHECK CONSTRAINT [FK_ventasdetalles_ventas]
GO
/****** Object:  StoredProcedure [dbo].[categoriaporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoriaporId](
@IdCategoria int
)
as 
begin 

select * from categoria where IdCategoria = @IdCategoria and estado = 'Disponible'
end
GO
/****** Object:  StoredProcedure [dbo].[categoriasBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[categoriasBUSQUEDA](
@Busqueda varchar(100)
)
as 
begin 

select c.IdCategoria,
u.IdUsuario,
c.Categoria,
c.Descripcion,
c.FechaCreacion

from categorias as c
inner join 
usuarios as u on c.idusuario = u.IdUsuario
where c.Estado = 'Disponible' and 
(c.Categoria like + '%' + @Busqueda + '%' or
c.IdCategoria like + '%' + @Busqueda + '%' or
c.Descripcion like + '%' + @Busqueda + '%'
)

end
GO
/****** Object:  StoredProcedure [dbo].[categoriasCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[categoriasCRUD](
@IdCategoria int,
@Valor int,
@IdUsuario int,
@Categoria varchar (30),
@Descripcion varchar(25),
@fechaCreacion datetime,
@Mensaje varchar(120) output
)
as 
begin 

if (@Valor=1)
begin 

if not exists (select  1 from categorias where categoria = @Categoria and estado = 'Disponible') 
begin
insert into categorias (IdUsuario, Categoria, Descripcion, FechaCreacion)
VALUES (@IdUsuario, @Categoria,@Descripcion, GETDATE())

set @Mensaje = 'La categoria se registró correctamente.'

end

else
begin

set @Mensaje = 'La categoria que quiere registrar ya existe, verifique y vuelva a proceder.'
end
end

else if (@Valor=2)
begin 

update categorias 
set Categoria = @Categoria,
Descripcion = @Descripcion
where IdCategoria = @IdCategoria
set @Mensaje = 'La categoria se ha actualizado correctamente.'
end

else if (@Valor = 3)
Begin
update categorias set Estado = 'No disponible'
where idcategoria = @IdCategoria

set @Mensaje = 'La categoria se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[categoriasporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[categoriasporId](
@IdCategoria int
)
as 
begin 

select c.IdCategoria,
c.IdCategoria,
u.IdUsuario,
c.Categoria,
c.Descripcion,
c.FechaCreacion

from categorias as c
inner join 
usuarios as u on c.idusuario = u.IdUsuario
where c.idcategoria = @idcategoria and c.estado = 'Disponible'
end
GO
/****** Object:  StoredProcedure [dbo].[clientesBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[clientesBUSQUEDA](
@Busqueda varchar(100)
)
as 
begin 

select
c.IdCliente,
c.IdUsuario,
u.Nombre as Usuario,
c.Nombre,
c.Telefono,
c.Direccion,
c.FechaCreacion
from clientes as c

inner join 
usuarios as u on c.IdUsuario = u.IdUsuario

where c.Estado = 'Disponible' and 

(c.Nombre like + '%' + @Busqueda + '%' or 
c.IdCliente like + '%' + @Busqueda + '%' or 
u.Nombre like + '%' + @Busqueda + '%' or 
c.Telefono like + '%' + @Busqueda + '%' or
c.FechaCreacion like + '%' + @Busqueda + '%' or 
c.Direccion like + '%' + @Busqueda + '%'
)
end
GO
/****** Object:  StoredProcedure [dbo].[clientesCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[clientesCRUD](
@IdCliente int,
@Valor int,
@IdUsuario int,
@Nombre varchar (30),
@Telefono varchar(25),
@Direccion varchar(100),
@fechaCreacion datetime,
@Mensaje varchar(120) output
)
as 
begin 

if (@Valor=1)
begin 

if not exists (select  1 from clientes where Nombre = @Nombre) 
begin
insert into clientes (IdUsuario, Nombre, Telefono, Direccion, FechaCreacion)
VALUES (@IdUsuario, @Nombre,@Telefono,@Direccion, GETDATE())

set @Mensaje = 'El cliente se registró correctamente.'

end

else
begin

set @Mensaje = 'El cliente que quiere registrar ya existe, verifique y vuelva a proceder.'
end
end

else if (@Valor=2)
begin 

update clientes 
set nombre = @Nombre,
Telefono = @Telefono,
Direccion = @Direccion
where IdCliente = @IdCliente
set @Mensaje = 'El cliente se ha actualizado correctamente.'
end

else if (@Valor = 3)
Begin
update clientes set Estado = 'No disponible'
where IdCliente = @IdCliente

set @Mensaje = 'El cliente se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[clientesporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[clientesporId](
@IdCliente int
)
as
begin 

select 
c.IdCliente,
u.Usuario,
c.Nombre,
c.Telefono,
c.Direccion,
c.FechaCreacion

from clientes as c 
left join 
usuarios u on c.IdUsuario = u.idusuario
where c.IdCliente = @IdCliente and c.Estado = 'Disponible'
end
GO
/****** Object:  StoredProcedure [dbo].[compraCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado compraCRUD
CREATE PROCEDURE [dbo].[compraCRUD](
    @Valor INT,
    @IdCompra INT = NULL OUTPUT,
    @IdUsuario INT,
    @IdEmpresa INT,
    @IdSuplidor INT,
    @Descripcion VARCHAR(100),
    @AplicaImpuesto VARCHAR(10),
    @Impuesto INT,
    @NroComprobante VARCHAR(40),
    @MetodoPago VARCHAR(50),
    @TipoTarjeta VARCHAR(40),
    @Estado VARCHAR(30),
    @NroTarjeta VARCHAR(90),
    @TarjetaHabiente VARCHAR(40),
    @Efectivo DECIMAL(10, 2),
    @MontoDebitado DECIMAL(10, 2),
    @Transferencia DECIMAL(10, 2),
    @Total DECIMAL(10, 2),
    @Debe DECIMAL(10, 2),
    @Devuelta DECIMAL(10, 2),
    @Pago DECIMAL(10, 2),
    @vCompradetalles compradetalles READONLY,
    @Mensaje VARCHAR(40) OUTPUT
)
AS
BEGIN
    IF (@Valor = 1)
    BEGIN
        -- Inserción de la compra
        INSERT INTO compras (IdUsuario, IdEmpresa, IdSuplidor, NroComprobante, MetodoPago, TipoTarjeta, EstadoCompra, Descripcion, NroTarjeta, TarjetaHabiente, Efectivo, MontoDebitado, Transferencia, Total, Debe, Devuelta, Pago, FechaCreacion)
        VALUES (@IdUsuario, @IdEmpresa, @IdSuplidor, @NroComprobante, @MetodoPago, @TipoTarjeta, @Estado, @Descripcion, @NroTarjeta, @TarjetaHabiente, @Efectivo, @MontoDebitado, @Transferencia, @Total, @Debe, @Devuelta, @Pago, GETDATE());

        SET @IdCompra = SCOPE_IDENTITY();

        -- Inserción de los detalles de la compra
        INSERT INTO comprasdetalles (IdCompra, IdProducto, CodProducto, Impuesto, Cantidad, Costo, Precio, SubTotal, Total)
        SELECT @IdCompra, IdProducto, CodProducto, Impuesto, Cantidad, Costo, Precio, SubTotal, Total FROM @vCompradetalles;

        -- Actualización del stock del producto
        UPDATE p
        SET 
            p.Stock = p.Stock + cd.Cantidad,
            p.AplicaImpuesto = @AplicaImpuesto,
            p.Impuesto = @Impuesto,
            p.Costo = cd.Costo,
            p.Precio = cd.Precio
        FROM productos AS p
        INNER JOIN @vCompradetalles AS cd ON p.IdProducto = cd.IdProducto;

        SET @Mensaje = 'La compra se realizó correctamente';
    END
    ELSE IF (@Valor = 2)
    BEGIN
       -- Actualizar la cabecera de la compra
UPDATE compras
SET 
    IdSuplidor = @IdSuplidor,
    IdUsuario = @IdUsuario,
    NroComprobante = @NroComprobante,
    MetodoPago = @MetodoPago,
    TipoTarjeta = @TipoTarjeta,
    EstadoCompra = @Estado,
    Descripcion = @Descripcion,
    NroTarjeta = @NroTarjeta,
    TarjetaHabiente = @TarjetaHabiente,
    Efectivo = @Efectivo,
    MontoDebitado = @MontoDebitado,
    Transferencia = @Transferencia,
    Debe = @Debe,
    Devuelta = @Devuelta,
    Pago = @Pago,
    Total = @Total,
    FechaCreacion = GETDATE()
WHERE IdCompra = @IdCompra;

-- Crear tabla temporal para productos originales
CREATE TABLE #OriginalDetalles (
    IdProducto INT, 
    Cantidad INT, 
    Impuesto INT, 
    CodProducto INT, 
    SubTotal DECIMAL(10, 2), 
    Total DECIMAL(10, 2)
);

-- Insertar productos originales asegurando que Cantidad e Impuesto estén en sus campos correctos
INSERT INTO #OriginalDetalles (IdProducto, Cantidad, Impuesto, CodProducto, SubTotal, Total)
SELECT IdProducto, Cantidad, Impuesto, CodProducto, SubTotal, Total 
FROM comprasdetalles 
WHERE IdCompra = @IdCompra;

-- Restablecer el stock restando las cantidades originales
UPDATE p
SET 
    p.Stock = p.Stock - od.Cantidad
FROM productos p
INNER JOIN #OriginalDetalles od 
ON p.IdProducto = od.IdProducto;

-- Eliminar los detalles antiguos
DELETE FROM comprasdetalles 
WHERE IdCompra = @IdCompra;

-- Insertar los nuevos detalles de la compra asegurando que cada campo esté en la posición correcta
INSERT INTO comprasdetalles (IdCompra, IdProducto, CodProducto, Impuesto, Cantidad, Costo, Precio, SubTotal, Total)
SELECT @IdCompra, IdProducto, CodProducto, Impuesto, Cantidad, Costo, Precio, SubTotal, Total 
FROM @vCompradetalles;

-- Ajustar el stock sumando las nuevas cantidades
UPDATE p
SET 
    p.Stock = p.Stock + nd.Cantidad
FROM productos p
INNER JOIN @vCompradetalles nd 
ON p.IdProducto = nd.IdProducto;

-- Eliminar la tabla temporal
DROP TABLE #OriginalDetalles;

SET @Mensaje = 'La compra se actualizó correctamente';

end
    ELSE IF (@Valor = 3)
    BEGIN
        -- Ajuste de stock y eliminación
        UPDATE p
        SET 
            p.Stock = p.Stock - cd.Cantidad
        FROM productos AS p
        INNER JOIN comprasdetalles AS cd ON p.IdProducto = cd.IdProducto
        WHERE cd.IdCompra = @IdCompra;

        UPDATE compras SET Estado = 'No disponible' WHERE IdCompra = @IdCompra;
        UPDATE comprasdetalles SET Estado = 'No disponible' WHERE IdCompra = @IdCompra;

        SET @Mensaje = 'La compra se eliminó correctamente';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[compraCuadreDelDia]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[compraCuadreDelDia]
as 
begin

SELECT 
    CONVERT(DATE, FechaCreacion) AS Fecha, -- Fecha del cuadre
    SUM(Efectivo) AS TotalEfectivo,
    SUM(MontoDebitado) AS TotalTarjeta,
    SUM(Transferencia) AS TotalTransferencias,
    SUM(Pago) AS TotalPagado,
    SUM(Total) AS TotalCompras,
    SUM(Debe) AS TotalPendiente,
    SUM(Devuelta) AS TotalDevuelto
FROM compras
WHERE CONVERT(DATE, FechaCreacion) = CONVERT(DATE, GETDATE()) -- Filtrar por el día actual
GROUP BY CONVERT(DATE, FechaCreacion);
end
GO
/****** Object:  StoredProcedure [dbo].[comprasBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[comprasBUSQUEDA](
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SELECT
        c.IdCompra,
        c.IdUsuario,
        usr.Usuario,
        c.IdSuplidor,
        supl.Nombre AS NombreSuplidor,
        c.IdEmpresa,
        c.NroComprobante,
        c.MetodoPago,
        c.TipoTarjeta,
		c.EstadoCompra,
        c.Descripcion,
        c.NroTarjeta,
        c.TarjetaHabiente,
        c.Efectivo,
        c.MontoDebitado,
        c.Transferencia,
        c.Pago,
        c.Total,
        c.Debe,
        c.Devuelta,
        c.FechaCreacion
    FROM compras AS c
    LEFT JOIN usuarios AS usr ON c.IdUsuario = usr.IdUsuario
    LEFT JOIN suplidores AS supl ON c.IdSuplidor = supl.IdSuplidor
    WHERE c.Estado = 'Disponible'
      AND (
            c.NroComprobante LIKE '%' + @Busqueda + '%' OR
            c.Descripcion LIKE '%' + @Busqueda + '%' OR
            c.MetodoPago LIKE '%' + @Busqueda + '%' OR
            c.TipoTarjeta LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, c.FechaCreacion, 120) LIKE '%' + @Busqueda + '%' OR
            usr.Usuario LIKE '%' + @Busqueda + '%' OR
            supl.Nombre LIKE '%' + @Busqueda + '%' OR
            c.EstadoCompra LIKE '%' + @Busqueda + '%'
      )
END
GO
/****** Object:  StoredProcedure [dbo].[comprasdetallesporIdCompra]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[comprasdetallesporIdCompra](
@IdCompra int
)
as
begin 

select 
    cd.IdCompraDetalles,
	cd.IdProducto,
    cd.CodProducto,
    p.Producto,
    cd.Impuesto,
    cd.Cantidad,
    cd.Costo,
    cd.Precio,
    cd.SubTotal,
    cd.Total
from comprasdetalles as cd
left join
productos as p on p.IdProducto = cd.IdProducto
where cd.IdCompra = @IdCompra and cd.Estado = 'Disponible'

end
GO
/****** Object:  StoredProcedure [dbo].[comprasporfecha]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[comprasporfecha](
@Busqueda varchar (100) = '',
@Desde date,
@Hasta date
)
as 
begin 

  SELECT
        c.IdCompra,
        c.IdUsuario,
        usr.Usuario,
        c.IdSuplidor,
        supl.Nombre AS NombreSuplidor,
        c.IdEmpresa,
        c.NroComprobante,
        c.MetodoPago,
        c.TipoTarjeta,
		c.EstadoCompra,
        c.Descripcion,
        c.NroTarjeta,
        c.TarjetaHabiente,
        c.Efectivo,
        c.MontoDebitado,
        c.Transferencia,
        c.Pago,
        c.Total,
        c.Debe,
        c.Devuelta,
        c.FechaCreacion
    FROM compras AS c
    LEFT JOIN usuarios AS usr ON c.IdUsuario = usr.IdUsuario
    LEFT JOIN suplidores AS supl ON c.IdSuplidor = supl.IdSuplidor
    WHERE c.Estado = 'Disponible' and c.FechaCreacion between @Desde and @Hasta 
      AND (
            c.NroComprobante LIKE '%' + @Busqueda + '%' OR
            c.Descripcion LIKE '%' + @Busqueda + '%' OR
            c.MetodoPago LIKE '%' + @Busqueda + '%' OR
            c.TipoTarjeta LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, c.FechaCreacion, 120) LIKE '%' + @Busqueda + '%' OR
            usr.Usuario LIKE '%' + @Busqueda + '%' OR
            supl.Nombre LIKE '%' + @Busqueda + '%' OR
            c.EstadoCompra LIKE '%' + @Busqueda + '%')
		end
GO
/****** Object:  StoredProcedure [dbo].[comprasporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[comprasporId](
@IdCompra int
)
as
begin 

select 
    c.IdCompra,
    u.Usuario,
    c.IdSuplidor,
	s.Nombre,
    c.NroComprobante,
    c.MetodoPago,
    c.TipoTarjeta,
    c.EstadoCompra,
    c.Descripcion,
    c.NroTarjeta,
    c.TarjetaHabiente,
    c.Efectivo,
    c.MontoDebitado,
    c.Transferencia,
    c.Pago,
    c.Total,
    c.Debe,
    c.Devuelta,
    c.FechaCreacion,
    c.Estado
from compras as c 
left join 
suplidores as s on s.IdSuplidor = c.IdSuplidor
left join 
usuarios as u on u.IdUsuario = c.IdUsuario
where c.IdCompra = @IdCompra and c.Estado = 'Disponible'

end
GO
/****** Object:  StoredProcedure [dbo].[ComprasTotal]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ComprasTotal]
@valor int

as 
begin

if (@valor =1)
begin
select Replace(Format(sum(Total), 'N2'), '.', ',') as Total from compras
end
else if (@valor = 2)
begin 
SELECT REPLACE(FORMAT(SUM(Total), 'N2'), '.', ',') AS Total
FROM compras
WHERE CAST(FechaCreacion AS DATE) = CAST(GETDATE() AS DATE);

end
end
GO
/****** Object:  StoredProcedure [dbo].[empresaBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[empresaBUSQUEDA]    Script Date: 11/11/2024 19:06:52 ******/
create proc [dbo].[empresaBUSQUEDA]
(

@Busqueda varchar(100)

)
as
begin 

select
e.IdEmpresa,
e.IdUsuario,
u.Usuario,
e.Nombre,
e.Telefono,
e.RNC,
e.Direccion,
e.FechaCreacion,
e.FechaCreacion
from empresa as e

inner join 
usuarios as u on e.IdUsuario = u.IdUsuario

where e.Estado = 'Disponible' and 

(e.IdEmpresa like + '%' + @Busqueda + '%' or 
e.Nombre like + '%' + @Busqueda + '%' or 
e.Telefono like + '%' + @Busqueda + '%' or 
e.RNC like + '%' + @Busqueda + '%' or 
e.FechaCreacion like + '%' + @Busqueda + '%'
)
end
GO
/****** Object:  StoredProcedure [dbo].[empresaCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[empresaCRUD](
@IdEmpresa int,
@Valor int,
@IdUsuario int,
@Nombre varchar (70),
@Telefono varchar(25),
@Direccion varchar(100),
@RNC varchar(60),
@fechaCreacion datetime,
@Mensaje varchar(120) output
)

as 
begin 

if (@Valor=1)
begin 

if not exists (select  1 from empresa where nombre = @Nombre and estado = 'Disponible') 
begin
insert into empresa (IdUsuario, Nombre, telefono,RNC, direccion, FechaCreacion)
VALUES (@IdUsuario, @Nombre,@Telefono,@RNC, @Direccion,GETDATE())

set @Mensaje = 'La empresa se registró correctamente.'
end
else
begin

set @Mensaje = 'La empresa que quiere registrar ya existe, verifique y vuelva a proceder.'
end
end


else if (@Valor=2)
begin 

update empresa 
set Nombre = @Nombre,
Telefono = @Telefono,
rnc = @rnc,
direccion = @Direccion
where IdEmpresa = @IdEmpresa
set @Mensaje = 'La empresa se ha actualizado correctamente.'
end

else if (@Valor = 3)
Begin
update empresa set Estado = 'No disponible'
where idempresa = @IdEmpresa

set @Mensaje = 'La empresa se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[empresaporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[empresaporId](
@IdEmpresa int
)
as
begin 

select
e.IdEmpresa,
e.IdUsuario,
u.Usuario,
e.Nombre,
e.Telefono,
e.RNC,
e.Direccion,
e.FechaCreacion,
e.FechaCreacion
from empresa as e

inner join 
usuarios as u on e.IdUsuario = u.IdUsuario

where e.Estado = 'Disponible' and e.IdEmpresa = @IdEmpresa


end
GO
/****** Object:  StoredProcedure [dbo].[inventariolistar]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[inventariolistar](
@Busqueda varchar(100)
)
as 
begin


select p.CodProducto, p.Producto, c.Categoria,u.Ubicacion, s.Nombre, p.Stock as Existencia
from productos as p 
left join
ubicaciones as u on p.IdUbicacion = u.IdUbicacion
left join 
secciones as s on p.IdSeccion = s.IdSeccion
left join 
categorias as c on p.IdCategoria = c.IdCategoria
where p.Estado = 'Disponible' and 
    (
            p.Producto LIKE '%' + @Busqueda + '%' OR 
            p.CodProducto LIKE '%' + @Busqueda + '%' OR 
            p.Descripcion LIKE '%' + @Busqueda + '%' OR
            u.Ubicacion LIKE '%' + @Busqueda + '%' OR
			s.Nombre LIKE '%' + @Busqueda + '%' OR
			c.Categoria LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, p.FechaCreacion, 120) LIKE '%' + @Busqueda + '%'
      )

end
GO
/****** Object:  StoredProcedure [dbo].[inventarioproductos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[inventarioproductos]
(
@Busqueda varchar(100)
)
as
begin

select
p.IdProducto,
p.CodProducto,
p.Producto,
c.Categoria,
p.Descripcion,
u.Ubicacion,
s.Nombre as Seccion,
p.Precio,
p.Stock
from productos as p
left join
ubicaciones as u on u.IdUbicacion = p.IdUbicacion
left join
secciones as s on s.IdSeccion = p.IdSeccion
left join
categorias as c on c.IdCategoria = p.IdCategoria
    WHERE p.Estado = 'Disponible'
      AND (
            p.Producto LIKE '%' + @Busqueda + '%' OR 
            p.CodProducto LIKE '%' + @Busqueda + '%' OR 
			c.Categoria LIKE '%' + @Busqueda + '%' OR 
            p.Descripcion LIKE '%' + @Busqueda + '%' OR
            u.Ubicacion LIKE '%' + @Busqueda + '%' OR
			s.Nombre LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, p.FechaCreacion, 120) LIKE '%' + @Busqueda + '%'
      )




end
GO
/****** Object:  StoredProcedure [dbo].[laboratorioporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[laboratorioporId]
(
    @IdLaboratorio INT
)
AS
BEGIN
    SELECT
        l.IdLaboratorio,
        l.Nombre,
        l.Telefono,
        l.Direccion,
        l.Email,
        l.FechaCreacion
    FROM laboratorios AS l
    WHERE l.Estado = 'Disponible' 
      AND l.IdLaboratorio = @IdLaboratorio
END
GO
/****** Object:  StoredProcedure [dbo].[laboratoriosBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[laboratoriosBUSQUEDA](
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SELECT
        l.IdLaboratorio,
        l.Nombre,
		u.IdUsuario,
		u.Usuario,
        l.Telefono,
        l.Direccion,
        l.Email,
        l.FechaCreacion
    FROM laboratorios AS l
	left join 
	usuarios as u on u.IdUsuario = l.idusuario
    WHERE l.Estado = 'Disponible' 
      AND (
            l.Nombre LIKE '%' + @Busqueda + '%' OR 
            l.IdLaboratorio LIKE '%' + @Busqueda + '%' OR 
            l.Telefono LIKE '%' + @Busqueda + '%' OR
            l.Email LIKE '%' + @Busqueda + '%' OR
            l.Direccion LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, l.FechaCreacion, 120) LIKE '%' + @Busqueda + '%'
      )
END
GO
/****** Object:  StoredProcedure [dbo].[laboratoriosCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[laboratoriosCRUD]
(
    @Valor INT,
    @IdLaboratorio INT = NULL,
	@IdUsuario int,
    @Nombre VARCHAR(50),
    @Telefono VARCHAR(20),
    @Direccion VARCHAR(100),
    @Email VARCHAR(50),
    @Mensaje VARCHAR(120) OUTPUT
)
AS
BEGIN
    IF (@Valor = 1) 
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM laboratorios WHERE Nombre = @Nombre and estado = 'Disponible')
        BEGIN
            INSERT INTO laboratorios (idusuario,Nombre,Telefono, Direccion, Email, FechaCreacion)
            VALUES (@IdUsuario,@Nombre, @Telefono, @Direccion, @Email, GETDATE())

            SET @Mensaje = 'El laboratorio se ha registrado correctamente.'
        END
        ELSE
        BEGIN
            SET @Mensaje = 'El laboratorio que quiere registrar ya existe, coloque otro nombre y vuelva a intentar.'
        END
    END
    ELSE IF (@Valor = 2) 
    BEGIN
        UPDATE laboratorios
        SET Nombre = @Nombre,
            Telefono = @Telefono,
            Direccion = @Direccion,
            Email = @Email
        WHERE IdLaboratorio = @IdLaboratorio

        SET @Mensaje = 'El laboratorio se ha actualizado correctamente.'
    END
    ELSE IF (@Valor = 3)  
    BEGIN
        UPDATE laboratorios
        SET Estado = 'No disponible'
        WHERE IdLaboratorio = @IdLaboratorio

        SET @Mensaje = 'El laboratorio se ha eliminado correctamente'
    END

END
GO
/****** Object:  StoredProcedure [dbo].[pagoagregarCompra]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pagoagregarCompra](
@IdPago int,
@Valor int,
@IdUsuario int,
@IdVenta int,
@IdCompra int,
@Debe decimal (10,2),
@MetodoPago varchar(30),
@TipoTarjeta varchar(40),
@Descripcion varchar(100),
@NroTarjeta varchar(40),
@TarjetaHabiente varchar(40),
@Efectivo decimal(10,2),
@MontoDebitado decimal(10,2),
@Transferencia decimal(10,2),
@Pago decimal(10,2),
@EstadoCompra varchar(30),
@Mensaje varchar(120) output
)
as 
begin 

if (@Valor=1)
begin 
insert into pagos (IdUsuario, IdVenta, IdCompra,MetodoPago, TipoTarjeta,Descripcion,NroTarjeta,
TarjetaHabiente, Efectivo, MontoDebitado, Transferencia, Pago, FechaCreacion)
VALUES (@IdUsuario, @IdVenta, @IdCompra, @MetodoPago, @TipoTarjeta, @Descripcion,@NroTarjeta,
@TarjetaHabiente, @Efectivo, @MontoDebitado, @Transferencia, @Pago, GETDATE())

update compras set
Efectivo = @Efectivo,
MontoDebitado = @MontoDebitado,
EstadoCompra = @EstadoCompra,
Transferencia = @Transferencia,
Pago = @Pago,
Debe = @Debe
where IdCompra = @IdCompra


set @Mensaje = 'El pago se registró correctamente.'
end
else if (@Valor=2)
begin 

update pagos 
set MetodoPago = @MetodoPago,
TipoTarjeta = @TipoTarjeta,
Descripcion = @Descripcion,
NroTarjeta = @NroTarjeta,
TarjetaHabiente = @TarjetaHabiente,
Efectivo += @Efectivo,
MontoDebitado += @MontoDebitado,
Transferencia += @Transferencia,
Pago += @Pago,
FechaCreacion = GETDATE()
where IdCompra = @IdCompra
set @Mensaje = 'El pago se ha actualizado correctamente.'
end

else if (@Valor = 3)
Begin
update pagos set Estado = 'No disponible'
where IdCompra = @IdCompra

set @Mensaje = 'El pago se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[pagoagregarVenta]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pagoagregarVenta](
@IdPago int,
@Valor int,
@IdUsuario int,
@IdVenta int,
@Debe decimal (10,2),
@MetodoPago varchar(30),
@TipoTarjeta varchar(40),
@Descripcion varchar(100),
@NroTarjeta varchar(40),
@TarjetaHabiente varchar(40),
@Efectivo decimal(10,2),
@MontoDebitado decimal(10,2),
@Transferencia decimal(10,2),
@Pago decimal(10,2),
@EstadoVenta varchar(30),
@Mensaje varchar(120) output
)
as 
begin 

if (@Valor=1)
begin 
insert into pagos (IdUsuario, IdVenta, MetodoPago, TipoTarjeta,Descripcion,NroTarjeta,
TarjetaHabiente, Efectivo, MontoDebitado, Transferencia, Pago, FechaCreacion)
VALUES (@IdUsuario, @IdVenta, @MetodoPago, @TipoTarjeta, @Descripcion,@NroTarjeta,
@TarjetaHabiente, @Efectivo, @MontoDebitado, @Transferencia, @Pago, GETDATE())

update ventas set
Efectivo = @Efectivo,
MontoDebitado = @MontoDebitado,
EstadoVenta = @EstadoVenta,
Transferencia = @Transferencia,
Pago = @Pago,
Debe = @Debe
where IdVenta = @IdVenta


set @Mensaje = 'El pago se registró correctamente.'
end
else if (@Valor=2)
begin 

update pagos 
set MetodoPago = @MetodoPago,
TipoTarjeta = @TipoTarjeta,
Descripcion = @Descripcion,
NroTarjeta = @NroTarjeta,
TarjetaHabiente = @TarjetaHabiente,
Efectivo += @Efectivo,
MontoDebitado += @MontoDebitado,
Transferencia += @Transferencia,
Pago += @Pago,
FechaCreacion = GETDATE()
where IdVenta = @IdVenta
set @Mensaje = 'El pago se ha actualizado correctamente.'
end

else if (@Valor = 3)
Begin
update pagos set Estado = 'No disponible'
where IdVenta = @IdVenta

set @Mensaje = 'El pago se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[productoEliminadoDeLaCompraDisminuyeStock]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[productoEliminadoDeLaCompraDisminuyeStock](
@IdCompra int,
@IdProducto int,
@Cantidad int,
@Mensaje varchar(120) output
)
as 
begin 


update p set p.Stock = Stock - @Cantidad
from productos as p
where IdProducto = @IdProducto
set @Mensaje = 'El producto ha disminuido su stock'
end 

GO
/****** Object:  StoredProcedure [dbo].[productoEliminadoDeLaVentaAumentaStock]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[productoEliminadoDeLaVentaAumentaStock](
@IdProducto int,
@Cantidad int,
@Mensaje varchar(120) output
)
as 
begin 


update p set p.Stock = Stock + @Cantidad
from productos as p
where IdProducto = @IdProducto
set @Mensaje = 'El producto aumentó su stock'
end 

GO
/****** Object:  StoredProcedure [dbo].[productosalertastock]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[productosalertastock]
as 
begin
 SELECT
        p.IdProducto,
        p.CodProducto,
		p.Stock
		from productos as p
		where p.Stock <=5
end
GO
/****** Object:  StoredProcedure [dbo].[productosBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productosBUSQUEDA]
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SELECT
        p.IdProducto,
		u.IdUsuario,
        p.CodProducto,
        p.Producto,
        p.Descripcion,
        c.Categoria,
		p.IdCategoria,
		p.IdUbicacion,
        ubi.Ubicacion,
		p.IdSeccion,
        s.Nombre as Seccion,
		p.Imagen,
        p.AplicaImpuesto,
        p.Impuesto,
		p.Stock,
        p.Costo,
        p.Precio,
        p.FechaCreacion,
        p.Estado,
        u.Usuario
    FROM productos AS p
    LEFT JOIN usuarios AS u ON u.IdUsuario = p.IdUsuario
	 LEFT JOIN secciones AS s ON s.idseccion = p.idseccion
	 LEFT JOIN categorias AS c ON c.idcategoria = p.idcategoria
	 	 LEFT JOIN ubicaciones AS ubi ON ubi.IdUbicacion = p.IdUbicacion
    WHERE p.Estado = 'Disponible'
      AND (
            p.Producto LIKE '%' + @Busqueda + '%' OR 
            p.CodProducto LIKE '%' + @Busqueda + '%' OR 
            p.Descripcion LIKE '%' + @Busqueda + '%' OR
            ubi.Ubicacion LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, p.FechaCreacion, 120) LIKE '%' + @Busqueda + '%'
      )
END

GO
/****** Object:  StoredProcedure [dbo].[productosCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productosCRUD]
(
    @Valor INT,
    @IdProducto INT,
    @IdUsuario INT,
    @CodProducto VARCHAR(25),
    @Producto VARCHAR(30),
    @Descripcion VARCHAR(100),
    @IdCategoria INT,
    @Imagen VARBINARY(MAX)= null,
    @Ubicacion VARCHAR(20),
    @IdSeccion INT,
    @AplicaImpuesto VARCHAR(10),
    @Impuesto INT,
    @Stock INT,
    @Costo DECIMAL(10, 2),
    @Precio DECIMAL(10, 2),
    @Mensaje VARCHAR(120) OUTPUT
)
AS
BEGIN
    IF (@Valor = 1) 
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM productos WHERE CodProducto = @CodProducto and Producto = @Producto and Estado = 'disponible')
        BEGIN
            INSERT INTO productos (IdUsuario, CodProducto, Producto, Descripcion, IdCategoria, Imagen, IdUbicacion, IdSeccion ,AplicaImpuesto, Impuesto, Stock, Costo, Precio, FechaCreacion)
            VALUES (@IdUsuario, @CodProducto, @Producto, @Descripcion, @IdCategoria, @Imagen, @Ubicacion, @IdSeccion ,@AplicaImpuesto, @Impuesto, @Stock, @Costo, @Precio, GETDATE())

            SET @Mensaje = 'El producto se ha registrado correctamente.'
        END
        ELSE
        BEGIN
            SET @Mensaje = 'El código de producto ya existe. Por favor, utilice otro.'
        END
    END
    ELSE IF (@Valor = 2) 

        BEGIN
        UPDATE productos
        SET IdUsuario = @IdUsuario,
            CodProducto = @CodProducto,
            Producto = @Producto,
            Descripcion = @Descripcion,
            IdCategoria = @IdCategoria,
            Imagen = @Imagen,
            IdUbicacion = @Ubicacion,
            IdSeccion = @IdSeccion,
            AplicaImpuesto = @AplicaImpuesto,
            Impuesto = @Impuesto,
			Stock = @Stock,
            Costo = @Costo,
            Precio = @Precio
        WHERE IdProducto = @IdProducto

        SET @Mensaje = 'El producto se ha actualizado correctamente.'
    END
    ELSE IF (@Valor = 3)
    BEGIN
        UPDATE productos
        SET Estado = 'No disponible'
        WHERE IdProducto = @IdProducto

        SET @Mensaje = 'El producto se ha eliminado correctamente.'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[productosporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productosporId]
(
    @IdProducto INT
)
AS
BEGIN 
SELECT
        p.IdProducto,
		u.IdUsuario,
        p.CodProducto,
        p.Producto,
        p.Descripcion,
        c.Categoria,
		p.IdCategoria,
		p.IdUbicacion,
        ubi.Ubicacion,
		p.IdSeccion,
        s.Nombre as Seccion,
        p.AplicaImpuesto,
        p.Impuesto,
        p.Stock,
        p.Costo,
        p.Precio,
		p.Imagen,
        p.FechaCreacion,
        p.Estado,
        u.Usuario
    FROM productos AS p
    LEFT JOIN usuarios AS u ON u.IdUsuario = p.IdUsuario
	 LEFT JOIN secciones AS s ON s.idseccion = p.idseccion
	 LEFT JOIN categorias AS c ON c.idcategoria = p.idcategoria
	 	 LEFT JOIN ubicaciones AS ubi ON ubi.IdUbicacion = p.IdUbicacion
    WHERE p.IdProducto = @IdProducto AND p.Estado = 'Disponible'
END
GO
/****** Object:  StoredProcedure [dbo].[rolesBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[rolesBUSQUEDA]
(
@Busqueda varchar(100)
)
as 
begin 

SELECT  roles.IdRol, roles.Rol, Roles.Descripcion, roles.FechaCreacion
FROM    roles


where roles.estado = 'Disponible'and
(roles.IdRol like + '%' + @Busqueda + '%' or 
roles.Rol like + '%' + @Busqueda + '%'or
roles.Descripcion like + '%' + @Busqueda + '%'or
roles.FechaCreacion like + '%' + @Busqueda + '%')

end
GO
/****** Object:  StoredProcedure [dbo].[rolesCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[rolesCRUD](
@Valor int,
@IdRol int,
@Rol varchar(25),
@Descripcion varchar(100)= '',
@Mensaje varchar(40) output
)
as 
begin 

if (@Valor = 1)
begin 

if not exists (select 1 from roles where Rol = @Rol)
begin
insert into roles ( Rol, Descripcion, FechaCreacion)
VALUES ( @Rol, @Descripcion,GETDATE())

set @Mensaje = 'El rol se ha registrado correctamente.'
end

else 

begin 

set @Mensaje = 'El rol que intentó registrar ya existe,  verifique otro nombre y vuelva a registrar.'
end
end
else if (@Valor = 2)
begin

update roles set rol = @rol,
descripcion = @Descripcion

set @Mensaje = 'El rol se ha actualizado correctamente'
end
else if (@Valor = 3)
begin
update roles set estado = 'No disponible'
end
end
GO
/****** Object:  StoredProcedure [dbo].[seccionesBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[seccionesBUSQUEDA]
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SELECT
        s.IdSeccion,
		s.IdUsuario,
		s.Nombre,
        u.Usuario,
        s.Descripcion,
        s.FechaCreacion
    FROM secciones AS s
	left join
	usuarios as u on u.IdUsuario = s.IdUsuario
    WHERE s.Estado = 'Disponible'
      AND (
            s.Nombre LIKE '%' + @Busqueda + '%' OR 
            CONVERT(VARCHAR, s.IdSeccion) LIKE '%' + @Busqueda + '%' OR 
            s.Descripcion LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, s.FechaCreacion, 120) LIKE '%' + @Busqueda + '%'
      )
END
GO
/****** Object:  StoredProcedure [dbo].[seccionesCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[seccionesCRUD]
(
    @Valor INT,
	@IdUsuario int,
    @IdSeccion INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100),
    @Mensaje VARCHAR(120) OUTPUT
)
AS
BEGIN
    IF @Valor = 1
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM secciones WHERE Nombre = @Nombre and estado = 'Disponible')
        BEGIN
            INSERT INTO secciones (IdUsuario,Nombre, Descripcion, FechaCreacion)
            VALUES (@IdUsuario,@Nombre, @Descripcion, GETDATE())

            SET @Mensaje = 'La sección se ha registrado correctamente.'
        END
        ELSE
        BEGIN
            SET @Mensaje = 'La sección ya existe. Intente con un nombre diferente.'
        END
    END

    ELSE IF @Valor = 2
    BEGIN
	  IF NOT EXISTS (SELECT 1 FROM secciones WHERE Nombre = @Nombre and estado = 'Disponible')
        BEGIN
        UPDATE secciones
        SET Nombre = @Nombre,
            Descripcion = @Descripcion
        WHERE IdSeccion = @IdSeccion

        SET @Mensaje = 'La sección se ha actualizado correctamente.'
    END
	 ELSE
        BEGIN
            SET @Mensaje = 'La sección ya existe. Intente con un nombre diferente.'
        END
		end

    ELSE IF @Valor = 3
    BEGIN
        UPDATE secciones
        SET Estado = 'No disponible'
        WHERE IdSeccion = @IdSeccion

        SET @Mensaje = 'La sección se ha eliminado correctamente.'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[seccionesPorId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[seccionesPorId]
(
    @IdSeccion int
)
AS
BEGIN
    SELECT
        s.IdSeccion,
        s.IdUsuario,
        usr.Usuario,
        s.Nombre,
        s.Descripcion,
        s.FechaCreacion,
        s.Estado
    FROM secciones AS s
    INNER JOIN usuarios AS usr ON s.IdUsuario = usr.IdUsuario
    WHERE s.Estado = 'Disponible' AND s.IdSeccion = @IdSeccion
END
GO
/****** Object:  StoredProcedure [dbo].[suplidoresBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[suplidoresBUSQUEDA](
@Busqueda varchar(100)
)
as 
begin 

select
s.IdSuplidor,
s.IdUsuario,
u.Usuario,
s.Nombre,
s.Direccion,
s.Telefono,
s.ManejaComprobantes,
s.FechaCreacion
from suplidores as s

inner join 
usuarios as u on s.idusuario = u.idusuario

where s.Estado = 'Disponible' and 

(s.Nombre like + '%' + @Busqueda + '%' or 
s.IdSuplidor like + '%' + @Busqueda + '%' or 
u.Nombre like + '%' + @Busqueda + '%' or 
s.Direccion like + '%' + @Busqueda + '%' or
s.Telefono like + '%' + @Busqueda + '%' or
s.FechaCreacion like + '%' + @Busqueda + '%')
end
GO
/****** Object:  StoredProcedure [dbo].[suplidoresCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[suplidoresCRUD](
@Valor int,
@IdSuplidor int,
@IdUsuario int,
@Nombre varchar(30),
@Direccion varchar(100),
@Telefono varchar(25),
@ManejaComprobante varchar(5),
@FechaCreacion datetime,
@Mensaje varchar(120) output
)
as
begin 

if (@Valor = 1)
begin 


if not exists (select 1 from suplidores where Nombre = @Nombre)
begin
insert into suplidores(IdUsuario,Nombre, Direccion, Telefono, ManejaComprobantes,FechaCreacion)

VALUES (@IdUsuario,@Nombre, @Direccion,@Telefono, @ManejaComprobante,GETDATE())

set @Mensaje = 'El suplidor se ha registrado correctamente.'

end

else

begin 

set @Mensaje = 'El suplidor que ha intentado registrar ya existe, verifique otro nombre y vuelva a registrar.'

end
end

else if (@Valor =2)

begin

update suplidores set Nombre = @Nombre,
Direccion = @Direccion,
Telefono = @Telefono,
ManejaComprobantes = @ManejaComprobante
where IdSuplidor = @IdSuplidor

set @Mensaje = 'El suplidor se ha Actualizado correctamente.'
end
else if (@Valor=3)
begin 
update suplidores set estado = 'No disponible'
where IdSuplidor = @IdSuplidor
set @Mensaje = 'El suplidor se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[suplidoresporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[suplidoresporId]
(
@IdSuplidor int
)
as 
begin 
select
s.IdSuplidor,
s.IdUsuario,
u.Usuario,
s.Nombre,
s.Direccion,
s.Telefono,
s.ManejaComprobantes,
s.FechaCreacion

from suplidores as s

inner join 
usuarios as u on s.IdUsuario = u.IdUsuario

where s.Estado = 'Disponible'
end
GO
/****** Object:  StoredProcedure [dbo].[TipoComprobante]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TipoComprobante]
    @campo INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Selecciona el valor actual del correolativo
        SELECT Correolativo,
		Desde, Hasta
        FROM tiposcomprobantes 
        WHERE idtipocomprobante = @campo;

        -- Incrementa el valor del correolativo
        UPDATE tiposcomprobantes
        SET Correolativo = Correolativo + 1
        WHERE idtipocomprobante = @campo;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[tipocomprobanteporid]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[tipocomprobanteporid](
@IdTipoComprobante int
)

as 
begin

select * from tiposcomprobantes where IdTipoComprobante = @IdTipoComprobante

end
GO
/****** Object:  StoredProcedure [dbo].[tiposcomprobantesBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[tiposcomprobantesBUSQUEDA]
(
@Busqueda varchar(100)
)
as 
begin 

select
t.IdTipoComprobante,
u.Nombre,
t.TipoComprobante,
t.NroComprobante,
t.Desde,
t.Hasta,
t.FechaCreacion
from tiposcomprobantes as t


left join
usuario as u on r.idusuario = r.IdUsuario

where r.estado = 'Disponible'and
(t.IdTipoComprobante like + '%' + @Busqueda + '%' or 
t.TipoComprobante like + '%' + @Busqueda + '%' or 
t.NroComprobante like + '%' + @Busqueda + '%' or 
t.Desde like + '%' + @Busqueda + '%' or 
t.Hasta like + '%' + @Busqueda + '%' or 
t.FechaCreacion like + '%' + @Busqueda + '%')

end
GO
/****** Object:  StoredProcedure [dbo].[ubicacionesBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ubicacionesBUSQUEDA]
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SELECT
        u.IdUbicacion,
		u.IdUsuario,
		usu.Usuario,
        u.Ubicacion,
        u.Descripcion,
        u.FechaCreacion
    FROM ubicaciones AS u
	left join usuarios as usu on usu.IdUsuario = u.IdUsuario
    WHERE u.Estado = 'Disponible'
      AND (
            u.Ubicacion LIKE '%' + @Busqueda + '%' OR 
            CONVERT(VARCHAR, u.IdUbicacion) LIKE '%' + @Busqueda + '%' OR 
            u.Descripcion LIKE '%' + @Busqueda + '%' OR
            CONVERT(VARCHAR, u.FechaCreacion, 120) LIKE '%' + @Busqueda + '%'
      )
END
GO
/****** Object:  StoredProcedure [dbo].[ubicacionesCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ubicacionesCRUD]
(
    @Valor INT,
    @IdUbicacion INT,
	@IdUsuario int,
    @Ubicacion VARCHAR(50),
    @Descripcion VARCHAR(100),
    @Mensaje VARCHAR(120) OUTPUT
)
AS
BEGIN
    IF @Valor = 1
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM ubicaciones WHERE Ubicacion = @Ubicacion and estado = 'Disponible')
        BEGIN
            INSERT INTO ubicaciones (IdUsuario,Ubicacion, Descripcion, FechaCreacion)
            VALUES (@IdUsuario,@Ubicacion, @Descripcion, GETDATE())

            SET @Mensaje = 'La ubicación se ha registrado correctamente.'
        END
        ELSE
        BEGIN
            SET @Mensaje = 'La ubicación ya existe. Intente con un nombre diferente.'
        END
    END

    ELSE IF @Valor = 2
    BEGIN
        UPDATE ubicaciones
        SET Ubicacion = @Ubicacion,
            Descripcion = @Descripcion
        WHERE IdUbicacion = @IdUbicacion

        SET @Mensaje = 'La ubicación se ha actualizado correctamente.'
    END
    ELSE IF @Valor = 3
    BEGIN
        UPDATE ubicaciones
        SET Estado = 'No disponible'
        WHERE IdUbicacion = @IdUbicacion

        SET @Mensaje = 'La ubicación se ha eliminado correctamente.'
    END
    
    END
select * from productos
GO
/****** Object:  StoredProcedure [dbo].[ubicacionesPorId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[ubicacionesPorId]
(
    @IdUbicacion int
)
AS
BEGIN
    SELECT
        u.IdUbicacion,
        u.IdUsuario,
        usr.Usuario,
        u.Ubicacion,
        u.Descripcion,
        u.FechaCreacion,
        u.Estado
    FROM ubicaciones AS u
    INNER JOIN usuarios AS usr ON u.IdUsuario = usr.IdUsuario
    WHERE u.Estado = 'Disponible' AND u.IdUbicacion = @IdUbicacion

	end
GO
/****** Object:  StoredProcedure [dbo].[usuariosBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuariosBUSQUEDA](
@Busqueda varchar(100) = ''
)
as 
begin 

select
u.IdUsuario,
u.Nombre,
u.Apellidos,
u.IdRol,
r.Rol,
u.Usuario,
u.Password,
u.FechaCreacion
from usuarios as u


left join 
roles as r on u.IdRol = r.IdRol


where u.Estado = 'Disponible' and 
(u.Nombre like '%' + @Busqueda + '%' or 
u.IdUsuario like '%' + @Busqueda + '%' or 
u.Apellidos like '%' + @Busqueda + '%' or
u.fechacreacion like '%' + @Busqueda + '%' or 
u.Usuario like '%' + @Busqueda + '%')
end
GO
/****** Object:  StoredProcedure [dbo].[usuariosCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuariosCRUD](
@Valor int,
@IdUsuario int,
@Nombre varchar(30),
@Apellidos varchar(30),
@IdRol int,
@Usuario varchar (30),
@Password varchar (30),
@FechaCreacion datetime,
@Mensaje varchar(120) output
)
as
begin 

if (@Valor = 1)
begin 


if not exists (select 1 from usuarios where Usuario = @Usuario)
begin
insert into usuarios (Nombre, Apellidos, IdRol,Usuario, Password, FechaCreacion)

VALUES (@Nombre, @Apellidos,@IdRol,@Usuario,@Password, GETDATE())

set @Mensaje = 'El usuario se ha registrado correctamente.'

end

else

begin 

set @Mensaje = 'El usuario que quiere registrar ya existe, coloque otro y vuelva a registrar'

end
end

else if (@Valor =2)

begin

update usuarios set Nombre = @Nombre,
Apellidos = @Apellidos,
Usuario = @Usuario,
Password = @Password,
IdRol = @IdRol,
FechaCreacion = @FechaCreacion
where IdUsuario = @IdUsuario

set @Mensaje = 'El usuario se ha Actualizado correctamente.'
end
else if (@Valor=3)
begin 
update usuarios set estado = 'No disponible'
where idusuario = @IdUsuario
set @Mensaje = 'El usuario se ha eliminado correctamente.'
end
end
GO
/****** Object:  StoredProcedure [dbo].[usuariosLOGIN]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuariosLOGIN](
@Usuario varchar (30),
@Password varchar (30),
@Mensaje varchar(40) output
)
as
begin 

select u.usuario, u.apellidos, u.nombre, r.Rol, u.IdRol, u.IdUsuario
from usuarios as u
left join 
roles as r on u.IdRol = r.IdRol

where Usuario = @Usuario and Password = @Password and u.Estado = 'Disponible'


set @Mensaje = 'Bienvenido/a   al sistema'

end 
GO
/****** Object:  StoredProcedure [dbo].[usuariosporID]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuariosporID]
(
@IdUsuario int
)
as 
begin 
select
u.IdUsuario,
u.Nombre,
u.Apellidos,
u.IdRol,
r.Rol,
u.Imagen,
u.Usuario,
u.Password,
u.FechaCreacion
from usuarios as u


left join 
roles as r on u.IdRol = r.IdRol
where IdUsuario = @IdUsuario and u.Estado = 'Disponible'
end
GO
/****** Object:  StoredProcedure [dbo].[validarproductoenlacompra]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[validarproductoenlacompra]
(
@IdProducto int
)
as
begin
select p.IdProducto,p.CodProducto,p.producto
from productos AS p
left join comprasdetalles as cd on cd.IdProducto = p.IdProducto
where cd.IdProducto = @IdProducto


end
GO
/****** Object:  StoredProcedure [dbo].[validarproductoenlaventa]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[validarproductoenlaventa]
(
@IdProducto int
)
as
begin
select p.IdProducto,p.CodProducto,p.producto
from productos AS p
left join ventasdetalles as cd on cd.IdProducto = p.IdProducto
where cd.IdProducto = @IdProducto


end
GO
/****** Object:  StoredProcedure [dbo].[VentaCuadreDelDia]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[VentaCuadreDelDia] 
as 
begin

SELECT 
    CONVERT(DATE, FechaCreacion) AS Fecha, -- Fecha del cuadre
    SUM(Efectivo) AS TotalEfectivo,
    SUM(MontoDebitado) AS TotalTarjeta,
    SUM(Transferencia) AS TotalTransferencias,
    SUM(Total) AS TotalVentas,
    SUM(Debe) AS TotalPendiente,
    SUM(Devuelta) AS TotalDevuelto
FROM ventas
WHERE CONVERT(DATE, FechaCreacion) = CONVERT(DATE, GETDATE()) -- Filtrar por el día actual
GROUP BY CONVERT(DATE, FechaCreacion);
end
GO
/****** Object:  StoredProcedure [dbo].[ventadetalleporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ventadetalleporId]
    @IdVenta INT
AS
BEGIN
    SELECT 
        v.IdVentaDetalle,
        v.IdProducto,
        p.CodProducto,
        p.Producto,
        v.Cantidad,
        v.Precio,
        v.Impuesto,
        v.Descuento,
        v.SubTotal,
        v.Total
    FROM 
        ventasdetalles AS v
    LEFT JOIN 
        productos AS p ON v.IdProducto = p.IdProducto
    WHERE 
        v.IdVenta = @IdVenta;
END;
GO
/****** Object:  StoredProcedure [dbo].[ventaporId]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ventaporId]
    @IdVenta INT
AS
BEGIN
    SELECT 
        v.IdVenta,
        u.Nombre AS Usuario,
        emp.Nombre AS Empresa,
        emp.Telefono AS EmpresaTelefono,
        emp.RNC AS EmpresaRNC,
        c.IdCliente,
        c.Nombre AS Cliente,
        c.Telefono AS ClienteTelefono,
        c.Direccion AS ClienteDireccion,
		v.IdTipoComprobante, 
        t.TipoComprobante,
		v.NroComprobante,
        v.MetodoPago,
        v.TipoTarjeta,
        v.NroTarjeta,
        v.TarjetaHabiente,
        v.EstadoVenta,
        v.Descripcion,
        v.Efectivo,
        v.MontoDebitado,
        v.Transferencia,
        v.Pago,
        vd.SubTotal,
        v.Total,
        v.Debe,
        v.Devuelta,
        v.FechaCreacion
    FROM 
        ventas AS v
    LEFT JOIN 
        clientes AS c ON v.IdCliente = c.IdCliente
    LEFT JOIN 
        tiposcomprobantes AS t ON v.IdTipoComprobante = t.IdTipoComprobante
    LEFT JOIN 
        usuarios AS u ON v.IdUsuario = u.IdUsuario
    LEFT JOIN 
        ventasdetalles AS vd ON v.IdVenta = vd.IdVenta
    LEFT JOIN 
        empresa AS emp ON v.IdEmpresa = emp.IdEmpresa
    WHERE 
        v.Estado = 'Disponible' 
        AND v.IdVenta = @IdVenta;
END;
GO
/****** Object:  StoredProcedure [dbo].[ventasBUSQUEDA]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ventasBUSQUEDA](
    @Busqueda varchar(100)
)
AS
BEGIN
    SELECT
        v.IdVenta,
		v.IdUsuario,
        u.Usuario,
		c.IdCliente,
        c.Nombre AS Cliente,
        t.TipoComprobante,
        v.NroComprobante,
        v.MetodoPago,
		v.TipoTarjeta,
        v.NroTarjeta,
        v.TarjetaHabiente,
        v.EstadoVenta,
        v.Descripcion,
        v.Efectivo,
        v.MontoDebitado,
        v.Transferencia,
        v.Pago,
        -- Usar SUM para obtener el SubTotal total y el Total general
        SUM(vd.SubTotal) AS SubTotal,
        v.Total,
        v.Debe,
        v.Devuelta,
        v.FechaCreacion
    FROM
        ventas AS v
    LEFT JOIN
        clientes AS c ON v.IdCliente = c.IdCliente
    LEFT JOIN
        tiposcomprobantes AS t ON v.IdTipoComprobante = t.IdTipoComprobante
    LEFT JOIN
        usuarios AS u ON v.IdUsuario = u.IdUsuario
    LEFT JOIN
        ventasdetalles AS vd ON v.IdVenta = vd.IdVenta
    WHERE
        v.Estado = 'Disponible' AND 
        (v.IdVenta LIKE '%' + @Busqueda + '%' OR
        u.Usuario LIKE '%' + @Busqueda + '%' OR
        c.Nombre LIKE '%' + @Busqueda + '%' OR
        t.TipoComprobante LIKE '%' + @Busqueda + '%' OR
        v.NroComprobante LIKE '%' + @Busqueda + '%' OR
        v.EstadoVenta LIKE '%' + @Busqueda + '%' OR
        v.MetodoPago LIKE '%' + @Busqueda + '%' OR
        v.Descripcion LIKE '%' + @Busqueda + '%' OR
        v.NroTarjeta LIKE '%' + @Busqueda + '%' OR
        v.TarjetaHabiente LIKE '%' + @Busqueda + '%' OR
        v.Efectivo LIKE '%' + @Busqueda + '%' OR
        v.MontoDebitado LIKE '%' + @Busqueda + '%' OR
        v.Pago LIKE '%' + @Busqueda + '%' OR
        v.Total LIKE '%' + @Busqueda + '%' OR
        v.Debe LIKE '%' + @Busqueda + '%' OR
        v.Devuelta LIKE '%' + @Busqueda + '%' OR
        v.FechaCreacion LIKE '%' + @Busqueda + '%')
    GROUP BY
        v.IdVenta,
		v.IdUsuario,
        u.Usuario,
		c.IdCLiente,
        c.Nombre,
        t.TipoComprobante,
        v.NroComprobante,
        v.MetodoPago,
		v.TipoTarjeta,
        v.NroTarjeta,
        v.TarjetaHabiente,
        v.EstadoVenta,
        v.Descripcion,
        v.Efectivo,
        v.MontoDebitado,
        v.Transferencia,
        v.Pago,
        v.Total,
        v.Debe,
        v.Devuelta,
        v.FechaCreacion
END
GO
/****** Object:  StoredProcedure [dbo].[ventasCRUD]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ventasCRUD]
(
    @Valor INT,
    @IdVenta INT output,
    @IdUsuario INT,
    @IdEmpresa INT,
    @IdCliente INT,
	@IdTipoComprobante int,
	@NroComprobante varchar(100),
    @Estado varchar(25),
    @MetodoPago varchar(25),
    @Descripcion VARCHAR(100),
    @TipoTarjeta VARCHAR(30),
    @NroTarjeta VARCHAR(90),
    @TarjetaHabiente VARCHAR(40),
    @Efectivo DECIMAL(10,2),
    @MontoDebitado DECIMAL(10,2),
    @Transferencia DECIMAL(10,2),
    @Pago DECIMAL(10,2),
    @Total DECIMAL(10,2),
    @Debe DECIMAL(10,2),
    @Devuelta DECIMAL(10,2),
    @ventasdetalle ventasdetalles READONLY,
    @Mensaje VARCHAR(120) OUTPUT
)
AS 
BEGIN 
    IF (@Valor = 1)
    BEGIN 
	  

        -- Insertar nueva venta
        INSERT INTO ventas (IdUsuario, IdEmpresa, IdCliente, IdTipoComprobante, NroComprobante ,EstadoVenta, MetodoPago, Descripcion, TipoTarjeta, NroTarjeta, TarjetaHabiente, Efectivo,
                            MontoDebitado, Transferencia, Pago, Total, Debe, Devuelta, FechaCreacion)
        VALUES (@IdUsuario, @IdEmpresa, @IdCliente, @IdTipoComprobante, @NroComprobante ,@Estado, @MetodoPago, @Descripcion, @TipoTarjeta, @NroTarjeta, @TarjetaHabiente, @Efectivo,
                @MontoDebitado, @Transferencia, @Pago, @Total, @Debe, @Devuelta, GETDATE());

        -- Obtener el ID de la venta recién insertada

        SET @IdVenta = SCOPE_IDENTITY();
        -- Insertar detalles de la venta
        INSERT INTO ventasdetalles (IdVenta, IdProducto, CodProducto, Cantidad, Precio, Descuento, Impuesto ,SubTotal, Total)
        SELECT @IdVenta, IdProducto, CodProducto ,Cantidad, Precio, Descuento, Impuesto,SubTotal, Total FROM @ventasdetalle;

        -- Actualizar stock de productos
    UPDATE p
        SET p.Stock = p.Stock - vd.Cantidad
        FROM productos AS p
        INNER JOIN @ventasdetalle vd ON p.IdProducto = vd.IdProducto;

        SET @Mensaje = 'La venta se realizó correctamente';
    END
   ELSE IF (@Valor = 2)
   BEGIN
        SET NOCOUNT ON;

        -- Actualizar la cabecera de la venta
        UPDATE ventas 
        SET 
            IdCliente = @IdCliente,
            EstadoVenta = @Estado,
            MetodoPago = @MetodoPago,
            Descripcion = @Descripcion,
            NroTarjeta = @NroTarjeta,
			IdTipoComprobante = @IdTipoComprobante,
			NroComprobante = @NroComprobante,
            TarjetaHabiente = @TarjetaHabiente,
            Efectivo = @Efectivo,
            MontoDebitado = @MontoDebitado,
            Transferencia = @Transferencia,
            Pago = @Pago,
			
            Total = @Total,
            Debe = @Debe,
            Devuelta = @Devuelta,
            FechaCreacion = GETDATE()
        WHERE IdVenta = @IdVenta;

        -- Crear tabla temporal para los productos originales de la venta
        CREATE TABLE #OriginalDetalles (
		CodProducto varchar(100),
            IdProducto INT,
            Cantidad INT,
			Impuesto int,
            Descuento INT,
            SubTotal DECIMAL(18,2),
            Total DECIMAL(18,2)
        );

        -- Insertar los productos originales en la tabla temporal
        INSERT INTO #OriginalDetalles (IdProducto, CodProducto ,Cantidad, Descuento, Impuesto,SubTotal, Total)
        SELECT IdProducto, CodProducto ,Cantidad, Descuento, Impuesto,SubTotal, Total
        FROM ventasdetalles
        WHERE IdVenta = @IdVenta;

        -- Ajustar stock: revertir los cambios del stock para los detalles originales
        UPDATE p
        SET p.Stock = p.Stock + od.Cantidad
        FROM productos p
        INNER JOIN #OriginalDetalles od ON p.IdProducto = od.IdProducto;

        -- Eliminar todos los detalles actuales de la venta
        DELETE FROM ventasdetalles WHERE IdVenta = @IdVenta;

        -- Insertar los detalles actualizados
        INSERT INTO ventasdetalles (IdVenta, IdProducto, CodProducto,Cantidad, Precio, Descuento, Impuesto,SubTotal, Total)
        SELECT @IdVenta, IdProducto, CodProducto ,Cantidad, Precio, Descuento, Impuesto ,Subtotal,Total FROM @ventasdetalle;

        -- Ajustar stock nuevamente según los nuevos detalles
        UPDATE p
        SET p.Stock = p.Stock - vd.Cantidad
        FROM productos p
        INNER JOIN @ventasdetalle vd ON p.IdProducto = vd.IdProducto;

        -- Eliminar la tabla temporal
        DROP TABLE #OriginalDetalles;

        SET @Mensaje = 'La venta se actualizó correctamente';
    END


	ELSE IF (@Valor = 3)
BEGIN
    SET NOCOUNT ON;

    -- Crear tabla temporal para los detalles de la venta a "eliminar"
    CREATE TABLE #DetallesVenta (
        IdProducto INT,
        Cantidad INT
    );

    -- Insertar los detalles de la venta en la tabla temporal
    INSERT INTO #DetallesVenta (IdProducto, Cantidad)
    SELECT IdProducto, Cantidad
    FROM ventasdetalles
    WHERE IdVenta = @IdVenta;

    -- Cambiar el estado de la venta a "No disponible"
    UPDATE ventas
    SET Estado = 'No disponible',
	IdUsuario = @IdUsuario
    WHERE IdVenta = @IdVenta;

    -- Actualizar el stock de los productos
    UPDATE p
    SET p.Stock = p.Stock + dv.Cantidad
    FROM productos p
    INNER JOIN #DetallesVenta dv ON p.IdProducto = dv.IdProducto;

    -- Eliminar la tabla temporal
    DROP TABLE #DetallesVenta;

    SET @Mensaje = 'La venta se cambió a eliminado y el stock fue actualizado correctamente';
END




END

GO
/****** Object:  StoredProcedure [dbo].[ventasporfecha]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ventasporfecha](
@Busqueda varchar (100) = '',
@Desde date,
@Hasta date
)
as 
begin 

  SELECT
        v.IdVenta,
		v.IdUsuario,
        u.Usuario,
		c.IdCliente,
        c.Nombre AS Cliente,
        t.TipoComprobante,
        v.NroComprobante,
        v.MetodoPago,
		v.TipoTarjeta,
        v.NroTarjeta,
        v.TarjetaHabiente,
        v.EstadoVenta,
        v.Descripcion,
        v.Efectivo,
        v.MontoDebitado,
        v.Transferencia,
        v.Pago,
        -- Usar SUM para obtener el SubTotal total y el Total general
        SUM(vd.SubTotal) AS SubTotal,
        v.Total,
        v.Debe,
        v.Devuelta,
        v.FechaCreacion
    FROM
        ventas AS v
    LEFT JOIN
        clientes AS c ON v.IdCliente = c.IdCliente
    LEFT JOIN
        tiposcomprobantes AS t ON v.IdTipoComprobante = t.IdTipoComprobante
    LEFT JOIN
        usuarios AS u ON v.IdUsuario = u.IdUsuario
    LEFT JOIN
        ventasdetalles AS vd ON v.IdVenta = vd.IdVenta

		where   CAST(v.FechaCreacion AS DATE) BETWEEN @Desde AND @Hasta
		 and   v.Estado = 'Disponible' AND 
        (v.IdVenta LIKE '%' + @Busqueda + '%' OR
        u.Usuario LIKE '%' + @Busqueda + '%' OR
        c.Nombre LIKE '%' + @Busqueda + '%' OR
        t.TipoComprobante LIKE '%' + @Busqueda + '%' OR
        v.NroComprobante LIKE '%' + @Busqueda + '%' OR
        v.EstadoVenta LIKE '%' + @Busqueda + '%' OR
        v.MetodoPago LIKE '%' + @Busqueda + '%' OR
        v.Descripcion LIKE '%' + @Busqueda + '%' OR
        v.NroTarjeta LIKE '%' + @Busqueda + '%' OR
        v.TarjetaHabiente LIKE '%' + @Busqueda + '%' OR
        v.Efectivo LIKE '%' + @Busqueda + '%' OR
        v.MontoDebitado LIKE '%' + @Busqueda + '%' OR
        v.Pago LIKE '%' + @Busqueda + '%' OR
        v.Total LIKE '%' + @Busqueda + '%' OR
        v.Debe LIKE '%' + @Busqueda + '%' OR
        v.Devuelta LIKE '%' + @Busqueda + '%' OR
        v.FechaCreacion LIKE '%' + @Busqueda + '%')


		    GROUP BY
        v.IdVenta,
		v.IdUsuario,
        u.Usuario,
		c.IdCLiente,
        c.Nombre,
        t.TipoComprobante,
        v.NroComprobante,
        v.MetodoPago,
		v.TipoTarjeta,
        v.NroTarjeta,
        v.TarjetaHabiente,
        v.EstadoVenta,
        v.Descripcion,
        v.Efectivo,
        v.MontoDebitado,
        v.Transferencia,
        v.Pago,
        v.Total,
        v.Debe,
        v.Devuelta,
        v.FechaCreacion
		end
GO
/****** Object:  StoredProcedure [dbo].[VentasTotal]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[VentasTotal]
@valor int
as 
begin
if (@valor =1)
begin
select Replace(Format(sum(Total), 'N2'), '.', ',') as Total from ventas
end
else if (@valor = 2)
begin 
SELECT REPLACE(FORMAT(SUM(Total), 'N2'), '.', ',') AS Total
FROM ventas
WHERE CAST(FechaCreacion AS DATE) = CAST(GETDATE() AS DATE);

end
end
GO
/****** Object:  StoredProcedure [dbo].[verpagos]    Script Date: 13/12/2024 13:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[verpagos](
@IdVenta int,
@IdCompra int,
@Valor varchar(25)
)
as
begin 

if (@Valor =1)
begin

select p.IdPago, u.Usuario, p.MetodoPago, p.TipoTarjeta, p.Descripcion, p.NroTarjeta, 
p.TarjetaHabiente, p.Efectivo, p.MontoDebitado, p.Transferencia, p.Pago, p.FechaCreacion

from pagos as p
left join
usuarios as u on u.IdUsuario = p.IdUsuario
where IdVenta = @IdVenta
end
else
begin 
select p.IdPago, u.Usuario, p.MetodoPago, p.TipoTarjeta, p.Descripcion, p.NroTarjeta, 
p.TarjetaHabiente, p.Efectivo, p.MontoDebitado, p.Transferencia, p.Pago, p.FechaCreacion

from pagos as p
left join
usuarios as u on u.IdUsuario = p.IdUsuario
where IdCompra = @IdCompra
end
end
GO

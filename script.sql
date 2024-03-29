USE [master]
GO
/****** Object:  Database [DBCARRITO]    Script Date: 10/5/2022 6:01:12 PM ******/
CREATE DATABASE [DBCARRITO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBCARRITO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBCARRITO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBCARRITO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBCARRITO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBCARRITO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBCARRITO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBCARRITO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBCARRITO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBCARRITO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBCARRITO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBCARRITO] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBCARRITO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBCARRITO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBCARRITO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBCARRITO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBCARRITO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBCARRITO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBCARRITO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBCARRITO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBCARRITO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBCARRITO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBCARRITO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBCARRITO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBCARRITO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBCARRITO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBCARRITO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBCARRITO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBCARRITO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBCARRITO] SET RECOVERY FULL 
GO
ALTER DATABASE [DBCARRITO] SET  MULTI_USER 
GO
ALTER DATABASE [DBCARRITO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBCARRITO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBCARRITO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBCARRITO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBCARRITO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBCARRITO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBCARRITO', N'ON'
GO
ALTER DATABASE [DBCARRITO] SET QUERY_STORE = OFF
GO
USE [DBCARRITO]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[Idcarrito] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Idproducto] [int] NULL,
	[Cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idcarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[Correo] [varchar](100) NULL,
	[Clave] [varchar](150) NULL,
	[Reestablecer] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDepartamento] [varchar](2) NOT NULL,
	[Descripcion] [varchar](45) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Venta]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Venta](
	[Iddetall_Venta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[Idproducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Total] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Iddetall_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[IdDistrito] [varchar](6) NOT NULL,
	[Descripcion] [varchar](45) NOT NULL,
	[IdProvincia] [varchar](4) NOT NULL,
	[IdDepartamento] [varchar](2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[Idmarca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idmarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Idproducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](500) NULL,
	[Descripcion] [varchar](500) NULL,
	[Idmarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[precio] [decimal](10, 2) NULL,
	[stock] [int] NULL,
	[RutaImagen] [varchar](100) NULL,
	[NombreImagen] [varchar](100) NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[Idprovincia] [varchar](4) NOT NULL,
	[Descripcion] [varchar](45) NOT NULL,
	[IdDepartamento] [varchar](2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[Correo] [varchar](100) NULL,
	[Clave] [varchar](150) NULL,
	[Reestablecer] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[TotalProducto] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[Contacto] [varchar](50) NULL,
	[IdDistrito] [varchar](100) NULL,
	[Telefono] [varchar](100) NULL,
	[Direccion] [varchar](150) NULL,
	[IdTransaccion] [varchar](150) NULL,
	[FechaVenta] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((0)) FOR [Reestablecer]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Marca] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Marca] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((0)) FOR [precio]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [Reestablecer]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Venta] ADD  DEFAULT (getdate()) FOR [FechaVenta]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([Idproducto])
REFERENCES [dbo].[Producto] ([Idproducto])
GO
ALTER TABLE [dbo].[Detalle_Venta]  WITH CHECK ADD FOREIGN KEY([Idproducto])
REFERENCES [dbo].[Producto] ([Idproducto])
GO
ALTER TABLE [dbo].[Detalle_Venta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([Idmarca])
REFERENCES [dbo].[Marca] ([Idmarca])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EditarCategoria](
@IdCategoria int,
@Descripcion varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
		SET @Resultado = 0
		IF NOT EXISTS (SELECT * FROM Categoria WHERE Descripcion = @Descripcion and IdCategoria != @IdCategoria)
		begin

		update top (1) Categoria set
		Descripcion = @Descripcion,
		Activo = @Activo
		WHERE IdCategoria = @IdCategoria
		
		
		SET @Resultado= 1
end
 else
	SET @Mensaje='La  categoria ya existe'

	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarMarca]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_EditarMarca](
@IdMarca int,
@Descripcion varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
		SET @Resultado = 0
		IF NOT EXISTS (SELECT * FROM Marca WHERE Descripcion = @Descripcion and IdMarca != @IdMarca)
		begin

		update top (1) Marca set
		Descripcion = @Descripcion,
		Activo = @Activo
		WHERE IdMarca = @IdMarca
		
		
		SET @Resultado= 1
end
 else
	SET @Mensaje='La  Marca ya existe'

	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProducto]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EditarProducto](
@IdProducto int,
@Nombre varchar(100),
@Descripcion varchar(100),
@IdMarca varchar(100),
@IdCategoria varchar(100),
@Precio decimal(10,2),
@Stock int,
@Activo bit,
@Mensaje varchar(500) output,
@Resultado bit output

)
as
begin
		SET @Resultado = 0

		IF NOT EXISTS	 (SELECT * FROM Producto WHERE Nombre = @Nombre and IdProducto != @IdProducto)
		begin

		update Producto set
		Nombre = @Nombre,      
		Descripcion= @Descripcion,
		IdMarca= @IdMarca,
		IdCategoria = @IdCategoria,
		Precio=  @Precio,
		Stock = @Stock, 
		Activo= @Activo	
		 where  IdProducto = @IdProducto		
		
		SET @Resultado = 1
end
 else
	SET @Mensaje='El Producto ya existe'
	end
	
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarUsuario]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_EditarUsuario](
@IdUsuario int,
@Nombres varchar(100),
@Apellidos varchar(100),
@Correo varchar(100),
--@Clave varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
		SET @Resultado = 0
		IF NOT EXISTS (SELECT * FROM Usuario WHERE Correo = @Correo and IdUsuario != @IdUsuario)
		begin

		update top (1) usuario set
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		Correo = @Correo,
		Activo = @Activo
		WHERE IdUsuario = @IdUsuario
		
		
		SET @Resultado= 1
end
 else
	SET @Mensaje='El correo del usuario ya existe'

	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EliminarCategoria](
@IdCategoria int,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
		SET @Resultado = 0
		IF NOT EXISTS (SELECT * FROM Producto p
		inner join CATEGORIA c on c.IdCategoria = p.IdCategoria
		where p.IdCategoria = @IdCategoria)
		begin

		delete top (1) from Categoria where IdCategoria = @IdCategoria
		SET @Resultado = 1
end
 else
	set  @Mensaje='La  categoria se encuentra relacionada  a un producto'

	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMarca]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EliminarMarca](
@IdMarca int,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
		SET @Resultado = 0
		IF NOT EXISTS (SELECT * FROM Producto p
		inner join Marca m on m.IdMarca = p.IdMarca
		where p.IdMarca = @IdMarca)
		begin

		delete top (1) from Marca where IdMarca = @IdMarca
		SET @Resultado = 1
end
 else
	set  @Mensaje='La Marca se encuentra relacionada  a un producto'

	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProducto]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EliminarProducto](
@IdProducto int,
@Mensaje varchar(500) output,
@Resultado bit output

)
as
begin
		SET @Resultado = 0

		IF NOT EXISTS	 (SELECT * FROM DETALLE_VENTA dv
		inner join Producto p on p.Idproducto = dv.Idproducto
		where p.Idproducto = @Idproducto)
	begin
		Delete top (1) from Producto where Idproducto = @Idproducto
		
		SET @Resultado = 1
end
 else
	SET @Mensaje='El Producto se encuentra relacionado a  una venta'
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCategoria]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_RegistrarCategoria](
@Descripcion varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado int output
)
as
begin
		SET @Resultado = 0

		IF NOT EXISTS	 (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
		begin
		insert into CATEGORIA(Descripcion,Activo) values
		      (@Descripcion,@Activo)		
		
		SET @Resultado= SCOPE_IDENTITY()
end
 else
	SET @Mensaje='La categoria ya existe'
	end
	
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarMarca]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_RegistrarMarca](
@Descripcion varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado int output
)
as
begin
		SET @Resultado = 0

		IF NOT EXISTS	 (SELECT * FROM Marca WHERE Descripcion = @Descripcion)
		begin
		insert into Marca(Descripcion,Activo) values
		      (@Descripcion,@Activo)		
		
		SET @Resultado= SCOPE_IDENTITY()
end
 else
	SET @Mensaje='La Marca ya existe'
	end
	
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProducto]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_RegistrarProducto](
@Nombre varchar(100),
@Descripcion varchar(100),
@IdMarca varchar(100),
@IdCategoria varchar(100),
@Precio decimal(10,2),
@Stock int,
@Activo bit,
@Mensaje varchar(500) output,
@Resultado int output

)
as
begin
		SET @Resultado = 0

		IF NOT EXISTS	 (SELECT * FROM Producto WHERE Nombre = @Nombre)
		begin
		insert into Producto(Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock ,Activo) values
		      (@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio,@Stock ,@Activo)		
		
		SET @Resultado= SCOPE_IDENTITY()
end
 else
	SET @Mensaje='El Producto ya existe'
	end
	
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUsuario]    Script Date: 10/5/2022 6:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_RegistrarUsuario](
@Nombres varchar(100),
@Apellidos varchar(100),
@Correo varchar(100),
@Clave varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado int output
)
as
begin
        --SET @Mensaje=''
		SET @Resultado = 0

		IF NOT EXISTS (SELECT * FROM Usuario WHERE Correo = @Correo)
		begin
		insert into Usuario(Nombres,Apellidos,Correo,Clave,Activo) values
		(@Nombres,@Apellidos,@Correo,@Clave,@Activo)		
		
		SET @Resultado= SCOPE_IDENTITY()
end
 else
	SET @Mensaje='El correo del usuario ya existe'

	end
GO
USE [master]
GO
ALTER DATABASE [DBCARRITO] SET  READ_WRITE 
GO

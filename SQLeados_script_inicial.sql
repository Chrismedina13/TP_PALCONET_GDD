--Me conecto a la base de datos a usar
USE [GD2C2018]
GO
----------------------------------------------------------------------------------------------
								/** CREACION DE SCHEMA **/
----------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SQLeados')
BEGIN
    EXEC ('CREATE SCHEMA SQLeados AUTHORIZATION gd')
END
GO


----------------------------------------------------------------------------------------------
								/** VAlidacion tablas **/
----------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.FuncionalidadXRol'))
    DROP TABLE SQLeados.FuncionalidadXRol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Compra'))
    DROP TABLE SQLeados.Compra

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.ubicacionXpublicacion'))
    DROP TABLE SQLeados.ubicacionXpublicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Publicacion'))
    DROP TABLE SQLeados.Publicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Empresa'))
    DROP TABLE SQLeados.Empresa

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Cliente'))
    DROP TABLE SQLeados.Cliente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Usuario'))
    DROP TABLE SQLeados.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Rol'))
    DROP TABLE SQLeados.Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Funcionalidad'))
    DROP TABLE SQLeados.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Ubicacion'))
    DROP TABLE SQLeados.Ubicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.GradoPrioridad'))
    DROP TABLE SQLeados.GradoPrioridad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Rubro'))
    DROP TABLE SQLeados.Rubro

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Domicilio'))
    DROP TABLE SQLeados.Domicilio

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLeados.Funcionalidad'))
    DROP TABLE SQLeados.Funcionalidad


----------------------------------------------------------------------------------------------
								/** CREACION de tablas **/
----------------------------------------------------------------------------------------------

create table [SQLeados].Funcionalidad(
funcionalidad_Id int primary key identity,
funcionalidad_descripcion nvarchar(255) not null,)




create table [SQLeados].Rol(
rol_Id int primary key identity,
rol_nombre nvarchar(255) not null,
rol_estado bit default 1
)

create table [SQLeados].FuncionalidadXRol(
funcionalidadXRol_Id int primary key identity,
funcionalidadXRol_rol int not null references [SQLeados].Rol,
funcionalidadXRol_funcionalidad int not null references [SQLeados].Funcionalidad ,
)

create table [SQLeados].Usuario(
usuario_Id int primary key identity,
usuario_username varchar(255) unique not null,
usuario_password varchar(255) not null,
usuario_rol int not null references [SQLeados].Rol,
usuario_tipo varchar(20) not null,
usuario_estado int default 1,
usuario_intentos int default 0,
)

create table [SQLeados].Domicilio(
domicilio_id int primary key identity,
domicilio_calle varchar(255) not null,
domicilio_numero int not null,
domicilio_piso int,
domicilio_dto varchar(2),
domicilio_localidad varchar(255),
domicilio_codigo_postal int not null,
)

create table [SQLeados].Cliente(
cliente_nombre varchar(255) not null,
cliente_apellido varchar(255) not null,
cliente_usuario int not null references [SQLeados].Usuario,
cliente_tipo_documento varchar(5) not null,
cliente_numero_documento numeric(18,0) not null,
cliente_fecha_nacimiento datetime not null,
cliente_fecha_creacion datetime not null,
cliente_datos_tarjeta varchar(255),
cliente_puntaje int default 0,
cliente_email varchar(255) not null,
cliente_telefono varchar(255),
cliente_estado int default 1,
cliente_cuit varchar(20),
cliente_domicilio int references [SQLeados].Domicilio,
PRIMARY KEY (cliente_tipo_documento,cliente_numero_documento)
)

create table [SQLeados].Empresa(
empresa_cuit nvarchar(255) primary key,
empresa_razon_social varchar(255) not null,
empresa_usuario int not null references [SQLeados].Usuario,
empresa_domicilio int references [SQLeados].Domicilio,
empresa_ciudad varchar(255) not null,
empresa_estado int default 1,
)

create table [SQLeados].Rubro(
rubro_id int primary key identity,
rubro_descripcion varchar(255) not null,
)

create table [SQLeados].GradoPrioridad(
grado_id int primary key identity,
grado_nombre varchar(255) not null,
grado_comision numeric(10,2) not null,
)

create table [SQLeados].Ubicacion(
ubicacion_id int primary key identity,
ubicacion_fila nvarchar(3) not null,
ubicacion_asiento numeric(18,0) not null,
ubicacion_sin_numerar bit,
ubicacion_precio numeric(18,0) ,
ubicacion_Tipo_codigo numeric(18,0),
ubicacion_Tipo_Descripcion nvarchar(255),
)

create table [SQLeados].Publicacion(
publicacion_codigo int primary key identity,
publicacion_usuario_responsable int references [SQLeados].Usuario,
publicacion_rubro int references [SQLeados].Rubro not null,
publicacion_grado int references [SQLeados].GradoPrioridad not null,
publicacion_descripcion varchar(255),
publicacion_precio numeric(20,2) not null,
publicacion_stock int not null,
publicacion_estado varchar(20) not null,
publicacion_puntaje_venta int not null,
publicacion_ubicaciones int references [SQLeados].Ubicacion not null,
publicacion_fecha datetime not null
)

create table [SQLeados].ubicacionXpublicacion(
ubiXpubli_ID int primary key identity,
ubiXpubli_Ubicacion int references [SQLeados].Ubicacion,
ubiXpubli_Publicacion int references [SQLeados].Publicacion,
)

create table [SQLeados].Compra(
compra_id int primary key identity,
compra_cliente_tipo_documento varchar(5),
compra_cliente_numero_documento numeric(18,0),
compra_publicacion_codigo int references [SQLeados].Publicacion,
compra_fecha datetime not null,
compra_cantidad numeric(18,0) not null,
FOREIGN KEY (compra_cliente_tipo_documento, compra_cliente_numero_documento) REFERENCES [SQLeados].Cliente(cliente_tipo_documento,cliente_numero_documento),
)
















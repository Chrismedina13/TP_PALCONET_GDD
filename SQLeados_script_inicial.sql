--Me conecto a la base de datos a usar
USE [GD2C2018]
GO

----------------------------------------------------------------------------------------------
								/** ELIMINACIÓN DE CONSTRAINS DE TABLAS ANTERIORES **/
----------------------------------------------------------------------------------------------

PRINT('Eliminacion de Schema anterior') 
IF EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'SQLEADOS')
BEGIN
	DECLARE @Sql NVARCHAR(MAX) = '';

-------------------------------------
--		ELIMINACION DE CONSTRAINTS
-------------------------------------
PRINT('Eliminacion de Constraints anteriores') 
	SELECT @Sql = @Sql + 'ALTER TABLE ' + QUOTENAME('SQLEADOS') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' 
																		+ QUOTENAME(f.name)  + ';' + CHAR(13)
	FROM SYS.TABLES t 
	INNER JOIN SYS.FOREIGN_KEYS f ON f.parent_object_id = t.object_id 
	INNER JOIN SYS.SCHEMAS s ON t.SCHEMA_ID = s.SCHEMA_ID
	WHERE s.name = 'SQLEADOS'
	ORDER BY t.name;
	PRINT @Sql
	EXEC  (@Sql)
	PRINT('Eliminacion HECHA') 
	/*
	*/
-------------------------------------
--		ELIMINACION DE TABLAS
-------------------------------------
PRINT('Eliminacion de tablas existentes') 
	DECLARE @SqlStatement NVARCHAR(MAX)
	SELECT @SqlStatement = COALESCE(@SqlStatement, N'') + N'DROP TABLE [SQLEADOS].' + QUOTENAME(TABLE_NAME) + N';' + CHAR(13)
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'SQLEADOS' AND TABLE_TYPE = 'BASE TABLE'
	PRINT @SqlStatement
	EXEC  (@SqlStatement)
	--DROP SCHEMA SQLEADOS
END
GO
PRINT('Eliminacion HECHA') 


----------------------------------------------------------------------------------------------
								/** CREACION DE SCHEMA **/
----------------------------------------------------------------------------------------------
PRINT('Creando Schema SQLEADOS') 
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SQLEADOS')
BEGIN
    EXEC ('CREATE SCHEMA SQLEADOS AUTHORIZATION gdEspectaculos2018')
END
GO
PRINT('Creacion hecha') 
----------------------------------------------------------------------------------------------
								/** VALIDACION TABLAS **/
----------------------------------------------------------------------------------------------
PRINT('Validacion de tablas, procedures, triggers y funciones, las elimina si existen') 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.func_coincide_fecha_creacion'))
    DROP FUNCTION SQLEADOS.func_coincide_fecha_creacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.FuncionalidadXRol'))
    DROP TABLE SQLEADOS.FuncionalidadXRol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Compra'))
    DROP TABLE SQLEADOS.Compra

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Domicilio'))
    DROP TABLE SQLEADOS.Domicilio

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.ubicacionXpublicacion'))
    DROP TABLE SQLEADOS.ubicacionXpublicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Publicacion'))
    DROP TABLE SQLEADOS.Publicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Empresa'))
    DROP TABLE SQLEADOS.Empresa

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Cliente'))
    DROP TABLE SQLEADOS.Cliente

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Usuario'))
    DROP TABLE SQLEADOS.Usuario

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Rol'))
    DROP TABLE SQLEADOS.Rol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Funcionalidad'))
    DROP TABLE SQLEADOS.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Ubicacion'))
    DROP TABLE SQLEADOS.Ubicacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.GradoPrioridad'))
    DROP TABLE SQLEADOS.GradoPrioridad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Rubro'))
    DROP TABLE SQLEADOS.Rubro

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Funcionalidad'))
    DROP TABLE SQLEADOS.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Factura'))
    DROP TABLE SQLEADOS.Funcionalidad

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.Factura'))
    DROP TABLE SQLEADOS.Factura

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.ItemFactura'))
    DROP TABLE SQLEADOS.ItemFactura

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.puntaje'))
    DROP TABLE SQLEADOS.puntaje
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.canjeproducto'))
    DROP TABLE SQLEADOS.canjeproducto

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.UserXRol'))
    DROP TABLE SQLEADOS.UserXRol

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.UsuarioXRol'))
    DROP TABLE SQLEADOS.UsuarioXRol
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.func_coincide_fecha_creacion'))
    DROP TABLE SQLEADOS.func_coincide_fecha_creacion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[actualizarContra]'))
    DROP proc SQLEADOS.[actualizarContra]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[ValidarUsuario]'))
    DROP proc SQLEADOS.[ValidarUsuario]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[inhabilitarRolPorUsuario]'))
    DROP proc SQLEADOS.[inhabilitarRolPorUsuario]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[inhabilitarRol]'))
    DROP proc SQLEADOS.[inhabilitarRol]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cargarRolesHabilitados]'))
    DROP proc SQLEADOS.[cargarRolesHabilitados]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[eliminarFuncionalidades]'))
    DROP proc SQLEADOS.[eliminarFuncionalidades]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[modificarRol]'))
    DROP proc SQLEADOS.[modificarRol]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[FuncionalidadesPorRol]'))
    DROP proc SQLEADOS.[FuncionalidadesPorRol]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[rolHabilitado]'))
    DROP proc SQLEADOS.[rolHabilitado]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cargarRoles]'))
    DROP proc SQLEADOS.[cargarRoles]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[codigoFuncionalidad]'))
    DROP proc SQLEADOS.[codigoFuncionalidad]
		
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearFuncionalidad]'))
    DROP proc SQLEADOS.[crearFuncionalidad]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[codigoRol]'))
    DROP proc SQLEADOS.[codigoRol]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearRolNuevo]'))
    DROP proc SQLEADOS.[crearRolNuevo]


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[NombreRoles]'))
    DROP proc SQLEADOS.[Nombreroles]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[ubicacionesXPublicidadComprada]'))
    DROP proc SQLEADOS.[ubicacionesXPublicidadComprada]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[bloquearUsuario]'))
    DROP proc SQLEADOS.[bloquearUsuario]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[esAdministrador]'))
    DROP proc SQLEADOS.[esAdministrador]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cargarClientesEliminar]'))
    DROP proc SQLEADOS.[cargarClientesEliminar]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[existeRol]'))
    DROP proc SQLEADOS.[existeRol]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[ValidarContra]'))
    DROP proc SQLEADOS.[ValidarContra]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[actualizarContra]'))
    DROP proc SQLEADOS.actualizarContra

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[listarFuncionalidades]'))
    DROP proc SQLEADOS.[listarFuncionalidades]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[agregarIntentoFallidos]'))
    DROP proc SQLEADOS.[agregarIntentoFallidos]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[resetearIntentoFallidos]'))
    DROP proc SQLEADOS.[resetearIntentoFallidos]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[estaBloqueado]'))
    DROP proc SQLEADOS.[estaBloqueado]


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[habilitarRol]'))
    DROP proc SQLEADOS.[habilitarRol]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[intentosFallidos]'))
    DROP proc SQLEADOS.[intentosFallidos]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cargarNuevoUser]'))
    DROP proc SQLEADOS.[cargarNuevoUser]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearNuevoUserPorRegistroOABM]'))
    DROP proc SQLEADOS.[crearNuevoUserPorRegistroOABM]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearNuevoCliente]'))
    DROP proc SQLEADOS.[crearNuevoCliente]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearNuevoDomicilioDeCliente]'))
    DROP proc SQLEADOS.[crearNuevoDomicilioDeCliente]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearNuevoDomicilioDeEmpresa]'))
    DROP proc SQLEADOS.[crearNuevoDomicilioDeEmpresa]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[obtenerPKdelUltimoClienteIngresado]'))
    DROP proc SQLEADOS.[obtenerPKdelUltimoClienteIngresado]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[llenarGrillaABMCliente]'))
    DROP proc SQLEADOS.[llenarGrillaABMCliente]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[ubicacionesXPublicidadComprada]'))
    DROP table SQLEADOS.[ubicacionesXPublicidadComprada]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[crearNuevoCliente]'))
    DROP proc SQLEADOS.[crearNuevoCliente]
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[Canjes]'))
    DROP table SQLEADOS.Canjes

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[TRIG_si_tiene_factura_entonces_es_publicacion_finalizada]'))
    DROP Trigger SQLEADOS.TRIG_si_tiene_factura_entonces_es_publicacion_finalizada

	
PRINT('Validacion hecha y OK') 
----------------------------------------------------------------------------------------------
								/** CREACION de tablas **/
----------------------------------------------------------------------------------------------
PRINT('Creacion de tablas') 

create table [SQLEADOS].Funcionalidad(
funcionalidad_Id int primary key identity,
funcionalidad_descripcion nvarchar(255) not null)

PRINT('Tabla creada: Funcionalidad') 

create table [SQLEADOS].Rol(
rol_Id int primary key identity,
rol_nombre nvarchar(255) not null,
rol_estado bit default 1
)
PRINT('Tabla creada: Rol') 

create table [SQLEADOS].FuncionalidadXRol(
--ELIMINO FUNCIONALIDADXROL_ID
--	MOTIVO: La tabla solo referencia funcionalidad y rol, lo cual el ID deja de tener mucho sentido
funcionalidadXRol_rol int not null references [SQLEADOS].Rol,
funcionalidadXRol_funcionalidad int not null references [SQLEADOS].Funcionalidad,
)
PRINT('Tabla creada: FuncionalidadXRol') 


create table [SQLEADOS].Usuario(
usuario_Id int primary key identity,
usuario_nombre varchar(255)  not null, --SACO EL UNIQUE ASÍ PUEDE ANDAR EL TRIGGER
usuario_password varbinary(100) not null,
--usuario_rol int not null references [SQLEADOS].Rol,
usuario_administrador bit default 0,
usuario_estado bit default 1, --Indicador para saber si está habilitado o no
usuario_intentos int default 0, --Como es un contador de intentos fallidos que cuenta hasta 3, iniciará en 0
usuario_primer_ingreso bit default 1
)
PRINT('Tabla creada: Usuario') 

create table [SQLEADOS].UsuarioXRol(
usuarioXRol_usuario int NOT NULL,
usuarioXRol_rol int NOT NULL,
PRIMARY KEY(usuarioXRol_usuario, usuarioXRol_rol),
CONSTRAINT fk_rpu_username FOREIGN KEY (usuarioXRol_usuario) REFERENCES [SQLEADOS].Usuario (Usuario_Id),
CONSTRAINT fk_rpu_codigo_rol FOREIGN KEY (usuarioXRol_rol) REFERENCES [SQLEADOS].Rol (rol_id)
)
GO
PRINT('Tabla creada: UsuarioXRol') 



--create table [SQLEADOS].UserXRol(
--userXRol_rol int not null references [SQLEADOS].Rol,
--userXRol_usuario int not null references [SQLEADOS].Usuario
--)

--usuario_tipo varchar(20) not null,
--usuario_estado int default 1, --Indicador para saber si está habilitado o no
--usuario_logins_fallidos int default 0, --Como es un contador de intentos fallidos que cuenta hasta 3, iniciará en 0
--usuario_fecha_creacion datetime
--)




create table [SQLEADOS].Cliente(
--cliente_id int primary key identity,
cliente_id int identity,
cliente_nombre varchar(255) not null,
cliente_apellido varchar(255) not null,
cliente_usuario int references [SQLEADOS].Usuario,
cliente_tipo_documento varchar(5) not null,
cliente_numero_documento numeric(18,0) not null CHECK (cliente_numero_documento >= 0),
cliente_fecha_nacimiento datetime not null CHECK (YEAR(cliente_fecha_nacimiento) >= 1900),
cliente_fecha_creacion datetime not null,
cliente_datos_tarjeta varchar(255),
cliente_puntaje int default 0,
--cliente_compra int references [SQLEADOS].Compra,
cliente_email varchar(255) not null,
cliente_telefono varchar(255),
cliente_estado int default 1,
cliente_cuit varchar(20) unique, 
PRIMARY KEY (cliente_tipo_documento,cliente_numero_documento)
		--EJ: DNI 18563520
)
PRINT('Tabla creada: Cliente') 

create table [SQLEADOS].Empresa(
empresa_id int identity,
empresa_cuit nvarchar(255),
empresa_razon_social varchar(255) not null unique,
empresa_fecha_creacion datetime,
empresa_email nvarchar(50),
empresa_usuario int references [SQLEADOS].Usuario,
empresa_ciudad varchar(255) ,
empresa_estado int default 1,
empresa_telefono varchar(20),
PRIMARY KEY (empresa_cuit,empresa_razon_social)
)
PRINT('Tabla creada: Empresa') 

create table [SQLEADOS].Domicilio(
domicilio_id int primary key identity,
domicilio_calle varchar(255) not null,
domicilio_numero int not null CHECK (domicilio_numero >= 0),
domicilio_piso int CHECK (domicilio_piso >= 0),
domicilio_dto varchar(2),
domicilio_localidad varchar(255),
domicilio_codigo_postal int not null,
--domicilio_persona int not null,
--FOREIGN KEY (domicilio_persona) REFERENCES [SQLEADOS].Empresa(empresa_id)
domicilio_cliente_tipo_documento varchar(5),
domicilio_cliente_numero_documento numeric(18,0),
domicilio_empresa_razon_social varchar(255),
domicilio_empresa_cuit nvarchar(255),
FOREIGN KEY (domicilio_cliente_tipo_documento, domicilio_cliente_numero_documento) REFERENCES [SQLEADOS].Cliente(cliente_tipo_documento,cliente_numero_documento),
FOREIGN KEY (domicilio_empresa_cuit,domicilio_empresa_razon_social)	REFERENCES [SQLEADOS].Empresa(empresa_cuit,empresa_razon_social)
)
PRINT('Tabla creada: Domicilio') 

create table [SQLEADOS].Rubro(
rubro_id int primary key identity,
rubro_descripcion varchar(255) not null,
)
PRINT('Tabla creada: Rubro') 

create table [SQLEADOS].GradoPrioridad(
grado_id int primary key identity,
grado_nombre varchar(255) not null,
grado_comision numeric(10,2) not null,
)
PRINT('Tabla creada: GradoPrioridad') 

create table [SQLEADOS].Ubicacion(
ubicacion_id int primary key identity,
ubicacion_fila nvarchar(3) not null,
ubicacion_asiento numeric(18,0) not null,
ubicacion_sin_numerar bit,
ubicacion_Tipo_codigo numeric(18,0),
ubicacion_Tipo_Descripcion nvarchar(255),
)
PRINT('Tabla creada: Ubicacion') 

create table [SQLEADOS].Publicacion(
publicacion_codigo int primary key identity(12353,1),
publicacion_usuario_responsable int references [SQLEADOS].Usuario,
publicacion_rubro int references [SQLEADOS].Rubro not null,
publicacion_grado int references [SQLEADOS].GradoPrioridad not null,
publicacion_descripcion varchar(255),
publicacion_stock int not null,
publicacion_estado varchar(20) not null,
publicacion_puntaje_venta int not null default 100, -- DEFAULT 100 ES ARBITRARIO
pubicacion_putaje_compra int not null default 30, -- DEFAULT 30 ES ARBITRARIO (Cantidad de puntos que necesitas para comprarlo)
publicacion_fecha datetime not null,
publicacion_fecha_venc datetime not null,		--NUEVO CAMPO
publicacion_estado_validacion int default 0,		--NUEVO CAMPO
publicacion_direccion varchar(255)
)
PRINT('Tabla creada: Publicacion') 



create table [SQLEADOS].ubicacionXpublicacion(
ubiXpubli_ID int primary key identity,
ubiXpubli_Ubicacion int references [SQLEADOS].Ubicacion,
ubiXpubli_Publicacion int references [SQLEADOS].Publicacion,
ubiXpubli_precio int 
)
PRINT('Tabla creada: ubicacionXpublicacion') 

--TABLA NUEVA
create table [SQLEADOS].Factura(

factura_nro int primary key ,
factura_empresa_cuit nvarchar(255),
factura_empresa_razon_social varchar(255),
factura_publicacion int,
factura_fecha datetime,
factura_total decimal(14,2) not null CHECK (factura_total>0),
factura_forma_de_pago nvarchar(255),
FOREIGN KEY (factura_empresa_cuit, factura_empresa_razon_social) REFERENCES [SQLEADOS].Empresa(empresa_cuit, empresa_razon_social),
FOREIGN KEY (factura_publicacion) REFERENCES [SQLEADOS].Publicacion(publicacion_codigo),
)
PRINT('Tabla creada: Factura') 

create table [SQLEADOS].Compra(
compra_id int primary key identity,
compra_factura int references SQLEADOS.Factura,
compra_cliente_tipo_documento varchar(5),
compra_cliente_numero_documento numeric(18,0),
compra_forma_de_pago varchar(50),
compra_fecha datetime not null,
compra_cantidad numeric(18,0) not null,
compra_precio int not null,
--compra_ubiXpubli int references [SQLEADOS].ubicacionXpublicacion,
compra_ubiXpubli int,
FOREIGN KEY (compra_cliente_tipo_documento, compra_cliente_numero_documento) REFERENCES [SQLEADOS].Cliente(cliente_tipo_documento,cliente_numero_documento),
)
PRINT('Tabla creada: Compra') 

create table [SQLEADOS].ubicacionesXPublicidadComprada (
ubxpcomp_id int primary key identity,
ubxpcomp_compra int,
ubxpcom_ubicacionXPublicidad int,
FOREIGN KEY (ubxpcomp_compra) REFERENCES [SQLEADOS].Compra(compra_id),
FOREIGN KEY (ubxpcom_ubicacionXPublicidad) REFERENCES [SQLEADOS].ubicacionXpublicacion(ubiXpubli_ID),
)
PRINT('Tabla creada: ubicacionesXPublicidadComprada') 


--TABLA NUEVA
create table [SQLEADOS].ItemFactura(
item_factura_id int primary key identity,
item_factura_nro int References SQLEADOS.FACTURA,
item_factura_monto decimal(16,2),
item_factura_cantidad numeric(18,0),
item_factura_descripcion nvarchar(60),
item_factura_ubicacion int
)


PRINT('Tabla creada: ItemFactura') 

-- TABLA NUEVA
create table [SQLEADOS].puntaje(
punt_id int primary key identity,
punt_cliente_tipo_documento  varchar(5),
punt_cliente_numero_documento numeric(18,0),
--punt_premio varchar(255),
punt_fecha_vencimiento date,
punt_puntaje int,
punt_vencido int,	
FOREIGN KEY (punt_cliente_tipo_documento, punt_cliente_numero_documento) REFERENCES [SQLEADOS].Cliente(cliente_tipo_documento,cliente_numero_documento),
)
PRINT('Tabla creada: puntaje') 

--TABLA CANJE DE PREMIOS
create table [SQLEADOS].canjeproducto(
canj_id int primary key identity,
canj_costo_puntaje int,
canj_producto varchar(50),
)
PRINT('Tabla creada: canjeproducto') 

create table [SQLEADOS].Canjes(
canjes_id int primary key identity,
canje_cliente_tipo_documento varchar(5),
canje_cliente_numero_documento numeric(18,0),
canje_fecha datetime,
canje_puntos_gastados int,
canje_producto nvarchar(255),
FOREIGN KEY (canje_cliente_tipo_documento, canje_cliente_numero_documento) REFERENCES [SQLEADOS].Cliente(cliente_tipo_documento,cliente_numero_documento),
)

PRINT('Tabla creada: Canjes') 
/*
NO SE SI LO VOY  AUSAR AL FINAL ESTO
create table [SQLEADOS].CanjeXPunto(
canxpun_puntaje int,
canxpun_canje int,
FOREIGN KEY (canxpun_canje) REFERENCES [SQLEADOS].Canjes(canjes_id),
FOREIGN KEY (canxpun_puntaje) REFERENCES [SQLEADOS].puntaje(punt_id)
)*/
----------------------------------------------------------------------------------------------
								/** insertar en tablas **/
----------------------------------------------------------------------------------------------

--ROL
PRINT('Migrar de Rol') 
go
insert into SQLEADOS.Rol (rol_nombre) values
('Administrativo'), 
('Empresa'),
('Cliente');
PRINT('Migracion terminada') 

---/** FUNCIONALIDAD **/
PRINT('Migracion de Funcionalidad') 
go
insert into SQLEADOS.Funcionalidad (funcionalidad_descripcion) values
('ABM de Rol'),
('Registro de usuarios'),
('ABM de Clientes'),
('ABM de Empresa de espectaculo'),
('ABM de Rubro'),
('ABM Grado de publicacion'),
('Generar Publicacion'),
('Editar Publicacion'),
('Comprar'),
('Historial de cliente'),
('Canje y Administracion de puntos'),
('Generar rendicion de comisiones'),
('Listado Estadistico');

PRINT('Migracion terminada') 

--FUNCIONALIDAD POR ROL

--FUNCIONALIDADXROL ADMIN
PRINT('Migrar FuncionalidadXRol') 

PRINT('Migrar FuncionalidadXRol para rol Administrativo') 
go
insert into SQLEADOS.FuncionalidadXRol (funcionalidadXRol_funcionalidad, funcionalidadXRol_rol) 
select distinct A.funcionalidad_Id, 
	R.rol_Id												-- Referencia a administrativo
	from SQLEADOS.Funcionalidad A, SQLEADOS.Rol R
		where R.rol_nombre like 'Administrativo'
	order by 1
PRINT('Migracion terminada para funcionalidadxrol administrativo') 

--FUNCIONALIDADXROL de CLIENTES
PRINT('POR A FuncionalidadXRol para clientes') 
go
insert into SQLEADOS.FuncionalidadXRol (funcionalidadXRol_funcionalidad, funcionalidadXRol_rol)
select  
	funcionalidad_Id, 
	R.rol_Id												-- REFERENTE DE CLIENTES
	from SQLEADOS.Funcionalidad, SQLEADOS.Rol R
	where 
		(funcionalidad_descripcion LIKE 'Comprar' 
		OR funcionalidad_descripcion LIKE 'Historial de cliente' 
		OR funcionalidad_descripcion LIKE 'Canje y Administracion de puntos')
		AND R.rol_nombre like 'Cliente'
	order by 1
PRINT('Migracion terminada para funcionalidadxrol para Cliente') 

--	FUNCIONALIDADXROL DE EMPRESAS
PRINT('POR A FuncionalidadXRol para empresas') 
go
insert into SQLEADOS.FuncionalidadXRol (funcionalidadXRol_funcionalidad, funcionalidadXRol_rol)
select distinct 
	F.funcionalidad_Id, 
	R.rol_Id												-- REFERENTE DE EMPRESAS
	from SQLEADOS.Funcionalidad F, SQLEADOS.Rol R
	where 
		(funcionalidad_descripcion LIKE 'Generar Publicacion' 
		OR funcionalidad_descripcion LIKE 'ABM de Rubro' 
		OR funcionalidad_descripcion LIKE 'Editar Publicacion'
		OR funcionalidad_descripcion LIKE 'ABM Grado de publicacion')
		AND R.rol_nombre like 'Empresa'
	order by 1
PRINT('Migracion terminada para funcionalidadxrol para Empresas') 

PRINT('Migracion funcionalidadxrol COMPLETADA') 

--EMPRESA
PRINT('Migracion de Empresas') 
go
insert into SQLEADOS.Empresa(empresa_razon_social,empresa_cuit,empresa_fecha_creacion,empresa_email)
select distinct Espec_Empresa_Razon_Social,Espec_Empresa_Cuit,Espec_Empresa_Fecha_Creacion,Espec_Empresa_Mail from gd_esquema.Maestra 
				order by Espec_Empresa_Razon_Social 
PRINT('Empresas migradas') 

--DOMICILIO_EMPRESA
PRINT('Migracion de Domicilio de empresas') 
go
insert into SQLEADOS.Domicilio(domicilio_calle,domicilio_numero,domicilio_piso,domicilio_dto,
								domicilio_codigo_postal,domicilio_empresa_razon_social,domicilio_empresa_cuit)
select distinct Espec_Empresa_Dom_Calle,Espec_Empresa_Nro_Calle,Espec_Empresa_Piso,
				Espec_Empresa_Depto,Espec_Empresa_Cod_Postal,Espec_Empresa_Razon_Social,Espec_Empresa_Cuit from gd_esquema.Maestra 
				order by Espec_Empresa_Razon_Social
PRINT('Migracion de domicilios de empresas hechas') 

--CLIENTE
PRINT('Migracion de CLIENTE') 
go
insert into SQLEADOS.Cliente(cliente_nombre,cliente_apellido,cliente_tipo_documento,cliente_numero_documento,
							cliente_fecha_nacimiento,cliente_fecha_creacion,cliente_puntaje,cliente_email,cliente_cuit)
select distinct Cli_Nombre,Cli_Apeliido,'DNI',Cli_Dni,Cli_Fecha_Nac,GETDATE(),0,Cli_Mail,CONCAT('20-',Cli_Dni,'-4') 
	from gd_esquema.Maestra where Cli_Dni is not null order by Cli_Nombre

PRINT('CLIENTE migrados') 
--DOMICILIO_CLIENTE
PRINT('Migracion de domicilios de clientes') 
go
insert into SQLEADOS.Domicilio(domicilio_calle,domicilio_numero,domicilio_piso,domicilio_dto,
								domicilio_codigo_postal,domicilio_cliente_tipo_documento,domicilio_cliente_numero_documento)
select distinct Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal,'DNI',Cli_Dni from gd_esquema.Maestra where Cli_Dni is not null
PRINT('Migracion de domicilios de clientes hechas') 
--USUARIO

--Usuarios ADMIN
/************************************************************
 USER ADMIN ->
	NOMBRE: admin
	CONTRA: 1234
***********************************************************/


PRINT('Creacion de Usuario ADMIN') 
go
insert into SQLEADOS.Usuario(usuario_nombre, usuario_password,usuario_estado, usuario_administrador) values
('admin',
HASHBYTES('SHA2_256', '1234'),
1,
1)
go
PRINT('USER ADMIN CREADO') 

/*
create table [SQLEADOS].Usuario(
usuario_Id int primary key identity,
usuario_nombre varchar(255)  not null, --SACO EL UNIQUE ASÍ PUEDE ANDAR EL TRIGGER
usuario_password varbinary(100) not null,
--usuario_rol int not null references [SQLEADOS].Rol,
usuario_administrador bit default 0,
usuario_estado bit default 1, --Indicador para saber si está habilitado o no
usuario_intentos int default 0, --Como es un contador de intentos fallidos que cuenta hasta 3, iniciará en 0
)*/


--Usuarios Empresas
PRINT('Creacion de usuarios de Empresas') 
go
insert into SQLEADOS.Usuario (usuario_nombre, usuario_password
	,usuario_estado, usuario_administrador
--	,usuario_tipo, usuario_fecha_creacion
	)
select distinct 
	(LOWER(replace(e.empresa_razon_social, space(1), '_'))), --NOMBRE 
	(select top 1 HASHBYTES('SHA2_256',  (STR(1000000*RAND(convert(varbinary, newid())))))),  --contraseñas_autogeneradas
--	'Empresa',
--	GETDATE()
	1, --ESTADO
	0  --USER ADMIN
	from SQLEADOS.Empresa e
	order by 1
PRINT('Creacion de usuarios de Empresas: HECHA') 

----Usuarios clientes
PRINT('Creacion de usuarios de Cliente') 
go
insert into SQLEADOS.Usuario(usuario_nombre, usuario_password 
	,usuario_estado, usuario_administrador
--,usuario_tipo, usuario_fecha_creacion
	)
select distinct 
	(LOWER(replace(A.Cli_Nombre, space(1), '_'))+'_'+replace(A.Cli_Apeliido, space(1), '_')), -- as nombre_user
	(select top 1 HASHBYTES('SHA2_256',  (STR(1000000*RAND(convert(varbinary, newid())))))), 
	--  contraseñas_autogeneradas,
	--CONTRASEÑA AUTOGENERADA DE FORMA NUMÉRICA DECIMAL, ES POCO PROBABLE QUE SE REPITA, está entre 1 y 100000
--	'Cliente', -- as tipo_user --TIPO USER
--	GETDATE()
	1,	-- ESTADO
	0	-- USER ADMIN
	from gd_esquema.Maestra A 
	where A.cli_mail is not null order by 1
PRINT('Creacion de usuarios de Cliente: HECHA') 

PRINT('EMPRESAS, CLIENTES, ADMIN Y USERS MIGRADOS')

PRINT('Creando UsuarioXRol Cliente') 
insert into SQLEADOS.UsuarioXRol(usuarioXRol_rol, usuarioXRol_usuario)
select rol_Id, usuario_Id 
from SQLeados.Usuario, SQLeados.Rol
where usuario_nombre NOT like 'admin' 
		AND usuario_nombre not like 'razon_social%' and rol_nombre in ('Cliente')
go
PRINT('HECHO')


PRINT('Creando UsuarioXRol ADMIN') 
insert into SQLEADOS.UsuarioXRol(usuarioXRol_rol, usuarioXRol_usuario)
select rol_Id, usuario_Id 
from SQLeados.Usuario, SQLeados.Rol
where usuario_nombre like 'admin' and rol_nombre in ('Administrativo','Empresa','Cliente')
go
PRINT('HECHO')
PRINT('Creando UsuarioXRol EMPRESA') 
insert into SQLEADOS.UsuarioXRol(usuarioXRol_rol, usuarioXRol_usuario)
select rol_Id, usuario_Id 
from SQLeados.Usuario, SQLeados.Rol
where usuario_nombre not like 'admin' 
	AND usuario_nombre like 'razon_social%' and rol_nombre in ('Empresa')
go
PRINT('HECHO')
PRINT('UsuarioXRol  MIGRADO POR COMPLETO') 

---- USERXROL
--PRINT('POR A USERXROL ADMIN') 
---- ADMIN

--go 
--insert into SQLEADOS.UserXRol(userXRol_rol,userXRol_usuario)
--select distinct 0, u.usuario_Id from SQLEADOS.Usuario u
--	WHERE u.usuario_nombre LIKE 'admin'

-- --EMPRESAS
-- PRINT('USERXROL EMPRESA') 
--go
--insert into SQLEADOS.UserXRol(userXRol_rol,userXRol_usuario)
--select distinct 1,u.usuario_Id from SQLEADOS.Usuario u
--	INNER JOIN SQLEADOS.Empresa e ON (LOWER(replace(empresa_razon_social, space(1), '_'))) = u.usuario_nombre

----CLIENTE
-- PRINT('USERXROL CLIENTE') 
--go
--insert into SQLEADOS.UserXRol(userXRol_rol,userXRol_usuario)
--select distinct 2, u.usuario_Id from SQLEADOS.Usuario u
--	INNER JOIN SQLEADOS.Cliente c ON (LOWER(replace(c.cliente_nombre, space(1), '_'))+'_'+c.cliente_apellido) = u.usuario_nombre

----RUBRO 


 PRINT('MIGRANDO RUBRO') 
go
insert into SQLEADOS.Rubro(rubro_descripcion)
select distinct Espectaculo_Rubro_Descripcion from gd_esquema.Maestra

insert into SQLeados.Rubro(rubro_descripcion) values
('Musical'),
('Infaltil'),
('Comedia');
PRINT('HECHO')

--Grado Publicacion
PRINT('MIGRANDO GradoPrioridad') 
go
insert into SQLeados.GradoPrioridad(grado_nombre,grado_comision) values
('Alta',15),
('Media',10),
('Baja',5);
PRINT('HECHO')



--PUBLICACION

/*
create table [SQLEADOS].Publicacion(
publicacion_codigo int primary key identity(12353,1),
publicacion_usuario_responsable int references [SQLEADOS].Usuario,
publicacion_rubro int references [SQLEADOS].Rubro not null,
publicacion_grado int references [SQLEADOS].GradoPrioridad not null,
publicacion_descripcion varchar(255),
publicacion_stock int not null,
publicacion_estado varchar(20) not null,
publicacion_puntaje_venta int not null default 100, -- DEFAULT 100 ES ARBITRARIO
pubicacion_putaje_compra int not null default 30, -- DEFAULT 30 ES ARBITRARIO (Cantidad de puntos que necesitas para comprarlo)
publicacion_fecha datetime not null,
publicacion_fecha_venc datetime not null,		--NUEVO CAMPO
publicacion_estado_validacion int default 0		--NUEVO CAMPO
)
*/

PRINT('MIGRANDO  Publicacion') 
go
insert into SQLEADOS.Publicacion(
			publicacion_rubro,
			publicacion_grado,
			publicacion_descripcion,
			publicacion_estado,
			publicacion_fecha,
			publicacion_fecha_venc,
			publicacion_stock,
			publicacion_usuario_responsable, 
			publicacion_estado_validacion)

select			2,  --Le asigno un rubro y grado por defecto
				2,	-- GRADO
				A.Espectaculo_Descripcion,
				A.Espectaculo_Estado,
				A.Espectaculo_Fecha, 
				A.Espectaculo_Fecha_Venc,
				count(*) - count(Cli_Nombre) -(count(Cli_Nombre)/2),  --por cada asiento comprado hay 3 registros uno en null otro con la compra y otro con la facturacion por eso esta cuenta 
				U.usuario_Id,
				CASE							--VALIDACION SI LA FECHA DE VENCIMIENTO DEL ESPECTACULO ES MAYOR QUE LA ANUNCIADA
					WHEN 
						(
						NOT(YEAR(Espectaculo_Fecha) < YEAR(Espectaculo_Fecha_Venc)
						OR (YEAR(Espectaculo_Fecha) = YEAR(Espectaculo_Fecha_Venc) AND MONTH(Espectaculo_Fecha) < MONTH(Espectaculo_Fecha_Venc))
						OR (YEAR(Espectaculo_Fecha) = YEAR(Espectaculo_Fecha_Venc) AND MONTH(Espectaculo_Fecha) = MONTH(Espectaculo_Fecha_Venc) 
							AND DAY(Espectaculo_Fecha) < DAY(Espectaculo_Fecha_Venc)))
						)
						THEN 1
					ELSE 
						0
				END
				from gd_esquema.Maestra A
				JOIN SQLEADOS.Empresa E on E.empresa_cuit = A.Espec_Empresa_Cuit 
				JOIN SQLEADOS.Usuario U on U.usuario_nombre = (LOWER(replace(A.Espec_Empresa_Razon_Social, space(1), '_')))
				group by Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Estado,Espectaculo_Fecha,Espectaculo_Fecha_Venc,usuario_Id 
				order by Espectaculo_Cod,usuario_Id
PRINT('HECHO')
--select a.Espectaculo_Cod from gd_esquema.Maestra a		 	

--UBICACION

PRINT('MIGRANDO  Ubicacion') 
insert into SQLEADOS.Ubicacion(ubicacion_asiento,ubicacion_fila,ubicacion_sin_numerar,
								ubicacion_Tipo_codigo,ubicacion_Tipo_Descripcion)
select distinct Ubicacion_Asiento, Ubicacion_Fila, 
	Ubicacion_Sin_numerar, Ubicacion_Tipo_Codigo, 
	Ubicacion_Tipo_Descripcion from gd_esquema.Maestra 
PRINT('HECHO')


	/*
create table [SQLEADOS].ubicacionXpublicacion(
ubiXpubli_ID int primary key identity,
ubiXpubli_Ubicacion int references [SQLEADOS].Ubicacion,
ubiXpubli_Publicacion int references [SQLEADOS].Publicacion,
ubiXpubli_precio int 
)
create table [SQLEADOS].Publicacion(
publicacion_codigo int primary key identity(12353,1),
publicacion_usuario_responsable int references [SQLEADOS].Usuario,
publicacion_rubro int references [SQLEADOS].Rubro not null,
publicacion_grado int references [SQLEADOS].GradoPrioridad not null,
publicacion_descripcion varchar(255),
publicacion_stock int not null,
publicacion_estado varchar(20) not null,
publicacion_puntaje_venta int not null default 100, -- DEFAULT 100 ES ARBITRARIO
pubicacion_putaje_compra int not null default 30, -- DEFAULT 30 ES ARBITRARIO (Cantidad de puntos que necesitas para comprarlo)
publicacion_fecha datetime not null,
publicacion_fecha_venc datetime not null,		--NUEVO CAMPO
publicacion_estado_validacion int default 0		--NUEVO CAMPO
)
*/


--UBICACIONXPUBLICACION
PRINT('MIGRANDO ubicacionXpublicacion') 
insert into SQLEADOS.ubicacionXpublicacion(
			ubiXpubli_Publicacion,
			ubiXpubli_Ubicacion,
			ubiXpubli_precio)
select distinct a.Espectaculo_Cod, u.ubicacion_id,a.Ubicacion_Precio from gd_esquema.Maestra a
	JOIN SQLeados.ubicacion u on u.ubicacion_asiento = a.Ubicacion_Asiento
								AND u.ubicacion_fila = a.Ubicacion_Fila
								AND u.ubicacion_sin_numerar = a.Ubicacion_Sin_numerar
								AND u.ubicacion_Tipo_codigo = a.Ubicacion_Tipo_Codigo
								AND u.ubicacion_Tipo_Descripcion = a.Ubicacion_Tipo_Descripcion
--	JOIN SQLEADOS.Publicacion p on p.publicacion_codigo = a.Espectaculo_Cod
	order by 1
PRINT('HECHO') 

--select ubiXpubli_ID, ubiXpubli_precio, ubiXpubli_Publicacion, ubiXpubli_Ubicacion from SQLEADOS.ubicacionXpublicacion
/* ITEM FACTURA Y FACTURA */


--Factura
PRINT('MIGRANDO Factura') 
GO
insert into [SQLEADOS].Factura(factura_publicacion, factura_nro, factura_empresa_cuit, 
								factura_empresa_razon_social, factura_fecha, 
								factura_total, factura_forma_de_pago)
	select distinct Espectaculo_Cod, Factura_Nro, Espec_Empresa_Cuit, Espec_Empresa_Razon_Social, Factura_Fecha, Factura_Total, Forma_Pago_Desc
	from gd_esquema.Maestra
	where Factura_Nro is not null
	order by 1
PRINT('HECHO')

--COMPRA--

PRINT('MIGRANDO Compra') 
go
insert into SQLEADOS.Compra(
			compra_factura,
			compra_cliente_tipo_documento,
			compra_cliente_numero_documento,
			compra_fecha,
			compra_cantidad,
			compra_precio,
			compra_ubiXpubli,
			compra_forma_de_pago)
select distinct m.Factura_Nro,'DNI',m.Cli_Dni,m.Compra_Fecha, m.Compra_Cantidad,x.ubiXpubli_precio,x.ubiXpubli_ID, 'Efectivo' 
from gd_esquema.Maestra m
join SQLeados.ubicacionXpublicacion x on m.Espectaculo_Cod = x.ubiXpubli_Publicacion 
join SQLeados.Ubicacion u on u.ubicacion_asiento = m.Ubicacion_Asiento and m.Ubicacion_Fila = u.ubicacion_fila and m.Ubicacion_Sin_numerar = u.Ubicacion_Sin_numerar
and m.Ubicacion_Tipo_Codigo = u.ubicacion_Tipo_codigo and u.ubicacion_Tipo_Descripcion = m.Ubicacion_Tipo_Descripcion 
where (m.Compra_Fecha is not null) and (m.Factura_Fecha is not null) and x.ubiXpubli_Ubicacion = u.ubicacion_id 
PRINT('HECHO')

PRINT('MIGRANDO ubicacionesXPublicidadComprada') 
GO
INSERT INTO [SQLEADOS].ubicacionesXPublicidadComprada
	(ubxpcomp_compra, ubxpcom_ubicacionXPublicidad)
SELECT DISTINCT c.compra_id, c.compra_ubiXpubli FROM SQLEADOS.Compra c

PRINT('HECHO')

--ItemFactura--
PRINT('MIGRANDO ItemFactura') 
GO
insert into [SQLEADOS].ItemFactura(item_factura_nro, item_factura_monto, item_factura_descripcion, item_factura_cantidad, item_factura_ubicacion)
select DISTINCT Factura_Nro, Item_Factura_Monto, Item_Factura_Descripcion, Item_Factura_Cantidad, x.ubiXpubli_ID
	from gd_esquema.Maestra m
	join SQLeados.ubicacionXpublicacion x on m.Espectaculo_Cod = x.ubiXpubli_Publicacion 
	join SQLeados.Ubicacion u on u.ubicacion_asiento = m.Ubicacion_Asiento and m.Ubicacion_Fila = u.ubicacion_fila and m.Ubicacion_Sin_numerar = u.Ubicacion_Sin_numerar
	and m.Ubicacion_Tipo_Codigo = u.ubicacion_Tipo_codigo and u.ubicacion_Tipo_Descripcion = m.Ubicacion_Tipo_Descripcion 
	where (m.Compra_Fecha is not null) and (m.Factura_Fecha is not null) and x.ubiXpubli_Ubicacion = u.ubicacion_id 
	AND Factura_Nro is not null 
	--AND up.ubiXpubli_Publicacion = m.Espectaculo_Cod
	order by Factura_Nro
PRINT('HECHO')

PRINT('Actualizando TABLA COMPRA') 	
UPDATE c 
SET c.compra_ubiXpubli = u.ubxpcomp_id
FROM SQLEADOS.Compra c
	INNER JOIN SQLEADOS.ubicacionesXPublicidadComprada u ON u.ubxpcomp_compra = c.compra_id
	PRINT('ACTUALIZACIÓN HECHA') 	


--PUNTAJE
PRINT('MIGRANDO puntaje') 
go 
insert into SQLEADOS.puntaje(punt_cliente_numero_documento, punt_cliente_tipo_documento, punt_puntaje, punt_fecha_vencimiento, punt_vencido)
select distinct c.cliente_numero_documento, c.cliente_tipo_documento, SUM(p.publicacion_puntaje_venta) as 'PUNTAJE',
	Convert(varchar(30),CONVERT(varchar(4), YEAR(com.compra_fecha+1))
			 + '-'+ 
			 CONVERT(varchar(2), MONTH(com.compra_fecha))
			  +'-'+ 
			   CONVERT(varchar(2),  DAY(com.compra_fecha)) + ' 00:00:00'
			  ,102),
		CASE
			WHEN YEAR(com.compra_fecha)+1 < YEAR(GETDATE())
					OR (YEAR(com.compra_fecha)+1 = YEAR(GETDATE()) AND MONTH(com.compra_fecha) < MONTH(GETDATE()))
					OR (YEAR(com.compra_fecha)+1 = YEAR(GETDATE()) AND MONTH(com.compra_fecha) = MONTH(GETDATE()) AND DAY(com.compra_fecha) < DAY(GETDATE()))
				THEN 0
			ELSE 1 END 
	from SQLEADOS.Cliente c
	join SQLEADOS.Compra com ON com.compra_cliente_numero_documento = c.cliente_numero_documento
								AND c.cliente_tipo_documento = com.compra_cliente_tipo_documento
	JOIN SQLEADOS.ubicacionesXPublicidadComprada ubcom ON ubcom.ubxpcomp_compra = com.compra_id
	join SQLEADOS.ubicacionXpublicacion ubxp ON ubxp.ubiXpubli_ID = ubxpcom_ubicacionXPublicidad
	join SQLEADOS.Publicacion p on p.publicacion_codigo = ubxp.ubiXpubli_Publicacion
	GROUP BY c.cliente_numero_documento, c.cliente_tipo_documento, com.compra_fecha
PRINT('HECHO')
--CANJE DE PREMIOS
PRINT('MIGRANDO canjeproducto') 
go
insert into SQLEADOS.canjeproducto (canj_costo_puntaje, canj_producto) values
(1000, 'Taza PALCONET'), 
(2000, 'Gorra PALCONET'),
(3000, 'Remera PALCONET'),
(4000, 'Campera PALCONET'),
(5000, 'Viaje a Orlando Resort');

PRINT('HECHO')

----------------------------------------------------------------------------------------------
								/** FUNCIONES, PROCEDURES Y TRIGGERS **/
----------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------
/** Esta función debe estar aqui pues será utilizada por USUARIOS mas tarde en la creacion **/
----------------------------------------------------------------------------------------------


PRINT('Comienza UPDATE CLIENTE agregando la ID de USER') 

UPDATE SQLEADOS.Cliente
SET cliente_usuario = usuario_Id 
FROM SQLEADOS.Cliente
INNER JOIN SQLEADOS.Usuario
       ON (LOWER(replace(cliente_nombre, space(1), '_'))+'_'+cliente_apellido) = usuario_nombre

PRINT('HECHO')

PRINT('Comienza UPDATE EMPRESA agregando la ID de USER') 

UPDATE SQLEADOS.Empresa
SET empresa_usuario = usuario_Id 
FROM SQLEADOS.Empresa
INNER JOIN SQLEADOS.Usuario ON usuario_nombre = (LOWER(replace(empresa_razon_social, space(1), '_'))) 

PRINT('HECHO')

PRINT('Comienza UPDATE Cambio de estado PUBLICADO a FINALIZADO si la publicación tiene una factura ya hecha') 

UPDATE publ
SET publ.publicacion_estado  = 'Finalizado'
FROM SQLEADOS.Publicacion AS publ
INNER JOIN SQLEADOS.Factura AS f
       ON f.factura_publicacion = publ.publicacion_codigo 

PRINT('HECHO')


/*
PRINT('func_coincide_fecha_creacion HECHA') 
CREATE FUNCTION SQLEADOS.func_coincide_fecha_creacion (@fechaUser datetime, @fechaBuscada datetime)
RETURNS int 
AS 
BEGIN
	IF @fechaUser = @fechaBuscada 
	BEGIN
		RETURN 1
	END
	RETURN 0
END
GO
*/

PRINT('Comienza TRIG_fecha_publicada_es_menor_a_vencimiento') 
GO
CREATE TRIGGER 
	TRIG_fecha_publicada_es_menor_a_vencimiento on [SQLEADOS].[Publicacion]
for insert as
	begin 
		declare @fecha1 datetime
		declare @fecha2 datetime
		declare @indice int
			select 
				@fecha1 = publicacion_fecha,
				@fecha2 = publicacion_fecha_venc,
				@indice = publicacion_codigo
				from SQLEADOS.Publicacion
				
				IF( 
					NOT(YEAR(@fecha1) < YEAR(@fecha2)
					OR (YEAR(@fecha1) = YEAR(@fecha2) AND MONTH(@fecha1) < MONTH(@fecha2))
					OR (YEAR(@fecha1) = YEAR(@fecha2) AND MONTH(@fecha1) = MONTH(@fecha2) AND DAY(@fecha1) < DAY(@fecha2)))
				) 
					update SQLEADOS.Publicacion
					set publicacion_estado_validacion = 1
					where 
				--		(NOT(YEAR(@fecha1) < YEAR(@fecha2)
				--		OR (YEAR(@fecha1) = YEAR(@fecha2) AND MONTH(@fecha1) < MONTH(@fecha2))
				--		OR (YEAR(@fecha1) = YEAR(@fecha2) AND MONTH(@fecha1) = MONTH(@fecha2) AND DAY(@fecha1) < DAY(@fecha2))))
				--		AND 
						publicacion_codigo=@indice;
		END
go
print('HECHO')

PRINT('Comienza TRIG_poner_nombre_bien_al_user') 
GO
CREATE TRIGGER 
	TRIG_poner_nombre_bien_al_user on [SQLEADOS].[Usuario]
for insert as
	begin 
		declare @UsuarioNombre varchar(255)
		declare @nombreOriginal varchar(255)
		declare @contaseniaOriginal varchar(255)
		declare @numero int = 0
		declare @userID int
		
			Select 
				@UsuarioNombre = usuario_nombre,
				@nombreOriginal = @UsuarioNombre,
				@contaseniaOriginal = usuario_password,
				@userID = usuario_Id
				from [SQLEADOS].Usuario u
							
				WHILE((select count(*) from [SQLEADOS].Usuario u1 
							WHERE @UsuarioNombre LIKE u1.usuario_nombre)							
								) > 1 
					select 
						@UsuarioNombre = @nombreOriginal + CONVERT(varchar(10),@numero),
						@numero = @numero +1
						from [SQLEADOS].Usuario
							where @UsuarioNombre LIKE usuario_nombre
							order by usuario_Id DESC
				--update [SQLEADOS].Usuario
				--	set usuario_password = HASHBYTES('SHA2_256', @contaseniaOriginal)
				--	Where usuario_nombre=@nombreOriginal AND usuario_Id = @userID;
				if(@numero>0) 
					update [SQLEADOS].Usuario
						set usuario_nombre = @UsuarioNombre
						where 
							usuario_nombre=@nombreOriginal AND usuario_Id = @userID;
		END
		go
print('HECHO')

/*
PRINT('Comienza TRIG_si_tiene_factura_entonces_es_publicacion_finalizada') 
GO
CREATE TRIGGER 
	TRIG_si_tiene_factura_entonces_es_publicacion_finalizada on [SQLEADOS].[Publicacion]
for insert as
	begin 
		declare @publicacionNombre varchar(255)
		declare @publicacionID int
			
			SELECT
				@publicacionID = publicacion_codigo,
				@publicacionNombre = publicacion_descripcion
				FROM SQLEADOS.Publicacion
				
				
						UPDATE SQLEADOS.Publicacion
						SET publicacion_estado = 'Finalizado'
							WHERE publicacion_codigo = @publicacionID
		END
		go
print('HECHO')

*/

--------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------
														/*  PROCEDURES */	
--------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------


print('Creacion de PROCEDURES')
print('')
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[listarFuncionalidades]
as begin
select funcionalidad_descripcion from [SQLeados].Funcionalidad
end
go

print('PROCEDURE [listarFuncionalidades]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[existeRol] (@nombre nvarchar(30))
as
begin
declare @existe int
set @existe = (select count(rol_Id) from [SQLeados].Rol where Rol_nombre = @nombre) 
return @existe
end
go

print('PROCEDURE [existeRol]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[crearRolNuevo] (@nombre nvarchar(30))
as
begin
insert into [SQLeados].Rol(Rol_nombre, rol_estado)
values(@nombre,1)
end
go

print('PROCEDURE [crearRolNuevo]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[codigoRol] (@nombre nvarchar(30))
as
begin
declare @cod int
set @cod = (select rol_Id from [SQLeados].rol where Rol_nombre = @nombre)
return @cod
end
go

print('PROCEDURE [codigoRol]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[crearFuncionalidad] (@codigoRol int, @codigoFunc int)
as
begin
insert into [SQLeados].FuncionalidadXRol(funcionalidadXRol_rol, funcionalidadXRol_funcionalidad)
values(@codigoRol, @codigoFunc)
end
go

print('PROCEDURE [crearFuncionalidad]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SQLeados].[codigoFuncionalidad] (@nombre nvarchar(370))
as
begin
declare @cod int
set @cod = (select funcionalidad_Id from [SQLeados].Funcionalidad where funcionalidad_descripcion = @nombre)
return @cod
end
GO

print('PROCEDURE [codigoFuncionalidad]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cargarRoles] 
as
begin
select Rol_nombre from [SQLeados].Rol
end
GO

print('PROCEDURE [cargarRoles]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [SQLeados].[rolHabilitado] (@nombre nvarchar(30))
as
begin
declare @resultado bit
set @resultado = (select rol_estado from [SQLeados].Rol where Rol_nombre = @nombre)
return @resultado
end
GO

print('PROCEDURE [rolHabilitado]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[FuncionalidadesPorRol] (@Rol nvarchar(30))
as
begin
select funcionalidad_descripcion from [SQLeados].FuncionalidadXRol join [SQLeados].Rol ON funcionalidadXRol_rol = rol_Id join [SQLeados].Funcionalidad on
funcionalidad_Id = funcionalidadXRol_funcionalidad
where Rol_nombre = @Rol
end
GO

print('PROCEDURE [FuncionalidadesPorRol]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[modificarRol] (@nombre nvarchar(30), @anterior nvarchar(30))
as
begin
update [SQLeados].Rol set Rol_nombre = @nombre
where Rol_nombre = @anterior
end
go

print('PROCEDURE [modificarRol]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[eliminarFuncionalidades] (@rol int)
as
begin
delete from [SQLeados].FuncionalidadXRol
where funcionalidadXRol_rol = @rol
end
go

print('PROCEDURE [eliminarFuncionalidades]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cargarRolesHabilitados] 
as
begin
select Rol_nombre from [SQLeados].Rol where rol_estado = 1
end
go



print('PROCEDURE [cargarRolesHabilitados]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[inhabilitarRol] (@codigo int)
as
begin
update [SQLeados].Rol
set rol_estado = 0
where rol_Id = @codigo
end
go

print('PROCEDURE [inhabilitarRol]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[inhabilitarRolPorUsuario] (@codigo int)
as
begin
delete from [SQLeados].UsuarioXRol
where usuarioXRol_rol = @codigo
end
go

print('PROCEDURE [inhabilitarRolPorUsuario]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[ValidarUsuario] (@Username nvarchar(30))
as
begin
declare @Resultado int

set @Resultado =CAST(
   CASE WHEN EXISTS(SELECT usuario_nombre FROM [SQLeados].Usuario where usuario_nombre like @Username)
    THEN 1 
   ELSE 0 
   END 
AS int)
return @Resultado
end
go

print('PROCEDURE [ValidarUsuario]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[estaBloqueado] (@Username nvarchar(30))
as 
begin
declare @bloqueado bit
set @bloqueado = (select usuario_estado from [SQLeados].Usuario where usuario_nombre = @Username)
return @bloqueado
end
go

print('PROCEDURE [estaBloqueado]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SQLeados].[intentosFallidos] (@Username nvarchar(30))
as 
begin
declare @intentos int
set @intentos = (select Usuario_intentos from [SQLeados].Usuario where usuario_nombre = @Username)
return @intentos
end
go

print('PROCEDURE [intentosFallidos]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[ValidarContra] (@Username nvarchar(30), @Password nvarchar(30))
as
begin
declare @Resultado int
declare @pre varbinary(100)
set @pre = HASHBYTES('SHA2_256',cast(@Password as varchar(30)))
set @Resultado =CAST(
   CASE WHEN EXISTS(SELECT usuario_nombre FROM [SQLeados].Usuario where usuario_nombre like @Username and Usuario_password like @pre)
    THEN 1 
   ELSE 0 
   END 
AS int)
return @Resultado
end
go

print('PROCEDURE [ValidarContra]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[resetearIntentoFallidos] (@Username nvarchar(30))
as 
begin
update [SQLeados].Usuario
set Usuario_intentos = 0
where usuario_nombre = @Username
end
go

print('PROCEDURE [resetearIntentoFallidos]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[agregarIntentoFallidos] (@Username nvarchar(30))
as 
begin
update [SQLeados].Usuario
set Usuario_intentos = (select Usuario_intentos from [SQLeados].Usuario where usuario_nombre = @Username) + 1
where usuario_nombre = @Username
end
go

print('PROCEDURE [agregarIntentoFallidos]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[bloquearUsuario] (@Username nvarchar(30))
as 
begin
update [SQLeados].Usuario
set usuario_estado = 0
where usuario_nombre = @Username
end
go

print('PROCEDURE [bloquearUsuario]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[esAdministrador] (@Username nvarchar(30))
as
begin
declare @resultado bit
set @resultado = (select usuario_administrador from [SQLeados].Usuario where Usuario.usuario_nombre = @Username)
return @resultado
end
go

print('PROCEDURE [esAdministrador]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[Nombreroles] (@Username nvarchar(30))
as
begin
select Rol_nombre
from [SQLeados].UsuarioXRol join [SQLeados].Rol on usuarioXRol_rol = rol_Id
join [SQLeados].Usuario on usuarioXRol_usuario = usuario_Id
where Usuario.usuario_nombre = @Username and rol_estado = 1
end
go

print('PROCEDURE [Nombreroles]: OK')

/****** Object:  StoredProcedure [PERSISTIENDO].[actualizarContra]    Script Date: 26/06/2016 19:30:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[actualizarContra] (@user nvarchar(30), @pass nvarchar(30))
as
begin
update [SQLeados].Usuario 
set Usuario_password = (HASHBYTES('SHA2_256',cast (@pass as varchar)))
where usuario_nombre = @user
end
GO



print('PROCEDURE [actualizarContra]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[habilitarRol] (@nombre nvarchar(30))
as
begin
update [SQLeados].Rol
set rol_estado = 1
where Rol_nombre = @nombre
end
go

print('PROCEDURE [habilitarRol]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cargarNuevoUser]
as
begin
select cliente_numero_documento, Cliente_apellido, Cliente_nombre, cliente_email
from [SQLeados].Cliente join [SQLeados].Usuario on usuario_Id = cliente_usuario
where Usuario.usuario_estado = 1
end
GO

print('PROCEDURE [cargarNuevoUser]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[crearNuevoUserPorRegistroOABM] (@user nvarchar(30), @pass nvarchar(30), @rol nvarchar(30))
as
begin
insert into [SQLeados].Usuario (usuario_nombre, usuario_password) values
(@user, HASHBYTES('SHA2_256',cast (@pass as varchar)))
insert into [SQLeados].UsuarioXRol (usuarioXRol_usuario, usuarioXRol_rol)
select TOP 1 u.usuario_Id, r.rol_Id from SQLEADOS.Usuario u, SQLEADOS.Rol r 
	where r.rol_nombre in (@rol) AND u.usuario_nombre LIKE @user+'%'
	order by u.usuario_Id DESC
end
GO

print('PROCEDURE [crearNuevoUserPorRegistroOABM]: OK')


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[crearNuevoCliente] (@nombre nvarchar(255), @apellido nvarchar(255), @tipoDoc nvarchar(5), @fechaNacimiento nvarchar(255), @fechaCreacion nvarchar(255), @mail nvarchar(255), @cuit nvarchar(20), @numeroDocumento nvarchar(50), @telefono nvarchar(255), @tarjeta nvarchar(255))
as
begin
insert into [SQLeados].Cliente (cliente_nombre, cliente_apellido, cliente_cuit, cliente_datos_tarjeta, cliente_email, cliente_fecha_creacion, cliente_fecha_nacimiento, cliente_numero_documento, cliente_telefono, cliente_tipo_documento
	, cliente_usuario
	)
 values
(@nombre, @apellido, @cuit, @tarjeta, @mail, @fechaCreacion, @fechaNacimiento,CONVERT(numeric(18,0), @numeroDocumento), @telefono, @tipoDoc
	, (Select top 1 usuario_Id from SQLEADOS.Usuario order by usuario_Id DESC))

end
GO

print('PROCEDURE [crearNuevoCliente]: OK')

/*
select * from SQLEADOS.Cliente where cliente_nombre LIKE 'dam%'
select usuario_nombre, c.usuarioXRol_rol, r.rol_nombre  from SQLEADOS.Usuario u 
	JOIN SQLEADOS.UsuarioXRol c ON c.usuarioXRol_usuario = u.usuario_Id 
	JOIN SQLEADOS.Rol r ON r.rol_Id = c.usuarioXRol_rol order by usuario_Id desc
	*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[obtenerPKdelUltimoClienteIngresado]
as
begin
	SELECT TOP 1 cliente_tipo_documento, cliente_numero_documento  
		FROM SQLEADOS.Cliente JOIN SQLEADOS.Usuario ON usuario_Id = cliente_id order by usuario_Id DESC
return 
end
go

print('PROCEDURE [obtenerPKdelUltimoClienteIngresado]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLEADOS].[crearNuevoDomicilioDeCliente] (@calle nvarchar(255), @numeroCalle int, @piso int, @dto nvarchar(10), @localidad nvarchar(255), @codPostal nvarchar(255), @tipoDoc nvarchar(5), @numeroDoc  nvarchar(50))
as
begin
insert into [SQLEADOS].Domicilio (domicilio_calle, domicilio_numero, domicilio_piso, domicilio_dto, domicilio_localidad, domicilio_codigo_postal, domicilio_cliente_numero_documento, domicilio_cliente_tipo_documento)
 values
(@calle, @numeroCalle, @piso, @dto, @localidad, @codPostal, @numeroDoc, @tipoDoc)
end
GO

print('PROCEDURE [crearNuevoDomicilioDeCliente]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLEADOS].[crearNuevoDomicilioDeEmpresa] (@calle nvarchar(255), @numeroCalle int, @piso int, @dto nvarchar(10), @localidad nvarchar(255), @codPostal nvarchar(255))
as
begin
insert into [SQLEADOS].Domicilio (domicilio_calle, domicilio_numero, domicilio_piso, domicilio_dto, domicilio_localidad, domicilio_codigo_postal)
 values
(@calle, @numeroCalle, @piso, @dto, @localidad, @codPostal)
end
GO

print('PROCEDURE [crearNuevoDomicilioDeEmpresa]: OK')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[llenarGrillaABMCliente]
as
begin
	SELECT u.usuario_Id as 'ID', c.cliente_nombre as 'Nombre', c.cliente_apellido as 'Apellido', cliente_tipo_documento as 'Tipo documento', cliente_numero_documento as 'Número', c.cliente_email as 'EMail'
		FROM SQLEADOS.Cliente c JOIN SQLEADOS.Usuario u ON usuario_Id = cliente_id where usuario_estado = 1 order by usuario_Id ASC
return 
end
go

print('PROCEDURE [llenarGrillaABMCliente]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[completarGriddClienteAPartirDe]'))
    DROP proc SQLEADOS.[completarGriddClienteAPartirDe]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[completarGriddClienteAPartirDe]
as
begin
	SELECT u.usuario_Id, c.cliente_nombre, c.cliente_apellido, cliente_tipo_documento, cliente_numero_documento, c.cliente_email
		FROM SQLEADOS.Cliente c JOIN SQLEADOS.Usuario u ON usuario_Id = cliente_id order by usuario_Id DESC
return 
end
go

print('PROCEDURE [completarGriddClienteAPartirDe]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[darDeBajaUserCliente]'))
    DROP proc SQLEADOS.[darDeBajaUserCliente]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[darDeBajaUserCliente] (@user int)
as
begin
	UPDATE SQLEADOS.Usuario
		SET usuario_estado = 0
			where	usuario_Id = (SELECT cliente_usuario FROM SQLEADOS.Cliente where cliente_id = @user)
end
go

print('PROCEDURE [darDeBajaUserCliente]: OK')



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[repeticionDeCUILEnCliente]'))
    DROP proc SQLEADOS.[repeticionDeCUILEnCliente]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[repeticionDeCUILEnCliente] (@cuil nvarchar(50))
as
begin
	SELECT 
		CASE
			WHEN (SELECT COUNT(*) FROM SQLEADOS.Cliente where cliente_cuit like @cuil) > 0 then 1
			else 0 END
		FROM SQLEADOS.Cliente
	return
end
go

print('PROCEDURE [repeticionDeCUILEnCliente]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[repeticionDeTIPODOCYNumeroEnCliente]'))
    DROP proc SQLEADOS.[repeticionDeTIPODOCYNumeroEnCliente]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[repeticionDeTIPODOCYNumeroEnCliente] (@tipo nvarchar(50), @numero nvarchar(20))
as
begin
	SELECT 
		CASE
			WHEN (SELECT COUNT(*) FROM SQLEADOS.Cliente where cliente_tipo_documento like @tipo AND cliente_numero_documento = CONVERT(numeric(18,0), @numero)) > 0   then 1
			else 0 END
		FROM SQLEADOS.Cliente
	return
end
go



print('PROCEDURE [repeticionDeTIPODOCYNumeroEnCliente]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[repeticionDeMail]'))
    DROP proc SQLEADOS.[repeticionDeMail]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[repeticionDeMail] (@mail nvarchar(100))
as
begin
	SELECT 
		CASE
			WHEN (SELECT COUNT(*) FROM SQLEADOS.Cliente where cliente_email like @mail) > 0   then 1
			else 0 END
		FROM SQLEADOS.Cliente
	return
end
go

print('PROCEDURE [repeticionDeMail]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[obtenerDatosRelevantesParaModificarCliente]'))
    DROP proc SQLEADOS.[obtenerDatosRelevantesParaModificarCliente]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[obtenerDatosRelevantesParaModificarCliente] (@userID int)
as
begin
	SELECT 
		cliente_nombre as 'NOMBRE', cliente_apellido  as 'APELLIDO', cliente_datos_tarjeta  as 'DATOS_TARJETA', 
		cliente_telefono as 'TELEFONO', domicilio_calle as 'DOM_CALLE', domicilio_numero as 'DOM_NUMERO', 
		domicilio_piso as 'DOM_PISO', domicilio_dto as 'DOM_DEPARTAMENTO', domicilio_localidad as 'DOM_LOCALIDAD', 
		domicilio_codigo_postal as 'COD_POSTAL', usuario_estado as 'USER_ESTADO'  
		FROM [SQLEADOS].Cliente 
		JOIN [SQLEADOS].Usuario ON usuario_Id = cliente_usuario AND usuario_Id = @userID
		JOIN [SQLEADOS].Domicilio ON domicilio_cliente_tipo_documento = cliente_tipo_documento 
			AND domicilio_cliente_numero_documento = cliente_numero_documento
return
end
go



print('PROCEDURE [obtenerDatosRelevantesParaModificarCliente]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.cargarHistorialCliente1Pagina'))
    DROP proc SQLEADOS.[cargarHistorialCliente1Pagina]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cargarHistorialCliente1Pagina] (@userID int, @tamanioPagina int, @paginasAnteriores int)
as
begin
	SELECT TOP (@tamanioPagina)
		com.compra_id as 'ID', com.compra_fecha as 'FECHA',  
		p.publicacion_descripcion as 'Evento', u.ubicacion_asiento as 'Asiento', u.ubicacion_fila as 'Fila', 
		compra_forma_de_pago as 'Forma de pago', com.compra_cantidad as 'Cantidad',
		(uxp.ubiXpubli_precio)*com.compra_cantidad as 'Precio total en $'
		
		FROM [SQLEADOS].Cliente c
		JOIN [SQLEADOS].Usuario us ON us.usuario_Id = @userID AND us.usuario_Id = c.cliente_usuario
		JOIN [SQLEADOS].Compra com ON com.compra_cliente_numero_documento = c.cliente_numero_documento 
							AND compra_cliente_tipo_documento = c.cliente_tipo_documento
		JOIN [SQLEADOS].ubicacionXpublicacion uxp ON uxp.ubiXpubli_ID = com.compra_ubiXpubli
		JOIN [SQLEADOS].Ubicacion u on u.ubicacion_id = uxp.ubiXpubli_Ubicacion
		JOIN [SQLEADOS].Publicacion p on p.publicacion_codigo = uxp.ubiXpubli_Publicacion

return
end
go

print('PROCEDURE [cargarHistorialCliente1Pagina]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cantidadTotalDeComprasDeCliente]'))
    DROP proc SQLEADOS.cantidadTotalDeComprasDeCliente

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cantidadTotalDeComprasDeCliente] (@userID int)
as
begin
	SELECT
		COUNT(com.compra_id) as 'ID'		
		FROM [SQLEADOS].Cliente c
		JOIN [SQLEADOS].Usuario us ON us.usuario_Id = @userID AND us.usuario_Id = c.cliente_usuario
		JOIN [SQLEADOS].Compra com ON com.compra_cliente_numero_documento = c.cliente_numero_documento 
							AND compra_cliente_tipo_documento = c.cliente_tipo_documento
		JOIN [SQLEADOS].ubicacionXpublicacion uxp ON uxp.ubiXpubli_ID = com.compra_ubiXpubli
		JOIN [SQLEADOS].Ubicacion u on u.ubicacion_id = uxp.ubiXpubli_Ubicacion
		JOIN [SQLEADOS].Publicacion p on p.publicacion_codigo = uxp.ubiXpubli_Publicacion
return
end
go

print('PROCEDURE [cantidadTotalDeComprasDeCliente]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cargarHistorialClientePaginada]'))
    DROP proc SQLEADOS.[cargarHistorialClientePaginada]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cargarHistorialClientePaginada] (@userID int, @tamanioPagina int, @paginasAnteriores int)
as
begin
	SELECT TOP (@tamanioPagina)
		com.compra_id as 'ID', com.compra_fecha as 'FECHA',  
		p.publicacion_descripcion as 'Evento', u.ubicacion_asiento as 'Asiento', u.ubicacion_fila as 'Fila', 
		compra_forma_de_pago as 'Forma de pago', com.compra_cantidad as 'Cantidad',
		(uxp.ubiXpubli_precio)*com.compra_cantidad as 'Precio total en $'
		
		FROM [SQLEADOS].Cliente c
		JOIN [SQLEADOS].Usuario us ON us.usuario_Id = @userID AND us.usuario_Id = c.cliente_usuario
		JOIN [SQLEADOS].Compra com ON com.compra_cliente_numero_documento = c.cliente_numero_documento 
							AND compra_cliente_tipo_documento = c.cliente_tipo_documento
		JOIN [SQLEADOS].ubicacionXpublicacion uxp ON uxp.ubiXpubli_ID = com.compra_ubiXpubli
		JOIN [SQLEADOS].Ubicacion u on u.ubicacion_id = uxp.ubiXpubli_Ubicacion
		JOIN [SQLEADOS].Publicacion p on p.publicacion_codigo = uxp.ubiXpubli_Publicacion
			WHERE com.compra_id NOT IN (
				SELECT TOP (@paginasAnteriores)
					com.compra_id
				FROM [SQLEADOS].Cliente c
					JOIN [SQLEADOS].Usuario us ON us.usuario_Id = @userID AND us.usuario_Id = c.cliente_usuario
					JOIN [SQLEADOS].Compra com ON com.compra_cliente_numero_documento = c.cliente_numero_documento 
							AND compra_cliente_tipo_documento = c.cliente_tipo_documento
					JOIN [SQLEADOS].ubicacionXpublicacion uxp ON uxp.ubiXpubli_ID = com.compra_ubiXpubli
					JOIN [SQLEADOS].Ubicacion u on u.ubicacion_id = uxp.ubiXpubli_Ubicacion
					JOIN [SQLEADOS].Publicacion p on p.publicacion_codigo = uxp.ubiXpubli_Publicacion
				)
return
end
go



print('PROCEDURE [cargarHistorialClientePaginada]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[obtenerTotalPublicacionesDeEmpresa]'))
    DROP proc SQLEADOS.[obtenerTotalPublicacionesDeEmpresa]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[obtenerTotalPublicacionesDeEmpresa] (@userID int)
as
begin
	SELECT
		COUNT(p.publicacion_codigo) as 'ID'		
		FROM [SQLEADOS].Empresa e
		JOIN [SQLEADOS].Usuario us ON us.usuario_Id = @userID AND us.usuario_Id = e.empresa_usuario
		JOIN [SQLEADOS].Publicacion p on p.publicacion_usuario_responsable = us.usuario_Id
return
end
go

print('PROCEDURE [obtenerTotalPublicacionesDeEmpresa]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[obtenerPublicacionesParaCompra]'))
    DROP proc SQLEADOS.[obtenerPublicacionesParaCompra]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[obtenerPublicacionesParaCompra] (@userID int)
as
begin
	SELECT
		COUNT(p.publicacion_codigo) as 'ID'		
		FROM [SQLEADOS].Empresa e
		JOIN [SQLEADOS].Usuario us ON us.usuario_Id = @userID AND us.usuario_Id = e.empresa_usuario
		JOIN [SQLEADOS].Publicacion p on p.publicacion_usuario_responsable = us.usuario_Id
return
end
go

print('PROCEDURE [obtenerPublicacionesParaCompra]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[obtenerDatosDeUbicacionDeEspectaculoDeseada]'))
    DROP proc SQLEADOS.[obtenerDatosDeUbicacionDeEspectaculoDeseada]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[obtenerDatosDeUbicacionDeEspectaculoDeseada] (@espectaculo nvarchar(255), @asiento int, @fila nvarchar(10), @fecha nvarchar(255), @categoria nvarchar(255))
as
begin
	SELECT
		p.publicacion_descripcion as 'Espectáculo', u.ubicacion_asiento as 'Asiento', u.ubicacion_fila as 'Fila',
		r.rubro_descripcion as 'Categoría', p.publicacion_fecha_venc as 'Fecha', ux.ubiXpubli_precio as 'Precio'	
		FROM [SQLEADOS].Publicacion p
		JOIN [SQLEADOS].ubicacionXpublicacion ux ON p.publicacion_codigo = ux.ubiXpubli_Publicacion
		JOIN [SQLEADOS].Ubicacion u ON u.ubicacion_id = ux.ubiXpubli_Ubicacion 
		
			--					AND		u.ubicacion_fila LIKE @fila AND
							--			u.ubicacion_asiento = @asiento
		JOIN [SQLEADOS].Rubro r ON r.rubro_id = p.publicacion_rubro
			where p.publicacion_fecha_venc = '2018-12-12 0:00:00.000' -- AND r.rubro_descripcion LIKE @categoria
return
end
go

print('PROCEDURE [obtenerDatosDeUbicacionDeEspectaculoDeseada]: OK')


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[cargarDatosDeCompra]'))
    DROP proc SQLEADOS.[cargarDatosDeCompra]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[cargarDatosDeCompra] (@userID int, @espectaculo nvarchar(255), @asiento int, @fila nvarchar(10), @fecha nvarchar(255), @categoria nvarchar(255))
as
begin
	SELECT
		p.publicacion_descripcion as 'Espectáculo', u.ubicacion_asiento as 'Asiento', u.ubicacion_fila as 'Fila',
		r.rubro_descripcion as 'Categoría', p.publicacion_fecha_venc as 'Fecha', ux.ubiXpubli_precio as 'Precio'	
		FROM [SQLEADOS].Publicacion p
		JOIN [SQLEADOS].ubicacionXpublicacion ux ON p.publicacion_codigo = ux.ubiXpubli_Publicacion
		JOIN [SQLEADOS].Ubicacion u ON u.ubicacion_id = ux.ubiXpubli_Ubicacion 
		
			--					AND		u.ubicacion_fila LIKE @fila AND
							--			u.ubicacion_asiento = @asiento
		JOIN [SQLEADOS].Rubro r ON r.rubro_id = p.publicacion_rubro
			where p.publicacion_fecha_venc = '2018-12-12 0:00:00.000' -- AND r.rubro_descripcion LIKE @categoria
end
go

print('PROCEDURE [cargarDatosDeCompra]: OK')

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[obtenerPublicacionesParaCompra]'))
    DROP proc SQLEADOS.[obtenerPublicacionesParaCompra]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[obtenerPublicacionesParaCompra] (@userID int)
 --EN REALIDAD ES ID DE PUBLICACION, PERO LO DEJO PARA QUE NO ROMPA CON EL CÓDIGO YA HECHO ASÍ AHORRO TIEMPO
as
begin
	SELECT
		u.ubicacion_asiento as 'Asiento', u.ubicacion_fila as 'Piso', up.ubiXpubli_precio as 'Precio en $', g.grado_comision		
		FROM [SQLEADOS].Publicacion p
		JOIN [SQLEADOS].ubicacionXpublicacion  up ON up.ubiXpubli_Publicacion = p.publicacion_codigo
		JOIN [SQLEADOS].Ubicacion u ON u.ubicacion_id = up.ubiXpubli_Ubicacion
		JOIN [SQLEADOS].GradoPrioridad g ON g.grado_id = p.publicacion_grado
			where p.publicacion_codigo = 15555 AND p.publicacion_estado LIKE 'Publicada'
return
end
go

print('PROCEDURE [obtenerPublicacionesParaCompra]: OK')


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SQLEADOS.[ActualizarPublicacion]'))
    DROP proc SQLEADOS.[ActualizarPublicacion]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SQLeados].[ActualizarPublicacion] (@id int, @estado nvarchar(255), @rubro int, @grado int, @fecha nvarchar(255), @puntaje int )
as
begin
	UPDATE SQLEADOS.Publicacion
		SET publicacion_estado = @estado
			where	publicacion_codigo = @id
	UPDATE SQLEADOS.Publicacion
		SET publicacion_grado = @grado
			where	publicacion_codigo = @id
	UPDATE SQLEADOS.Publicacion
		SET publicacion_rubro = @rubro
			where	publicacion_codigo = @id
	UPDATE SQLEADOS.Publicacion
		SET publicacion_fecha_venc = @fecha
			where	publicacion_codigo = @id
	UPDATE SQLEADOS.Publicacion
		SET publicacion_puntaje_venta = @puntaje
			where	publicacion_codigo = @id
end
go

print('PROCEDURE [ActualizarPublicacion]: OK')

print('PROCEDURES HECHOS')


-- HARDCODEAR LAS CONTRAS DE LAS EMPRESAS
print('Actualización de contraseñas para pruebas')
UPDATE SQLEADOS.Usuario
SET usuario_password = HASHBYTES('SHA2_256', '1234')
WHERE usuario_Id <= 2 OR usuario_Id = 85

print('ACTUALIZACIÓN PARA PRUEBA HECHA')

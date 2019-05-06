use master
go

create database dbpedidos
go

use dbpedidos
go

create table categorias
(
	idcategoria int identity,
	nombre varchar(50) not null,
	descripcion varchar(100)

	constraint pk_categorias primary key(idcategoria),
	constraint ak_nombre_categorias unique(nombre)
)
go

create table productos
(
	idproducto int identity,
	idcategoria int not null,
	nombre varchar(60)not null,
	presentacion varchar(80),
	precio decimal(10,2) not null default 0

	constraint pk_productos primary key(idproducto),
	constraint fk_idcategoria_productos foreign key(idcategoria) references categorias(idcategoria)
)
go

create table clientes
(
	idcliente int identity,
	dni char(8) not null,
	nombres varchar(60) not null,
	apellidos varchar(100) not null,

	constraint pk_clientes primary key(idcliente),
	constraint ak_dni_clientes unique(dni)
)
go

create table pedidos
(
	idpedido int identity,
	idcliente int not null,
	fecha date,

	constraint pk_pedidos primary key(idpedido),
	constraint fk_idcliente foreign key (idcliente) references clientes(idcliente)
)
go

create table detalle_pedidos
(
	idpedido int not null,
	idproducto int not null,
	precio decimal(10,2) not null,
	cantidad int not null

	constraint pk_detalle_pedidos primary key(idpedido,idproducto),
	constraint fk_idpedido_detalle_pedidos foreign key(idpedido) references pedidos(idpedido),
	constraint fk_idproducto_detalle_pedidos foreign key(idproducto) references productos(idproducto)
)
go


use dbpedidos
go

SET IDENTITY_INSERT dbo.categorias ON
insert into dbo.categorias (idcategoria,nombre) values
(1,'Frutas y verduras'),
(2,'Carnes, aves y pescados'),
(3,'Lácteos y huevos'),
(4,'Bebidas')
SET IDENTITY_INSERT dbo.categorias OFF
Go


SET IDENTITY_INSERT dbo.productos ON
insert into dbo.productos(idproducto,idcategoria,nombre,presentacion,precio) values
(1,1,'Naranja para Jugo','5un = 1Kg (aprox)',1.29),
(2,1,'Palta Fuerte','3un = 1Kg (aprox)',6.69),
(3,1,'Piña Golden','1un = 2.2Kg (aprox)',6.49),
(4,2,'Guiso Tierno de Res','Bandeja = 3un (aprox)',21.90),
(5,2,'Bisteck de Res','Bandeja = 3un (aprox)',28.59),
(6,3,'Yogurt Bebible GLORIA Fresa', 'Galonera 2Kg',9.79)
SET IDENTITY_INSERT dbo.productos OFF
Go

SET IDENTITY_INSERT dbo.clientes ON
insert into dbo.clientes(idcliente,dni,nombres,apellidos) values
(1,'88888881','Linus','Torvalds'),
(2,'88888882','Satya','Nadella'),
(3,'88888883','Elon','Musk'),
(4,'88888884','James','Gosling')
SET IDENTITY_INSERT dbo.clientes OFF
Go

SET IDENTITY_INSERT dbo.pedidos ON
insert into dbo.pedidos(idpedido,idcliente,fecha)values
(1,2,getdate()),
(2,1,getdate())
SET IDENTITY_INSERT dbo.pedidos OFF
Go

insert into dbo.detalle_pedidos(idpedido,idproducto,precio,cantidad) values
(1,3, 6.49, 5),
(1,5,28.59,2),
(1,1,1.29,10),
(2,6,9.79,2),
(2,4,21.90,1)
Go

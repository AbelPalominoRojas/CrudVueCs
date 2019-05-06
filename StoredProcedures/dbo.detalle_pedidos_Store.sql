
Use dbpedidos
Go

IF OBJECT_ID('dbo.USP_detalle_pedidos_Insert', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_detalle_pedidos_Insert
Go
CREATE PROCEDURE dbo.USP_detalle_pedidos_Insert
@idpedido int,
@idproducto int,
@precio decimal(10,2),
@cantidad int
as
INSERT [dbo].[detalle_pedidos]
(
idpedido,
idproducto,
precio,
cantidad
)
values
(
@idpedido,
@idproducto,
@precio,
@cantidad
)
Go

IF OBJECT_ID('dbo.USP_detalle_pedidos_Update', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_detalle_pedidos_Update
Go
CREATE PROCEDURE dbo.USP_detalle_pedidos_Update
@idpedido int,
@idproducto int,
@precio decimal(10,2),
@cantidad int
as
UPDATE [dbo].[detalle_pedidos] SET 
precio = @precio,
cantidad = @cantidad
where
idpedido = @idpedido and 
idproducto = @idproducto
Go

IF OBJECT_ID('dbo.USP_detalle_pedidos_SelectAll', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_detalle_pedidos_SelectAll
Go
CREATE PROCEDURE dbo.USP_detalle_pedidos_SelectAll
@idpedido int
as
SELECT
dp.idpedido,
dp.idproducto,
dp.precio,
dp.cantidad,
p.nombre,
p.presentacion,
p.precio precioproducto,
p.idcategoria,
c.nombre categoria
FROM [dbo].[detalle_pedidos] dp
inner join [dbo].[productos] p
on dp.idproducto = p.idproducto
inner join [dbo].[categorias] c
on p.idcategoria= c.idcategoria
where dp.idpedido = @idpedido
Go 

IF OBJECT_ID('dbo.USP_detalle_pedidos_SelectById', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_detalle_pedidos_SelectById
Go
CREATE PROCEDURE dbo.USP_detalle_pedidos_SelectById
@idpedido int,
@idproducto int
as
SELECT
idpedido,
idproducto,
precio,
cantidad
FROM [dbo].[detalle_pedidos]
where
idpedido = @idpedido and 
idproducto = @idproducto
Go

IF OBJECT_ID('dbo.USP_detalle_pedidos_Delete', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_detalle_pedidos_Delete
Go
CREATE PROCEDURE dbo.USP_detalle_pedidos_Delete
@idpedido int,
@idproducto int
as
DELETE FROM [dbo].[detalle_pedidos]
where
idpedido = @idpedido and 
idproducto = @idproducto
Go


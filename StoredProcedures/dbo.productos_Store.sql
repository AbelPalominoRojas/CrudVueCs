
Use dbpedidos
Go

IF OBJECT_ID('dbo.USP_productos_Insert', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_productos_Insert
Go
CREATE PROCEDURE dbo.USP_productos_Insert
@idproducto int OUT,
@idcategoria int,
@nombre varchar(60),
@presentacion varchar(80),
@precio decimal(10,2)
as
INSERT [dbo].[productos]
(
idcategoria,
nombre,
presentacion,
precio
)
values
(
@idcategoria,
@nombre,
@presentacion,
@precio
)
Go

IF OBJECT_ID('dbo.USP_productos_Update', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_productos_Update
Go
CREATE PROCEDURE dbo.USP_productos_Update
@idproducto int,
@idcategoria int,
@nombre varchar(60),
@presentacion varchar(80),
@precio decimal(10,2)
as
UPDATE [dbo].[productos] SET 
idcategoria = @idcategoria,
nombre = @nombre,
presentacion = @presentacion,
precio = @precio
where
idproducto = @idproducto
Go

IF OBJECT_ID('dbo.USP_productos_SelectAll', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_productos_SelectAll
Go
CREATE PROCEDURE dbo.USP_productos_SelectAll
as
SELECT
p.idproducto,
p.idcategoria,
p.nombre,
p.presentacion,
p.precio,
a.nombre categoria
FROM [dbo].[productos] p
inner join [dbo].[categorias] a
on p.idcategoria= a.idcategoria
Go 

IF OBJECT_ID('dbo.USP_productos_SelectById', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_productos_SelectById
Go
CREATE PROCEDURE dbo.USP_productos_SelectById
@idproducto int
as
SELECT
idproducto,
idcategoria,
nombre,
presentacion,
precio
FROM [dbo].[productos]
where
idproducto = @idproducto
Go

IF OBJECT_ID('dbo.USP_productos_Delete', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_productos_Delete
Go
CREATE PROCEDURE dbo.USP_productos_Delete
@idproducto int
as
DELETE FROM [dbo].[productos]
where
idproducto = @idproducto
Go

IF OBJECT_ID('dbo.USP_productos_SelectByIdCategoria', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_productos_SelectAll
Go
CREATE PROCEDURE dbo.USP_productos_SelectByIdCategoria
@idcategoria int
as
SELECT
p.idproducto,
p.idcategoria,
p.nombre,
p.presentacion,
p.precio,
a.nombre categoria
FROM [dbo].[productos] p
inner join [dbo].[categorias] a
on p.idcategoria= a.idcategoria
where p.idcategoria = @idcategoria
Go
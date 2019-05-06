
Use dbpedidos
Go

IF OBJECT_ID('dbo.USP_categorias_Insert', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_categorias_Insert
Go
CREATE PROCEDURE dbo.USP_categorias_Insert
@idcategoria int OUT,
@nombre varchar(50),
@descripcion varchar(100)
as
INSERT [dbo].[categorias]
(
nombre,
descripcion
)
values
(
@nombre,
@descripcion
)
Go

IF OBJECT_ID('dbo.USP_categorias_Update', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_categorias_Update
Go
CREATE PROCEDURE dbo.USP_categorias_Update
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(100)
as
UPDATE [dbo].[categorias] SET 
nombre = @nombre,
descripcion = @descripcion
where
idcategoria = @idcategoria
Go

IF OBJECT_ID('dbo.USP_categorias_SelectAll', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_categorias_SelectAll
Go
CREATE PROCEDURE dbo.USP_categorias_SelectAll
as
SELECT
idcategoria,
nombre,
descripcion
FROM [dbo].[categorias]
Go 

IF OBJECT_ID('dbo.USP_categorias_SelectById', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_categorias_SelectById
Go
CREATE PROCEDURE dbo.USP_categorias_SelectById
@idcategoria int
as
SELECT
idcategoria,
nombre,
descripcion
FROM [dbo].[categorias]
where
idcategoria = @idcategoria
Go

IF OBJECT_ID('dbo.USP_categorias_Delete', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_categorias_Delete
Go
CREATE PROCEDURE dbo.USP_categorias_Delete
@idcategoria int
as
DELETE FROM [dbo].[categorias]
where
idcategoria = @idcategoria
Go


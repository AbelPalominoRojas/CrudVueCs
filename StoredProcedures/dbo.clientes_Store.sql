
Use dbpedidos
Go

IF OBJECT_ID('dbo.USP_clientes_Insert', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_clientes_Insert
Go
CREATE PROCEDURE dbo.USP_clientes_Insert
@idcliente int OUT,
@dni char(8),
@nombres varchar(60),
@apellidos varchar(100)
as
INSERT [dbo].[clientes]
(
dni,
nombres,
apellidos
)
values
(
@dni,
@nombres,
@apellidos
)
Go

IF OBJECT_ID('dbo.USP_clientes_Update', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_clientes_Update
Go
CREATE PROCEDURE dbo.USP_clientes_Update
@idcliente int,
@dni char(8),
@nombres varchar(60),
@apellidos varchar(100)
as
UPDATE [dbo].[clientes] SET 
dni = @dni,
nombres = @nombres,
apellidos = @apellidos
where
idcliente = @idcliente
Go

IF OBJECT_ID('dbo.USP_clientes_SelectAll', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_clientes_SelectAll
Go
CREATE PROCEDURE dbo.USP_clientes_SelectAll
as
SELECT
idcliente,
dni,
nombres,
apellidos
FROM [dbo].[clientes]
Go 

IF OBJECT_ID('dbo.USP_clientes_SelectById', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_clientes_SelectById
Go
CREATE PROCEDURE dbo.USP_clientes_SelectById
@idcliente int
as
SELECT
idcliente,
dni,
nombres,
apellidos
FROM [dbo].[clientes]
where
idcliente = @idcliente
Go

IF OBJECT_ID('dbo.USP_clientes_Delete', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_clientes_Delete
Go
CREATE PROCEDURE dbo.USP_clientes_Delete
@idcliente int
as
DELETE FROM [dbo].[clientes]
where
idcliente = @idcliente
Go


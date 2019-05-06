
Use dbpedidos
Go

IF OBJECT_ID('dbo.USP_pedidos_Insert', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_pedidos_Insert
Go
CREATE PROCEDURE dbo.USP_pedidos_Insert
@idpedido int OUT,
@idcliente int,
@fecha date
as
INSERT [dbo].[pedidos]
(
idcliente,
fecha
)
values
(
@idcliente,
@fecha
)

set @idpedido = @@IDENTITY
Go

IF OBJECT_ID('dbo.USP_pedidos_Update', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_pedidos_Update
Go
CREATE PROCEDURE dbo.USP_pedidos_Update
@idpedido int,
@idcliente int,
@fecha date
as
UPDATE [dbo].[pedidos] SET 
idcliente = @idcliente,
fecha = @fecha
where
idpedido = @idpedido
Go

IF OBJECT_ID('dbo.USP_pedidos_SelectAll', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_pedidos_SelectAll
Go
CREATE PROCEDURE dbo.USP_pedidos_SelectAll
as
SELECT
p.idpedido,
p.idcliente,
p.fecha,
c.nombres,
c.apellidos,
c.dni
FROM [dbo].[pedidos] p
inner join [dbo].[clientes] c
on p.idcliente= c.idcliente
Go 

IF OBJECT_ID('dbo.USP_pedidos_SelectById', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_pedidos_SelectById
Go
CREATE PROCEDURE dbo.USP_pedidos_SelectById
@idpedido int
as
SELECT
idpedido,
idcliente,
fecha
FROM [dbo].[pedidos]
where
idpedido = @idpedido
Go

IF OBJECT_ID('dbo.USP_pedidos_Delete', 'P') IS NOT NULL
   DROP PROCEDURE dbo.USP_pedidos_Delete
Go
CREATE PROCEDURE dbo.USP_pedidos_Delete
@idpedido int
as
DELETE FROM [dbo].[pedidos]
where
idpedido = @idpedido
Go


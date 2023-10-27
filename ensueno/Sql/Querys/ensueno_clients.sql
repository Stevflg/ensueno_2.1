--Perfumería Ensueño.

create database ENSUENO
go

use ENSUENO
go

--Tabla de Clientes con sus campos.
create table CLIENTS
(
    client_id int not null identity(1,1) primary key,
    client_id_card nvarchar(20) unique,
    client_name nvarchar(50),
    client_last_name nvarchar(50),
    client_phone nvarchar(20),
    client_address nvarchar(100),
    client_active bit default 1,
	date_time datetime default current_timestamp
)
go

--Restricciones.

alter table [dbo].[CLIENTS] add constraint unique_client_id_card unique ([client_id_card])
go

--Procedimientos almacenados.

--Crear cliente.

create procedure client_create(
    @client_id_card nvarchar(20),
    @client_name nvarchar(50),
    @client_last_name nvarchar(50),
    @client_phone nvarchar(20),
    @client_address nvarchar(100)
	)
as
begin
    insert into CLIENTS(client_id_card,client_name,client_last_name,client_phone,client_address)
    values
        (@client_id_card, @client_name, @client_last_name, @client_phone, @client_address)
end
go

--Leer clientes activos.

create procedure clients_read
as
begin
    select c.client_id as 'ID', c.client_id_card as 'Cédula', c.client_name as 'Nombre', c.client_last_name as 'Apellido', c.client_phone as 'Teléfono', c.client_address as 'Dirección',
	c.date_time as 'FechaRegistro'
    from CLIENTS as c
    where client_active=1
end
go

--Actualizar cliente.
create procedure client_update
    @client_id int,
    @client_id_card nvarchar(20),
    @client_name nvarchar(50),
    @client_last_name nvarchar(50),
    @client_phone nvarchar(20),
    @client_address nvarchar(100)
as
begin
    update CLIENTS
    set client_id_card=@client_id_card, client_name=@client_name, client_last_name=@client_last_name, client_phone=@client_phone, client_address=@client_address
	where client_id=@client_id
end
go

--Cambiar estado del cliente a desactivado.
create procedure client_deactivate
    @client_id int
as
begin
    update CLIENTS
    set client_active=0
	where client_id=@client_id
end
go

--Cambiar estado del cliente a activado.
create procedure client_activate
    @client_id int
as
begin
    update CLIENTS
    set client_active=1
	where client_id=@client_id
end
go

--Leer historial de clientes.

create procedure clients_read_history
as
begin
    select c.client_id as 'ID', c.client_id_card as 'Cédula', c.client_name as 'Nombre', c.client_last_name as 'Apellido', c.client_phone as 'Teléfono', c.client_address as 'Dirección'
    from CLIENTS as c
    where client_active=0
end
go

--Autocompletar por nombre.
create procedure clients_read_by_name
    @client_name nvarchar(50)
as
begin
    select c.client_id as 'ID', c.client_id_card as 'Cédula', c.client_name as 'Nombre', c.client_last_name as 'Apellido', c.client_phone as 'Teléfono', c.client_address as 'Dirección'
    ,c.date_time as 'Fecha de registro'
	from CLIENTS as c
    where client_name like '%'+@client_name+'%' and client_active=1
end
go

--Autocompletar por apellido.
create procedure clients_read_by_last_name
    @client_last_name nvarchar(50)
as
begin
    select c.client_id as 'ID', c.client_id_card as 'Cédula', c.client_name as 'Nombre', c.client_last_name as 'Apellido', c.client_phone as 'Teléfono', c.client_address as 'Dirección'
    ,c.date_time as 'Fecha de registro'
	from CLIENTS as c
    where client_last_name like '%'+@client_last_name+'%' and client_active=1
end
go

--Validar cédula en clientes.
create procedure clients_validate_id_card
    @id_card nvarchar(20)
as
begin
    select *
    from CLIENTS
    where client_id_card=@id_card
end
go

--Validar actualizar cédula en clientes.
create procedure clients_validate_update_id_card
    @id int,
    @id_card nvarchar(20)
as
begin
    select *
    from CLIENTS
    where client_id=@id and client_id_card=@id_card
end
go
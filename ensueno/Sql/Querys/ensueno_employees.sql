--Perfumería Ensueño.

create database ENSUENO
go

use ENSUENO
go

--Tabla de Empleados con sus campos.
create table EMPLOYEES
(
    employee_id int not null identity(1,1) primary key,
    employee_id_card nvarchar(20)unique,
    employee_name nvarchar(50),
    employee_last_name nvarchar(50),
    employee_phone nvarchar(20),
    employee_address nvarchar(100),
    employee_user nvarchar(20)unique,
    employee_admin bit,
    employee_active bit default 1,
	date_time datetime default current_timestamp
)
go

--Restricciones.

alter table [dbo].[EMPLOYEES] add constraint unique_employee_id_card unique ([employee_id_card])
go
alter table [dbo].[EMPLOYEES] add constraint unique_employee_user unique ([employee_user])
go

--Procedimientos almacenados.

--Crear empleado.

create procedure employee_create
    @employee_id_card nvarchar(20),
    @employee_name nvarchar(50),
    @employee_last_name nvarchar(50),
    @employee_phone nvarchar(20),
    @employee_address nvarchar(100),
    @employee_user nvarchar(20),
    @employee_admin bit
as
begin
    insert into EMPLOYEES(employee_id_card,employee_name,employee_last_name,employee_phone, employee_address,employee_user,employee_admin)
    values
        (@employee_id_card, @employee_name, @employee_last_name, @employee_phone, @employee_address, @employee_user, @employee_admin)
end
go

exec employee_create @employee_id_card='001-1107', @employee_name='David', @employee_last_name='Ramos', @employee_phone='77771010', @employee_address='Managua', @employee_user='dav7', @employee_admin=1
go
exec employee_create @employee_id_card='001-1140', @employee_name='Julieta', @employee_last_name='Ponce', @employee_phone='55442233', @employee_address='Granada', @employee_user='ponc3', @employee_admin=0
go
exec employee_create @employee_id_card='001-1111', @employee_name='Steven', @employee_last_name='Flores', @employee_phone='75753040', @employee_address='Granada', @employee_user='st3v', @employee_admin=1
go

--Crear usuarios.

--Empleado David Ramos. *Admin*.

create login dav7 with password = '123'
go

exec [sys].[sp_addsrvrolemember] 'dav7', 'sysadmin'
go

--Empleado Julieta Ponce.

create login ponc3 with password = '567'
go

exec [sys].[sp_addsrvrolemember] 'ponc3', 'sysadmin'
go

--Empleado Steven Flores. *Admin*.

create login st3v with password = '123'
go

exec [sys].[sp_addsrvrolemember] 'st3v', 'sysadmin'
go

--Leer empleados activos.

create procedure employees_read
as
begin
    select e.employee_id as 'ID', e.employee_id_card as 'Cédula', e.employee_name as 'Nombre', e.employee_last_name as 'Apellido', e.employee_phone as 'Teléfono', e.employee_address as 'Dirección', e.employee_user as 'Usuario', e.employee_admin as 'Administrador'
    ,e.date_time as 'FechaRegistro'
	from EMPLOYEES as e
    where employee_active=1
end
go

--Validar por user.

create procedure employee_validate_user
    @employee_user nvarchar(20)
as
begin
    select *
    from EMPLOYEES
    where employee_user=@employee_user
end
go

--Actualizar empleado.
create procedure employee_update
    @employee_id int,
    @employee_id_card nvarchar (20),
    @employee_name nvarchar(50),
    @employee_last_name nvarchar(50),
    @employee_phone nvarchar(20),
    @employee_address nvarchar(100),
    @employee_admin bit
as
begin
    update EMPLOYEES
    set employee_id_card=@employee_id_card, employee_name=@employee_name, employee_last_name=@employee_last_name, employee_phone=@employee_phone, employee_address=@employee_address, employee_admin=@employee_admin
	where employee_id=@employee_id
end
go

--Cambiar estado del empleado a desactivado.
create procedure employee_deactivate
    @employee_id int
as
begin
    update EMPLOYEES
    set employee_active=0
	where employee_id=@employee_id
end
go

--Cambiar estado del empleado a activado.
create procedure employee_activate
    @employee_id int
as
begin
    update EMPLOYEES
    set employee_active=1
	where employee_id=@employee_id
end
go

--Leer historial de empleados.

create procedure employees_read_history
as
begin
    select e.employee_id as 'ID', e.employee_id_card as 'Cédula', e.employee_name as 'Nombre', e.employee_last_name as 'Apellido', e.employee_phone as 'Teléfono', e.employee_address as 'Dirección', e.employee_user as 'Usuario', e.employee_admin as 'Administrador'
    from EMPLOYEES as e
    where employee_active=0
end
go

--Autocompletar por nombre.
create procedure employees_read_by_name
    @employee_name nvarchar(50)
as
begin
    select e.employee_id as 'ID', e.employee_id_card as 'Cédula', e.employee_name as 'Nombre', e.employee_last_name as 'Apellido', e.employee_phone as 'Teléfono', e.employee_address as 'Dirección', e.employee_user as 'Usuario', e.employee_admin as 'Administrador'
    ,e.date_time as 'Fecha de registro'
	from EMPLOYEES as e
    where employee_name like '%'+@employee_name+'%' and employee_active=1
end
go


--Autocompletar por apellido.
create procedure employees_read_by_last_name
    @employee_last_name nvarchar(50)
as
begin
    select e.employee_id as 'ID', e.employee_id_card as 'Cédula', e.employee_name as 'Nombre', e.employee_last_name as 'Apellido', e.employee_phone as 'Teléfono', e.employee_address as 'Dirección', e.employee_user as 'Usuario', e.employee_admin as 'Administrador'
    ,e.date_time as 'Fecha de registro'
	from EMPLOYEES as e
    where employee_last_name like '%'+@employee_last_name+'%' and employee_active=1
end
go

--Validar cédula en empleados.
create procedure employees_validate_id_card
    @id_card nvarchar(20)
as
begin
    select *
    from EMPLOYEES
    where employee_id_card=@id_card
end
go

--Validar actualizar cédula en empleados.
create procedure employees_validate_update_id_card
    @id int,
    @id_card nvarchar(20)
as
begin
    select *
    from EMPLOYEES
    where employee_id=@id and employee_id_card=@id_card
end
go
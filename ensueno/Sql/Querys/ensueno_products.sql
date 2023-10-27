--Perfumería Ensueño.

create database ENSUENO
go

use ENSUENO
go

--Tabla de Productos con sus campos.

create table PRODUCTS
(
    product_id int not null identity(1,1) primary key,
    product_name nvarchar(50) unique,
    product_stock int,
    product_unit_price decimal,
    product_image image,
    product_active bit default 1,
	date_time datetime default current_timestamp
)
go

--Restricciones.

alter table [dbo].[PRODUCTS] add constraint unique_product_name unique ([product_name])
go

--Procedimientos almacenados.

--Crear producto.

create procedure product_create
    @product_name nvarchar(50),
    @product_stock int,
    @product_unit_price decimal,
    @product_image image
as
begin
    insert into PRODUCTS(product_name,product_stock,product_unit_price,product_image)
    values
        (@product_name, @product_stock, @product_unit_price, @product_image)
end

go

--Leer productos activos.

--create procedure products_read
--as
--begin
--    select p.product_id as 'ID', p.product_name as 'Nombre', p.product_stock as 'Existencia', p.product_unit_price as 'Precio unitario'
--    from PRODUCTS as p
--    where product_active=1
--end
--go

--Leer imagen del producto.

create procedure product_read_image
    @product_id int
as
begin
    select p.product_image
    from PRODUCTS as p
    where product_id=@product_id
end
go

--Actualizar producto.
create procedure product_update
    @product_id int,
    @product_name nvarchar(50),
    @product_stock int,
    @product_unit_price decimal,
    @product_image image
as
begin
    update PRODUCTS
    set product_name=@product_name, product_stock=@product_stock, product_unit_price=@product_unit_price, product_image=@product_image
	where product_id=@product_id
end
go

--Cambiar estado del producto a desactivado.
create procedure product_deactivate
    @product_id int
as
begin
    update PRODUCTS
    set product_active=0
	where product_id=@product_id
end
go

--Cambiar estado del producto a activado.
create procedure product_activate
    @product_id int
as
begin
    update PRODUCTS
    set product_active=1
	where product_id=@product_id
end
go

create procedure products_read
as
begin
    select p.product_id as 'ID', p.product_name as 'Nombre', p.product_stock as 'Existencia', p.product_unit_price as 'PrecioUnitario'
    ,p.date_time as 'FechaRegistro'
	from PRODUCTS as p
    where product_active=1
end
go



--Leer historial de productos.

create procedure products_read_history
as
begin
    select p.product_id as 'ID', p.product_name as 'Nombre', p.product_stock as 'Existencia', p.product_unit_price as 'Precio unitario'
    from PRODUCTS as p
    where product_active=0
end
go

--Autocompletar por nombre.
create procedure products_read_by_name
    @product_name nvarchar(50)
as
begin
    select p.product_id as 'ID', p.product_name as 'Nombre', p.product_stock as 'Existencia', p.product_unit_price as 'Precio unitario',
	p.date_time as 'Fecha de registro'
    from PRODUCTS as p
    where product_name like '%'+@product_name+'%' and product_active=1
end
go

--Validar nombre en productos.
create procedure products_validate_name
    @product_name nvarchar(50)
as
begin
    select *
    from PRODUCTS
    where product_name=@product_name
end
go

--Validar actualizar nombre en productos.
create procedure products_validate_update_name
    @product_id int,
    @product_name nvarchar(50)
as
begin
    select *
    from PRODUCTS
    where product_id=@product_id and product_name=@product_name
end
go
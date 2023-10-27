go
use ENSUENO
go
create table INVOICE_DETAIL(
invoice_id int references INVOICE(invoice_id),
product_id int references PRODUCTS(product_id),
units int not null,
price money not null,
subtotal as units*price,
iva as units*price*0.15,
total as units*price + (units*price*0.15),
invoice_detail_active bit default 1
)

--Procedimiento para insertar registro
go
create procedure invoice_detail_create(
@invoice_id int,
@product_id int,
@units int
)as begin
declare @S as int 
select @S=[product_stock]from PRODUCTS where product_active=1 and product_id=@product_id
if(@S>@units)
BEGIN 
declare @Price as MONEY
select @Price =[product_unit_price] from PRODUCTS where product_active=1 and product_id=@product_id
insert into INVOICE_DETAIL(invoice_id,product_id,units,price) Values(@invoice_id,@product_id,@units,@Price)
declare @Stock as int
select @Stock=[product_stock]from PRODUCTS  where product_active=1 and product_id=@product_id
declare @New_Stock as int
set @New_Stock= @stock-@units
update PRODUCTS set product_stock=@New_Stock where product_active=1 and product_id=@product_id;
end
if (@S<@units) print 'Stock insuficiente para realizar esta compra';
else 
print 'Este producto no existe en inventario';
end

go
--procedimiento para actualizar registros
create procedure invoice_detail_update(
@invoice_id int,
@product_id int,
@units int
)as begin
declare @Stock_P as int
select @Stock_P =[product_stock] from PRODUCTS where product_active=1 and product_id=@product_id
declare @Units_I_D as int
select @Units_I_D=[units]from INVOICE_DETAIL where invoice_detail_active=1 and invoice_id=@invoice_id and product_id=@product_id
declare @New_Stock as int
declare @New_Stock_Product as int
IF(@units>@Units_I_D and @units>0)
begin
set @New_Stock=@units-@Units_I_D
set @New_Stock_Product=@Stock_P-@New_Stock
update INVOICE_DETAIL set units=@units where invoice_detail_active=1 and invoice_id=@invoice_id and product_id=@product_id
update PRODUCTS set product_stock=@New_Stock_Product where product_active=1 and product_id=@product_id;
end
if(@units<@Units_I_D and @units>0)
begin
set @New_Stock=@Units_I_D-@units
set @New_Stock_Product=@Stock_P+@New_Stock
update INVOICE_DETAIL set units=@units where invoice_detail_active=1 and invoice_id=@invoice_id AND product_id=@product_id
update PRODUCTS set product_stock=@New_Stock_Product where product_active=1 and product_id=@product_id; end
if(@units>@Stock_P)
print'La cantidad Ingresada es mayor al stock en inventario';
if(@units<0)
print'El Valor ingresado tiene que ser mayor que 0';
end

go
--Procedimiento para eliminar registro
create procedure invoice_detail_delete(
@Invoice_id int,
@Product_id int
)as begin
Declare @units_I_D as int 
select @units_I_D =[units]from INVOICE_DETAIL where invoice_detail_active=1 and invoice_id=@Invoice_id and product_id=@Product_id
update INVOICE_DETAIL SET invoice_detail_active=0 WHERE invoice_id=@Invoice_id AND product_id=@Product_id
declare @Stock_Prod as int 
select @Stock_Prod=[product_stock]from PRODUCTS where product_active=1 and product_id=@Product_id
declare @New_Stock as int
set @New_Stock=@Stock_Prod+@units_I_D
update PRODUCTS set product_stock=@New_Stock where product_active=1 and product_id=@Product_id
end

--Procedimiento para restaurar Registro
go
create procedure invoice_detail_restore(
@Invoice_id int,
@Product_id int
)as begin
declare @Restore_Stock as int 
select @Restore_Stock=[units]from INVOICE_DETAIL where invoice_detail_active=0 and invoice_id=@Invoice_id and product_id=@Product_id
declare @Stock_Product as int 
select @Stock_Product=[product_stock] from PRODUCTS where product_active=1 and product_id=@Product_id
declare @New_Stock_Product AS INT
Update INVOICE_DETAIL set invoice_detail_active=1 where invoice_id=@Invoice_id and product_id=@Product_id
set @New_Stock_Product=@Stock_Product-@Restore_Stock
update PRODUCTS set product_stock=@New_Stock_Product where product_active=1 and product_id=@Product_id
end
go
--Procedimiento para leer registros con i
create procedure invoice_detail_read_by_id(
@Invoice_id int
)as begin
select ID.invoice_id AS 'Id Factura', ID.product_id AS 'Id Producto', P.product_name as 'Nombre Producto',
cast(round(ID.price,2) as decimal(20,2)) AS 'Precio',ID.units AS 'Unidades',cast(round(ID.subtotal,2) as decimal (20,2)) AS 'Subtotal',
cast(round(ID.iva,2)as decimal(20,2)) AS 'IVA',cast(round(total,2) as decimal(20,2)) AS 'Total'
from INVOICE_DETAIL ID
inner join PRODUCTS P on ID.product_id=P.product_id
where ID.invoice_detail_active=1 and ID.invoice_id=@Invoice_id
END
go
--Procedimiento para leer Historial de facturas eliminadas
create procedure invoice_detail_read_history_by_Id(
@Invoice_id int
)as begin
select ID.invoice_id AS 'Id Factura', ID.product_id AS 'Id Producto', P.product_name as 'Nombre Producto',
cast(round(ID.price,2) as decimal(20,2)) AS 'Precio',ID.units AS 'Unidades',cast(round(ID.subtotal,2) as decimal (20,2)) AS 'Subtotal',
cast(round(ID.iva,2)as decimal(20,2)) AS 'IVA',cast(round(total,2) as decimal(20,2)) AS 'Total'
from INVOICE_DETAIL ID
inner join PRODUCTS P on ID.product_id=P.product_id
where ID.invoice_detail_active=0 and ID.invoice_id=@Invoice_id
end
go
--Procedimiento para obtener total factura
create procedure invoice_detail_total(
@Invoice_id int
)as begin
SELECT cast(round(SUM(total),2)as decimal (20,2)) as 'Total'from INVOICE_DETAIL where invoice_detail_active=1 AND invoice_id=@Invoice_id 
end
go
--Procedimiento para listar Productos
create procedure invoce_detail_product_list
as begin 
select product_id as 'Id Producto',product_name as 'Nombre',product_stock as 'Stock',
product_unit_price as 'Precio Unitario'
from PRODUCTS where product_active=1
end

go
--Procedimiento para Buscar producto por id
create procedure invoice_detail_search_product(
@Product_id int
)as begin
select product_id as 'Id_Producto',product_name as 'Nombre',product_stock as 'Stock',
product_unit_price as 'Precio Unitario'
from PRODUCTS where product_active=1 and product_id=@Product_id
end

--Consulta para obtener ultimo id
SELECT max(invoice_id) as 'Valor ID' FROM INVOICE
select * from PRODUCTS
go
create procedure val_exist_product_invoice_detail_by_id(
@Invoice_id int,
@Product_id int
)as begin 
select * from INVOICE_DETAIL where invoice_id=@Invoice_id and product_id=@Product_id
end
--Validacion de unidades
go
create procedure  Validate_Units(
@Invoice_id int,
@Product_id int
)as begin 
select units from INVOICE_DETAIL where invoice_id=@Invoice_id and product_id=@Product_id
end

--Buscar producto en detalle facturas
go

create procedure invoice_detail_search_product_name(
@Invoice_id int,
@Product_name nvarchar(50)
)as begin
select ID.invoice_id AS 'Id Factura', ID.product_id AS 'Id Producto', P.product_name as 'Nombre Producto',
cast(round(ID.price,2) as decimal(20,2)) AS 'Precio',ID.units AS 'Unidades',cast(round(ID.subtotal,2) as decimal (20,2)) AS 'Subtotal',
cast(round(ID.iva,2)as decimal(20,2)) AS 'IVA',cast(round(total,2) as decimal(20,2)) AS 'Total'
from INVOICE_DETAIL ID
inner join PRODUCTS P on ID.product_id=P.product_id
where ID.invoice_detail_active=1 and ID.invoice_id=@Invoice_id and P.product_name like '%'+@Product_name+'%'
END
go
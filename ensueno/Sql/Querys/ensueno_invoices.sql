--Creacion  de tabla facturas
use ENSUENO
create table INVOICE
(
invoice_id int identity primary key,
employee_id int references EMPLOYEES(Employee_id),
client_id int references CLIENTS(client_id),
active bit default 1,
date_time DATETIME Default current_timestamp
)

--Procedimiento para crear factura
go
create procedure invoice_create(
@Employe_id int,
@Client_id int
)as begin
insert into INVOICE (employee_id,client_id) values (@Employe_id,@Client_id)
end

--Procedimiento para actualizar
go
create procedure invoice_update(
@invoice_id int,
@Client_id int
)as begin
update INVOICE set client_id=@Client_id where invoice_id=@invoice_id
end

go
--Procedimiento para eliminar
create procedure invoice_delete
(
@invoice_id int
)as begin
update INVOICE set active=0 where invoice_id=@invoice_id
end
go

--Procedimiento para autocompletado
create procedure invoice_search_client
as begin
select c.client_id as 'ID', c.client_id_card as 'Cédula',CONCAT(c.client_name, ' ' ,c.client_last_name )as 'Nombre Completo', c.client_phone as 'Teléfono', c.client_address as 'Dirección'
    from CLIENTS as c
	end

--Procedimiento para leer facturas
go
create procedure invoice_Read
as begin
select I.invoice_id as 'Id Factura',I.employee_id as 'Id Empleado',concat(E.employee_name,' ',E.employee_last_name) as 'Nombre Empleado',
I.client_id as 'Id Cliente', concat(C.client_name,' ',C.client_last_name) AS 'Nombre Cliente',
I.date_time as 'Fecha de emision' from INVOICE I
inner join CLIENTS C ON I.client_id=C.client_id
inner join EMPLOYEES E ON I.employee_id=E.employee_id
where active=1
END


--Lectura del Historial
go
create procedure invoice_Read_history
as begin
select I.invoice_id as 'Id Factura',I.employee_id as 'Id Empleado',concat(E.employee_name,' ',E.employee_last_name) as 'Nombre Empleado',
I.client_id as 'Id Cliente', concat(C.client_name,' ',C.client_last_name) AS 'Nombre Cliente',
I.date_time as 'Fecha de emision' from INVOICE I
inner join CLIENTS C ON I.client_id=C.client_id
inner join EMPLOYEES E ON I.employee_id=E.employee_id
where active=0
END
go
--Restaurar factura
create procedure invoice_active
(
@invoice_id int
)as begin
update INVOICE set active=1 where invoice_id=@invoice_id
end
go

--Obtencion del ultimo id
SELECT max(invoice_id) as 'Valor ID' FROM INVOICE
go

create procedure Search_invoice_id
(@Invoice_id int)
as begin
select I.invoice_id as 'Id Factura',I.employee_id as 'Id Empleado',concat(E.employee_name,' ',E.employee_last_name) as 'Nombre Empleado',
I.client_id as 'Id Cliente', concat(C.client_name,' ',C.client_last_name) AS 'Nombre Cliente',
I.date_time as 'Fecha de emision' from INVOICE I
inner join CLIENTS C ON I.client_id=C.client_id
inner join EMPLOYEES E ON I.employee_id=E.employee_id
where active=1 and I.invoice_id = @Invoice_id
END
go
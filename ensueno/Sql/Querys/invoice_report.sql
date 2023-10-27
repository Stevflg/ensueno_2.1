use ENSUENO
go
create procedure Report_invoice_detail_by_id(
    @Invoice_id int
)
as
begin
    select ID.invoice_id AS 'IdFactura', I.employee_id AS 'IdEmpleado', Concat(E.employee_name,' ' ,E.employee_last_name) as 'NombreEmpleado',
        I.client_id as 'IdCliente', concat(C.client_name,' ',C.client_last_name) as 'NombreCliente',
        ID.product_id AS 'IdProducto', P.product_name as 'NombreProducto',
        concat ('C$ ',cast(round(ID.price,2) as decimal(20,2))) AS 'Precio', ID.units AS 'Unidades',
        concat ('C$ ',cast(round(ID.subtotal,2) as decimal (20,2))) AS 'Subtotal',
        concat('C$ ',cast(round(ID.iva,2)as decimal(20,2))) AS 'IVA', concat('C$ ',cast(round(total,2) as decimal(20,2))) AS 'Total'
    from INVOICE_DETAIL ID
        inner join PRODUCTS P on ID.product_id=P.product_id
        inner join INVOICE I on ID.invoice_id=I.invoice_id
        inner join EMPLOYEES E on I.employee_id=E.employee_id
        inner join CLIENTS C on I.client_id=C.client_id
    where ID.invoice_detail_active=1 and ID.invoice_id=@Invoice_id
END
go

create Procedure Report_invoice_detail_total(
    @Invoice_id int
)
as
begin
    Select concat('C$ ',cast(round(SUM(total),2)as decimal (20,2))) as 'Total_detalle'
    from INVOICE_DETAIL
    where invoice_detail_active=1 AND invoice_id=@Invoice_id
end
go

--exec Report_invoice_detail_by_id 1
--exec Report_invoice_detail_total 1
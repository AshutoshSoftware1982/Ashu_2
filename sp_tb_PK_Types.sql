Alter PROCEDURE sp_tb_PK_Types
(

@CustomerID varchar(299),
@CS_Pack varchar(299),
@Pack_Desc varchar(299),
@Pack_Qty int,
@Pack_Cat varchar(299),
@UOM varchar(299),
@EDI_UOM varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO Pack_type(CustomerID,CS_Pack,Pack_Desc,Pack_Qty,Pack_Cat,UOM,EDI_UOM)VALUES(@CustomerID,@CS_Pack,@Pack_Desc,@Pack_Qty,@Pack_Cat,@UOM,@EDI_UOM)
						
        END
End







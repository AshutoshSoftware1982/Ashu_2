Create PROCEDURE Sp_Customer_InsertUpdateDetete
 (
 @id         INTEGER,
 @Customer_name    VARCHAR(10),
 @Customer_Address     VARCHAR(10),
 @EmailID      DECIMAL(10, 2),
 @Mobile          INTEGER,
 @Gender VARCHAR(20),
 @StatementType NVARCHAR(20) = ''
 )
                                          
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO Customer
                        (
						 
                         CustomerName,
                         CustomerAddress,
                         EmailID,
                         Mobile_Number,
						 Gender
						 )
            VALUES     ( 
			             
                         @Customer_name ,
                         @Customer_Address,
                         @EmailID,
						 @Mobile,
                         @Gender
						)
        END

      IF @StatementType = 'Select'
        BEGIN
            SELECT *
            FROM   Customer
        END

      IF @StatementType = 'Update'
        BEGIN
            UPDATE Customer
            SET    
                   CustomerName =@Customer_name,
                   CustomerAddress = @Customer_Address,
				   EmailID=@EmailID,
                   Mobile_Number=@Mobile,
				   Gender=@Gender
            WHERE  CustomerID = @id
        END
      ELSE IF @StatementType = 'Delete'
        BEGIN
            DELETE FROM Customer
            WHERE  CustomerID = @id
        END
  END
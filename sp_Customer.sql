CREATE PROCEDURE sp_Customer
(
@CustomerID INT,
@CustomerName varchar(299),
@CustomerAddress varchar(299),
@EmailID varchar(299),
@Mobile_Number varchar(299),
@Gender varchar(299),
@CustomerAddress2 varchar(299),
@CustomerAddress3 varchar(299),
@Country varchar(299),
@State varchar(299),
@City varchar(299),
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
						 Gender,
						 CustomerAddress2,
						 CustomerAddress3,
						 Country,
						 State,
						 City
						 )
            VALUES     ( 
			             @CustomerName,
						 @CustomerAddress,
						 @EmailID,
						 @Mobile_Number,
						 @Gender,
						 @CustomerAddress2,
						 @CustomerAddress3,
						 @Country,
						 @State,
						 @City
						)
        END
End







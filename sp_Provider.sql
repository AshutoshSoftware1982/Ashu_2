CREATE PROCEDURE sp_Provider
(
@ProviderName varchar(299),
@ProviderAddress varchar(299),
@Gender varchar(299),
@EmailID varchar(299),
@Phone_Number varchar(299),
@Country varchar(299),
@State varchar(299),
@City varchar(299),
@StatementType VARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO Provider
                        (
						 ProviderName,
                         ProviderAddress,
						 Gender,
						 EmailID,
						 Phone_Number,
						 Country,
						 State,
						 City
						 )
            VALUES     ( 
			             
                         @ProviderName,
                         @ProviderAddress,
						 @Gender,
						 @EmailID,
						 @Phone_Number,
						 @Country,
						 @State,
						 @City
						)
        END
End



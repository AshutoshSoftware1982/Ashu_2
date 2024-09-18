Create PROCEDURE sp_register
(

@User_Type varchar(299),
@UserName varchar(299),
@UPassword varchar(299),
@UCPassword varchar(299),
@CompanyID INT,
@Country_Name  varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO New_User
                        (
						 
                         User_Type,
                         UserName,
                         UPassword,
						 UCPassword,
						 CompanyID,
						 Country_Name
						 )
            VALUES     ( 
			             
                         @User_Type,
                         @UserName,
                         @UPassword,
						 @UCPassword,
                         @CompanyID,
						 @Country_Name
						)
        END
End



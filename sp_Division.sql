CREATE PROCEDURE sp_Division
(
@CustomerID int,
@DivisionName varchar(299),
@Country varchar(299),
@State varchar(299),
@City varchar(299),
@Fin_Entity varchar(299),
@Div_Group varchar(299),
@Division_Group varchar(299),
@Address1 varchar(299),
@Address2 varchar(299),
@Zip varchar(299),
@Phone_Number varchar(299),
@Fax varchar(299),
@ManufacturerID varchar(299),
@G_Code varchar(299),
@Days_To_Start DateTime,
@Days_To_Cancel DateTime,
@Duns_No varchar(299),
@Base_Currency varchar(299),
@RN varchar(299),
@Email_Sender_Account varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO Division
                        (
						CustomerID,DivisionName,Country,State,City,Fin_Entity,Div_Group,Division_Group,Address1,Address2,Zip,Phone_Number,Fax,ManufacturerID,G_Code,Days_To_Start,Days_To_Cancel,Duns_No,Base_Currency,RN,Email_Sender_Account						 )
            VALUES     ( 
			             @CustomerID,@DivisionName,@Country,@State,@City,@Fin_Entity,@Div_Group,@Division_Group,@Address1,@Address2,@Zip,@Phone_Number,@Fax,@ManufacturerID,@G_Code,@Days_To_Start,@Days_To_Cancel,@Duns_No,@Base_Currency,@RN,@Email_Sender_Account
						)
        END
End







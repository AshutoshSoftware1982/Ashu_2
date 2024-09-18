CREATE PROCEDURE sp_Package_Category
(
@Package_ID INT,
@ClientID INT,
@Packet_Code varchar(299),
@Packcat_Desc varchar(299),
@Time_Created date,
@Last_Mod date,
@Mod_User varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO Package_Category
                        (
						 ClientID,
						 Packet_Code,
						 Packcat_Desc,
						 Time_Created,
						 Last_Mod,
						 Mod_User
						 )
            VALUES     ( 
			             @ClientID,
                         @Packet_Code,
                         @Packcat_Desc,
						 @Time_Created,
						 @Last_Mod,
						 @Mod_User
						)
        END
End



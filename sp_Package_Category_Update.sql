create PROCEDURE sp_Package_Category_Update
(
@ClientID varchar(299),
@Packet_Code varchar(299),
@Packcat_Desc varchar(299),
@Time_Created date,
@Last_Mod date,
@Mod_User varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Update'
        BEGIN
            Update Package_Category set Packet_Code=@Packet_Code,Packcat_Desc=@Packcat_Desc,Time_Created=@Time_Created,Last_Mod=@Last_Mod,Mod_User=@Mod_User where ClientID=@ClientID
						
        END
End







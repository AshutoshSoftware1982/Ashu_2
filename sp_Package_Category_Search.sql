create PROCEDURE sp_Package_Category_Search
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
      IF @StatementType = 'Select'
        BEGIN
            SELECT *
            FROM   Package_Category where @ClientID=ClientID
        END
End
USE [ERP_Project]
GO
/****** Object:  StoredProcedure [dbo].[sp_SizeExplosionInsert]    Script Date: 9/17/2024 11:33:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_SizeExplosionInsert]
(

@ClientID varchar(299),
@Size_Explosion varchar(299),
@SizeExplDesc varchar(299),
@Divison varchar(299),
@SizeRange varchar(299),
@ExplBy varchar(299),
@ModUser varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO tbl_SizeExplosion
                        (
						
ClientID,
Size_Explosion,
SizeExplDesc,
Divison,
SizeRange,
ExplBy,
ModUser
						 )
            VALUES     ( 
			             @ClientID,
@Size_Explosion,
@SizeExplDesc,
@Divison,
@SizeRange,
@ExplBy,
@ModUser
						)
        END
End

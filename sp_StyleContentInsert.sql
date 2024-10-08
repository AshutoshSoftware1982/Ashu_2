USE [ERP_Project]
GO
/****** Object:  StoredProcedure [dbo].[sp_StyleContentInsert]    Script Date: 9/17/2024 6:50:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_StyleContentInsert]
(

@ClientID varchar(299),
@ContentCode varchar(299),
@ContentDesc varchar(299),
@ModUser varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO tbl_StyleContent
                        (
						
ClientID,
ContentCode,
ContentDesc,
ModUser
						 )
            VALUES     ( 
			             @ClientID,
@ContentCode,
@ContentDesc,
@ModUser
						)
        END
End


USE [ERP_Project]
GO
/****** Object:  StoredProcedure [dbo].[sp_ColorInsert]    Script Date: 9/17/2024 3:24:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ColorInsert]
(
@ClientID varchar(299),
@Color varchar(299),
@ColorFlag varchar(299),
@ShortColorDesc varchar(299),
@ColorDesc varchar(299),
@ColorGroup varchar(299),
@NRFColor varchar(299),
@ColorRef varchar(299),
@ColorStandard varchar(299),
@ColorName varchar(299),
@LegacyColor varchar(299),
@ColorUDF01 varchar(299),
@ColorUDF02 varchar(299),
@ColorUDF03 varchar(299),
@ColorUDF04 varchar(299),
@ColorUDF05 varchar(299),
@C varchar(299),
@M varchar(299),
@Y varchar(299),
@K varchar(299),
@ModUser varchar(299),
@NRFColorList varchar(299),
@StatementType NVARCHAR(20) = ''
)
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO tbl_Color
                        (
						ClientID,Color,ColorFlag,ShortColorDesc,ColorDesc,ColorGroup,NRFColor,ColorRef,ColorStandard,ColorName,LegacyColor,ColorUDF01,ColorUDF02,ColorUDF03,ColorUDF04,ColorUDF05,C,M,Y,K,ModUser,NRFColorList )
            VALUES     ( 
			             @ClientID,@Color,@ColorFlag,@ShortColorDesc,@ColorDesc,@ColorGroup,@NRFColor,@ColorRef,@ColorStandard,@ColorName,@LegacyColor,@ColorUDF01,@ColorUDF02,@ColorUDF03,@ColorUDF04,@ColorUDF05,@C,@M,@Y,@K,@ModUser,@NRFColorList
						)
        END
End






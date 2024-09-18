create Proc Sp_Pagination
As
begin
with product As (SELECT Row_Number() Over(ORDER BY CustomerId DESC ) As RowNum,  *                          


  FROM Customer
  )                        
  select (select max(RowNum) from product) as Pages,* from product                                     
  WHERE ROWNUM BETWEEN (2 - 1) * 10+ 1 AND 2* 10
end
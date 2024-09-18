-------------Create Store Proc for Login Page---
CREATE PROCEDURE login_pro
(
    @UserName VARCHAR(50),
    @Password VARCHAR(50)
)
AS
BEGIN
    DECLARE @status INT

    IF EXISTS(SELECT * FROM New_User WHERE UserName = @UserName AND UPassword = @Password)
        SET @status = 1
    ELSE
        SET @status = 0

    SELECT @status
END



login_pro'Ashutosh@gmail.com','ASHU@12345'

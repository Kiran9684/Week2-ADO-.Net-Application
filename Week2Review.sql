/* Stored Procedure*/

CREATE PROCEDURE uspDeleteEmployee(@Id INT)
AS
BEGIN
	DELETE FROM Employees
	WHERE employeId = @Id 
END;

 /***UserDefinedFunctions ******/

CREATE FUNCTION udfGetEmployees(
    @designation varchar
)
RETURNS TABLE
AS
RETURN
    (SELECT 
      A.designation,COUNT(A.employeId) AS NoOFEmployees ,COUNT(B.locationName)AS NoOFLocation
    FROM
        Employees AS A
	INNER JOIN Departments AS B
    ON A.departmentId = B.departmentId
     GROUP BY A.designation);
/*****************/
SELECT 
    * 
FROM 
    udfGetEmployees('engineer');

/**/

use Week2Review

/***************/
/*Alter Statement */

CREATE TABLE Sample(
column1 int not null);

/*To Add a column*/
ALTER TABLE Sample 
ADD column2 varchar(20) not null

/*To Drop A column*/
ALTER TABLE Sample 
DROP COLUMN column2 

/*To add constraint*/
ALTER TABLE Sample
ADD PRIMARY KEY(column1)

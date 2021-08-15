/*

Sql Query to insert bulk data.
set value for below parameter
@totalData

*/

--Use [DATABASE_NAME]

SET IDENTITY_INSERT Products ON;

declare @id int;
--set below value to generate data.
declare @totalData int = 1000;

select @id = (Select Top 1 Id From Products order by 1 desc)
IF(@id is null)
	set @id = 1
ELSE
set @id = @id+1;

declare @end int = @id + @totalData;

while @id<=@id and @id <= @end
Begin
Print @id

    insert into Products(Id,Name,Description,Price,CreatedDate,Quantity)
	Values(
	@id,'Product ' + convert(varchar(5), @id), 
	'Product desc ' + convert(varchar(5), @id), 
	FLOOR(rand() * 1000 + 1), GETDATE(),
	FLOOR(rand() * 1000 + 1))

set @id=@id+1
END

SET IDENTITY_INSERT Products OFF;

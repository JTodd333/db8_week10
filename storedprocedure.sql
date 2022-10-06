drop procedure if exists addDepartment;

delimiter //
create procedure addDepartment(in fullname varchar(50), in loc varchar(50))
begin
	declare theid varchar(8);
    set theid = upper(substring(fullname, 1, 5));
    /* Anoter way:   select substring(fullname, 1, 5) into theid; */
    insert into department (id, name, location) value (theid, fullname, loc);
end //
delimiter ;

call addDepartment ('Development and Research', 'Cincinnatti');
/* I think to call this in C# with Dapper, we just do
	DB.Execute("call addDepartment ('Development and Research', 'Cincinnatti')");
    (Or there might be a function for runnning stored procedures, maybe called "Call" or something)
*/
select * from department;
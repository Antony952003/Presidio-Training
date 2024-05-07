use SalesDb
select * from EMP
select * from DEPARTMENT

create index empdepartment_index on EMP(Department)
drop index empdepartment_index on EMp
select * from emp where Department = 'Marketing'

create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure
drop proc proc_GreetWithName

create proc proc_GreetWithName(@cname varchar(20),@cdepartment varchar(20))
as
begin
   print 'Hello '+@cname+' of department : '+@cdepartment
end

execute proc_GreetWithName 'Antony', 'IT'

alter proc proc_AddEmployee(@empno int, @ename varchar(10),@empsalary varchar (10),@edepartment varchar(10),@ebossno varchar (10))
as
begin
   insert into EMP(Empno,Empname, Empsalary, Department,Bossno)
   values(@empno,@ename,@empsalary, @edepartment, @ebossno)
end

exec proc_AddEmployee 101,'Bimu','250000','Accounting','101'


alter proc proc_GreetWithName(@cname varchar(20),@cdepartment varchar(20),@cage int)
as
begin
   print 'Hello '+@cname+' of department : '+@cdepartment+' of age : '+cast(@cage as varchar(3))
end

execute proc_GreetWithName 'Antony', 'IT', 22

SELECT USER_NAME() AS CurrentUser;



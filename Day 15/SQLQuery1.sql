--creating a database
create database dbEmployeeTracker
--select the database
use dbEmployeeTracker

use master

drop database dbEmployeeTracker

SELECT name
FROM sys.databases

--create table
create table Areas(
Area varchar(20), ZipCode char(5));

select * from Areas

sp_help Areas

--Edit the area colum to be teh primary key
alter table Areas
alter column Area varchar(20) not null
alter table Areas
add constraint pk_Area primary key(Area)

--Drop and re create table to add primary key

drop table Areas

create Table Areas
(Area varchar(20) constraint pk_Area primary key,
Zipcode char(5))

alter table Areas
add AreaDescription varchar(20)

alter table Areas
drop column AreaDescription

create table Skills(
Skill_id int identity(1,1) constraint pk_Skill_id primary key,
Skill varchar(20),
SkillDescription varchar(20) )

sp_help Skills

create table Employees
(id int identity(101,1) constraint pk_EmployeeId primary key,
name varchar(100) ,
DateOfBirth datetime constraint chk_DOB Check(DateOfBirth<Getdate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null)

create table EmployeeSkill
(Employee_id int constraint fk_skill_eid foreign key references Employees(id),
Skill int constraint fk_Skill_EmplSkill foreign key references Skills(skill_id),
skillLevel float constraint chk_skilllevel check(skillLevel>=0),
constraint pk_employee_skill primary key(EMployee_id,Skill))

sp_help EmployeeSkill

--insert
Insert into Areas(Area, Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode, Area) values('12334','FFFF')

Insert into Areas values ('HHHH','60009')


--insert failures
Insert into Areas values ('HHHH','600094') --size violation
Insert into Areas(Area, Zipcode) values('DDDD','12345') --duplicate primary key violation
Insert into Areas(Zipcode) values ('12432') --primary key null violation

select * from Areas

insert into skills(Skill,SkillDescription) values('C','PLT')
insert into skills(Skill,SkillDescription) values('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS')
select * from skills

--Foreign Key insert
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','
ramu@gmail.com')
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com')

select * from Employees

--Employee Skill- Composite key

Insert into EmployeeSkill values(101,3,8)
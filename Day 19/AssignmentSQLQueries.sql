use pubs
select * from pub_info
select * from authors
select * from titles
select * from titleauthor
select * from sales
select * from employee
--1) Create a stored procedure that will take the author firstname and print all the books 
--polished by him with the publisher's 
create proc PrintAllBooks_procedure(@authorname varchar(20))
as
begin
	select t.title
	from titleauthor ta
	join authors a on a.au_id = ta.au_id
	join titles t on t.title_id = ta.title_id
	where a.au_fname = @authorname
end

exec PrintAllBooks_procedure 'Albert'

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, 
--price, quantity and the cost.
 select * from employee
alter proc PrintTitledetails_procedure(@ename varchar(20))
as
begin
	select title, sum(t.price) "Unit price",sum(s.qty) "Quantity",sum(s.qty * t.price) "Total Cost"
	from employee e
	join titles t on e.pub_id = t.pub_id
	join sales s on s.title_id = t.title_id
	where e.fname = @ename
	group by title
end

select * from employee

exec PrintTitledetails_procedure 'Karin'

drop proc PrintTitledetails_procedure
--3) Create a query that will print all names from authors and employees

select au_fname from authors
union
select fname from employee

--4) Create a  query that will float the data from sales,titles, publisher and 
--authors table to print title name, Publisher's name, author's full name with 
--quantity ordered and price for the order for all orders,
 
--print first 5 orders after sorting them based on the price of order
select * from titleauthor
select * from publishers
select * from titles
select * from sales

select top 5  t.title, p.pub_name, concat(a.au_fname,' ', a.au_lname) "Author Name",sum(s.qty), sum(s.qty * t.price) as TotalPrice
from titleauthor ta
join authors a on a.au_id = ta.au_id
join titles t on t.title_id = ta.title_id
join publishers p on p.pub_id = t.pub_id
join sales s on s.title_id = t.title_id
order by TotalPrice desc


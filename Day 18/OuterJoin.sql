use Northwind

select * from customers where CustomerID not in (select distinct customerid from Orders)

select * from orders
select * from [Order Details]
select * from Products

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID

--are there products which are never ordered

select * from Products where ProductID not in
(select distinct ProductID from [Order Details])
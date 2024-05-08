use Northwind
select * from Categories

select * from Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
union
select * from orders where Freight>50

select * from Orders where ShipCountry='Spain'
union all
select * from orders where Freight>50

select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50
--get the order id, productname and quantitysold of products that have price
--greater than 15

select * from [Order Details]
select * from products

select od.OrderID, p.ProductName, od.Quantity
from [Order Details] od 
join Products p on p.ProductID = od.ProductID
where p.UnitPrice > 15

--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20
select * from Categories

select od.OrderID, p.ProductName, od.Quantity "Quantity Sold"
from [Order Details] od 
join Products p on p.ProductID = od.ProductID
where p.UnitPrice > 15
union all
select od.OrderID , p.ProductName, od.Quantity "Quantity Sold"
from [Order Details] od
join Products p on p.ProductID = od.ProductID
join Categories c on c.CategoryID = p.CategoryID
where c.CategoryName like 'Dairy%' and p.UnitPrice between 10 and 20
order by p.UnitPrice desc


--CTE

with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc


create view vwOrderDetails
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select * from vwOrderDetails order by UnitPrice

select top 10 * from (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%') as t order by t.UnitPrice desc

select * from Orders
select * from Customers

with orderDetails_CTE (OrderID, ContactName, ProductName) as
(
select od.OrderID, c.ContactName, p.ProductName
from Orders o
join [Order Details] od
on od.OrderID = o.OrderID
join Products p on p.ProductID = od.ProductID
join Customers c on c.CustomerID = o.CustomerID
where c.Country = 'USA'
union 
select od.OrderID, c.ContactName, p.ProductName
from Orders o
join [Order Details] od
on od.OrderID = o.OrderID
join Products p on p.ProductID = od.ProductID
join Customers c on c.CustomerID = o.CustomerID
where c.Country = 'France' and Freight < 20
)

select top 10 * from orderDetails_CTE


sp_help categories
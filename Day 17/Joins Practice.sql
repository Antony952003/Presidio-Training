use Northwind

select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from products
select * from Suppliers
--select product names from the supplier Tokyo Traders
select productname from products where SupplierID = (
select SupplierID from Suppliers where CompanyName = 'Tokyo Traders'
)

--get all the products that are supplied by suppliers from USA

select productname, SupplierID from products where SupplierID in (
select SupplierID from Suppliers where country = 'USA'
)

--get all products from category taht has 'ea' in description
select productname, CategoryID from products where CategoryID in (
select CategoryID from Categories where description like '%ea%'
)

select * from customers
--select the product id and the quantity ordered by customrs from France
select * from products
select * from Suppliers
select * from orders
select * from categories
select ProductID, Quantity from [Order Details] where OrderID in (
select OrderID from orders where CustomerID in (select CustomerID from customers where country = 'France'))
select CustomerID from customers where Country = 'France'

--Get the products that are priced above the average price of all the products
select productName, UnitPrice from products where UnitPrice > (
select AVG(UnitPrice) from Products 
)
select * from Employees
--select the latest order of every employee
select employeeid, max(OrderDate) from Orders group by EmployeeID order by EmployeeID

--Select the lastet order by every employee
--select * from Orders where orderdate in 
--(select distinct Max(OrderDate) from orders group by Employeeid)
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
select * from products p1 where UnitPrice = (
select max(UnitPrice) from Products p2 where p1.CategoryID = p2.CategoryID
) order by ProductID

--select the order number for the maximum fright paid by every customer
select * from orders
select * from customers

select * from Orders o1 where Freight = (
select max(Freight) from Orders o2 where o1.CustomerID = o2.CustomerID
) order by o1.EmployeeID

--cross join
select * from customers, products

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID
select * from Suppliers
select * from products

--Get the Supplier company name, contact person name, Product name and the stock ordered
select CompanyName,ContactName, productname,unitsonorder from Suppliers s
join Products p on s.SupplierID = p.SupplierID
order by s.SupplierID

 --Print the order id, customername and the fright cost for all teh orders
select * from orders
select * from customers
select orderID,o.CustomerId,freight from Orders o, customers c where o.CustomerID = c.CustomerID order by o.Freight desc

 --Print the order id, customername and the fright cost for all teh orders
  --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)

 select * from [Order Details]
 select * from orders
 select * from customers
 select * from products

 select c.ContactName, p.ProductName, od.Quantity, o.Freight,((p.UnitPrice * od.Quantity)+ o.Freight) "Total Price" from [Order Details] od join Orders o on o.OrderID = od.OrderID
 join Customers c on c.CustomerID = o.CustomerID
 join Products p on p.ProductID = od.ProductID

 --prin the product name and total quantity sold
 select productname, sum(quantity) "total quantity sold" from products p join [Order Details] od on p.ProductID = od.ProductID group by p.ProductName

 --customer name and no of products bought for every order
 select * from [Order Details]
 select * from customers
 select * from orders
 select * from products
 select * from Employees
select o.OrderID,c.contactname, count(od.ProductID) "No of products" from customers c join orders o on o.CustomerID = c.CustomerID 
join [Order Details] od on o.OrderID = od.OrderID group by o.OrderID,c.ContactName order by o.OrderID

--select the employee name , customer name, product name, and the total price of the product
select e.FirstName, c.ContactName, p.ProductName,(p.UnitPrice * od.Quantity) "total price of the product" from orders o join [Order Details] od on o.OrderID = od.OrderID
join customers c on c.CustomerID = o.CustomerID
join Products p on p.ProductID = od.ProductID
join Employees e on e.EmployeeID = o.EmployeeID
order by e.EmployeeID



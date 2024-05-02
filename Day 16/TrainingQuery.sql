use NorthWind

select * from Products

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products

select * from products where UnitPrice>10

--Select all the products that are out of stock
select * from Products where UnitsInStock=0

--select the products that will no more be stocked
select * from products where Discontinued =1

--Select Products that will be in clearance
select * from products where Discontinued =1 and UnitsInStock>0

--select products in the range 10 to 30
select * from Products where UnitPrice>=10 and UnitPrice<=30
select * from Products where UnitPrice between 10 and 30

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products where CategoryID =3

select * from products
--Stock of products in category 3

select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3

--Avreage price of products supplied by supplier 2
select AVG(UnitPrice) "Average of Prices of supplier id = 2" from Products where SupplierID = 2

--Worth of products in order
select sum(unitsinstock * ReorderLevel) "Expected amount to be paid" from products

--Aggr by grouping
--Get the sum of products in stock for every category
select categoryId,sum(UnitsInStock) 'Stock Available' from products
group by CategoryId

--Get the Average price of products supplied by every supplier
select AVG(UnitPrice) 'Average Price' from Products
group by SupplierID

select SupplierId, avg(Unitprice) from Products group by SupplierID
go
select CategoryId, avg(unitprice) from Products group by CategoryID
go
select SupplierId, CategoryId, avg(Unitprice) from Products group by SupplierID, CategoryID

select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId
having avg(UnitPrice)>15

select * from products
--Select category ID and Sum of products avaible if the total number of products is 
--greater than 10

select CategoryId, sum(UnitsInStock) from Products group by CategoryID having count(ProductName) > 10

select * from products order by SupplierID, CategoryID desc

select productName,UnitPrice from products
where UnitPrice>15
order by CategoryId

--Get the products sorted by the price. Fetch only those products that will be discontiued

select * from Products where Discontinued = 1 order by UnitPrice 

select * from products

select Categoryid, sum(unitprice) from Products
where Discontinued = 0 
group by CategoryID
order by CategoryID

--sort by category id and fetch the sum of unit price of products that will not be discontinued
--select only if the category is having products total price greater than 200
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by categoryId
--(or)
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by 1

select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId

select * from Customers

select ContactName,
Rank() over( order by country) 'Rank'
from Customers


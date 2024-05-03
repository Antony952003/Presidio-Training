use pubs

select * from publishers
select * from authors
select* from employee
select * from stores
select * from titles
select * from sales
select * from titleauthor
select * from jobs
select * from roysched
--1) Print the storeid and number of orders for the store
	select st.stor_id, count(st.stor_id) "No of orders in store" from stores st join sales s on s.stor_id = st.stor_id group by st.stor_id order by st.stor_id
--  2) print the numebr of orders for every title
	select t.title_id, count(r.title_id) from titles t, roysched r where t.title_id = r.title_id group by t.title_id
--  3) print the publisher name and book name
	select p.pub_name, t.title from publishers p, titles t where p.pub_id = t.pub_id group by p.pub_name
--  4) Print the author full name for all the authors
	select a.au_id, a.au_fname, a.au_lname from authors a
--  5) Print the price or every book with tax (price+price*12.36/100)
	select t.title, (t.price+t.price*12.36/100) "Tax Price", t.price from titles t

--  6) Print the author name, title name
	select a.au_fname, t.title from titles t join titleauthor ta on ta.title_id = t.title_id 
	join authors a on a.au_id = ta.au_id
--  7) print the author name, title name and the publisher name
	select a.au_fname, t.title, p.pub_name from authors a join titleauthor ta on ta.au_id = a.au_id
	join titles t on t.title = ta.title_id 
	join publishers p on p.pub_id = t.pub_id
--  8) Print the average price of books pulished by every publicher
	select p.pub_id , p.pub_name, avg(t.price) "Average price of books" from publishers p join titles t on p.pub_id = t.pub_id group by p.pub_id,p.pub_name

--  9) print the books published by 'Marjorie'
	select t.title from titles t, publishers p where p.pub_id = t.pub_id and t.pub_id = 'Marjorie' 

--  10) Print the order numbers of books published by 'New Moon Books'
	select count(pub_id) "Number of Books published" from titles where pub_id = (
	select pub_id from publishers where pub_name = 'New Moon Books'
	)
--  11) Print the number of orders for every publisher
	select p.pub_name, count(s.ord_num)"No of Books" from sales s
	join titles t on t.title_id = s.title_id
	join publishers p on p.pub_id = t.pub_id group by p.pub_name

--  12) print the order number , book name, quantity, price and the total price for all orders
	select s.ord_num, t.title, s.qty, t.price , (t.price*s.qty) "Total Price" from sales s join titles t on t.title_id = s.title_id

--  13) print he total order quantity fro every book
	select t.title , sum(s.qty) "Orders" from sales s join titles t on t.title_id = s.title_id group by t.title

--  14) print the total ordervalue for every book
	select t.title, sum(t.price*s.qty) "Total Ordervalue" from sales s join titles t on t.title_id = s.title_id group by t.title

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
	select s.stor_id, s.ord_num, s.ord_date, s.qty, s.ord_date,s.title_id from sales s join titles t on t.title_id = s.title_id
	join publishers p on p.pub_id = t.pub_id 
	join employee e on e.pub_id = p.pub_id
	where e.fname = 'Paolo'

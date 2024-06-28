from functools import reduce
#  txt = "hello, and welcome to my world."

# x = txt.capitalize()
# txt2 = "banana is a very healthy meal for breakfast"+"banana is high is fiber and vitamins essential."

# if(txt.casefold() == txt2.casefold()):
#     print("valid")

# print(len(txt2))
# x = txt2.center(46)
# print(len(x))
# print (x)

# x = txt2.count("h")

# print(x)

# if(txt2.endswith('.', 3)):
#     print(True)

# txt = "H\te\tl\tl\to"

# txt = txt.expandtabs(8)
# print(txt)

txt2 = "banana is a very healthy meal for breakfast"+"banana is high is fiber and vitamins essential."

# x = txt2.find("breakfast")
# tuple = ("car", "is", "not", "an", "asset")
# x = " ".join(tuple)

# print(x)


# txt = "50"

# x = txt.zfill(10)

# print(x)

# square = lambda x : x ** 2
# print(square(4))

# mylist = [12,3,10,23,43,87]
# squared = list(map(lambda x: x**2,mylist))
# reversedlist = list(reversed(mylist))
# filteredlist = list(filter( lambda x: x % 2 == 0 ,mylist))
# reducedvalue  = reduce(lambda x, y: x * y, mylist)
# print(reducedvalue)
# print(filteredlist)
# print(squared)
# print(reversedlist)


# mytuple = (1,2,3,4)
# mylist  = [1,2,3,3,4]

# d = {'name': 'Alice', 'age': 30}

# for i,j in d.items():
#     print(i,j)

a = {1, 2, 3, 2, 3}
b = {3, 4, 5}
print(len(a))
print(a)
print(a | b)  # Union
print(a & b)  # Intersection
print(b - a)  # Difference
print(a ^ b)  # Symmetric Difference

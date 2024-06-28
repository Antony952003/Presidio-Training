def prime(number):
    end = number//2
    for i in range(2,end):
        if(number % i == 0):
            return False
    return True

def listofprimes(number):
    ans = []
    for i in range(2, number):
        if(prime(i)):
            ans.append(i)
    return ans

number = int(input("Enter a number : "))
res = listofprimes(number)
print(res)
number = int(input("Enter a number : "))
def prime(number):
    end = number//2
    for i in range(2,end):
        if(number % i == 0):
            return False
    return True
if(prime(number)):
    print("Its is a prime Number")
else:
    print("Its is not a prime number")
    
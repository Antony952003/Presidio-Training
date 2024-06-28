def prime(number):
    end = number//2
    for i in range(2,end):
        if(number % i == 0):
            return False
    return True

numbers = []
for i in range(1,11):
    value = (int(input(F"Enter the {i} value :")))
    numbers.append(value)

print(numbers)
sum = 0
cnt = 0
for i in numbers:
    if(prime(i)):
        sum += i
        cnt += 1

average = sum / cnt
print(f"The average of 10 nos be {average}")
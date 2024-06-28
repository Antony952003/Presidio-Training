s = input("Enter the account number : ")
s = list(s)
n = len(s)

for i in range(n-1, 0, -1):
    if(i % 2 != 0):
        s[i] = str(int(s[i]) * 2)
        if(int(s[i]) > 9):
            sum = 0
            num = int(s[i])
            sum += num%10
            sum += num//10
            s[i] = str(sum)

value = 0
for i in range(len(s)):
    value += int(s[i])

print(value % 10 == 0)

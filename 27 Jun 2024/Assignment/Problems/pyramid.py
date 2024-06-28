row = int(input("Enter the row number : "))
for i in range(1,row+1):
    # space
    j = row-i
    while(j > 0):
        print(" ", end="")
        j -= 1
    k = (i*2)-1
    while(k > 0):
        print("*",end="")
        k -= 1
    print()
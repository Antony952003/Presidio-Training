value = input("Enter a string : ")

def string_length(value):
    count = 0
    for char in value:
        count += 1
    return count

print(f"Using loop {string_length(value)}")
print(f"Using inbuilt-method {len(value)}")
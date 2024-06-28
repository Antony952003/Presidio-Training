s = input("Enter a string : ")

def permutations(s):
    if len(s) == 0:
        return ['']
    
    result = []
    
    for i in range(len(s)):
        current_char = s[i]
        
        remaining_chars = s[:i] + s[i+1:]
        sub_permutations = permutations(remaining_chars)
        
        for perm in sub_permutations:
            result.append(current_char + perm)
    
    return result

print("The string is ", s)
allpermutations = permutations(s)

for permutaion in allpermutations:
    print(permutaion)

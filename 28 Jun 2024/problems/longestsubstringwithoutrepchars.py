def longestsubstring(s):
    n = len(s)
    char_index = {}
    max_len = 0
    start = 0
    
    for end in range(n):
        if s[end] in char_index:
            # Move the start to the right of the same character last seen
            start = max(start, char_index[s[end]] + 1)
        
        char_index[s[end]] = end
        max_len = max(max_len, end - start + 1)
    
    return max_len
s = input("Enter a string : ")
ans = longestsubstring(s)
print(ans)
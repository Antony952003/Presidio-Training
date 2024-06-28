
def norepeating_chars(s):
    visited = (256) * [False]
    for i in range(len(s)):
        if(visited[ord(s[i])] == True):
            return False
        visited[ord(s[i])] = True
    return True

def longestsubstring(s):
    res = 0
    for i in range(len(s)):
        for j in range(i, len(s)):
            if(norepeating_chars(s[i:j+1])):
                if(len(s[i:j+1]) > res):
                    res = len(s[i:j+1])
                    str = s[i:j+1]
    return str

s = input("Enter a string : ")
ans = longestsubstring(s)
print(f"{ans} is the string of length : {len(ans)}")
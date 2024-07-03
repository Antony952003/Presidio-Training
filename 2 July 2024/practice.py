# string = "AAABCADDE"
# k = 3

# for i in range(0, len(string), k):
#     print(string[i:(i+k)])

#238
#28

# step 1 : reverse

#832
#82
#[0 0 0]
#[0 ]
#0 0 0
#0 


def canJump(nums: list[int]) -> bool:
        n = len(nums)
        return jump(0, nums, n)
    
def jump(ind: int, nums: list[int], n: int) -> bool:
    if(ind >= n-1):
         return True
    
    if(nums[ind] == 0):
        return False
    
    for i in range(1,nums[ind]+1):
        if(jump(ind+i, nums, n)):
             return True
    return False
nums = [2, 3, 1, 1, 4]
print(canJump(nums))
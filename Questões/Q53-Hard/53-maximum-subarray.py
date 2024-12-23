def maximum_subarray(nums):
    return find_maximum_subarray(nums, 0, len(nums) - 1)

def find_maximum_subarray(nums, start, end):
    if start == end:  
        return nums[start]

    mid = (start + end) // 2
    left_max = find_maximum_subarray(nums, start, mid) 
    right_max = find_maximum_subarray(nums, mid + 1, end)  
    cross_max = max_crossing_sum(start, mid, end, nums)  

    return max(left_max, right_max, cross_max)

def max_crossing_sum(start, mid, end, nums):
   
    left_sum = float('-inf')
    total = 0
    for i in range(mid, start - 1, -1):
        total += nums[i]
        left_sum = max(left_sum, total)

   
    right_sum = float('-inf')
    total = 0
    for i in range(mid + 1, end + 1):
        total += nums[i]
        right_sum = max(right_sum, total)

    return left_sum + right_sum


print(maximum_subarray([-2, 1, -3, 4, -1, 2, 1, -5, 4]))  
print(maximum_subarray([1])) 
print(maximum_subarray([-1, -2, -3]))
print(maximum_subarray([5, 4, -1, 7, 8]))  

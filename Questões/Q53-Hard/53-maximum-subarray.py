def find_maximum_subarray(nums, start, end):
    if start == end:  
        return nums[start]

    mid = (start + end) // 2
    left_max = find_maximum_subarray(nums, start, mid)  
    right_max = find_maximum_subarray(nums, mid + 1, end)  
    cross_max = max_crossing_sum(start, mid, end, nums)  

    return max(left_max, right_max, cross_max)

def max_crossing_sum(start, mid, end, nums):
    
    pass

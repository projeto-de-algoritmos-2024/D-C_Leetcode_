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

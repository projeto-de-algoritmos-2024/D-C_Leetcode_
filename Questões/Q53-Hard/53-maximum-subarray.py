class Solution:
    def maxSubArray(self, nums):
        return self.find_maximum_subarray(nums, 0, len(nums) - 1)

    def find_maximum_subarray(self, nums, start, end):
        if start == end:  
            return nums[start]

        mid = (start + end) // 2
        left_max = self.find_maximum_subarray(nums, start, mid)  
        right_max = self.find_maximum_subarray(nums, mid + 1, end)  
        cross_max = self.max_crossing_sum(start, mid, end, nums)

        return max(left_max, right_max, cross_max)

    def max_crossing_sum(self, start, mid, end, nums):
       
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

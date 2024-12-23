import numpy as np
class Solution(object):
    def findKthLargest(self, nums, k):
        return np.partition(nums, len(nums) - k)[-k]
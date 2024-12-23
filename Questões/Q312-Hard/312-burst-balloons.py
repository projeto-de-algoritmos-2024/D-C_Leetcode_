def maxCoins(nums):
    def burst(nums):
        
        if not nums:
            return 0
        
        max_coins = 0
 
        for i in range(len(nums)):
            coins = nums[i]
            if i > 0:
                coins *= nums[i - 1]
            if i < len(nums) - 1:
                coins *= nums[i + 1]
           
            max_coins = max(max_coins, coins + burst(nums[:i] + nums[i+1:]))
        
        return max_coins

    return burst(nums)

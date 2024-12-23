def maxCoins(nums):
   
    nums = [1] + nums + [1]
    n = len(nums)
  
    memo = [[0] * n for _ in range(n)]
 
    def dp(left, right):
        
        if left + 1 >= right:
            return 0
        
        
        if memo[left][right] > 0:
            return memo[left][right]
        
        
        max_coins = 0
        for i in range(left + 1, right):
            coins = nums[left] * nums[i] * nums[right]  
            coins += dp(left, i) + dp(i, right)       
            max_coins = max(max_coins, coins)
        
   
        memo[left][right] = max_coins
        return max_coins
    
   
    return dp(0, n - 1)

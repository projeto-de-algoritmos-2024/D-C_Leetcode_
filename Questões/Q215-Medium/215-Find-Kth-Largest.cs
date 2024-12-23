public class Solution {

    public static int MedianOfMedians(int[] nums, int k)
    {
        if (nums.Length <= 5)
        {
            Array.Sort(nums);
            return nums[k];
        }

        // Divide em grupos de 5 e calcula as medianas
        List<int> medians = new List<int>();
        for (int i = 0; i < nums.Length; i += 5)
        {
            int[] group = nums.Skip(i).Take(5).ToArray();
            Array.Sort(group);
            medians.Add(group[group.Length / 2]);
        }

        // Encontra a mediana das medianas
        int pivot = MedianOfMedians(medians.ToArray(), medians.Count / 2);

        // Particiona o array em torno do pivô
        List<int> lows = nums.Where(x => x < pivot).ToList();
        List<int> highs = nums.Where(x => x > pivot).ToList();
        List<int> pivots = nums.Where(x => x == pivot).ToList();

        // Decide onde está o k-ésimo menor elemento
        if (k < lows.Count)
        {
            return MedianOfMedians(lows.ToArray(), k);
        }
        else if (k < lows.Count + pivots.Count)
        {
            return pivot;
        }
        else
        {
            return MedianOfMedians(highs.ToArray(), k - lows.Count - pivots.Count);
        }
    }
    public int FindKthLargest(int[] nums, int k) {
        return MedianOfMedians(nums, nums.Length - k);
    }
}
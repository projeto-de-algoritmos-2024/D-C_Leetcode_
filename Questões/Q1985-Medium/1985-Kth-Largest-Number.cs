using System;

public class Solution {
    // Função para comparar dois números representados como strings
    private static int CompareStrings(string a, string b)
    {
        if (a.Length != b.Length)
        {
            return a.Length.CompareTo(b.Length);
        }
        return string.Compare(a, b, StringComparison.Ordinal);
    }

    public static string MedianOfMedians(string[] nums, int k)
    {
        if (nums.Length <= 5)
        {
            Array.Sort(nums, CompareStrings); // Ordena strings usando comparação customizada
            return nums[k];
        }

        // Divide em grupos de no máximo 5 e calcula as medianas
        List<string> medians = new List<string>();
        for (int i = 0; i < nums.Length; i += 5)
        {
            string[] group = nums.Skip(i).Take(Math.Min(5, nums.Length - i)).ToArray();
            Array.Sort(group, CompareStrings);
            medians.Add(group[group.Length / 2]);
        }

        // Encontra a mediana das medianas
        string pivot = MedianOfMedians(medians.ToArray(), medians.Count / 2);

        // Particiona o array em torno do pivô
        List<string> lows = new List<string>();
        List<string> highs = new List<string>();
        List<string> pivots = new List<string>();

        foreach (var num in nums)
        {
            int comparison = CompareStrings(num, pivot);
            if (comparison < 0)
                lows.Add(num);
            else if (comparison > 0)
                highs.Add(num);
            else
                pivots.Add(num);
        }

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

    public string KthLargestNumber(string[] nums, int k)
    {
        // Calcula o índice do k-ésimo maior elemento
        int index = nums.Length - k;

        // Encontra o k-ésimo maior elemento usando Mediana das Medianas
        return MedianOfMedians(nums, index);
    }
}

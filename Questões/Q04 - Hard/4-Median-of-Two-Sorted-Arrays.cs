public class Solution {
    private static void Merge(int[] array, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;

        // Mescla enquanto houver elementos em ambos os subarrays
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k++] = left[i++];
            }
            else
            {
                array[k++] = right[j++];
            }
        }

        // Copia os elementos restantes do subarray esquerdo (se houver)
        while (i < left.Length)
        {
            array[k++] = left[i++];
        }

        // Copia os elementos restantes do subarray direito (se houver)
        while (j < right.Length)
        {
            array[k++] = right[j++];
        }
    }
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] mergedArray = new int[nums1.Length + nums2.Length];
        Merge(mergedArray, nums1, nums2);
        double m;

        if (mergedArray.Length % 2 == 0){
            m = (mergedArray[mergedArray.Length / 2] + mergedArray[(mergedArray.Length / 2) - 1]) / 2.0;
        } else {
            m = mergedArray[mergedArray.Length / 2];
        }

        return m;
    }
}
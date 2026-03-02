namespace hashset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MergeSortedArrays(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 });
        }

        static bool HasDuplicated(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                if (set.Contains(num))
                {
                    return true; // Found a duplicate
                }
                set.Add(num);
            }
            return false; // No duplicates found
        }

        static int CountBinarySearchSteps(int[] nums, int target)
        {
            int count = 0;
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                count++;
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return count; // Target found
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1; // Search right half
                }
                else
                {
                    right = mid - 1; // Search left half
                }
            }
            return count; // Target not found
        }

        public static int[] ComplexityCapstone(int[] numbers)
        {
            // Your code here
            int[] result = new int[3];

            // Compare each pair
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        result[0] = 1;
                    }
                }
            }
            // HashSet
            HashSet<int> set = new HashSet<int>();
            foreach (int num in numbers)
            {
                if (set.Contains(num))
                {
                    result[1] = 1; // Found a duplicate
                }

                set.Add(num);
            }

            // Binary Search
            int count = 0;
            int left = 0;
            int right = numbers.Length - 1;
            numbers = sortArray(numbers);
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (numbers[left] == numbers[mid])
                {
                    result[2] = 1; // Target found
                    break;
                }
                else if (left < mid)
                {
                    left = mid + 1; // Search right half
                }
                else
                {
                    right = mid - 1; // Search left half
                }
            }
            if (numbers.Length == 1)
            {
                result[2] = 1;
            }
            return result; // No duplicates found
        }

        static int[] sortArray(int[] nums)
        {
            int[] sorted = new int[nums.Length];
            Array.Copy(nums, sorted, nums.Length);
            Array.Sort(sorted);
            return sorted;
        }

        static int[] ReverseArrayTwoPointer(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
            return nums;
        }

        static int[] FindDuplicates(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();
            List<int> result = new List<int>();

            foreach (int num in nums)
            {
                if (seen.Contains(num))
                {
                    // This is a duplicate
                    if (!duplicates.Contains(num))
                    {
                        // First time identifying this as a duplicate
                        duplicates.Add(num);
                        result.Add(num);
                    }
                }
                else
                {
                    // First time seeing this value
                    seen.Add(num);
                }
            }

            return result.ToArray();
        }

        static int[] MoveZeroes(int[] arr)
        {
            // Your code here
            // 5, -2, 8, -1, 3 
            int wp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    arr[wp] = arr[i];
                    wp++;
                }
            }

            // Fill remaining positions with default value
            while (wp < arr.Length)
            {
                arr[wp] = 0;
                wp++;
            }
            return arr;
        }

        static int SecondLargest(int[] arr)
        {
            // Handle edge cases
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            if (arr.Length == 1)
            {
                return -1;
            }

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    secondLargest = largest;
                    largest = arr[i];
                }
                else if (arr[i] > secondLargest && arr[i] != largest)
                {
                    secondLargest = arr[i];
                }
            }

            // If no valid second largest found
            if (secondLargest == int.MinValue)
            {
                return -1;
            }

            return secondLargest;
        }

        static int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                if (numToIndex.ContainsKey(complement))
                {
                    return new int[] { numToIndex[complement], i };
                }
                if (!numToIndex.ContainsKey(numbers[i]))
                {
                    numToIndex[numbers[i]] = i;
                }
            }
            return new int[] { -1, -1 }; // No solution found
        }

        static int[] RotateArray(int[] arr, int k)
        {
            if (arr == null || arr.Length == 0)
            {
                return arr; // Return the original array if it's null or empty
            }
            k = k % arr.Length; // Handle cases where k is greater than array length
            Reverse(arr, 0, arr.Length - 1);
            Reverse(arr, 0, k - 1);
            Reverse(arr, k, arr.Length - 1);
            return arr;
        }

        static void Reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        static int[] MergeSortedArrays(int[] arr1, int[] arr2)
        {
            int[] merged = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                {
                    merged[k++] = arr1[i++];
                }
                else
                {
                    merged[k++] = arr2[j++];
                }
            }

            while (i < arr1.Length)
            {
                merged[k++] = arr1[i++];
            }

            while (j < arr2.Length)
            {
                merged[k++] = arr2[j++];
            }

            return merged;
        }
    }
}
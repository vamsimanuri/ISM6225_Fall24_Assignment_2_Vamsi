using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
{
    try
    {
        // Performing Cyclic Sort to place numbers at their correct positions
        int i = 0;
        while (i < nums.Length)
        {
            int correctIndex = nums[i] - 1;  // Finding the correct index for nums[i]
            if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[correctIndex])
            {
                // Swapping nums[i] to its correct position
                int temp = nums[i];
                nums[i] = nums[correctIndex];
                nums[correctIndex] = temp;
            }
            else
            {
                i++;  // Moving to the next index if the number is already in its correct place
            }
        }

        // After sorting, collecting all indices where the number is incorrect
        List<int> missingNumbers = new List<int>();
        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] != j + 1)
            {
                // Adding the missing number (j+1) to the list if nums[j] is not j+1
                missingNumbers.Add(j + 1);
            }
        }

        // Returning the list of missing numbers
        return missingNumbers;
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: I learned how to use cyclic sorting to identify missing elements efficiently, placing numbers in their correct positions without extra space.

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
{
    try
    {
        // Initializing pointers for even and odd numbers
        int left = 0;  // Pointing to the beginning of the array
        int right = nums.Length - 1;  // Pointing to the end of the array

        // Iterating through the array while left pointer is less than right pointer
        while (left < right)
        {
            // Checking if the left number is odd and the right number is even
            if (nums[left] % 2 > nums[right] % 2)
            {
                // Swapping numbers to place even number on the left and odd number on the right
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
            }

            // Moving the left pointer if the number is even
            if (nums[left] % 2 == 0)
            {
                left++;
            }

            // Moving the right pointer if the number is odd
            if (nums[right] % 2 == 1)
            {
                right--;
            }
        }

        // Returning the sorted array by parity
        return nums;
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: I improved my understanding of using two pointers to segregate even and odd numbers in a single pass with optimal time complexity.

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
{
    try
    {
        // Creating a dictionary to store the numbers and their indices
        Dictionary<int, int> numIndices = new Dictionary<int, int>();

        // Iterating through the array to find the two indices
        for (int i = 0; i < nums.Length; i++)
        {
            // Calculating the complement needed to reach the target
            int complement = target - nums[i];

            // Checking if the complement exists in the dictionary
            if (numIndices.ContainsKey(complement))
            {
                // Returning the indices of the two numbers that sum to the target
                return new int[] { numIndices[complement], i };
            }

            // Storing the current number and its index in the dictionary
            numIndices[nums[i]] = i;
        }

        // Returning an empty array if no solution is found (optional)
        return new int[0]; // Placeholder
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: I gained insight into utilizing a hash map to solve the two-sum problem in linear time.

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
{
    try
    {
        // Sorting the array to easily access the largest and smallest values
        Array.Sort(nums);

        // Calculating the maximum product of the three largest numbers
        int product1 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];

        // Calculating the maximum product of the two smallest and the largest number (for negative numbers)
        int product2 = nums[0] * nums[1] * nums[nums.Length - 1];

        // Returning the maximum of the two calculated products
        return Math.Max(product1, product2);
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: Sorting helped me see how to calculate the maximum product by comparing products of the largest numbers and the smallest negatives.

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
{
    try
    {
        // Initializing an empty string to store the binary representation
        string binaryString = string.Empty;

        // Handling the case when the decimal number is zero
        if (decimalNumber == 0)
        {
            // Returning "0" for the binary representation of zero
            return "0";
        }

        // Using a loop to convert decimal to binary
        while (decimalNumber > 0)
        {
            // Appending the remainder (0 or 1) to the binary string
            binaryString = (decimalNumber % 2) + binaryString;

            // Dividing the decimal number by 2 to continue the conversion
            decimalNumber /= 2;
        }

        // Returning the final binary string representation
        return binaryString;
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: I practiced converting a decimal number to binary using simple modulus operations

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
{
    try
    {
        // Checking if the input array is empty
        if (nums.Length == 0)
        {
            // Throwing an exception for an empty array
            throw new ArgumentException("Array must not be empty.");
        }

        // Initializing variables for binary search
        int left = 0;
        int right = nums.Length - 1;

        // Performing binary search to find the minimum element
        while (left < right)
        {
            // Calculating the middle index
            int mid = left + (right - left) / 2;

            // Checking if the middle element is greater than the rightmost element
            if (nums[mid] > nums[right])
            {
                // Moving the left pointer to mid + 1, as the minimum must be in the right half
                left = mid + 1;
            }
            else
            {
                // Moving the right pointer to mid, as the minimum could be mid or in the left half
                right = mid;
            }
        }

        // Returning the minimum element found at the left pointer
        return nums[left];
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: I enhanced my understanding of binary search in a rotated sorted array to find the minimum element efficiently.


        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
{
    try
    {
        // Checking if the number is negative or ends with 0 (not a palindrome)
        if (x < 0 || (x % 10 == 0 && x != 0))
        {
            // Returning false as negative numbers and non-zero numbers ending with 0 are not palindromes
            return false;
        }

        // Initializing a variable to hold the reversed number
        int reversed = 0;

        // Reversing the number until the original number is less than or equal to the reversed number
        while (x > reversed)
        {
            // Adding the last digit of x to the reversed number
            reversed = reversed * 10 + x % 10;
            // Removing the last digit from x
            x /= 10;
        }

        // Returning true if x equals the reversed number or if it equals the reversed number without the last digit (for odd length)
        return x == reversed || x == reversed / 10;
    }
    catch (Exception)
    {
        throw;
    }
}

// Self-Reflection: I learned an efficient way to check if a number is a palindrome without converting it to a string.

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
{
    try
    {
        // Checking for the base cases
        if (n < 0)
        {
            // Throwing an exception for invalid input
            throw new ArgumentException("Input cannot be negative.");
        }
        else if (n == 0)
        {
            // Returning 0 for Fibonacci(0)
            return 0;
        }
        else if (n == 1)
        {
            // Returning 1 for Fibonacci(1)
            return 1;
        }

        // Initializing variables to hold the previous two Fibonacci numbers
        int a = 0; // Storing Fibonacci(0)
        int b = 1; // Storing Fibonacci(1)

        // Calculating Fibonacci numbers iteratively
        for (int i = 2; i <= n; i++)
        {
            // Summing the previous two Fibonacci numbers to get the next
            int temp = a + b;
            // Updating the previous numbers for the next iteration
            a = b; // Setting a to the last Fibonacci number
            b = temp; // Setting b to the newly calculated Fibonacci number
        }

        // Returning the nth Fibonacci number
        return b; // Returning Fibonacci(n)
    }
    catch (Exception)
    {
        throw; // Rethrowing the caught exception
    }
}

// Self-Reflection: I used my understanding of using a loop to calculate Fibonacci numbers, which is faster than using recursion

    }
}

using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of size 'length' to hold the multiples.
        // 2. Use a loop to populate the array:
        //    - Start at index 0.
        //    - For each index, calculate the multiple by multiplying 'number' with (index + 1).
        //    - Store the result in the array.
        // 3. Return the completed array.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Calculate and store each multiple.
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3, 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list 
    /// rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Calculate the effective rotation using modulo: effectiveRotation = amount % data.Count.
        //    - This handles cases where 'amount' is larger than the size of the list.
        // 2. Split the list into two parts:
        //    - Right slice: The last 'effectiveRotation' elements.
        //    - Left slice: The remaining elements at the start of the list.
        // 3. Clear the original list and recombine it:
        //    - Add the right slice to the list.
        //    - Add the left slice to the list.
        // 4. The original list is now rotated to the right.

        int effectiveRotation = amount % data.Count;

        // Get the right and left slices of the list.
        List<int> rightSlice = data.GetRange(data.Count - effectiveRotation, effectiveRotation);
        List<int> leftSlice = data.GetRange(0, data.Count - effectiveRotation);

        // Clear and recombine the list.
        data.Clear();
        data.AddRange(rightSlice);
        data.AddRange(leftSlice);
    }
}

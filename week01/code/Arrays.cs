public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Create new array to store multiples with 'length'
        // 2. Use a for loop to iterate 'length' times to populate the array
        // 3. For each i in the array:
        //    a. Calculate the multiple: number * (i + 1)
        //    b. Store the result to array
        // 4. Return array with all multiples

        // Create array to store results
        double[] result = new double[length];

        // Populate array with multiples
        for (int i = 0; i < length; i++)
        {
            // Calculate multiple: number * (i + 1)
            // Start at 1x then 2x, 3x...
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Check list for valid amount of data
        // 2. Get portion of list that needs to move from the end:
        //    a. Use GetRange to get last 'amount' to move to front
        // 3. Get portion of list that needs to move to the end:
        //    a. Use GetRange to get all elements except the last 'amount'
        // 4. Clear list
        // 5. Add elements with new order:
        //    a. Add elements at the end to front first
        //    b. Add elements at the front to the end

        // Check data in list
        if (data.Count <= 1) return;

        // Get the elements that will move from the end to the front
        List<int> end = data.GetRange(data.Count - amount, amount);

        // Get the elements that will move from the front to the end
        List<int> beginning = data.GetRange(0, data.Count - amount);

        // Clear original list
        data.Clear();

        // Add elements in new order
        data.AddRange(end);
        data.AddRange(beginning);
    }
}

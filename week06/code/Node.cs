public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // If value is equal to current node's data
        if (value == Data)
        {
            // Skip duplicates
            return;
        }

        // If value is less than current node's data
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            // Insert to the right
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Check if current node contains value
        if (value == Data)
        {
            return true;
        }
        // If value is less than current node's data
        else if (value < Data)
        {
            if (Left is null)
            {
                // Return False: Left subtree is empty
                return false;
            }
            else
            {
                // Not empty: search in left subtree
                return Left.Contains(value);
            }
        }
        else
        {
            if (Right is null)
            {
                // Return False: Right subtree is empty
                return false;
            }
            else
            {
                // Not empty: search in right subtree
                return Right.Contains(value);
            }
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Get the height of left and right subtrees
        int left, right;

        // If Left is not null
        if (Left != null)
        {
            // Get the height of Left
            left = Left.GetHeight();
        }
        else
        {
            // If null: height is 0
            left = 0;
        }

        // If Right is not null
        if (Right != null)
        {
            // Get the height of Right
            right = Right.GetHeight();
        }
        else
        {
            // If null: height is 0
            right = 0;
        }
        
        // Return 1 (current node) + height of taller subtree
        return 1 + Math.Max(left, right);
    }
}
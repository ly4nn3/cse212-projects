using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    // T E S T - C A S E - 1
    [TestMethod]
    // Scenario: Enqueue items with different priorities, highest at the beginning.
    // Dequeue should return value with the highest priority.
    // Expected Result: "vip"
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("vip", 10);
        priorityQueue.Enqueue("elite", 5);
        priorityQueue.Enqueue("member", 1);

        var v = priorityQueue.Dequeue();
        Assert.AreEqual("vip", v);
    }

    // T E S T - C A S E - 2
    [TestMethod]
    // Scenario: Enqueue items with different priorities, highest in the middle.
    // Dequeue should return value with the highest priority.
    // Expected Result: "vip"
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("member", 1);
        priorityQueue.Enqueue("vip", 10);
        priorityQueue.Enqueue("elite", 5);

        var v = priorityQueue.Dequeue();
        Assert.AreEqual("vip", v);
    }

    // T E S T - C A S E - 3
    [TestMethod]
    // Scenario: Enqueue items with different priorities, highest at the end.
    // Dequeue should return value with the highest priority.
    // Expected Result: "vip"
    // Defect(s) Found: Actual result does not match expected.
    //                  Output is "elite" instead of "vip".
    //                  Indicates a defect in the priority queue implementation.
    //                  Using `index < _queue.Count - 1` in Dequeue stops loop at next-to-last item;
    //                  Last enqueued item with highest priority is not checked.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("elite", 5);
        priorityQueue.Enqueue("member", 1);
        priorityQueue.Enqueue("vip", 10);

        var v = priorityQueue.Dequeue();
        Assert.AreEqual("vip", v);
    }

    // T E S T - C A S E - 4
    [TestMethod]
    // Scenario: Enqueue multiple items with varying priorities, and ties.
    // Dequeue should always remove and return items in the order they were added.
    // Expected Result:
    //    1. "vip1"   (priority 10, added first)
    //    2. "vip3"   (priority 10, added second)
    //    3. "vip2"   (priority 5)
    //    4. "member" (priority 1)
    // Defect(s) Found: Actual result does not match expected.
    //                  First dequeued item is "vip3" instead of "vip1".
    //                  Indicates a defect in the FIFO handling for same-priroity items.
    //                  Using `_queue[index].Priority >=`:
    //                  Dequeue allows later items with same priority to be dequeued first.
    //                  Item is not removed from the queue, so it's returned again on next dequeue.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("member", 1);
        priorityQueue.Enqueue("vip1", 10);
        priorityQueue.Enqueue("vip2", 5);
        priorityQueue.Enqueue("vip3", 10);

        var v1 = priorityQueue.Dequeue();
        Assert.AreEqual("vip1", v1);

        var v2 = priorityQueue.Dequeue();
        Assert.AreEqual("vip3", v2);

        var v3 = priorityQueue.Dequeue();
        Assert.AreEqual("vip2", v3);

        var v4 = priorityQueue.Dequeue();
        Assert.AreEqual("member", v4);
    }

    // T E S T - C A S E - 5
    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with "The queue is empty." message.
    // Defect(s) Found: Actual result does not match expected.
    //                  First dequeued item is "vip3" instead of "vip1".
    //                  Indicates a defect in the FIFO handling for same-priroity items.
    //                  Using `_queue[index].Priority >=`:
    //                  Dequeue allows later items with same priority to be dequeued first.
    //                  Item is not removed from the queue, so it's returned again on next dequeue.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
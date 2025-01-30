using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding multiple elements with different priorities and ensuring highest priority is dequeued first
    // Expected Result: "High Priority" is dequeued first
    // Defect(s) Found: None
    public void TestPriorityQueue_HighestPriorityDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("Medium Priority", 2);
        priorityQueue.Enqueue("High Priority", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High Priority", result);
    }

    [TestMethod]
    // Scenario: Adding multiple elements with same priority and checking FIFO order
    // Expected Result: "First" is dequeued before "Second" since they have the same priority
    // Defect(s) Found: None
    public void TestPriorityQueue_FIFOWhenSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);

        var firstDequeue = priorityQueue.Dequeue();
        var secondDequeue = priorityQueue.Dequeue();

        Assert.AreEqual("First", firstDequeue);
        Assert.AreEqual("Second", secondDequeue);
    }

    [TestMethod]
    // Scenario: Attempting to dequeue from an empty queue
    // Expected Result: Exception is thrown
    // Defect(s) Found: None
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Adding an item with the lowest priority and ensuring it's dequeued last
    // Expected Result: "Low Priority" is the last item dequeued
    // Defect(s) Found: None
    public void TestPriorityQueue_LowestPriorityLast()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("High Priority", 3);
        priorityQueue.Enqueue("Medium Priority", 2);

        var first = priorityQueue.Dequeue(); // High Priority
        var second = priorityQueue.Dequeue(); // Medium Priority
        var third = priorityQueue.Dequeue(); // Low Priority

        Assert.AreEqual("High Priority", first);
        Assert.AreEqual("Medium Priority", second);
        Assert.AreEqual("Low Priority", third);
    }
}

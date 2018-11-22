using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheQueue
{
    public class TheQueueTests
    {
        private const int AnyIntegerBetweenBoundaries = 1;
        private TddQueue queue;

        [SetUp]
        public void SetUp()
        {
            queue = new TddQueue();
        }

        [Test]
        public void NewQueueHasNoItems()
        {
            Assert.AreEqual(0, queue.Count);
        }

        [Test]
        public void NewQueueIsEmpty()
        {
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void EnqueueingItemIncreasesCount()
        {
            queue.Enqueue(AnyIntegerBetweenBoundaries);
            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void FirstItemEnqueuedIsHeadOfQueue()
        {
            queue.Enqueue(AnyIntegerBetweenBoundaries);
            Assert.AreEqual(AnyIntegerBetweenBoundaries, queue.Head);
        }

        [Test]
        public void DequeueDecreasesCount()
        {
            queue.Enqueue(AnyIntegerBetweenBoundaries);
            queue.Enqueue(AnyIntegerBetweenBoundaries + 1);
            queue.Dequeue();
            Assert.AreEqual(1, queue.Count);
        }
        [Test]
        public void DequeuePromotesNextItemToHead()
        {
            queue.Enqueue(AnyIntegerBetweenBoundaries);
            queue.Enqueue(AnyIntegerBetweenBoundaries + 1);
            queue.Dequeue();
            Assert.AreEqual(AnyIntegerBetweenBoundaries + 1, queue.Head);
        }

        [Test]
        public void EnqueueAcceptsItemAtLowerBoundary()
        {
            queue.Enqueue(TddQueue.LowerBoundary);
            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void EnqueueAcceptsItemAtUpperBoundary()
        {
            queue.Enqueue(TddQueue.UpperBoundary);
            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void EnqueuingItemLowerThanBoundaryThrowsException()
        {
            Assert.Throws<ArgumentException>(() => queue.Enqueue(TddQueue.LowerBoundary - 1));
        }

        [Test]
        public void EnqueueItemHigherThanUpperBoundaryThrowsException()
        {
            Assert.Throws<ArgumentException>(() => queue.Enqueue(TddQueue.UpperBoundary + 1));
        }

        [Test]
        public void GetHeadOnEmptyQueueThrowsException()
        {
            var head=0;
            Assert.Throws<InvalidOperationException>(() => { head = queue.Head; });
            Assert.AreEqual(0,head);
        }

        [Test]
        public void DequeueOnEmptyQueueThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => { queue.Dequeue(); });
        }
    }

    internal class TddQueue
    {
        public const int LowerBoundary = 1;
        public const int UpperBoundary = 99;

        private readonly Queue<int> theQueue = new Queue<int>();
        public int Count => theQueue.Count;
        public int Head => theQueue.Peek();
        public bool IsEmpty => theQueue.Count == 0;

        public void Enqueue(int value)
        {
            if (value > UpperBoundary)
            {
                throw new ArgumentException("Value too high");
            }

            if (value < LowerBoundary)
            {
                throw new ArgumentException("value too low");
            }

            theQueue.Enqueue(value);
        }

        public void Dequeue()
        {
            theQueue.Dequeue();
        }
    }
}

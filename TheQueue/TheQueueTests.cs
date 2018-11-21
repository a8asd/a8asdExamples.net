using NUnit.Framework;
using System;

namespace TheQueue
{
    public class TheQueueTests
    {
        [Test]
        public void NewQueueHasNoItems()
        {
            TddQueue queue = new TddQueue();
            Assert.AreEqual(0, queue.Count);
        }

        [Test]
        public void AddingItemIncreasesCount()
        {
            TddQueue queue = new TddQueue();
            queue.Enqueue(43);
            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void AddingTooManyItemsThrowsException()
        {
            var queue = new TddQueue();
            Assert.Throws<ArgumentException>(() => queue.Enqueue(37));
        }
    }

    internal class TddQueue
    {
        public int Count
        {
            get; set;
        }

        public void Enqueue(int v)
        {
            ++Count;
        }
    }
}

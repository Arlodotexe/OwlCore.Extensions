namespace OwlCore.Extensions.Tests
{
    [TestClass]
    public class AsyncEnumerableExtensions
    {
        [DataRow(1000, 100)]
        [DataRow(100, 20)]
        [DataRow(100, 5)]
        [DataRow(100, 5)]
        [DataRow(100, 1)]
        [TestMethod, Timeout(1000)]
        public async Task BatchSize(int total, int batchSize)
        {
            await foreach (var batch in AsyncEnumerable.Range(0, total).Batch(batchSize))
            {
                Assert.IsTrue(batchSize == batch.Count);
            }
        }

        [DataRow(1000, 100)]
        [DataRow(5, 3)]
        [DataRow(100, 3)]
        [DataRow(100, 3)]
        [TestMethod, Timeout(1000)]
        public async Task BatchCount(int total, int batchSize)
        {
            var expectedBatchCount = Math.Ceiling((double)total / batchSize);
            var batchesEmitted = 0;

            await foreach (var _ in AsyncEnumerable.Range(0, total).Batch(batchSize))
                batchesEmitted++;

            Assert.AreEqual(expectedBatchCount, batchesEmitted);
        }

        [TestMethod, DataRow(0, -1)]
        [DataRow(0, 0)]
        public async Task PositiveBatchSizeOnly(int total, int batchSize)
        {
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await AsyncEnumerable.Range(0, total).Batch(batchSize).ToListAsync());
        }

        [DataRow(1000, 100)]
        [DataRow(100, 20)]
        [DataRow(100, 5)]
        [DataRow(100, 5)]
        [DataRow(100, 1)]
        [TestMethod, Timeout(1000)]
        public async Task BatchOrder(int total, int batchSize)
        {
            var currentNumber = 0;

            await foreach (var batch in AsyncEnumerable.Range(0, total).Batch(batchSize))
            {
                foreach (var item in batch)
                {
                    Assert.AreEqual(expected: currentNumber++, actual: item);
                }
            }
        }
    }
}

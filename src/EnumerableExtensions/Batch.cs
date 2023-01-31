using CommunityToolkit.Diagnostics;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OwlCore.Extensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Yields <typeparam name="TSource"/> in batches instead of yielding each individual item.
        /// </summary>
        /// <param name="source">The source to enumerate for batching.</param>
        /// <param name="batchSize">The size of each batch.</param>
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int batchSize)
        {
            Guard.IsGreaterThan(value: batchSize, minimum: 0);

            var currentBatch = new List<TSource>();

            foreach (var item in source)
            {
                currentBatch.Add(item);

                if (currentBatch.Count != batchSize)
                    continue;

                yield return currentBatch;
                currentBatch = new();
            }

            // If the batch has items, they were added without being yielded.
            if (currentBatch.Count > 0)
                yield return currentBatch;
        }
    }
}
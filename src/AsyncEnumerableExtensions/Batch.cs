using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Diagnostics;

// ReSharper disable once CheckNamespace
namespace OwlCore.Extensions
{
    /// <summary>
    /// Extension methods related to IAsyncEnumerable{T}.
    /// </summary>
    public static partial class AsyncEnumerableExtensions
    {
        /// <summary>
        /// Yields <typeparam name="TSource"/> in batches instead of yielding each individual item.
        /// </summary>
        /// <param name="sources">The source to enumerate for batching.</param>
        /// <param name="batchSize">The size of each batch.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work if it has not yet started.</param>
        public static async IAsyncEnumerable<IList<TSource>> Batch<TSource>(this IAsyncEnumerable<TSource> sources, int batchSize, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            Guard.IsGreaterThan(value: batchSize, minimum: 0);

            var currentBatch = new List<TSource>();

            await foreach (var item in sources.WithCancellation(cancellationToken))
            {
                currentBatch.Add(item);

                if (currentBatch.Count == batchSize)
                {
                    yield return currentBatch;
                    currentBatch = new();
                }
            }

            // If the batch has items, they were added without being yielded.
            if (currentBatch.Count > 0)
            {
                yield return currentBatch;
            }
        }
    }
}
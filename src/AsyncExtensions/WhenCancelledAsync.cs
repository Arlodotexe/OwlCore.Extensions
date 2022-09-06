using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace OwlCore.Extensions
{
    public static partial class AsyncExtensions
    {
        /// <summary>
        /// Awaits the cancellation of a <see cref="CancellationToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to watch for cancellation.</param>
        /// <param name="selfCancellationToken">When this token is cancelled, internal data is disposed and this task throw <see cref="TaskCanceledException"/>.</param>
        /// <returns>A <see cref="Task"/> that completes if the provided <paramref name="cancellationToken"/> is cancelled.</returns>
        /// <exception cref="TaskCanceledException"/>
        public static async Task WhenCancelledAsync(this CancellationToken cancellationToken, CancellationToken? selfCancellationToken = null)
        {
            var taskCompletionSource = new TaskCompletionSource<object?>();

            var cancellationRegistration = cancellationToken.Register(() =>
            {
                taskCompletionSource.SetResult(null);
            });

            selfCancellationToken?.Register(() =>
            {
                taskCompletionSource.SetCanceled();
            });

            await taskCompletionSource.Task;
            cancellationRegistration.Dispose();
        }
    }
}
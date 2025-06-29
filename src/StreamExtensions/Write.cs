using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwlCore.Extensions
{
    public static partial class StreamExtensions
    {
        /// <summary>
        /// Writes text to the specified <paramref name="output"/> stream using the specified <paramref name="encoding"/>.
        /// </summary>
        /// <param name="output">The output stream to write to.</param>
        /// <param name="text">The text to write.</param>
        /// <param name="encoding">The encoding to use for the output stream.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the arguments are null.</exception>
        public static void WriteText(this Stream output, string text, Encoding encoding)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            var bytes = encoding.GetBytes(text);
            output.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Asynchronously writes text to the specified <paramref name="output"/> stream using the specified <paramref name="encoding"/>.
        /// </summary>
        /// <param name="output">The output stream to write to.</param>
        /// <param name="text">The text to write.</param>
        /// <param name="encoding">The encoding to use for the output stream.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the ongoing <see cref="Task"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the arguments are null.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled.</exception>
        public static async Task WriteTextAsync(this Stream output, string text, Encoding encoding, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            var bytes = encoding.GetBytes(text);
            await output.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }
    }
}

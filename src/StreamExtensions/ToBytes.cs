using System;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace OwlCore.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Stream"/>
    /// </summary>
    public static partial class StreamExtensions
    {
        /// <summary>
        /// Converts the <paramref name="input"/> <see cref="Stream"/> to a byte array.
        /// </summary>
        /// <remarks>
        /// The method will seek to the start of the stream, read (and copy into a MemoryStream) until it runs out of data. It then asks the MemoryStream to return a copy of the data in an array.
        /// </remarks>
        public static byte[] ToBytes(this Stream input)
        {
            var originalPosition = input.Position;
            if (input.Position != 0)
            {
                if (input.CanSeek)
                    input.Position = 0;
                else
                    throw new ArgumentException("Stream is not at position 0 and is unable to seek.", nameof(input));
            }

            using var memStream = new MemoryStream();
            input.CopyTo(memStream);

            if (input.CanSeek)
                input.Position = originalPosition;

            return memStream.ToArray();
        }

        /// <summary>
        /// Converts the <paramref name="input"/> <see cref="Stream"/> to a byte array.
        /// </summary>
        /// <remarks>
        /// The method will seek to the start of the stream, read (and copy into a MemoryStream) until it runs out of data. It then asks the MemoryStream to return a copy of the data in an array.
        /// </remarks>
        public static async Task<byte[]> ToBytesAsync(this Stream input)
        {
            var originalPosition = input.Position;
            if (input.Position != 0)
            {
                if (input.CanSeek)
                    input.Position = 0;
                else
                    throw new ArgumentException("Stream is not at position 0 and is unable to seek.", nameof(input));
            }

            using var memStream = new MemoryStream();
            await input.CopyToAsync(memStream);

            if (input.CanSeek)
                input.Position = originalPosition;

            return memStream.ToArray();
        }
    }
}

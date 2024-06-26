﻿using System.IO;
using System.Threading;
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
        /// The method will read and copy into a MemoryStream until it runs out of data. It then asks the MemoryStream to return a copy of the data in an array.
        /// </remarks>
        public static byte[] ToBytes(this Stream input)
        {
            using var memStream = new MemoryStream();
            input.CopyTo(memStream);
            return memStream.ToArray();
        }

        /// <summary>
        /// Converts the <paramref name="input"/> <see cref="Stream"/> to a byte array asynchronously.
        /// </summary>
        /// <remarks>
        /// The method will read and copy into a MemoryStream until it runs out of data. It then asks the MemoryStream to return a copy of the data in an array.
        /// </remarks>
        public static async Task<byte[]> ToBytesAsync(this Stream input, CancellationToken cancellationToken = default)
        {
            using var memStream = new MemoryStream();
            await input.CopyToAsync(memStream, 81920, cancellationToken);
            return memStream.ToArray();
        }
    }
}

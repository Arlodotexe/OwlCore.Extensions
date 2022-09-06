using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace OwlCore.Extensions
{
    /// <summary>
    /// Provides extension methods for operating on arbitrary types.
    /// </summary>
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Cast from one type to another.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <returns>The same object, cast to the requested type.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTarget Cast<TTarget>(this object obj)
            where TTarget : class
        {
            return (TTarget)obj;
        }

        /// <summary>
        /// Cast from one type to another.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <returns>The same object, cast to the requested type.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TTarget> Cast<TTarget>(this IEnumerable enumerable)
        {
            return System.Linq.Enumerable.Cast<TTarget>(enumerable);
        }
    }
}
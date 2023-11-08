using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace OwlCore.Extensions
{
    /// <summary>
    /// Extensions for collections and dictionaries.
    /// </summary>
    public static partial class CollectionsExtensions
    {
        /// <summary>
        /// Gets a value from a dictionary, or creates and inserts one if the key doesn't exist.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary's key.</typeparam>
        /// <typeparam name="TValue">The type of the value stored in the dictionary.</typeparam>
        /// <param name="dict">The dictionary to check.</param>
        /// <param name="key">The key to look for.</param>
        /// <param name="createValue">The value to create and add if the key does not exist.</param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue createValue)
            where TKey : notnull
        {
            var valueExists = dict.TryGetValue(key, out TValue? value);

            if (valueExists)
            {
                // Silenced null. We don't care if this returns null, as long as the return type matches the provided input type.
                return value!;
            }
            else
            {
                dict.Add(key, createValue);
                return createValue;
            }
        }
    }
}

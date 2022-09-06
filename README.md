# OwlCore.Extensions [![Version](https://img.shields.io/nuget/v/OwlCore.Extensions.svg)](https://www.nuget.org/packages/OwlCore.Extensions)

A collection of exceptionally useful extension methods.

## Featuring:
- **`IEnumerable{T}.InParallel`** - Runs a specific task in parallel from a list of items.
  -  ```cs
      await items.InParallel(x => x.InitAsync()).
      ```
- **`SynchronizationContext.PostAsync`** - Asynchronously wait for a SynchronizationContext.Post call to finish.
- **`CancellationToken.WhenCancelled`** - Await the cancellation of a token using a task.
- **`DateTime.ChangeYear`**, **`DateTime.ChangeMonth`**, **`DateTime.ChangeDay`** - Return a new DateTime with a changed day, month or year.
- **`IEnumerable{T}.DistinctBy`** - .NET Standard 2.0 support for DistinctBy.
- **`IEnumerable{T}.PruneNull`** - Quickly remove null values and return a non-nullable cast.
- **`ObservableCollection.Sort`** - Sort an ObservableCollection using a Comparer{T}.
- **`T[].Shuffle`**, **`T[].Unshuffle`** - Shuffles the given array in place using a slightly modified fisher-yates algorithm, ensuring that no item remains in the same position.
  - Shuffling returns a "shuffle map" that can be used to map items to their original positions and `Unshuffle()` the collection, even if the order of items is changed while shuffled.
- **`IList{T}.InsertOrAdd`**, **`IList{T}.InsertOrAddRange`** - Inserts one or more items into an IList{T}, or adds if the index is the size of the list.
- **`IList{T}.Pop`** - Removes and returns the last item in the provided list.
- **`Stream.ReadToNull`** - Reads a sequence of bytes from a stream until a null byte is read.
- **`Stream.ToBytes`**, **`Stream.ToBytesAsync`** - Converts a Stream to a byte array.
- ... and more not listed here.

## Install

Published releases are available on [NuGet](https://www.nuget.org/packages/OwlCore.Extensions). To install, run the following command in the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console).

    PM> Install-Package OwlCore.Extensions
    
Or using [dotnet](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet)

    > dotnet add package OwlCore.Extensions

## Usage
Simply install the package, add a `using` statement, and start using the extension methods.

```cs
using OwlCore.Extensions;
```

## Financing

We accept donations, and we do not have any active bug bounties.

If you’re looking to contract a new project, new features, improvements or bug fixes, please contact me. 

## Versioning

Version numbering follows the Semantic versioning approach. However, if the major version is `0`, the code is considered alpha and breaking changes may occur as a minor update.

## License

We’re using the MIT license for 3 reasons:
1. We're here to share useful code. You may use any part of it freely, as the MIT license allows. 
2. A library is no place for viral licensing.
3. Easy code transition to larger community-based projects, such as the .NET Community Toolkit.


# OwlCore.Extensions [![Version](https://img.shields.io/nuget/v/OwlCore.Extensions.svg)](https://www.nuget.org/packages/OwlCore.Extensions)

A collection of exceptionally useful extension methods.

## Featuring:
- **`IEnumerable{T}.InParallel`** - Runs a specific task in parallel from a list of items.
    ```cs
      await items.InParallel(x => x.InitAsync());
    ```
- **`IEnumerable{T}.DistinctBy`**: .NET Standard 2.0 support for DistinctBy.
- **`IEnumerable{T}.PruneNull`**: Quickly remove null values and return a non-nullable cast.
- **`IList{T}.InsertOrAdd`**, **`IList{T}.InsertOrAddRange`**: Inserts one or more items into an IList{T}, or adds if the index is the size of the list.
- **`IList{T}.Pop`**: Removes and returns the last item in the provided list.
- **`T[].Shuffle`**, **`T[].Unshuffle`**: Shuffles the given array in place using fisher-yates, ensuring that no item remains in the same position.
  - Shuffling returns a "shuffle map" that can be used to map items to their original positions and `T[].Unshuffle()` the collection.
  - Enables freely modifying the shuffled list. Keep the shuffle map in sync with changes, and you can always `T[].Unshuffle()` the collection.
- **`ObservableCollection.Sort`**: Sort an ObservableCollection using a Comparer{T}.
- **`SemaphoreSlim.DisposableWaitAsync()`**: Provides syntactic sugar for releasing a `SemaphoreSlim` when execution leaves a `using` statement.
  ```cs
    using (await _myMutex.DisposableWaitAsync())
    {
        // do something inside the mutex.
        // Release happens automatically when execution leaves this `using` statement.
    }
  ```
- **`SynchronizationContext.PostAsync`**: Asynchronously wait for a SynchronizationContext.Post call to finish.
- **`CancellationToken.WhenCancelled`**: Await the cancellation of a token using a task.
- **`DateTime.ChangeYear`**, **`DateTime.ChangeMonth`**, **`DateTime.ChangeDay`**: Return a new DateTime with a changed day, month or year.
- **`Stream.ReadToNull`**: Reads a sequence of bytes from a stream until a null byte is read.
- **`Stream.ToBytes`**, **`Stream.ToBytesAsync`**: Quickly convert a Stream to a byte array.
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

We accept donations [here](https://github.com/sponsors/Arlodotexe) and [here](https://www.patreon.com/arlodotexe), and we do not have any active bug bounties.

## Versioning

Version numbering follows the Semantic versioning approach. However, if the major version is `0`, the code is considered alpha and breaking changes may occur as a minor update.

## License

All OwlCore code is licensed under the MIT License. OwlCore is licensed under the MIT License. See the [LICENSE](./src/LICENSE.txt) file for more details.

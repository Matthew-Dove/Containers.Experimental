# Containers.Experimental
A graveyard / testing ground of container types that didn't meet the cut, or have been made redundant to language / framework (_C# / .NET_) improvements over time.

![Banner](assets/images/girl-with-red-hat-6TKVyi11oCM-unsplash.jpg)

## Source

You can find the source projects these types where (_most likely_) originally from:  
* [ContainerExpressions](https://github.com/Matthew-Dove/ContainerExpressions)
* [FrameworkContainers](https://github.com/Matthew-Dove/FrameworkContainers)

## Loop`<T>`

A type to hold collections of things, not unlike `IEnumerable<T>`.  
`Loop<T>` can be used in the following ways:  
* for loops
* while loops
* foreach loops
* indexed directly
* incremented, or decremented
* any of `Linq`'s extension methods

The point of `Loop<T>`, was to make a more efficient `IEnumerable<T>`, by using `unsafe` methods from the `MemoryMarshal` class, and friends.  
Giving devs an easy to use interface into performant code.  

`Loop<T>` was abandoned due to the following concerns:  
* `Loop<T>` suffers from the same issue that `IEnumerable<T>` does: function calls for each element.
* Having to re-implement all of `Linq`, and keeping up with it - is a huge undertaking.
* As the .NET framework, and the BCL are updated overtime with even faster read / write methods for collections, `Loop<T>` will lag behind.
* `Linq` is already being updated with the `unsafe` improvements in .net 8+, making efforts in `loop<T>` redundant at best, and underperformant at worst.

Example using `Loop<T>`:
```cs
string[] source = new[] { "1", "2", "3" };

string[] items = new string[source.Length];
Loop<string> loop = new(source);

// Copy loop's elements into the items collection.
while (loop)
{
    source[loop] = loop;
}

// Lengths are the same.
Assert.AreEqual(items.Length, loop);

// Elements are the same.
Assert.AreEqual(loop[0], _items[0]);
Assert.AreEqual(loop[1], _items[1]);
Assert.AreEqual(loop[2], _items[2]);
```

We see `Loop<T>` has some cool casting tricks here:  
* Cast to `true` in the `while` condition, as long as it still has remaining elements.
* Cast to `int` when used as an indexer.
* Cast to `T` when trying to read out the element.

`Loop<T>` takes away the boilerplate when dealing with colections.  
`Loop<T>` is faster than using standard array indexers.  
`Loop<T>` will be quickly be made redundant, as improvements come to the common types we use everyday in the BCL; hence it being moved here.  

# Credits

Special thanks to the following:  
* [Girl with red hat](https://unsplash.com/@girlwithredhat) from unsplash for the [banner image](https://unsplash.com/photos/6TKVyi11oCM).

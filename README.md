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
while (loop) // loop is a boolean here!
{
    source[loop] = loop; // loop is both an int (index), and a string (element) here!
}

// Assert lengths are the same.
Assert.AreEqual(items.Length, loop);

// Assert elements are the same.
Assert.AreEqual(loop[0], items[0]);
Assert.AreEqual(loop[1], items[1]);
Assert.AreEqual(loop[2], items[2]);
```

We see `Loop<T>` has some cool casting tricks here:  
* Cast to `true` in the `while` condition, as long as it still has remaining elements.
* Cast to `int` when used as an indexer.
* Cast to `T` when trying to read out the element.

`Loop<T>` takes away the boilerplate when dealing with colections.  
`Loop<T>` is faster than using standard array indexers.  
`Loop<T>` will be quickly be made redundant, as improvements come to the common types we use everyday in the BCL; hence it being moved here.  

## Match`<T>`

Let's say you'd like to do different things based on the state of some input.  
For example summing an array of integers, you have three states, the array is null, the array is empty, the array has more then zero elements.  
You can have a pattern for each state (or a subset of the states), and have different behaviour for each pattern.  

In the example below when the input is null, we return an invalid response, when the input has no elements, we return 0, otherwise we return the sum of the array's elements.

```cs
var input = new int[] { 1, 2, 3 };

var result = Expression.Match(input,
    Pattern.Create<int[], int>(x => x == null, _ => Response.Create<int>()), // When null, return an invalid response.
    Pattern.Create<int[], int>(x => x.Length == 0, _ => Response.Create(0)), // When empty, return 0.
    Pattern.Create<int[], int>(x => x.Length > 0, Sum) // When more than zero elements exist, sum them, and return that result.
);

// Sum all elements in the array.
static Response<int> Sum(int[] numbers)
{
	var count = 0;
	for (int i = 0; i < numbers.Length; i++)
	{
		count += numbers[i];
	}
	return Response.Create(count);
}
```

`Match<T>` was abandoned due to C# adding native pattern matching to the language, that is much more powerful, and ever expanding in it's capability.  
Truth be told, I never once found a good use for it in my production code either; and it's a bit verbose to write out.  

# Credits

Thanks to the following:  
* [Girl with red hat](https://unsplash.com/@girlwithredhat) from unsplash for the [banner image](https://unsplash.com/photos/6TKVyi11oCM).

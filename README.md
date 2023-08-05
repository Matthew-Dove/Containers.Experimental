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
Truth be told, I never found a good use for it in my production code either; and it's a bit verbose to write out.  

## ResponseValueTask`<T>`

A helper type for the `Response` custom awaiters.  
`ResponseValueTask<T>` serves as a bridge between `Task<T>` / `ValueTask<T>`, and `Response<T>`.  
The core difference between `ResponseValueTask<T>`, and `Response<T>`; is `ResponseValueTask<T>` is constrained to be a `ValueTask<T>`.  
This allows us to cast easily from some `Task<T>`, to `ResponseValueTask<T>`, and then down to `Response<T>`.  
For example:

```cs
// Function to call.
static async Task<int> Divide(int numerator, int denominator)
{
    var quotient = numerator / denominator;
    await Task.Delay(1);
    return quotient;
}

// Calling code.
ResponseValueTask<int> successResponse = Divide(1, 1); 
Response<int> success = await successResponse; // Response<int> success = Divide(1, 1); is not possible to cast; so we use ResponseValueTask<int>.

ResponseValueTask<int> errorResponse = Divide(1, 0); // This would normally be a runtime exception.
Response<int> error = await errorResponse;

Assert.IsTrue(success);
Assert.AreEqual(1, success);
Assert.IsFalse(error);
```

Writing out the types on seperate lines is not necessary (*i.e.*):

```cs
Response<int> success = await new ResponseValueTask<int>(Divide(1, 1)); // OK.
Response<int> error = await new ResponseValueTask<int>(Divide(1, 0)); // Fail (but no runtime exception).

Assert.IsTrue(success);
Assert.AreEqual(1, success);
Assert.IsFalse(error);
```

It's fine to use `var` too, as it's the awaiter that determines the type:

```cs
// No need to wrap Task<T> types in try catches anymore!
var success = await new ResponseValueTask<int>(Divide(1, 1));
var error = await new ResponseValueTask<int>(Divide(1, 0));
```

## ResponseTask`<T>`

`ResponseTask<T>`, has all the properties of `ResponseValueTask<T>` - except it only works with `Task`, not `ValueTask`, or some pre-calculated value of `T`.  
This is the one you should be using 90% of the time, as `ResponseValueTask<T>` is only better in specific scenarios (*for all the same reasons as .net's `ValueTask`*).  

`ResponseValueTask<T>`, and `ResponseTask<T>` where abandoned due to the more generic type: `ResponseAsync<T>`.  
These types provided a safe conversion from `Task<T>`, or `ValueTask<T>` into `Response<T>`.  
The conversions are also handled by `ResponseAsync<T>`'s extension methods i.e. `AsResponse()`, making these types redundant.  

# Credits

Thanks to the following:  
* [Girl with red hat](https://unsplash.com/@girlwithredhat) from unsplash for the [banner image](https://unsplash.com/photos/6TKVyi11oCM).

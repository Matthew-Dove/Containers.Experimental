using System;

namespace Containers.Experimental.Containers.Internal
{
    /** Note: Not an experimental type, but required as a dependency. **/

    // Jit will keep these methods cold, until they are used (as long as they only throw exceptions as a single instruction).
    internal static class Throw
    {
        public static void ArgumentNullException(string name) => throw new ArgumentNullException(name);

        public static void InvalidOperationException(string message) => throw new InvalidOperationException(message);
    }
}

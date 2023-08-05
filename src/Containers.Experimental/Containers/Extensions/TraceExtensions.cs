using System;

namespace Containers.Experimental.Containers
{
    /** Note: Not an experimental type, but required as a dependency. **/

    /// <summary>Extensions for the Trace Container.</summary>
    public static class TraceExtensions
    {
        // Log without caturing any caller attributes, so the logs are not confusing (i.e. exposing internal methods / expressions).
        internal static AggregateException LogErrorPlain(this AggregateException ex)
        {
            if (ex == null) return default;
            // Log exception here...
            return ex;
        }
    }
}

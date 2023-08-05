﻿using Containers.Experimental.Containers.Internal;
using System.Threading.Tasks;
using System;
using Containers.Experimental.Containers;

namespace Containers.Experimental.Expressions.Models
{
    // <summary>Defines an input matcher, and a function to run, if that pattern matches.</summary>
    public readonly struct PatternAsync<TInput, TResult>
    {
        private readonly Func<TInput, bool> _evaluate;
        private readonly Func<TInput, Task<Response<TResult>>> _execute;

        /// <summary>Defines an input matcher, and a function to run, if that pattern matches.</summary>
        public PatternAsync(Func<TInput, bool> evaluate, Func<TInput, Task<Response<TResult>>> execute)
        {
            if (evaluate == null)
                Throw.ArgumentNullException(nameof(evaluate));
            if (execute == null)
                Throw.ArgumentNullException(nameof(execute));

            _evaluate = evaluate;
            _execute = execute;
        }

        /// <summary>Returns true if this patten matches.</summary>
        internal bool Evaluate(TInput input) => _evaluate(input);

        /// <summary>Invokes the function matching the pattern.</summary>
        internal Task<Response<TResult>> Execute(TInput input) => _execute(input);
    }

    /// <summary>Defines an input matcher, and a function to run, if that pattern matches.</summary>
    public readonly struct PatternAsync<TPivot, TInput, TResult>
    {
        private readonly Func<TPivot, bool> _evaluate;
        private readonly Func<TInput, Task<Response<TResult>>> _execute;

        /// <summary>Defines an input matcher, and a function to run, if that pattern matches.</summary>
        public PatternAsync(Func<TPivot, bool> evaluate, Func<TInput, Task<Response<TResult>>> execute)
        {
            if (evaluate == null)
                Throw.ArgumentNullException(nameof(evaluate));
            if (execute == null)
                Throw.ArgumentNullException(nameof(execute));

            _evaluate = evaluate;
            _execute = execute;
        }

        /// <summary>Returns true if this patten matches.</summary>
        internal bool Evaluate(TPivot pivot) => _evaluate(pivot);

        /// <summary>Invokes the function matching the pattern.</summary>
        internal Task<Response<TResult>> Execute(TInput input) => _execute(input);
    }
}

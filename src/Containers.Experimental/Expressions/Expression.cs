using Containers.Experimental.Containers;
using Containers.Experimental.Expressions.Models;
using System.Threading.Tasks;

namespace Containers.Experimental.Expressions
{
    /// <summary>Entry class for using Expressions.</summary>
    public static class Expression
    {
        #region Match

        #region Synchronous

        #region InputMatch

        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern) => Core.Match.Pattern(input, pattern);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2) => Core.Match.Pattern(input, pattern1, pattern2);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2, Pattern<TInput, TResult> pattern3) => Core.Match.Pattern(input, pattern1, pattern2, pattern3);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2, Pattern<TInput, TResult> pattern3, Pattern<TInput, TResult> pattern4) => Core.Match.Pattern(input, pattern1, pattern2, pattern3, pattern4);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2, Pattern<TInput, TResult> pattern3, Pattern<TInput, TResult> pattern4, Pattern<TInput, TResult> pattern5) => Core.Match.Pattern(input, pattern1, pattern2, pattern3, pattern4, pattern5);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2, Pattern<TInput, TResult> pattern3, Pattern<TInput, TResult> pattern4, Pattern<TInput, TResult> pattern5, Pattern<TInput, TResult> pattern6) => Core.Match.Pattern(input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2, Pattern<TInput, TResult> pattern3, Pattern<TInput, TResult> pattern4, Pattern<TInput, TResult> pattern5, Pattern<TInput, TResult> pattern6, Pattern<TInput, TResult> pattern7) => Core.Match.Pattern(input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Response<TResult> Match<TInput, TResult>(TInput input, Pattern<TInput, TResult> pattern1, Pattern<TInput, TResult> pattern2, Pattern<TInput, TResult> pattern3, Pattern<TInput, TResult> pattern4, Pattern<TInput, TResult> pattern5, Pattern<TInput, TResult> pattern6, Pattern<TInput, TResult> pattern7, Pattern<TInput, TResult> pattern8) => Core.Match.Pattern(input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7, pattern8);

        #endregion

        #region PivotMatch

        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern) => Core.Match.Pattern(pivot, input, pattern);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2) => Core.Match.Pattern(pivot, input, pattern1, pattern2);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2, Pattern<TPivot, TInput, TResult> pattern3) => Core.Match.Pattern(pivot, input, pattern1, pattern2, pattern3);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2, Pattern<TPivot, TInput, TResult> pattern3, Pattern<TPivot, TInput, TResult> pattern4) => Core.Match.Pattern(pivot, input, pattern1, pattern2, pattern3, pattern4);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2, Pattern<TPivot, TInput, TResult> pattern3, Pattern<TPivot, TInput, TResult> pattern4, Pattern<TPivot, TInput, TResult> pattern5) => Core.Match.Pattern(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2, Pattern<TPivot, TInput, TResult> pattern3, Pattern<TPivot, TInput, TResult> pattern4, Pattern<TPivot, TInput, TResult> pattern5, Pattern<TPivot, TInput, TResult> pattern6) => Core.Match.Pattern(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2, Pattern<TPivot, TInput, TResult> pattern3, Pattern<TPivot, TInput, TResult> pattern4, Pattern<TPivot, TInput, TResult> pattern5, Pattern<TPivot, TInput, TResult> pattern6, Pattern<TPivot, TInput, TResult> pattern7) => Core.Match.Pattern(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Response<TResult> Match<TPivot, TInput, TResult>(TPivot pivot, TInput input, Pattern<TPivot, TInput, TResult> pattern1, Pattern<TPivot, TInput, TResult> pattern2, Pattern<TPivot, TInput, TResult> pattern3, Pattern<TPivot, TInput, TResult> pattern4, Pattern<TPivot, TInput, TResult> pattern5, Pattern<TPivot, TInput, TResult> pattern6, Pattern<TPivot, TInput, TResult> pattern7, Pattern<TPivot, TInput, TResult> pattern8) => Core.Match.Pattern(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7, pattern8);

        #endregion

        #endregion

        #region Asynchronous

        #region InputMatch

        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern) => Core.MatchAsync.PatternAsync(input, pattern);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2, PatternAsync<TInput, TResult> pattern3) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2, pattern3);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2, PatternAsync<TInput, TResult> pattern3, PatternAsync<TInput, TResult> pattern4) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2, pattern3, pattern4);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2, PatternAsync<TInput, TResult> pattern3, PatternAsync<TInput, TResult> pattern4, PatternAsync<TInput, TResult> pattern5) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2, pattern3, pattern4, pattern5);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2, PatternAsync<TInput, TResult> pattern3, PatternAsync<TInput, TResult> pattern4, PatternAsync<TInput, TResult> pattern5, PatternAsync<TInput, TResult> pattern6) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2, PatternAsync<TInput, TResult> pattern3, PatternAsync<TInput, TResult> pattern4, PatternAsync<TInput, TResult> pattern5, PatternAsync<TInput, TResult> pattern6, PatternAsync<TInput, TResult> pattern7) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7);
        /// <summary>Invoke a function if the input patten matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TInput, TResult>(TInput input, PatternAsync<TInput, TResult> pattern1, PatternAsync<TInput, TResult> pattern2, PatternAsync<TInput, TResult> pattern3, PatternAsync<TInput, TResult> pattern4, PatternAsync<TInput, TResult> pattern5, PatternAsync<TInput, TResult> pattern6, PatternAsync<TInput, TResult> pattern7, PatternAsync<TInput, TResult> pattern8) => Core.MatchAsync.PatternAsync(input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7, pattern8);

        #endregion

        #region PivotMatch

        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern) => Core.MatchAsync.PatternAsync(pivot, input, pattern);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2, PatternAsync<TPivot, TInput, TResult> pattern3) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2, pattern3);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2, PatternAsync<TPivot, TInput, TResult> pattern3, PatternAsync<TPivot, TInput, TResult> pattern4) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2, pattern3, pattern4);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2, PatternAsync<TPivot, TInput, TResult> pattern3, PatternAsync<TPivot, TInput, TResult> pattern4, PatternAsync<TPivot, TInput, TResult> pattern5) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2, PatternAsync<TPivot, TInput, TResult> pattern3, PatternAsync<TPivot, TInput, TResult> pattern4, PatternAsync<TPivot, TInput, TResult> pattern5, PatternAsync<TPivot, TInput, TResult> pattern6) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2, PatternAsync<TPivot, TInput, TResult> pattern3, PatternAsync<TPivot, TInput, TResult> pattern4, PatternAsync<TPivot, TInput, TResult> pattern5, PatternAsync<TPivot, TInput, TResult> pattern6, PatternAsync<TPivot, TInput, TResult> pattern7) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7);
        /// <summary>Invoke a function if the pivot patten (some external variable) matches.</summary>
        public static Task<Response<TResult>> MatchAsync<TPivot, TInput, TResult>(TPivot pivot, TInput input, PatternAsync<TPivot, TInput, TResult> pattern1, PatternAsync<TPivot, TInput, TResult> pattern2, PatternAsync<TPivot, TInput, TResult> pattern3, PatternAsync<TPivot, TInput, TResult> pattern4, PatternAsync<TPivot, TInput, TResult> pattern5, PatternAsync<TPivot, TInput, TResult> pattern6, PatternAsync<TPivot, TInput, TResult> pattern7, PatternAsync<TPivot, TInput, TResult> pattern8) => Core.MatchAsync.PatternAsync(pivot, input, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7, pattern8);

        #endregion

        #endregion

        #endregion
    }
}

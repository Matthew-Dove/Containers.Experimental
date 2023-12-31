﻿using Containers.Experimental.Expressions;
using Containers.Experimental.Expressions.Models;

namespace Tests.Containers.Experimental.Expressions.Core
{
    [TestClass]
    public class MatchAsyncTests
    {
        private readonly static Func<int, bool> _isEven = x => x % 2 == 0;

        private static async Task<T> WaitThenDo<T>(Func<T> func)
        {
            await Task.Delay(0);
            return func();
        }

        [TestMethod]
        public async Task OnePattern_HasMatch_IsValid()
        {
            var guid = Guid.NewGuid();

            var pattern = await Expression.MatchAsync(10,
                Pattern.CreateAsync(_isEven, _ => WaitThenDo(() => Response.Create(guid)))
            );

            Assert.IsTrue(pattern);
            Assert.AreEqual(guid, pattern);
        }

        [TestMethod]
        public async Task OnePattern_HasNoMatch_IsNotValid()
        {
            var pattern = await Expression.MatchAsync(9,
                Pattern.CreateAsync(_isEven, _ => WaitThenDo(() => Response.Create(Guid.NewGuid())))
            );

            Assert.IsFalse(pattern);
        }

        [TestMethod]
        public async Task TwoPatterns_SkipsPatternsUntil_MatchIsFound()
        {
            var guid = Guid.NewGuid();

            var pattern = await Expression.MatchAsync(10,
                Pattern.CreateAsync<int, Guid>((x) => !_isEven(x), _ => WaitThenDo(() => Response.Create(Guid.NewGuid()))), // Skips thi pattern.
                Pattern.CreateAsync<int, Guid>(_isEven, _ => WaitThenDo(() => Response.Create(guid))) // Pattern match.
            );

            Assert.IsTrue(pattern);
            Assert.AreEqual(guid, pattern);
        }

        [TestMethod]
        public async Task PivotMatch_ExecutesCorrectPattern()
        {
            var pivot = 1;
            var guid = new Guid();

            var pattern = await Expression.MatchAsync(pivot, guid,
                Pattern.CreateAsync<int, Guid, Guid>(x => x == 0, _ => Task.FromResult(Response.Create(Guid.NewGuid()))),
                Pattern.CreateAsync<int, Guid, Guid>(x => x == 1, id => Task.FromResult(Response.Create(id)))
            );

            Assert.IsTrue(pattern);
            Assert.AreEqual(guid, pattern);
        }
    }
}

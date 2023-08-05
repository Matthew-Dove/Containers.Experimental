using Containers.Experimental.Expressions;
using Containers.Experimental.Expressions.Models;

namespace Tests.Containers.Experimental.Examples
{
    [TestClass]
    public class MatchTExample
    {
        [TestMethod]
        public void MatchT_Example()
        {
            var input = new int[] { 1, 2, 3 };

            var result = Expression.Match(input,
                Pattern.Create<int[], int>(x => x == null, _ => new Response<int>()),
                Pattern.Create<int[], int>(x => x.Length == 0, _ => Response.Create(0)),
                Pattern.Create<int[], int>(x => x.Length > 0, Sum)
            );

            Assert.IsTrue(result);
            Assert.AreEqual(System.Linq.Enumerable.Sum(input), result);
        }

        private static Response<int> Sum(int[] numbers)
        {
            var count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                count += numbers[i];
            }
            return Response.Create(count);
        }
    }
}

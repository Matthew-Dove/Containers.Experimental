namespace Tests.Containers.Experimental.Containers
{
    [TestClass]
    public class AwaiterTests
    {
        [TestMethod]
        public async Task TaskResponse_Pass()
        {
            var response = await new ResponseTask(Task.CompletedTask);
            Assert.IsTrue(response);
        }

        [TestMethod]
        public async Task TaskResponse_With_T_Pass()
        {
            var response = await new ResponseTask<int>(Task.FromResult(1));
            Assert.IsTrue(response);
            Assert.AreEqual(1, response);
        }

        [TestMethod]
        public async Task Runtime_Errors_Are_Handled_Async()
        {
            ResponseValueTask successResponse = Divide(1, 1);
            Response success = await successResponse;

            Response err = await new ResponseValueTask(Divide(1, 0));
            ResponseValueTask errorResponse = Divide(1, 0);
            Response error = await errorResponse;

            Assert.IsTrue(success);
            Assert.IsFalse(error);
            Assert.IsFalse(err);
        }

        [TestMethod]
        public async Task Runtime_Errors_WithT_Are_Handled_Async()
        {
            ResponseValueTask<int> successResponse = Divide(1, 1);
            Response<int> success = await successResponse;

            ResponseValueTask<int> errorResponse = Divide(1, 0);
            Response<int> error = await errorResponse;
            Response<int> err = await new ResponseValueTask<int>(Divide(1, 0));

            Assert.IsTrue(success);
            Assert.AreEqual(1, success);
            Assert.IsFalse(error);
            Assert.IsFalse(err);
        }

        private static async Task<int> Divide(int numerator, int denominator)
        {
            var quotient = numerator / denominator;
            await Task.Delay(1); // The method must use async await, otherwise the exception will be thrown at runtime instead of being handled.
            return quotient;
        }
    }
}

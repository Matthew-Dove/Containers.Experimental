﻿namespace Tests.Containers.Experimental.Containers
{
    [TestClass]
    public class LoopTests
    {
        private static readonly string[] _items = new[] { "1", "2", "3" };

        private Loop<string> _loop;

        [TestInitialize]
        public void Initialize()
        {
            _loop = new Loop<string>(_items);
        }

        [TestMethod] public void Index00() => Assert.AreEqual(0, _loop);
        [TestMethod] public void Index01() => Assert.AreEqual(1, _loop.Seek(1));
        [TestMethod] public void Index02() => Assert.AreEqual(2, _loop.Seek(1) + 1);
        [TestMethod] public void Index03() => Assert.AreEqual(3, _loop.Seek(1) + 2);
        [TestMethod] public void Index04() => Assert.AreEqual(0, _loop.Seek(1) - 1);
        [TestMethod] public void Index05() => Assert.AreEqual(0, _loop.Seek(2) - 2);
        [TestMethod] public void Index06() => Assert.AreEqual(1, _loop.Seek(0) + 1);
        [TestMethod] public void Index07() => Assert.AreEqual(-1, _loop - 1);
        [TestMethod] public void Index08() => Assert.AreEqual(0, _loop + 0);
        [TestMethod] public void Index09() => Assert.AreEqual(1, _loop + 1);

        [TestMethod]
        public void Zero()
        {
            string item = _loop;

            Assert.AreEqual(_items[0], item);
        }

        [TestMethod]
        public void Seek()
        {
            _loop.Seek(1);

            string item = _loop;

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void Indexer()
        {
            string item = _loop[1];

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void Increment()
        {
            string item = _loop++;

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void Decrement()
        {
            var loop = _loop + 2;

            string item = _loop--;

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void Add()
        {
            var loop = _loop + 1;

            string item = loop;

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void Minus()
        {
            var loop = _loop + 2;
            loop = loop - 1;

            string item = loop;

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void SeekMinus()
        {
            string item = _loop.Seek(2) - 1;

            Assert.AreEqual(_items[1], item);
        }

        [TestMethod]
        public void GetFirst()
        {
            string item1 = _loop[0];
            string item2 = _loop + 0;
            string item3 = _loop;

            Assert.AreEqual(_items[0], item1);
            Assert.AreEqual(_items[0], item2);
            Assert.AreEqual(_items[0], item3);
        }

        [TestMethod]
        public void GetLast()
        {
            var last = _items.Length - 1;

            string item1 = _loop[last];
            string item2 = _loop + last;
            string item3 = _loop;

            Assert.AreEqual(_items[last], item1);
            Assert.AreEqual(_items[last], item2);
            Assert.AreEqual(_items[last], item3);
        }

        [TestMethod]
        public void ForLoop()
        {
            var items = new string[_items.Length];

            for (; _loop;)
            {
                items[_loop] = _loop;
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);
        }

        [TestMethod]
        public void ForLoopIndex()
        {
            var items = new string[_items.Length];

            for (var i = 0; i < _loop.Length; i++)
            {
                items[i] = _loop[i];
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);
        }

        [TestMethod]
        public void ForLoopEmpty()
        {
            var loop = new Loop<string>(Array.Empty<string>());

            for (; loop;)
            {
                Assert.AreEqual(1, 2);
            }
        }

        [TestMethod]
        public void WhileLoop()
        {
            var items = new string[_items.Length];

            while (_loop)
            {
                items[_loop] = _loop;
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);
        }

        [TestMethod]
        public void WhileLoopIndex()
        {
            var items = new string[_items.Length];

            var i = 0;
            while (i < _loop.Length)
            {
                items[i] = _loop[i++];
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);
        }

        [TestMethod]
        public void WhileLoopEmpty()
        {
            var loop = new Loop<string>(Array.Empty<string>());

            while (loop)
            {
                Assert.AreEqual(1, 2);
            }
        }

        [TestMethod]
        public void ForEachLoop()
        {
            var items = new string[_items.Length];

            var i = 0;
            foreach (var item in _loop)
            {
                items[i++] = item;
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);
        }

        [TestMethod]
        public void TwoForEachLoops()
        {
            var items = new string[_items.Length];

            var i = 0;
            foreach (var item in _loop)
            {
                items[i++] = item;
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);

            items = new string[_items.Length];

            i = 0;
            foreach (var item in _loop)
            {
                items[i++] = item;
            }

            Assert.AreEqual(_items.Length, items.Length);
            Assert.AreEqual(_items[1], items[1]);
        }

        [TestMethod]
        public void ForEachLoopEmpty()
        {
            var loop = new Loop<string>(Array.Empty<string>());

            foreach (var item in loop)
            {
                Assert.AreEqual(1, 2);
            }
        }

        [TestMethod]
        public void LinqEnumerable()
        {
            var items = _loop.Skip(1).Take(1);
            Assert.AreEqual(_items[1], items.Single());
        }

        [TestMethod]
        public void LinqEnumerableTwice()
        {
            var items = _loop.Skip(1).Take(1);
            Assert.AreEqual(_items[1], items.Single());

            items = _loop.Seek().Skip(1).Take(1);
            Assert.AreEqual(_items[1], items.Single());
        }

        [TestMethod]
        public void LinqEnumerableEmpty()
        {
            var loop = new Loop<string>(Array.Empty<string>());

            var items = loop.Skip(1).Take(1);

            Assert.IsFalse(items.Any());
        }

        [TestMethod]
        public void ForEach()
        {
            var count = 0;

            _loop.ForEach(x => count++);

            Assert.AreEqual(count, _items.Length);
        }

        [TestMethod]
        public void Transform()
        {
            var numbers = _loop.Transform(long.Parse);

            Assert.AreEqual(_items.Length, numbers.Length);
            Assert.AreEqual(long.Parse(_items[1]), numbers[1]);
        }

        [TestMethod]
        public void Flattern()
        {
            var loop = Loop.Create(new[] { 1, 1, 1 });

            var sum = loop.Flattern(0, (x, y) => x + y);

            Assert.AreEqual(loop.Sum(), sum);
        }
    }
}

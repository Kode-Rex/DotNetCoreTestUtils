using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace StoneAge.TestUtils
{
    public class MockOptionsSnapshot<T> : IOptionsSnapshot<T> where T: class, new()
    {
        public T Value { get; }

        public MockOptionsSnapshot(T value)
        {
            Value = value;
        }

        public T Get(string name)
        {
            throw new NotImplementedException();
        }
    }

}

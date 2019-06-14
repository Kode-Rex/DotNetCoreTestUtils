using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace StoneAge.TestUtils
{
    public class MockOptions<T> : IOptions<T> where T: class, new()
    {
        public T Value { get; }

        public MockOptions(T value)
        {
            Value = value;
        }
    }

}

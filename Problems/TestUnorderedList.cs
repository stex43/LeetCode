using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Problems
{
    public sealed class TestUnorderedList<T> : List<T>, IEquatable<List<T>>
    {
        public bool Equals(List<T>? other)
        {
            try
            {
                this.Should().BeEquivalentTo(other);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

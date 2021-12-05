using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Problems
{
    public sealed class TestUnorderedCollection<T> : List<T>, IEquatable<IList<T>>
    {
        public bool Equals(IList<T>? other)
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

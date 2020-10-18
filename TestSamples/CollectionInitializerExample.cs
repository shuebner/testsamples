using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSamples
{
class CollectionInitializerExample : IEnumerable
{
    private readonly List<IEnumerable<object>> arraysOfSameType = new List<IEnumerable<object>>();

    public void Add<T>(params T[] valuesOfSameType) => arraysOfSameType.Add(valuesOfSameType.Cast<object>());

    public IEnumerator GetEnumerator() => ((IEnumerable)arraysOfSameType).GetEnumerator();
}

    class Bla
    {
        static void Foo()
        {
var pairSample = new CollectionInitializerExample
{
    { 1, 2, 3, 4 },
    { "foo", "bar" },
    { DateTime.Now, DateTime.UtcNow, DateTime.Today }
};


        }
    }
}

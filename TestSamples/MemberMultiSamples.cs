using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TestSamples
{
    public class MemberMultiSamples<T> : IEnumerable<(PropertyInfo PropertyInfo, object[] Values)>
    {
        private readonly List<(PropertyInfo PropertyInfo, object[] Values)> samples =
            new List<(PropertyInfo PropertyInfo, object[] Values)>();

        public void Add<TValue>(Expression<Func<T, TValue>> propertyExpr, TValue value, params TValue[] additionalValues)
        {
            var propertyInfo = (propertyExpr.Body as MemberExpression)?.Member as PropertyInfo
                ?? throw new ArgumentException($"{nameof(propertyExpr)} must be property expression, but was {propertyExpr}");

            samples.Add((propertyInfo, new object[] { value }.Concat(additionalValues.OfType<object>()).ToArray()));
        }

        public IEnumerator<(PropertyInfo PropertyInfo, object[] Values)> GetEnumerator() =>
            ((IEnumerable<(PropertyInfo PropertyInfo, object[] Values)>)samples).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)samples).GetEnumerator();
    }
}

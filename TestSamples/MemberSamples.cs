using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SvSoft.TestSamples
{
    public class MemberSamples<T> : IEnumerable<(string MemberName, Func<T, object> GetValue, object ExpectedValue)>
    {
        private readonly List<(string MemberName, Func<T, object> GetValue, object ExpectedValue)> samples =
            new List<(string MemberName, Func<T, object> GetValue, object ExpectedValue)>();

        public void Add<TValue>(Expression<Func<T, TValue>> getValueExpr, TValue expectedValue)
        {
            // easier than traversing the expression in the case of nested members
            var exprStr = getValueExpr.ToString();
            var memberName = exprStr.Substring(exprStr.IndexOf(".") + 1);

            samples.Add((memberName, instance => getValueExpr.Compile()(instance), expectedValue));
        }

        public IEnumerator<(string MemberName, Func<T, object> GetValue, object ExpectedValue)> GetEnumerator() =>
            ((IEnumerable<(string MemberName, Func<T, object> GetValue, object ExpectedValue)>)samples).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)samples).GetEnumerator();
    }
}

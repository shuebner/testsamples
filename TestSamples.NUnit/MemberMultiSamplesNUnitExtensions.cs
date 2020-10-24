using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSamples.NUnit
{
    public static class MemberMultiSamplesNUnitExtensions
    {
        private const string NullRepresentation = "<null>";

        public static IEnumerable<TestCaseData> ToTestCaseData<T>(this MemberMultiSamples<T> samples) =>
            samples.SelectMany(s =>
                s.Values.Select(v => 
                    new TestCaseData(s.PropertyInfo, v)
                        .SetArgDisplayNames(
                            s.PropertyInfo.Name,
                            v?.ToString() ?? NullRepresentation)));

        public static IEnumerable<TestCaseData> ToValidationTestCaseData<T>(this MemberMultiSamples<T> samples) =>
            samples.SelectMany(s =>
                s.Values.Select(v =>
                    new TestCaseData(
                        (Action<T, object>)((instance, value) => s.PropertyInfo.SetValue(instance, value)),
                        v)
                    .SetArgDisplayNames(
                        s.PropertyInfo.Name,
                        v?.ToString() ?? NullRepresentation)));
    }
}

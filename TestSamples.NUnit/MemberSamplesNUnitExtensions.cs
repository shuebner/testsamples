using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SvSoft.TestSamples.NUnit
{
    public static class MemberSamplesNUnitExtensions
    {
        public static IEnumerable<TestCaseData> ToTestCaseData<T>(this MemberSamples<T> samples) =>
            samples.Select(s =>
                new TestCaseData(s.GetValue, s.ExpectedValue)
                    .SetArgDisplayNames(
                        s.MemberName,
                        s.ExpectedValue.ToString()));
    }
}

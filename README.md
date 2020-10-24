# testsamples
Library for easy sample-based testing, e. g. for testing mapping, conversion and validation code.
It enables you to test multiple properties with the the same parameterized test method by making it possible to declare generic test samples in a type-safe manner.
You can write test samples for testing a validator like this with complete type safety:
```
static readonly IEnumerable<TestCaseData> InvalidSamples = new MemberMultiSamples<Organisation>
{
    { o => o.Name, null, string.Empty, " ", "no@specialcharactersallowed", "nonumb3rsallowed" },
    { o => o.Registration, null, string.Empty, " ", "wrongformat", "wrong-format", "RN-33-1", "R1-33-X", "1R-33-X", "RR-3A-X" },
    { o => o.FoundedAtDate, default, new DateTime(1899, 12, 31), new DateTime(2000, 1, 1) }
}.ToValidationTestCaseData();
```

For more information see my blog at https://svenhuebner-it.com/use-collection-initializers-to-simplify-tedious-mapping-and-validation-tests/

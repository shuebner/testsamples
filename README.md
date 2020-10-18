# testsamples
Library for easy sample-based testing, e. g. for testing mapping, conversion and validation code.
It enables you to test multiple properties with the the same parameterized test method by making it possible to declare generic test samples in a type-safe manner.
You can write test samples like this with complete type-safety:
```
static IEnumerable<TestCaseData> StaticDataSamples = new MemberSamples<ExportData>
{
    { e => e.Status, Status.OK },
    { e => e.Provider.Function, ProviderFunction.Provider },
    { e => e.Provider.Name, "SomeName" },
    { e => e.Software.Name, "My Awesome Software" },
    { e => e.Software.Vendor.Name, "Some Software Company" },
    { e => e.Software.Vendor.Function, OrganisationFunction.SoftwareVendor },
    { e => e.Software.Vendor.Registration, "200-A-DFF" },
    { e => e.Software.Specification, Specification.V2019_1 },
    // the following would not compile
    //{ e => e.Software.Specification, 4 }
}.ToTestCaseData();
```

For more information see my blog at https://svenhuebner-it.com/use-collection-initializers-to-simplify-tedious-mapping-and-validation-tests/

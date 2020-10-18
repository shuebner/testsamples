using NUnit.Framework;
using SvSoft.TestSamples;
using SvSoft.TestSamples.NUnit;
using System;
using System.Collections.Generic;

namespace TestSamples.ExampleUsage
{
    public class ExporterTests
    {
        private Exporter exporter;

        [SetUp]
        public void Setup()
        {
            exporter = new Exporter();
        }

        [Test]
        [TestCaseSource(nameof(StaticDataSamples))]
        public void Sets_static_data(Func<ExportData, object> getValue, object expectedExport)
        {
            var irrelevantApplicationData = new ApplicationData();
            var exportData = exporter.Export(irrelevantApplicationData);

            Assert.That(getValue(exportData), Is.EqualTo(expectedExport));
        }

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
    }
}
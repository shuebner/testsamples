using System;

namespace TestSamples.ExampleUsage
{
    public class ExportData
    {
        public Provider Provider { get; set; }
        public Status Status { get; set; }
        public Software Software { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
        public ProviderFunction Function { get; set; }
    }

    public class Software
    {
        public Organisation Vendor { get; set; }
        public string Name { get; set; }
        public Specification Specification { get; set; }
        public string Version { get; set; }
        public string Release { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class Organisation
    {
        public string Name { get; set; }
        public string Registration { get; set; }
        public DateTime FoundedAtDate { get; set; }
        public OrganisationFunction Function { get; set; }
    }

    public enum OrganisationFunction
    {
        SoftwareVendor,
        PublicInstitution,
        LawEnforcement
    }

    public enum Specification
    {
        V2019_1,
        V2019_2,
        V2020_1
    }

    public enum ProviderFunction
    {
        Provider,
        Broker,
        QualityAssurance,
        Other
    }

    public enum Status
    {
        OK,
        Warning,
        Error
    }
}

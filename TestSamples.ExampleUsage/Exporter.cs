namespace TestSamples.ExampleUsage
{
    public class Exporter
    {
        public ExportData Export(ApplicationData data)
        {
            return new ExportData
            {
                Status = Status.OK,
                Provider = new Provider
                {
                    Function = ProviderFunction.Provider,
                    Name = "SomeName"
                },
                Software = new Software
                {
                    Name = "My Awesome Software",
                    Vendor = new Organisation
                    {
                        Name = "Some Software Company",
                        Function = OrganisationFunction.SoftwareVendor,
                        Registration = "200-A-DFF"
                    },
                    Specification = Specification.V2019_1,
                    Release = data.Release,
                    ReleaseDate = data.ReleaseDate.Date,
                    Version = data.Version?.ToString()
                }
            };
        }
    }
}

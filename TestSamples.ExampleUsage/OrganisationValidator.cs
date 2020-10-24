using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestSamples.ExampleUsage
{
    public class OrganisationValidator
    {
        public bool IsValid(Organisation organisation)
        {
            var name = organisation.Name;
            if (string.IsNullOrWhiteSpace(name) || name.Contains("@") || name.Any(char.IsNumber))
            {
                return false;
            }

            var registration = organisation.Registration;
            if (registration is null || !Regex.IsMatch(registration, "[A-Z][A-Z]-[0-9][0-9]-[A-Z]"))
            {
                return false;
            }

            var foundedAtDate = organisation.FoundedAtDate;
            if (foundedAtDate < new DateTime(1900, 1, 1) || foundedAtDate >= new DateTime(2000, 1, 1))
            {
                return false;
            }

            return true;
        }
    }
}

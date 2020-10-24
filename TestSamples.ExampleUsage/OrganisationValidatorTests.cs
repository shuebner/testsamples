using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestSamples.NUnit;

namespace TestSamples.ExampleUsage
{
    public class OrganisationValidatorTests
    {
        private OrganisationValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new OrganisationValidator();
        }

        [Test]
        [TestCaseSource(nameof(InvalidSamples))]
        public void IsValid_When_individual_values_are_invalid_Then_is_invalid(Action<Organisation, object> setValue, object invalidValue)
        {
            var organisation = CreateValidOrganisation();
            setValue(organisation, invalidValue);

            bool isValid = validator.IsValid(organisation);

            Assert.That(isValid, Is.False);
        }

        [Test]
        [TestCaseSource(nameof(ValidSamples))]
        public void IsValid_When_individual_values_are_valid_Then_is_valid(Action<Organisation, object> setValue, object validValue)
        {
            var organisation = CreateValidOrganisation();
            setValue(organisation, validValue);

            bool isValid = validator.IsValid(organisation);

            Assert.That(isValid, Is.True);
        }

        static readonly IEnumerable<TestCaseData> InvalidSamples = new MemberMultiSamples<Organisation>
        {
            { o => o.Name, null, string.Empty, " ", "no@specialcharactersallowed", "nonumb3rsallowed" },
            { o => o.Registration, null, string.Empty, " ", "wrongformat", "wrong-format", "RN-33-1", "R1-33-X", "1R-33-X", "RR-3A-X" },
            { o => o.FoundedAtDate, default, new DateTime(1899, 12, 31), new DateTime(2000, 1, 1) }
        }.ToValidationTestCaseData();

        static readonly IEnumerable<TestCaseData> ValidSamples = new MemberMultiSamples<Organisation>
        {
            { o => o.Name, "Name", "Name With Space" },
            { o => o.Registration, "RN-33-X", "AA-00-Y" },
            { o => o.FoundedAtDate, new DateTime(1900, 1, 1), new DateTime(1999, 12, 31) }
        }.ToValidationTestCaseData();

        private Organisation CreateValidOrganisation() =>
            new Organisation
            {
                Name = "Valid Name",
                FoundedAtDate = new DateTime(1950, 1, 1),
                Function = OrganisationFunction.LawEnforcement,
                Registration = "RN-33-X",
            };
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals_API_DotNet.Controllers.API;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RomanNumerals_API_DotNet.Tests;

[TestClass]
public sealed class ConvertToRomanNumeralQueryTests
{
    [DataTestMethod]
    [DataRow(0, false)]
    [DataRow(4000, false)]
    [DataRow(2000, true)]
    public void ConvertToRomanNumeralQueryValidates(int number, bool expectedToBeValid)
    {
        // Arrange.
        var query = new ConvertToRomanNumeralQuery
        {
            Number = number,
        };

        // Act.
        bool actuallyValid = IsQueryValid(query);

        // Assert.
        Assert.AreEqual(expectedToBeValid, actuallyValid);
    }

    private static bool IsQueryValid(ConvertToRomanNumeralQuery query)
    {
        var context = new ValidationContext(query);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(query, context, results, true);

        return results.Count == 0;
    }
}

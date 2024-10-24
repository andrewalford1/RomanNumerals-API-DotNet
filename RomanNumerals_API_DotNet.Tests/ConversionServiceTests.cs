using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals_API_DotNet.Services;

namespace RomanNumerals_API_DotNet.Tests;

[TestClass]
public class ConversionServiceTests
{
    private ConversionService _service;

    [TestInitialize]
    public void TestInitialize()
    {
        _service = new ConversionService();
    }

    [DataTestMethod]
    [DataRow(1, "I")]
    [DataRow(4, "IV")]
    [DataRow(5, "V")]
    [DataRow(9, "IX")]
    [DataRow(10, "X")]
    [DataRow(40, "XL")]
    [DataRow(50, "L")]
    [DataRow(90, "XC")]
    [DataRow(100, "C")]
    [DataRow(400, "CD")]
    [DataRow(500, "D")]
    [DataRow(900, "CM")]
    [DataRow(1000, "M")]
    public void ConvertsCorrectly(int value, string expected)
    {
        var actual = _service.ToRomanNumerals(value).RomanNumeral;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(3999, "MMMCMXCIX")]
    [DataRow(2016, "MMXVI")]
    [DataRow(2018, "MMXVIII")]
    public void ConvertsSomeSpecialCases(int value, string expected)
    {
        var actual = _service.ToRomanNumerals(value).RomanNumeral;
        Assert.AreEqual(expected, actual);
    }
}

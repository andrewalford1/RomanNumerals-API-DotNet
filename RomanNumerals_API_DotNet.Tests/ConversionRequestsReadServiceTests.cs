using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals_API_DotNet.DAL;
using RomanNumerals_API_DotNet.DAL.Entities;
using RomanNumerals_API_DotNet.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals_API_DotNet.Tests;

[TestClass]
public class ConversionRequestsReadServiceTests
{
    private RomanNumeralsDbContext _dbContext;
    private ConversionRequestReadService _readService;
    private readonly DateTime _testExecutionTimestamp = DateTime.UtcNow;

    [TestInitialize]
    public void SetUp()
    {
        // Set up an in-memory database for testing
        var options = new DbContextOptionsBuilder<RomanNumeralsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;

        _dbContext = new RomanNumeralsDbContext(options);
        _readService = new ConversionRequestReadService(new ConversionService(), _dbContext);

        // Seed the database with test data
        SeedTestData();
    }

    private void SeedTestData()
    {
        _dbContext.ConversionRequests.AddRange(
            new ConversionRequestEntity() { ArebicNumeral = 1, TimeRequested = _testExecutionTimestamp.AddDays(-1) },
            new ConversionRequestEntity() { ArebicNumeral = 5, TimeRequested = _testExecutionTimestamp.AddDays(-2) },
            new ConversionRequestEntity() { ArebicNumeral = 4, TimeRequested = _testExecutionTimestamp.AddDays(-4) },
            new ConversionRequestEntity() { ArebicNumeral = 1, TimeRequested = _testExecutionTimestamp.AddDays(-4) },
            new ConversionRequestEntity() { ArebicNumeral = 4, TimeRequested = _testExecutionTimestamp.AddDays(-3) },
            new ConversionRequestEntity() { ArebicNumeral = 1, TimeRequested = _testExecutionTimestamp.AddDays(-5) });

        _dbContext.SaveChanges();
    }

    [TestMethod]
    public async Task GetTopConversions_ReturnsExpectedResults()
    {
        // Arrange.
        int take = 2;
        int mostCommonValue = 1;
        int secondMostCommonValue = 4;

        // Act.
        var conversions = await _readService.GetTopConversions(take);
        var convesionsArray = conversions.ToArray();

        // Assert.
        Assert.AreEqual(take, conversions.Count);
        Assert.AreEqual(mostCommonValue, convesionsArray[0].ArebicNumeral);
        Assert.AreEqual(secondMostCommonValue, convesionsArray[1].ArebicNumeral);
    }

    // Note. You could take this test further by injecting a mock timeProvider service.
    [TestMethod]
    public async Task GetRecentConversions_ReturnsExpectedResults()
    {
        // Arrange.
        TimeSpan within = TimeSpan.FromDays(3);
        int expectedNumberOfResults = 2;
        int expectedFirstResult = 1;
        int expectedSecondResult = 5;

        // Act.
        var conversions = await _readService.GetRecentConversions(within);
        var convesionsArray = conversions.ToArray();

        // Assert.
        Assert.AreEqual(expectedNumberOfResults, conversions.Count);
        Assert.AreEqual(expectedFirstResult, convesionsArray[0].ArebicNumeral);
        Assert.AreEqual(expectedSecondResult, convesionsArray[1].ArebicNumeral);
    }
}

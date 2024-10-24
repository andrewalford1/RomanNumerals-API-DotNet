using Microsoft.EntityFrameworkCore;
using RomanNumerals_API_DotNet.DAL.Entities;
using System;
using System.IO;

namespace RomanNumerals_API_DotNet.DAL;

public class RomanNumeralsDbContext : DbContext
{
    public DbSet<ConversionRequestEntity> ConversionRequests { get; set; }

    public string DatabasePath { get; }

    public RomanNumeralsDbContext(DbContextOptions<RomanNumeralsDbContext> options)
        : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DatabasePath = Path.Join(path, "romanNumerals.db");
    }
}

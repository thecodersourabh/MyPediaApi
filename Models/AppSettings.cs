using System.Diagnostics.CodeAnalysis;

namespace Models;

[ExcludeFromCodeCoverage]
public class AppSettings
{
    public string DatabaseName { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
    public CollectionNames CollectionNames { get; set; }
    public string Environment { get; set; }
    public string NLogPath { get; set; }
}
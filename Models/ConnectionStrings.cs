using System.Diagnostics.CodeAnalysis;

namespace Models;

[ExcludeFromCodeCoverage]
public class ConnectionStrings : IConnectionStrings
{
    public string MongoConnection { get; set; }
}
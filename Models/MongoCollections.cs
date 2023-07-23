using System.Diagnostics.CodeAnalysis;

namespace Models;

[ExcludeFromCodeCoverage]
public class CollectionNames : ICollectionNames
{
    public string UserManagementCollection { get; set; }
}
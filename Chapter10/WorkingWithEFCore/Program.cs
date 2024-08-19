using Northwind.EntityModels; // to use Northwind.

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");

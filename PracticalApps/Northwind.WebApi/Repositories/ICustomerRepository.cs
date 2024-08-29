using Northwind.EntityModels;

namespace Northwind.WebApi.Repositories;

public interface ICustomerRepository
{
  Task<Customer?> CreateAsync(Customer c);
  Task<Customer[]> RetrieveAllAsync();
  Task<Customer?> RetrieveAsync(string id);
  Task<bool?> DeleteAsync(string id);
}

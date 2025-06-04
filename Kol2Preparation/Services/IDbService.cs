using Kol2Preparation.DTOs;

namespace Kol2Preparation.Services;

public interface IDbService
{
    Task<object> GetCustomerData(int id);
    Task AddCustomerData(DataDto customer);
    Task<Boolean> DoesConcertExist(string concert);
}
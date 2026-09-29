

using combineDaySixteenN_TierAPIs.Models;

namespace combineDaySixteenN_TierAPIs.Services
{
    public interface ISupplyService
    {
       List<Supply> GetAll();
       Supply? GetById(int id);
       Supply Create(Supply newsSupply); 
       bool Withdraw(Supply newSupply, int amount);  //false if their is not enough

       void Delete(Supply newSupply); 
    }
}
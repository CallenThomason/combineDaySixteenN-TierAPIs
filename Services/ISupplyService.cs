

using combineDaySixteenN_TierAPIs.Dtos;
using combineDaySixteenN_TierAPIs.Models;

namespace combineDaySixteenN_TierAPIs.Services
{
    public interface ISupplyService
    {
       List<SupplyReadDTO> GetAll();
       SupplyReadDTO? GetById(int id);
       SupplyReadDTO Create(SupplyCreateDTO newsSupply); 
       bool Withdraw(int id, int amount);  //false if their is not enough

       void Delete(int id); 
    }
}
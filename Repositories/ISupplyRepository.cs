

using combineDaySixteenN_TierAPIs.Models;

namespace combineDaySixteenN_TierAPIs.Repositories
{
    public interface ISupplyRepository
    {
        List<Supply> GetAll();
        Supply? GetById(int id);
        Supply Add(Supply newSupply); 
        void Update(Supply newSupply);
        void Delete(Supply newSupply); 
    }
}

using combineDaySixteenN_TierAPIs.Models;
using combineDaySixteenN_TierAPIs.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace combineDaySixteenN_TierAPIs.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _repository; 

        public SupplyService(ISupplyRepository repository)
        {
            _repository = repository; 
        }
        public List<Supply> GetAll()
        {
            //The list always comes back in alphabetical order
            return _repository.GetAll().OrderBy(s => s.Name).ToList();
        }

        public Supply? GetById(int id)
        {
            return _repository.GetById(id); 
        }

        //Rules: We Must have a name, and we can not stock fewer than zero
        public Supply? Create(Supply newSupply)
        {
            if(newSupply.Quantity <= 0 || string.IsNullOrWhiteSpace(newSupply.Name))
            {
                return null;
            }
            return _repository.Add(newSupply); 
        }

        //Rules: You must take at least 1, and never more than what we have
        public bool Withdraw(Supply newSupply, int amount)
        {
            if(amount > newSupply.Quantity || amount <= 0)
            {
                return false;
            }

            newSupply.Quantity -= amount;
            _repository.Update(newSupply); 
            return true; 
        }
       public void Delete(Supply newSupply)
        {
            _repository.Delete(newSupply); 
        }
    }
}
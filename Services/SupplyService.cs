
using combineDaySixteenN_TierAPIs.Dtos;
using combineDaySixteenN_TierAPIs.Models;
using combineDaySixteenN_TierAPIs.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;

//The Service is where the rules live and is where our DTO's and models meet
//Controllers <- DTO -> Services <- models -> Repository
namespace combineDaySixteenN_TierAPIs.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _repository; 

        public SupplyService(ISupplyRepository repository)
        {
            _repository = repository; 
        }
        public List<SupplyReadDTO> GetAll()
        {
            //The list always comes back in alphabetical order
            //LINQ select: For every record in our Db we will do x to 
            return _repository.GetAll()
            .OrderBy(s => s.Name)
            .Select(s => ToReadDTO(s)) //Turns every mnodel into a DTO
            .ToList();
        }

        public SupplyReadDTO? GetById(int id)
        {
            Supply? supply = _repository.GetById(id); 
            if(supply is null)
            {
                return null; 
            }
            return ToReadDTO(supply); 
            //return _repository.GetById(id); //old
        }

        //Rules: We Must have a name, and we can not stock fewer than zero
        //Rules 2 No 2 Supplies can have the same name
        public SupplyReadDTO? Create(SupplyCreateDTO dto)
        {
            //We Do not need this code anymore, Handled within the DTO
            // if(newSupply.Quantity <= 0 || string.IsNullOrWhiteSpace(newSupply.Name))
            // {
            //     return null; 
            // }

            bool exists = _repository.GetAll().Any(s => s.Name.ToLower() == dto.Name.ToLower());
            //If a name already exists within our DB, we will return null
            if (exists)
            {
                return null; 
            }
            //DTO -> Model
            Supply supply = new Supply(); 

            supply.Name = dto.Name; 
            supply.Quantity = dto.Quantity;
            supply.StorageLocation = "Recieving Bay"; //everything new starts here

            //We are creating a new Supply variable and storing our added supply.
            Supply created = _repository.Add(supply); 

            return ToReadDTO(created); 
        }

        //Rules: You must take at least 1, and never more than what we have
        public bool Withdraw(int id, int amount)
        {
            Supply? existing = _repository.GetById(id); 

            if(existing is null || amount > existing.Quantity || amount <= 0)
            {
                return false;
            }

            existing.Quantity -= amount;
            _repository.Update(existing); 
            return true; 
        }
       public void Delete(int id)
        {
            Supply? supply = _repository.GetById(id); 
           //If it is not null we will delete it
           if(supply != null)
            {
                _repository.Delete(supply);
            }
           
             
        }

        //Our helper method that takes in our Supply Model and outputs our DTO
        private static SupplyReadDTO ToReadDTO(Supply supply)
        {
            SupplyReadDTO outputDTO = new SupplyReadDTO(); 
            outputDTO.Id = supply.Id; 
            outputDTO.Name = supply.Name;
            outputDTO.Quantity = supply.Quantity;

            return outputDTO; 

        }
    }
}


using combineDaySixteenN_TierAPIs.Data;
using combineDaySixteenN_TierAPIs.Models;

namespace combineDaySixteenN_TierAPIs.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly AppDbContext _db; 

        //Constructor runs once when the class is called
        //ASP.Net Core heands us the databse connection because we registered it in the Program.cs
        public SupplyRepository(AppDbContext db)
        {
            _db = db; 
        }

        public List<Supply> GetAll()
        {
            return _db.Supplies.ToList(); 
        }

        public Supply? GetById(int id)
        {
            return _db.Supplies.FirstOrDefault(s => s.Id == id); 
        
        }

        public Supply Add(Supply newSupply)
        {
            _db.Supplies.Add(newSupply);
            _db.SaveChanges();
            return newSupply; 
        }

        public void Update(Supply newSupply)
        {
            //The supply came out of the DB through GetById so Ef core is already Tracking it
            //We just need to save the changes
            _db.SaveChanges(); 
        }

        public void Delete(Supply newSupply)
        {
            _db.Supplies.Remove(newSupply);
            _db.SaveChanges(); 
        }
    }
}
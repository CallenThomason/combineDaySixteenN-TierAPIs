//This is what our client will get back
//the Model minus StorageLocation
namespace combineDaySixteenN_TierAPIs.Dtos
{
    public class SupplyReadDTO
    {
        public int Id{get; set;}
        public string Name{get; set;} = string.Empty; 
        public int Quantity{get; set;} 
    }
}
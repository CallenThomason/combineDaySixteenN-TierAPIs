

namespace combineDaySixteenN_TierAPIs.Models
{
    public class Supply
    {

        //When creating an entity we always need a unique identifer
        public int Id{get; set;}
        public string Name{get; set;} = string.Empty; 
        public int Quantity{get; set;}
        //StorageLocation is internal only, the client never sees it
        public string StorageLocation{get; set;} = string.Empty; 
        
    }
}
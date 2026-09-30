//What a client is allowed to SEND
//This will have no Id(Our DB picks it anyway) and no StorageLocation. (That is ours). 
//Even if a client wants to set those properties they cannot because we dont have them

using System.ComponentModel.DataAnnotations;

namespace combineDaySixteenN_TierAPIs.Dtos
{
    public class SupplyCreateDTO
    {
        //Attributes are characteristics of our properties
        [Required(ErrorMessage = "Every supply needs a name.")]
        public string Name{get; set;}
        [Range(1, 10000, ErrorMessage = "Quantity must be from 0 - 10000")]
        public int Quantity{get; set;}
    }
}
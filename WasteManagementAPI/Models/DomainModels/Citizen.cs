namespace WasteManagementAPI.Models.DomainModels
{
    public class Citizen
    {

        public int CitizenId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Family { get; set; } = string.Empty;

        public int? Score { get; set; }

        //FK
        public int UserProductId { get; set; }
        //Navigation property
        public UserProduct UserProduct { get; set; } = null!;

   
    }
}

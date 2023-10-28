namespace WasteManagementAPI.Models
{
    public class Citizen
    {
          
        public int CitizenId { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Family { get; set; } = string.Empty;

        public int? Score { get; set; }

        //FK
        public int  ProductId { get; set; }
        //Navigation property
        public Product Product { get; set; } = null!;

        //FK
        public int ID { get; set; }

        //navigation property
        public SumOfWeghitOfProducts SumOfWeghitOfProducts { get; set; } = null!;

    }
}

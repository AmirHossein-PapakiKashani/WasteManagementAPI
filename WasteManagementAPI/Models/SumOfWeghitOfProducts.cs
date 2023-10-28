namespace WasteManagementAPI.Models
{
    public class SumOfWeghitOfProducts
    {
        public int ID { get; set; }

        public int SumOfProducts { get; set; }
        
        //FK
        public int CitizenId { get; set; }

        //navigtion property
        public Citizen Citizen { get; set; } = null!;



    }
}

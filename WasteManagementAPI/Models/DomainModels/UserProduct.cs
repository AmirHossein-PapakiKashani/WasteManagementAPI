namespace WasteManagementAPI.Models.DomainModels
{
    public class UserProduct
    {
        public UserProduct() => Citizens = new HashSet<Citizen>();

        public int UserProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Weight { get; set; } 

        public int MainProductId { get; set; }

        public MainProduct MainProduct { get; set; }  = null!; 

        public ICollection<Citizen> Citizens { get; set; } 

    
    }
}

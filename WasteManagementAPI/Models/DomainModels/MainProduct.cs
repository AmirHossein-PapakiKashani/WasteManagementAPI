namespace WasteManagementAPI.Models.DomainModels
{
    public class MainProduct
    {
        public int MainProductId { get; set; }

        public string Name { get; set; } = string.Empty;

      

        public UserProduct UserProduct { get; set; } = null!;

    }
}

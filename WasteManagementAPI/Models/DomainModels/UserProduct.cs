namespace WasteManagementAPI.Models.DomainModels
{
    public class UserProduct
    {
        public UserProduct() => Citizens = new HashSet<Citizen>();

        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Weight { get; set; }

        public ICollection<Citizen> Citizens { get; set; }
    }
}

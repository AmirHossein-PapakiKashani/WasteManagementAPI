namespace WasteManagementAPI.Models.DomainModels
{
    public class WasteTypes
    {
        public int WasteTypeId { get; set; }

        public string WasteName { get; set;} = string.Empty;

        public ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();
    }
}

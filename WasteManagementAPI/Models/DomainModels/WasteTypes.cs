namespace WasteManagementAPI.Models.DomainModels
{
    public class WasteTypes
    {
        public int WasteTypesId { get; set; }

        public string WasteName { get; set;} = string.Empty;

        public int ShipmentId { get; set; }

        //nav prop
        public Shipments Shipments { get; set; } = null!;
    }
}
